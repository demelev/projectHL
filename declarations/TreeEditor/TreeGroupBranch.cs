namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditorInternal;
    using UnityEngine;

    [Serializable]
    public class TreeGroupBranch : TreeGroup
    {
        public float breakingChance;
        public Vector2 breakingSpot;
        public float capSmoothing;
        public AnimationCurve crinkCurve;
        public float crinklyness;
        private static string distributionModeString = LocalizationDatabase.GetLocalizedString("Distribution|The way the branches are distributed along their parent.");
        private static string edgeTurbulenceString = LocalizationDatabase.GetLocalizedString("Edge Turbulence|Turbulence along the edge of fronds. Useful for ferns, palms, etc.");
        public float flareHeight;
        public float flareNoise;
        public float flareSize;
        private static string frequencyString = LocalizationDatabase.GetLocalizedString("Frequency|Adjusts the number of branches created for each parent branch.");
        public int frondCount;
        public float frondCrease;
        public AnimationCurve frondCurve;
        public Vector2 frondRange;
        public float frondRotation;
        public float frondWidth;
        public GeometryMode geometryMode;
        private static string groupSeedString = LocalizationDatabase.GetLocalizedString("Group Seed|The seed for this group of branches. Modify to vary procedural generation.");
        private static string growthAngleString = LocalizationDatabase.GetLocalizedString("Growth Angle|Defines the initial angle of growth relative to the parent. Use the curve to adjust and the slider to fade the effect in and out.");
        private static string growthScaleString = LocalizationDatabase.GetLocalizedString("Growth Scale|Defines the scale of nodes along the parent node. Use the curve to adjust and the slider to fade the effect in and out.");
        public Vector2 height = new Vector2(10f, 15f);
        public float lodQualityMultiplier = 1f;
        private static string mainTurbulenceString = LocalizationDatabase.GetLocalizedString("Main Turbulence|Secondary turbulence effect. Produces more stochastic motion, which is individual per branch. Typically used for branches with fronds, such as ferns and palms.");
        private static string mainWindString = LocalizationDatabase.GetLocalizedString("Main Wind|Primary wind effect. This creates a soft swaying motion and is typically the only parameter needed for primary branches.");
        public Material materialBranch;
        public Material materialBreak;
        public Material materialFrond;
        public float noise;
        public AnimationCurve noiseCurve;
        public float noiseScaleU;
        public float noiseScaleV;
        public float radius = 0.5f;
        public AnimationCurve radiusCurve;
        public bool radiusMode;
        public float seekBlend;
        public AnimationCurve seekCurve;
        private static float spreadMul = 5f;
        private static string twirlString = LocalizationDatabase.GetLocalizedString("Twirl|Twirl around the parent branch.");
        public float weldHeight;
        public float weldSpreadBottom;
        public float weldSpreadTop;
        private static string whorledStepString = LocalizationDatabase.GetLocalizedString("Whorled Step|Defines how many nodes are in each whorled step when using Whorled distribution. For real plants this is normally a Fibonacci number.");

        public TreeGroupBranch()
        {
            Keyframe[] keys = new Keyframe[] { new Keyframe(0f, 1f, -1f, -1f), new Keyframe(1f, 0f, -1f, -1f) };
            this.radiusCurve = new AnimationCurve(keys);
            this.radiusMode = true;
            this.crinklyness = 0.1f;
            Keyframe[] keyframeArray2 = new Keyframe[] { new Keyframe(0f, 1f), new Keyframe(1f, 1f) };
            this.crinkCurve = new AnimationCurve(keyframeArray2);
            Keyframe[] keyframeArray3 = new Keyframe[] { new Keyframe(0f, 1f), new Keyframe(1f, 1f) };
            this.seekCurve = new AnimationCurve(keyframeArray3);
            this.noise = 0.1f;
            Keyframe[] keyframeArray4 = new Keyframe[] { new Keyframe(0f, 1f), new Keyframe(1f, 1f) };
            this.noiseCurve = new AnimationCurve(keyframeArray4);
            this.noiseScaleU = 0.2f;
            this.noiseScaleV = 0.1f;
            this.flareHeight = 0.1f;
            this.flareNoise = 0.3f;
            this.weldHeight = 0.1f;
            this.breakingSpot = new Vector2(0.4f, 0.6f);
            this.frondCount = 1;
            this.frondWidth = 1f;
            Keyframe[] keyframeArray5 = new Keyframe[] { new Keyframe(0f, 1f), new Keyframe(1f, 1f) };
            this.frondCurve = new AnimationCurve(keyframeArray5);
            this.frondRange = new Vector2(0.1f, 1f);
        }

        public override void BuildAOSpheres(List<TreeAOSphere> aoSpheres)
        {
            float num = 0.5f;
            if (base.visible)
            {
                bool flag = this.geometryMode != GeometryMode.Branch;
                bool flag2 = this.geometryMode != GeometryMode.Frond;
                for (int i = 0; i < base.nodes.Count; i++)
                {
                    TreeNode node = base.nodes[i];
                    if (node.visible)
                    {
                        float num7;
                        float scale = node.GetScale();
                        float approximateLength = node.spline.GetApproximateLength();
                        if (approximateLength < num)
                        {
                            approximateLength = num;
                        }
                        float a = num / approximateLength;
                        for (float j = 0f; j < 1f; j += Mathf.Max(a, num7 / approximateLength))
                        {
                            Vector3 pos = node.matrix.MultiplyPoint(node.spline.GetPositionAtTime(j));
                            num7 = 0f;
                            if (flag2)
                            {
                                num7 = this.GetRadiusAtTime(node, j, false) * 0.95f;
                            }
                            if (flag)
                            {
                                num7 = Mathf.Max(num7, 0.95f * ((Mathf.Clamp01(this.frondCurve.Evaluate(j)) * this.frondWidth) * scale));
                                pos.y -= num7;
                            }
                            if (num7 > 0.01f)
                            {
                                aoSpheres.Add(new TreeAOSphere(pos, num7, 1f));
                            }
                        }
                    }
                }
            }
            base.BuildAOSpheres(aoSpheres);
        }

        private Vector3 GetFlareWeldAtTime(TreeNode node, float time)
        {
            float scale = node.GetScale();
            float num2 = 0f;
            float num3 = 0f;
            if (this.flareHeight > 0.001f)
            {
                float num4 = ((1f - time) - (1f - this.flareHeight)) / this.flareHeight;
                num2 = Mathf.Pow(Mathf.Clamp01(num4), 1.5f) * scale;
            }
            if (this.weldHeight > 0.001f)
            {
                float num5 = ((1f - time) - (1f - this.weldHeight)) / this.weldHeight;
                num3 = Mathf.Pow(Mathf.Clamp01(num5), 1.5f) * scale;
            }
            return new Vector3(num2 * this.flareSize, (num3 * this.weldSpreadTop) * spreadMul, (num3 * this.weldSpreadBottom) * spreadMul);
        }

        public override float GetRadiusAtTime(TreeNode node, float time, bool includeModifications)
        {
            if (this.geometryMode == GeometryMode.Frond)
            {
                return 0f;
            }
            float num = Mathf.Clamp01(this.radiusCurve.Evaluate(time)) * node.size;
            float num2 = 1f - node.capRange;
            if (time > num2)
            {
                float num4 = Mathf.Sin(Mathf.Acos(Mathf.Clamp01((time - num2) / node.capRange)));
                num *= num4;
            }
            if (includeModifications)
            {
                Vector3 flareWeldAtTime = this.GetFlareWeldAtTime(node, time);
                num += Mathf.Max(flareWeldAtTime.x, Mathf.Max(flareWeldAtTime.y, flareWeldAtTime.z) * 0.25f) * 0.1f;
            }
            return num;
        }

        internal override bool HasExternalChanges()
        {
            List<UnityEngine.Object> list = new List<UnityEngine.Object>();
            if (this.geometryMode == GeometryMode.Branch)
            {
                list.Add(this.materialBranch);
                if (this.breakingChance > 0f)
                {
                    list.Add(this.materialBreak);
                }
            }
            else if (this.geometryMode == GeometryMode.BranchFrond)
            {
                list.Add(this.materialBranch);
                list.Add(this.materialFrond);
                if (this.breakingChance > 0f)
                {
                    list.Add(this.materialBreak);
                }
            }
            else if (this.geometryMode == GeometryMode.Frond)
            {
                list.Add(this.materialFrond);
            }
            string str = InternalEditorUtility.CalculateHashForObjectsAndDependencies(list.ToArray());
            if (str != base.m_Hash)
            {
                base.m_Hash = str;
                return true;
            }
            return false;
        }

        public override void UpdateMatrix()
        {
            if (base.parentGroup == null)
            {
                for (int i = 0; i < base.nodes.Count; i++)
                {
                    TreeNode node = base.nodes[i];
                    node.matrix = Matrix4x4.identity;
                }
            }
            else if (base.parentGroup is TreeGroupRoot)
            {
                TreeGroupRoot parentGroup = base.parentGroup as TreeGroupRoot;
                for (int j = 0; j < base.nodes.Count; j++)
                {
                    TreeNode node2 = base.nodes[j];
                    float num3 = node2.offset * base.GetRootSpread();
                    float f = node2.angle * 0.01745329f;
                    Vector3 pos = new Vector3(Mathf.Cos(f) * num3, -parentGroup.groundOffset, Mathf.Sin(f) * num3);
                    Quaternion q = Quaternion.Euler(node2.pitch * -Mathf.Sin(f), 0f, node2.pitch * Mathf.Cos(f)) * Quaternion.Euler(0f, node2.angle, 0f);
                    node2.matrix = Matrix4x4.TRS(pos, q, Vector3.one);
                }
            }
            else
            {
                for (int k = 0; k < base.nodes.Count; k++)
                {
                    TreeNode node3 = base.nodes[k];
                    Vector3 vector2 = new Vector3();
                    Quaternion rot = new Quaternion();
                    float rad = 0f;
                    node3.parent.GetPropertiesAtTime(node3.offset, out vector2, out rot, out rad);
                    Quaternion quaternion3 = Quaternion.Euler(90f, node3.angle, 0f);
                    Matrix4x4 matrixx = Matrix4x4.TRS(Vector3.zero, quaternion3, Vector3.one);
                    Matrix4x4 matrixx2 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(node3.pitch, 0f, 0f), Vector3.one);
                    node3.matrix = ((node3.parent.matrix * Matrix4x4.TRS(vector2, rot, Vector3.one)) * matrixx) * matrixx2;
                    Vector3 vector3 = node3.matrix.MultiplyPoint(new Vector3(0f, rad, 0f));
                    node3.matrix.m03 = vector3.x;
                    node3.matrix.m13 = vector3.y;
                    node3.matrix.m23 = vector3.z;
                }
            }
        }

        public override void UpdateMesh(List<TreeMaterial> materials, List<TreeVertex> verts, List<TreeTriangle> tris, List<TreeAOSphere> aoSpheres, int buildFlags, float adaptiveQuality, float aoDensity)
        {
            if ((this.geometryMode == GeometryMode.Branch) || (this.geometryMode == GeometryMode.BranchFrond))
            {
                TreeGroup.GetMaterialIndex(this.materialBranch, materials, true);
                if (this.breakingChance > 0f)
                {
                    TreeGroup.GetMaterialIndex(this.materialBreak, materials, false);
                }
            }
            if ((this.geometryMode == GeometryMode.Frond) || (this.geometryMode == GeometryMode.BranchFrond))
            {
                TreeGroup.GetMaterialIndex(this.materialFrond, materials, false);
            }
            for (int i = 0; i < base.nodes.Count; i++)
            {
                this.UpdateNodeMesh(base.nodes[i], materials, verts, tris, aoSpheres, buildFlags, adaptiveQuality, aoDensity);
            }
            base.UpdateMesh(materials, verts, tris, aoSpheres, buildFlags, adaptiveQuality, aoDensity);
        }

        private void UpdateNodeMesh(TreeNode node, List<TreeMaterial> materials, List<TreeVertex> verts, List<TreeTriangle> tris, List<TreeAOSphere> aoSpheres, int buildFlags, float adaptiveQuality, float aoDensity)
        {
            node.triStart = tris.Count;
            node.triEnd = tris.Count;
            node.vertStart = verts.Count;
            node.vertEnd = verts.Count;
            if (node.visible && base.visible)
            {
                Profiler.BeginSample("TreeGroupBranch.UpdateNodeMesh");
                int count = verts.Count;
                float approximateLength = node.spline.GetApproximateLength();
                List<RingLoop> list = new List<RingLoop>();
                float num3 = Mathf.Clamp01(adaptiveQuality * this.lodQualityMultiplier);
                List<float> list2 = TreeData.GetAdaptiveSamples(this, node, num3);
                int adaptiveRadialSegments = TreeData.GetAdaptiveRadialSegments(this.radius, num3);
                TreeGroupBranch parentGroup = null;
                if ((base.parentGroup != null) && (base.parentGroup.GetType() == typeof(TreeGroupBranch)))
                {
                    parentGroup = (TreeGroupBranch) base.parentGroup;
                }
                if ((this.geometryMode == GeometryMode.BranchFrond) || (this.geometryMode == GeometryMode.Branch))
                {
                    int materialIndex = TreeGroup.GetMaterialIndex(this.materialBranch, materials, true);
                    float bOffset = 0f;
                    float num7 = 0f;
                    float num8 = approximateLength / ((this.GetRadiusAtTime(node, 0f, false) * 3.141593f) * 2f);
                    bool flag = true;
                    if ((node.parent != null) && (parentGroup != null))
                    {
                        num7 = node.offset * node.parent.spline.GetApproximateLength();
                    }
                    float num9 = 1f - node.capRange;
                    for (int i = 0; i < list2.Count; i++)
                    {
                        float timeParam = list2[i];
                        Vector3 positionAtTime = node.spline.GetPositionAtTime(timeParam);
                        Quaternion rotationAtTime = node.spline.GetRotationAtTime(timeParam);
                        float r = this.GetRadiusAtTime(node, timeParam, false);
                        Matrix4x4 m = node.matrix * Matrix4x4.TRS(positionAtTime, rotationAtTime, new Vector3(1f, 1f, 1f));
                        Vector3 flareWeldAtTime = this.GetFlareWeldAtTime(node, timeParam);
                        float num13 = Mathf.Max(flareWeldAtTime.x, Mathf.Max(flareWeldAtTime.y, flareWeldAtTime.z) * 0.25f);
                        if (timeParam <= num9)
                        {
                            adaptiveRadialSegments = TreeData.GetAdaptiveRadialSegments(r + num13, num3);
                        }
                        if (flag)
                        {
                            if (i > 0)
                            {
                                float time = list2[i - 1];
                                float num15 = timeParam - time;
                                float num16 = (r + this.GetRadiusAtTime(node, time, false)) * 0.5f;
                                bOffset += (num15 * approximateLength) / ((num16 * 3.141593f) * 2f);
                            }
                        }
                        else
                        {
                            bOffset = num7 + (timeParam * num8);
                        }
                        Vector2 vector3 = base.ComputeWindFactor(node, timeParam);
                        RingLoop item = new RingLoop();
                        item.Reset(r, m, bOffset, adaptiveRadialSegments);
                        item.SetSurfaceAngle(node.GetSurfaceAngleAtTime(timeParam));
                        item.SetAnimationProperties(vector3.x, vector3.y, 0f, node.animSeed);
                        item.SetSpread(flareWeldAtTime.y, flareWeldAtTime.z);
                        item.SetNoise(this.noise * Mathf.Clamp01(this.noiseCurve.Evaluate(timeParam)), this.noiseScaleU * 10f, this.noiseScaleV * 10f);
                        item.SetFlares(flareWeldAtTime.x, this.flareNoise * 10f);
                        int num17 = verts.Count;
                        item.BuildVertices(verts);
                        int num18 = verts.Count;
                        if ((buildFlags & 2) != 0)
                        {
                            float weldHeight = this.weldHeight;
                            float num20 = Mathf.Pow(Mathf.Clamp01(((1f - timeParam) - (1f - this.weldHeight)) / this.weldHeight), 1.5f);
                            float num21 = 1f - num20;
                            if (((timeParam < weldHeight) && (node.parent != null)) && (node.parent.spline != null))
                            {
                                Ray ray = new Ray();
                                for (int k = num17; k < num18; k++)
                                {
                                    ray.origin = verts[k].pos;
                                    ray.direction = m.MultiplyVector(-Vector3.up);
                                    Vector3 pos = verts[k].pos;
                                    Vector3 nor = verts[k].nor;
                                    float num23 = -10000f;
                                    float num24 = 100000f;
                                    for (int n = node.parent.triStart; n < node.parent.triEnd; n++)
                                    {
                                        object obj2 = MathUtils.IntersectRayTriangle(ray, verts[tris[n].v[0]].pos, verts[tris[n].v[1]].pos, verts[tris[n].v[2]].pos, true);
                                        if (obj2 != null)
                                        {
                                            RaycastHit hit = (RaycastHit) obj2;
                                            if ((Mathf.Abs(hit.distance) < num24) && (hit.distance > num23))
                                            {
                                                num24 = Mathf.Abs(hit.distance);
                                                verts[k].nor = (Vector3) (((verts[tris[n].v[0]].nor * hit.barycentricCoordinate.x) + (verts[tris[n].v[1]].nor * hit.barycentricCoordinate.y)) + (verts[tris[n].v[2]].nor * hit.barycentricCoordinate.z));
                                                verts[k].nor = (Vector3) ((verts[k].nor * num20) + (nor * num21));
                                                verts[k].pos = (Vector3) ((hit.point * num20) + (pos * num21));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        list.Add(item);
                        if ((timeParam == 1f) && (item.radius > 0.005f))
                        {
                            RingLoop loop2 = item.Clone();
                            loop2.radius = 0f;
                            loop2.baseOffset += r / 6.283185f;
                            loop2.BuildVertices(verts);
                            list.Add(loop2);
                        }
                    }
                    if (((list.Count > 0) && (list[list.Count - 1].radius > 0.025f)) && (node.breakOffset < 1f))
                    {
                        float mappingScale = 1f / ((this.radius * 3.141593f) * 2f);
                        float sphereFactor = 0f;
                        float noise = 1f;
                        int mappingMode = 0;
                        Material materialBranch = this.materialBranch;
                        if (this.materialBreak != null)
                        {
                            materialBranch = this.materialBreak;
                        }
                        int num30 = TreeGroup.GetMaterialIndex(materialBranch, materials, false);
                        list[list.Count - 1].Cap(sphereFactor, noise, mappingMode, mappingScale, verts, tris, num30);
                    }
                    node.triStart = tris.Count;
                    for (int j = 0; j < (list.Count - 1); j++)
                    {
                        list[j].Connect(list[j + 1], tris, materialIndex, false, false);
                    }
                    node.triEnd = tris.Count;
                    list.Clear();
                }
                float num32 = Mathf.Min(this.frondRange.x, this.frondRange.y);
                float num33 = Mathf.Max(this.frondRange.x, this.frondRange.y);
                float num34 = num32;
                float num35 = num33;
                num32 = Mathf.Clamp(num32, 0f, node.breakOffset);
                num33 = Mathf.Clamp(num33, 0f, node.breakOffset);
                if (((this.geometryMode == GeometryMode.BranchFrond) || (this.geometryMode == GeometryMode.Frond)) && ((this.frondCount > 0) && (num32 != num33)))
                {
                    bool flag2 = true;
                    bool flag3 = true;
                    for (int num36 = 0; num36 < list2.Count; num36++)
                    {
                        float num37 = list2[num36];
                        if (num37 < num32)
                        {
                            list2.RemoveAt(num36);
                            num36--;
                        }
                        else if (num37 == num32)
                        {
                            flag2 = false;
                        }
                        else if (num37 == num33)
                        {
                            flag3 = false;
                        }
                        else if (num37 > num33)
                        {
                            list2.RemoveAt(num36);
                            num36--;
                        }
                    }
                    if (flag2)
                    {
                        list2.Insert(0, num32);
                    }
                    if (flag3)
                    {
                        list2.Add(num33);
                    }
                    int material = TreeGroup.GetMaterialIndex(this.materialFrond, materials, false);
                    float num39 = 1f - node.capRange;
                    for (int num40 = 0; num40 < this.frondCount; num40++)
                    {
                        float num41 = (this.frondCrease * 90f) * 0.01745329f;
                        float num42 = (((this.frondRotation * 360f) + ((num40 * 180f) / ((float) this.frondCount))) - 90f) * 0.01745329f;
                        float f = -num42 - num41;
                        float num44 = num42 - num41;
                        Vector3 vector6 = new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f));
                        Vector3 v = new Vector3(vector6.z, 0f, -vector6.x);
                        Vector3 vector8 = new Vector3(Mathf.Sin(num44), 0f, -Mathf.Cos(num44));
                        Vector3 vector9 = new Vector3(-vector8.z, 0f, vector8.x);
                        for (int num45 = 0; num45 < list2.Count; num45++)
                        {
                            float num46 = list2[num45];
                            float y = (num46 - num34) / (num35 - num34);
                            float num48 = num46;
                            if (num46 > num39)
                            {
                                num48 = num39;
                                float num49 = Mathf.Acos(Mathf.Clamp01((num46 - num39) / node.capRange));
                                float num50 = Mathf.Sin(num49);
                                float num51 = Mathf.Cos(num49) * this.capSmoothing;
                                vector6 = new Vector3(Mathf.Sin(f) * num50, num51, Mathf.Cos(f) * num50);
                                v = new Vector3(vector6.z, vector6.y, -vector6.x);
                                vector8 = new Vector3(Mathf.Sin(num44) * num50, num51, -Mathf.Cos(num44) * num50);
                                vector9 = new Vector3(-vector8.z, vector8.y, vector8.x);
                            }
                            Vector3 vector10 = new Vector3(0f, 0f, -1f);
                            Vector3 vector11 = node.spline.GetPositionAtTime(num48);
                            Quaternion q = node.spline.GetRotationAtTime(num46);
                            float num52 = (Mathf.Clamp01(this.frondCurve.Evaluate(num46)) * this.frondWidth) * node.GetScale();
                            Matrix4x4 matrixx2 = node.matrix * Matrix4x4.TRS(vector11, q, new Vector3(1f, 1f, 1f));
                            if (TreeGroup.GenerateDoubleSidedGeometry)
                            {
                                for (float num53 = -1f; num53 < 2f; num53 += 2f)
                                {
                                    TreeVertex vertex;
                                    TreeVertex vertex2;
                                    TreeVertex vertex3;
                                    TreeVertex vertex4;
                                    vertex = new TreeVertex {
                                        pos = matrixx2.MultiplyPoint((Vector3) (vector6 * num52)),
                                        nor = matrixx2.MultiplyVector((Vector3) (v * num53)).normalized,
                                        tangent = TreeGroup.CreateTangent(node, q, vertex.nor)
                                    };
                                    vertex.tangent.w = -num53;
                                    vertex.uv0 = new Vector2(1f, y);
                                    vertex2 = new TreeVertex {
                                        pos = matrixx2.MultiplyPoint(Vector3.zero),
                                        nor = matrixx2.MultiplyVector((Vector3) (vector10 * num53)).normalized,
                                        tangent = TreeGroup.CreateTangent(node, q, vertex2.nor)
                                    };
                                    vertex2.tangent.w = -num53;
                                    vertex2.uv0 = new Vector2(0.5f, y);
                                    vertex3 = new TreeVertex {
                                        pos = matrixx2.MultiplyPoint(Vector3.zero),
                                        nor = matrixx2.MultiplyVector((Vector3) (vector10 * num53)).normalized,
                                        tangent = TreeGroup.CreateTangent(node, q, vertex3.nor)
                                    };
                                    vertex3.tangent.w = -num53;
                                    vertex3.uv0 = new Vector2(0.5f, y);
                                    vertex4 = new TreeVertex {
                                        pos = matrixx2.MultiplyPoint((Vector3) (vector8 * num52)),
                                        nor = matrixx2.MultiplyVector((Vector3) (vector9 * num53)).normalized,
                                        tangent = TreeGroup.CreateTangent(node, q, vertex4.nor)
                                    };
                                    vertex4.tangent.w = -num53;
                                    vertex4.uv0 = new Vector2(0f, y);
                                    Vector2 vector12 = base.ComputeWindFactor(node, num46);
                                    vertex.SetAnimationProperties(vector12.x, vector12.y, base.animationEdge, node.animSeed);
                                    vertex2.SetAnimationProperties(vector12.x, vector12.y, 0f, node.animSeed);
                                    vertex3.SetAnimationProperties(vector12.x, vector12.y, 0f, node.animSeed);
                                    vertex4.SetAnimationProperties(vector12.x, vector12.y, base.animationEdge, node.animSeed);
                                    verts.Add(vertex);
                                    verts.Add(vertex2);
                                    verts.Add(vertex3);
                                    verts.Add(vertex4);
                                }
                                if (num45 > 0)
                                {
                                    int num54 = verts.Count;
                                    TreeTriangle triangle = new TreeTriangle(material, num54 - 4, num54 - 3, num54 - 11);
                                    TreeTriangle triangle2 = new TreeTriangle(material, num54 - 4, num54 - 11, num54 - 12);
                                    triangle.flip();
                                    triangle2.flip();
                                    TreeTriangle triangle3 = new TreeTriangle(material, num54 - 8, num54 - 7, num54 - 15);
                                    TreeTriangle triangle4 = new TreeTriangle(material, num54 - 8, num54 - 15, num54 - 0x10);
                                    tris.Add(triangle);
                                    tris.Add(triangle2);
                                    tris.Add(triangle3);
                                    tris.Add(triangle4);
                                    TreeTriangle triangle5 = new TreeTriangle(material, num54 - 2, num54 - 9, num54 - 1);
                                    TreeTriangle triangle6 = new TreeTriangle(material, num54 - 2, num54 - 10, num54 - 9);
                                    TreeTriangle triangle7 = new TreeTriangle(material, num54 - 6, num54 - 13, num54 - 5);
                                    TreeTriangle triangle8 = new TreeTriangle(material, num54 - 6, num54 - 14, num54 - 13);
                                    triangle7.flip();
                                    triangle8.flip();
                                    tris.Add(triangle5);
                                    tris.Add(triangle6);
                                    tris.Add(triangle7);
                                    tris.Add(triangle8);
                                }
                            }
                            else
                            {
                                TreeVertex vertex5 = new TreeVertex {
                                    pos = matrixx2.MultiplyPoint((Vector3) (vector6 * num52)),
                                    nor = matrixx2.MultiplyVector(v).normalized,
                                    uv0 = new Vector2(0f, y)
                                };
                                TreeVertex vertex6 = new TreeVertex {
                                    pos = matrixx2.MultiplyPoint(Vector3.zero),
                                    nor = matrixx2.MultiplyVector(Vector3.back).normalized,
                                    uv0 = new Vector2(0.5f, y)
                                };
                                TreeVertex vertex7 = new TreeVertex {
                                    pos = matrixx2.MultiplyPoint((Vector3) (vector8 * num52)),
                                    nor = matrixx2.MultiplyVector(vector9).normalized,
                                    uv0 = new Vector2(1f, y)
                                };
                                Vector2 vector13 = base.ComputeWindFactor(node, num46);
                                vertex5.SetAnimationProperties(vector13.x, vector13.y, base.animationEdge, node.animSeed);
                                vertex6.SetAnimationProperties(vector13.x, vector13.y, 0f, node.animSeed);
                                vertex7.SetAnimationProperties(vector13.x, vector13.y, base.animationEdge, node.animSeed);
                                verts.Add(vertex5);
                                verts.Add(vertex6);
                                verts.Add(vertex7);
                                if (num45 > 0)
                                {
                                    int num55 = verts.Count;
                                    TreeTriangle triangle9 = new TreeTriangle(material, num55 - 2, num55 - 3, num55 - 6);
                                    TreeTriangle triangle10 = new TreeTriangle(material, num55 - 2, num55 - 6, num55 - 5);
                                    tris.Add(triangle9);
                                    tris.Add(triangle10);
                                    TreeTriangle triangle11 = new TreeTriangle(material, num55 - 2, num55 - 4, num55 - 1);
                                    TreeTriangle triangle12 = new TreeTriangle(material, num55 - 2, num55 - 5, num55 - 4);
                                    tris.Add(triangle11);
                                    tris.Add(triangle12);
                                }
                            }
                        }
                    }
                }
                if ((buildFlags & 1) != 0)
                {
                    for (int num56 = count; num56 < verts.Count; num56++)
                    {
                        verts[num56].SetAmbientOcclusion(TreeGroup.ComputeAmbientOcclusion(verts[num56].pos, verts[num56].nor, aoSpheres, aoDensity));
                    }
                }
                node.vertEnd = verts.Count;
                Profiler.EndSample();
            }
        }

        public override void UpdateParameters()
        {
            if ((base.parentGroup == null) || (base.parentGroup.GetType() == typeof(TreeGroupRoot)))
            {
                this.weldSpreadTop = 0f;
                this.weldSpreadBottom = 0f;
                base.animationSecondary = 0f;
            }
            else
            {
                this.flareSize = 0f;
            }
            float num = (this.height.y - this.height.x) / this.height.y;
            for (int i = 0; i < base.nodes.Count; i++)
            {
                TreeNode node = base.nodes[i];
                UnityEngine.Random.seed = node.seed;
                float num3 = 1f;
                for (int j = 0; j < 5; j++)
                {
                    num3 = 1f - (UnityEngine.Random.value * num);
                }
                if (base.lockFlags == 0)
                {
                    node.scale *= num3;
                }
                float num5 = 0f;
                for (int k = 0; k < 5; k++)
                {
                    num5 = UnityEngine.Random.value;
                }
                for (int m = 0; m < 5; m++)
                {
                    node.breakOffset = 1f;
                    if ((UnityEngine.Random.value <= this.breakingChance) && (this.breakingChance > 0f))
                    {
                        node.breakOffset = this.breakingSpot.x + ((this.breakingSpot.y - this.breakingSpot.x) * num5);
                        if (node.breakOffset < 0.01f)
                        {
                            node.breakOffset = 0.01f;
                        }
                    }
                }
                if (!(base.parentGroup is TreeGroupRoot))
                {
                    node.size = this.radius;
                    if (this.radiusMode)
                    {
                        node.size *= node.scale;
                    }
                    if ((node.parent != null) && (node.parent.spline != null))
                    {
                        node.size = Mathf.Min(node.parent.group.GetRadiusAtTime(node.parent, node.offset, false) * 0.75f, node.size);
                    }
                }
                else if (base.lockFlags == 0)
                {
                    node.size = this.radius;
                    if (this.radiusMode)
                    {
                        node.size *= node.scale;
                    }
                }
            }
            this.UpdateMatrix();
            this.UpdateSplines();
            base.UpdateParameters();
        }

        public void UpdateSpline(TreeNode node)
        {
            if (base.lockFlags == 0)
            {
                UnityEngine.Random.seed = node.seed;
                if (node.spline == null)
                {
                    TreeSpline spline = new TreeSpline();
                    node.spline = spline;
                }
                float num = this.height.y * node.GetScale();
                float num2 = 1f;
                int num3 = (int) Mathf.Round(num / num2);
                float num4 = 0f;
                Quaternion identity = Quaternion.identity;
                Vector3 pos = new Vector3(0f, 0f, 0f);
                Matrix4x4 matrixx2 = node.matrix * base.GetRootMatrix();
                Matrix4x4 inverse = matrixx2.inverse;
                Quaternion b = MathUtils.QuaternionFromMatrix(inverse) * Quaternion.Euler(0f, node.angle, 0f);
                Quaternion quaternion3 = MathUtils.QuaternionFromMatrix(inverse) * Quaternion.Euler(-180f, node.angle, 0f);
                node.spline.Reset();
                node.spline.AddPoint(pos, 0f);
                for (int i = 0; i < num3; i++)
                {
                    float y = num2;
                    if (i == (num3 - 1))
                    {
                        y = num - num4;
                    }
                    num4 += y;
                    float time = num4 / num;
                    float num8 = Mathf.Clamp(this.seekCurve.Evaluate(time), -1f, 1f);
                    float t = Mathf.Clamp01(num8) * this.seekBlend;
                    float num10 = Mathf.Clamp01(-num8) * this.seekBlend;
                    identity = Quaternion.Slerp(Quaternion.Slerp(identity, b, t), quaternion3, num10);
                    float num11 = this.crinklyness * Mathf.Clamp01(this.crinkCurve.Evaluate(time));
                    Quaternion quaternion4 = Quaternion.Euler(new Vector3(180f * (UnityEngine.Random.value - 0.5f), node.angle, 180f * (UnityEngine.Random.value - 0.5f)));
                    identity = Quaternion.Slerp(identity, quaternion4, num11);
                    pos += identity * new Vector3(0f, y, 0f);
                    node.spline.AddPoint(pos, time);
                }
                node.spline.UpdateTime();
                node.spline.UpdateRotations();
            }
        }

        public void UpdateSplines()
        {
            for (int i = 0; i < base.nodes.Count; i++)
            {
                TreeNode node = base.nodes[i];
                this.UpdateSpline(node);
                if (this.capSmoothing < 0.01f)
                {
                    node.capRange = 0f;
                }
                else
                {
                    float num2 = Mathf.Clamp(this.radiusCurve.Evaluate(1f), 0f, 1f) * node.size;
                    float approximateLength = node.spline.GetApproximateLength();
                    node.capRange = ((num2 / approximateLength) * this.capSmoothing) * 2f;
                }
            }
        }

        internal override string DistributionModeString
        {
            get
            {
                return distributionModeString;
            }
        }

        internal override string EdgeTurbulenceString
        {
            get
            {
                return edgeTurbulenceString;
            }
        }

        internal override string FrequencyString
        {
            get
            {
                return frequencyString;
            }
        }

        internal override string GroupSeedString
        {
            get
            {
                return groupSeedString;
            }
        }

        internal override string GrowthAngleString
        {
            get
            {
                return growthAngleString;
            }
        }

        internal override string GrowthScaleString
        {
            get
            {
                return growthScaleString;
            }
        }

        internal override string MainTurbulenceString
        {
            get
            {
                return mainTurbulenceString;
            }
        }

        internal override string MainWindString
        {
            get
            {
                return mainWindString;
            }
        }

        internal override string TwirlString
        {
            get
            {
                return twirlString;
            }
        }

        internal override string WhorledStepString
        {
            get
            {
                return whorledStepString;
            }
        }

        public enum GeometryMode
        {
            Branch,
            BranchFrond,
            Frond
        }
    }
}

