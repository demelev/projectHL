namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class TreeGroup
    {
        [SerializeField]
        private int _internalSeed = 0x4d2;
        [SerializeField]
        private int _uniqueID = -1;
        public float animationEdge;
        public float animationPrimary;
        public float animationSecondary;
        public int[] childGroupIDs;
        [NonSerialized]
        internal List<TreeGroup> childGroups;
        public AnimationCurve distributionCurve;
        public int distributionFrequency = 1;
        public DistributionMode distributionMode;
        public int distributionNodes;
        public float distributionPitch;
        public AnimationCurve distributionPitchCurve;
        public float distributionScale;
        public AnimationCurve distributionScaleCurve;
        public float distributionTwirl;
        protected static readonly float GenerateBendBillboardNormalFactor = 0.8f;
        protected static readonly float GenerateBendNormalFactor = 0.4f;
        protected static readonly bool GenerateDoubleSidedGeometry = true;
        public int lockFlags;
        [SerializeField]
        internal string m_Hash;
        public int[] nodeIDs;
        [NonSerialized]
        internal List<TreeNode> nodes;
        [NonSerialized]
        internal TreeGroup parentGroup;
        public int parentGroupID;
        public int seed = 0x4d2;
        public bool showAnimationProps;
        public bool visible;

        public TreeGroup()
        {
            Keyframe[] keys = new Keyframe[] { new Keyframe(0f, 1f), new Keyframe(1f, 1f) };
            this.distributionCurve = new AnimationCurve(keys);
            this.distributionNodes = 5;
            Keyframe[] keyframeArray2 = new Keyframe[] { new Keyframe(0f, 1f), new Keyframe(1f, 1f) };
            this.distributionPitchCurve = new AnimationCurve(keyframeArray2);
            this.distributionScale = 1f;
            Keyframe[] keyframeArray3 = new Keyframe[] { new Keyframe(0f, 1f), new Keyframe(1f, 0.3f) };
            this.distributionScaleCurve = new AnimationCurve(keyframeArray3);
            this.showAnimationProps = true;
            this.animationPrimary = 0.5f;
            this.animationSecondary = 0.5f;
            this.animationEdge = 1f;
            this.visible = true;
            this.nodeIDs = new int[0];
            this.parentGroupID = -1;
            this.childGroupIDs = new int[0];
            this.nodes = new List<TreeNode>();
            this.childGroups = new List<TreeGroup>();
        }

        public virtual void BuildAOSpheres(List<TreeAOSphere> aoSpheres)
        {
            Profiler.BeginSample("BuildAOSpheres");
            for (int i = 0; i < this.childGroups.Count; i++)
            {
                this.childGroups[i].BuildAOSpheres(aoSpheres);
            }
            Profiler.EndSample();
        }

        public virtual bool CanHaveSubGroups()
        {
            return true;
        }

        public bool CheckExternalChanges()
        {
            bool flag = this.HasExternalChanges();
            for (int i = 0; i < this.childGroups.Count; i++)
            {
                flag |= this.childGroups[i].CheckExternalChanges();
            }
            return flag;
        }

        protected static float ComputeAmbientOcclusion(Vector3 pos, Vector3 nor, List<TreeAOSphere> aoSpheres, float aoDensity)
        {
            if (aoSpheres.Count == 0)
            {
                return 1f;
            }
            float num = 0f;
            for (int i = 0; i < aoSpheres.Count; i++)
            {
                num += (aoSpheres[i].PointOcclusion(pos, nor) * aoSpheres[i].density) * 0.25f;
            }
            return (1f - (Mathf.Clamp01(num) * aoDensity));
        }

        private float ComputeOffset(int index, int count, float distributionSum, float distributionStep)
        {
            float num = 0f;
            float num2 = ((index + 1f) / (count + 1f)) * distributionSum;
            for (float i = 0f; i <= 1f; i += distributionStep)
            {
                num += Mathf.Clamp01(this.distributionCurve.Evaluate(i));
                if (num >= num2)
                {
                    return i;
                }
            }
            return (num2 / distributionSum);
        }

        public Vector2 ComputeWindFactor(TreeNode node, float offset)
        {
            Vector2 vector;
            if (node.group.parentGroup.GetType() == typeof(TreeGroupRoot))
            {
                vector = new Vector2(0f, 0f);
            }
            else
            {
                vector = node.parent.group.ComputeWindFactor(node.parent, node.offset);
            }
            float scale = node.GetScale();
            vector.x += (((offset * offset) * offset) * scale) * this.animationPrimary;
            vector.y += ((offset * offset) * scale) * this.animationSecondary;
            return vector;
        }

        protected static Vector4 CreateTangent(TreeNode node, Quaternion rot, Vector3 normal)
        {
            Vector3 lhs = node.matrix.MultiplyVector((Vector3) (rot * new Vector3(1f, 0f, 0f)));
            lhs -= (Vector3) (normal * Vector3.Dot(lhs, normal));
            lhs.Normalize();
            return new Vector4(lhs.x, lhs.y, lhs.z, 1f);
        }

        protected static int GetMaterialIndex(Material m, List<TreeMaterial> materials, bool tileV)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                if (materials[i].material == m)
                {
                    TreeMaterial local1 = materials[i];
                    local1.tileV |= tileV;
                    return i;
                }
            }
            TreeMaterial item = new TreeMaterial {
                material = m,
                tileV = tileV
            };
            materials.Add(item);
            return (materials.Count - 1);
        }

        public virtual float GetRadiusAtTime(TreeNode node, float t, bool includeModifications)
        {
            return 0f;
        }

        public Matrix4x4 GetRootMatrix()
        {
            TreeGroup parentGroup = this;
            while (parentGroup.parentGroup != null)
            {
                parentGroup = parentGroup.parentGroup;
            }
            return parentGroup.nodes[0].matrix;
        }

        public float GetRootSpread()
        {
            TreeGroup parentGroup = this;
            while (parentGroup.parentGroup != null)
            {
                parentGroup = parentGroup.parentGroup;
            }
            return parentGroup.nodes[0].size;
        }

        internal virtual bool HasExternalChanges()
        {
            return false;
        }

        public void Lock()
        {
            if (this.lockFlags == 0)
            {
                for (int i = 0; i < this.nodes.Count; i++)
                {
                    this.nodes[i].baseAngle = this.nodes[i].angle;
                }
            }
            this.lockFlags = 7;
        }

        public void Unlock()
        {
            this.lockFlags = 0;
        }

        public void UpdateDistribution(bool completeUpdate, bool updateSubGroups)
        {
            Profiler.BeginSample("UpdateDistribution");
            UnityEngine.Random.seed = this._internalSeed;
            if (completeUpdate)
            {
                float distributionSum = 0f;
                float[] numArray = new float[100];
                float distributionStep = 1f / ((float) numArray.Length);
                float num3 = numArray.Length - 1f;
                for (int j = 0; j < numArray.Length; j++)
                {
                    float time = ((float) j) / num3;
                    numArray[j] = Mathf.Clamp01(this.distributionCurve.Evaluate(time));
                    distributionSum += numArray[j];
                }
                for (int k = 0; k < this.nodes.Count; k++)
                {
                    float num10;
                    float num11;
                    int num12;
                    TreeNode node = this.nodes[k];
                    if (this.lockFlags == 0)
                    {
                        if (((k == 0) && (this.nodes.Count == 1)) && ((this.parentGroup == null) || (this.parentGroup.GetType() == typeof(TreeGroupRoot))))
                        {
                            node.offset = 0f;
                            node.baseAngle = 0f;
                            node.pitch = 0f;
                            node.scale = (Mathf.Clamp01(this.distributionScaleCurve.Evaluate(node.offset)) * this.distributionScale) + (1f - this.distributionScale);
                        }
                        else
                        {
                            int index = 0;
                            int count = 0;
                            for (int n = 0; n < this.nodes.Count; n++)
                            {
                                if (this.nodes[n].parentID == node.parentID)
                                {
                                    if (k == n)
                                    {
                                        index = count;
                                    }
                                    count++;
                                }
                            }
                            switch (this.distributionMode)
                            {
                                case DistributionMode.Random:
                                    num10 = 0f;
                                    num11 = 0f;
                                    num12 = 0;
                                    goto Label_01D5;

                                case DistributionMode.Alternate:
                                {
                                    float num14 = this.ComputeOffset(index, count, distributionSum, distributionStep);
                                    float num15 = 180f * index;
                                    node.baseAngle = num15 + ((num14 * this.distributionTwirl) * 360f);
                                    node.offset = num14;
                                    break;
                                }
                                case DistributionMode.Opposite:
                                {
                                    float num16 = this.ComputeOffset(index / 2, count / 2, distributionSum, distributionStep);
                                    float num17 = (90f * (index / 2)) + ((index % 2) * 180f);
                                    node.baseAngle = num17 + ((num16 * this.distributionTwirl) * 360f);
                                    node.offset = num16;
                                    break;
                                }
                                case DistributionMode.Whorled:
                                {
                                    int distributionNodes = this.distributionNodes;
                                    int num19 = index % distributionNodes;
                                    int num20 = index / distributionNodes;
                                    float num21 = this.ComputeOffset(index / distributionNodes, count / distributionNodes, distributionSum, distributionStep);
                                    float num22 = ((360f / ((float) distributionNodes)) * num19) + ((180f / ((float) distributionNodes)) * num20);
                                    node.baseAngle = num22 + ((num21 * this.distributionTwirl) * 360f);
                                    node.offset = num21;
                                    break;
                                }
                            }
                        }
                    }
                    continue;
                Label_01C6:
                    num11 = UnityEngine.Random.value * distributionSum;
                    num12++;
                Label_01D5:
                    if (num12 < 5)
                    {
                        goto Label_01C6;
                    }
                    for (int m = 0; m < numArray.Length; m++)
                    {
                        num10 = ((float) m) / num3;
                        num11 -= numArray[m];
                        if (num11 <= 0f)
                        {
                            break;
                        }
                    }
                    node.baseAngle = UnityEngine.Random.value * 360f;
                    node.offset = num10;
                }
            }
            for (int i = 0; i < this.nodes.Count; i++)
            {
                TreeNode node2 = this.nodes[i];
                if (node2.parent == null)
                {
                    node2.visible = true;
                }
                else
                {
                    node2.visible = node2.parent.visible;
                    if (node2.offset > node2.parent.breakOffset)
                    {
                        node2.visible = false;
                    }
                }
                if (this.lockFlags == 0)
                {
                    node2.angle = node2.baseAngle;
                    node2.pitch = (Mathf.Clamp(this.distributionPitchCurve.Evaluate(node2.offset), -1f, 1f) * -75f) * this.distributionPitch;
                }
                else
                {
                    node2.angle = node2.baseAngle;
                }
                node2.scale = (Mathf.Clamp01(this.distributionScaleCurve.Evaluate(node2.offset)) * this.distributionScale) + (1f - this.distributionScale);
            }
            if ((this.parentGroup == null) || (this.parentGroup.GetType() == typeof(TreeGroupRoot)))
            {
                for (int num24 = 0; num24 < this.nodes.Count; num24++)
                {
                    this.nodes[num24].animSeed = 0f;
                }
            }
            else
            {
                for (int num25 = 0; num25 < this.nodes.Count; num25++)
                {
                    if (this.nodes[num25].parent == null)
                    {
                        this.nodes[num25].animSeed = 0f;
                    }
                    else if (this.nodes[num25].parent.animSeed == 0f)
                    {
                        this.nodes[num25].animSeed = ((((float) this.nodes[num25].seed) / 9.78f) % 1f) + 0.001f;
                    }
                    else
                    {
                        this.nodes[num25].animSeed = this.nodes[num25].parent.animSeed;
                    }
                }
            }
            if (updateSubGroups)
            {
                for (int num26 = 0; num26 < this.childGroups.Count; num26++)
                {
                    this.childGroups[num26].UpdateDistribution(completeUpdate, updateSubGroups);
                }
            }
            Profiler.EndSample();
        }

        public void UpdateFrequency(TreeData owner)
        {
            Profiler.BeginSample("UpdateFrequency");
            if (this.distributionFrequency < 1)
            {
                this.distributionFrequency = 1;
            }
            if (this.parentGroup == null)
            {
                this.distributionFrequency = 1;
                if (this.nodes.Count < 1)
                {
                    owner.AddNode(this, null, false);
                }
            }
            else if ((this.lockFlags == 0) && (this.parentGroup != null))
            {
                int num = 0;
                for (int j = 0; j < this.parentGroup.nodes.Count; j++)
                {
                    int num3 = Mathf.RoundToInt(this.distributionFrequency * this.parentGroup.nodes[j].GetScale());
                    if (num3 < 1)
                    {
                        num3 = 1;
                    }
                    for (int k = 0; k < num3; k++)
                    {
                        if (num < this.nodes.Count)
                        {
                            owner.SetNodeParent(this.nodes[num], this.parentGroup.nodes[j]);
                        }
                        else
                        {
                            owner.AddNode(this, this.parentGroup.nodes[j], false);
                        }
                        num++;
                    }
                }
                if (num < this.nodes.Count)
                {
                    List<TreeNode> list = new List<TreeNode>();
                    for (int m = num; m < this.nodes.Count; m++)
                    {
                        list.Add(this.nodes[m]);
                    }
                    for (int n = 0; n < list.Count; n++)
                    {
                        owner.DeleteNode(list[n], false);
                    }
                }
                this.UpdateSeed();
                this.UpdateDistribution(true, false);
            }
            for (int i = 0; i < this.childGroups.Count; i++)
            {
                this.childGroups[i].UpdateFrequency(owner);
            }
            Profiler.EndSample();
        }

        public virtual void UpdateMatrix()
        {
        }

        public virtual void UpdateMesh(List<TreeMaterial> materials, List<TreeVertex> verts, List<TreeTriangle> tris, List<TreeAOSphere> aoSpheres, int buildFlags, float adaptiveQuality, float aoDensity)
        {
            for (int i = 0; i < this.childGroups.Count; i++)
            {
                this.childGroups[i].UpdateMesh(materials, verts, tris, aoSpheres, buildFlags, adaptiveQuality, aoDensity);
            }
        }

        public virtual void UpdateParameters()
        {
            for (int i = 0; i < this.childGroups.Count; i++)
            {
                this.childGroups[i].UpdateParameters();
            }
        }

        public void UpdateSeed()
        {
            TreeGroup parentGroup = this;
            while (parentGroup.parentGroup != null)
            {
                parentGroup = parentGroup.parentGroup;
            }
            int seed = parentGroup.seed;
            this._internalSeed = seed + ((int) (this.seed * 1.21f));
            for (int i = 0; i < this.nodes.Count; i++)
            {
                this.nodes[i].seed = (seed + this._internalSeed) + ((int) (i * 3.7482f));
            }
            for (int j = 0; j < this.childGroups.Count; j++)
            {
                this.childGroups[j].UpdateSeed();
            }
        }

        internal virtual string DistributionModeString
        {
            get
            {
                return null;
            }
        }

        internal virtual string EdgeTurbulenceString
        {
            get
            {
                return null;
            }
        }

        internal virtual string FrequencyString
        {
            get
            {
                return null;
            }
        }

        internal virtual string GroupSeedString
        {
            get
            {
                return null;
            }
        }

        internal virtual string GrowthAngleString
        {
            get
            {
                return null;
            }
        }

        internal virtual string GrowthScaleString
        {
            get
            {
                return null;
            }
        }

        internal virtual string MainTurbulenceString
        {
            get
            {
                return null;
            }
        }

        internal virtual string MainWindString
        {
            get
            {
                return null;
            }
        }

        internal virtual string TwirlString
        {
            get
            {
                return null;
            }
        }

        public int uniqueID
        {
            get
            {
                return this._uniqueID;
            }
            set
            {
                if (this._uniqueID == -1)
                {
                    this._uniqueID = value;
                }
            }
        }

        internal virtual string WhorledStepString
        {
            get
            {
                return null;
            }
        }

        public enum BuildFlag
        {
            BuildAmbientOcclusion = 1,
            BuildWeldParts = 2
        }

        public enum DistributionMode
        {
            Random,
            Alternate,
            Opposite,
            Whorled
        }

        public enum LockFlag
        {
            LockAlignment = 2,
            LockPosition = 1,
            LockShape = 4
        }
    }
}

