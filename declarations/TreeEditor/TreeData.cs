namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using UnityEditor;
    using UnityEditorInternal;
    using UnityEngine;

    public class TreeData : ScriptableObject
    {
        [SerializeField]
        private int _uniqueID;
        public TreeGroupBranch[] branchGroups;
        public bool isInPreviewMode;
        public TreeGroupLeaf[] leafGroups;
        public string materialHash;
        public Mesh mesh;
        public TreeNode[] nodes;
        public Material optimizedCutoutMaterial;
        public Material optimizedSolidMaterial;
        public TreeGroupRoot root;

        public TreeGroup AddGroup(TreeGroup parent, System.Type type)
        {
            TreeGroup g = null;
            if (type == typeof(TreeGroupBranch))
            {
                g = new TreeGroupBranch();
                this.branchGroups = this.ArrayAdd(this.branchGroups, g as TreeGroupBranch);
            }
            else if (type == typeof(TreeGroupLeaf))
            {
                g = new TreeGroupLeaf();
                this.leafGroups = this.ArrayAdd(this.leafGroups, g as TreeGroupLeaf);
            }
            else
            {
                return null;
            }
            g.uniqueID = this._uniqueID;
            this._uniqueID++;
            g.parentGroupID = 0;
            g.distributionFrequency = 1;
            this.SetGroupParent(g, parent);
            return g;
        }

        public TreeNode AddNode(TreeGroup g, TreeNode parent)
        {
            return this.AddNode(g, parent, true);
        }

        public TreeNode AddNode(TreeGroup g, TreeNode parent, bool validate)
        {
            if (g == null)
            {
                return null;
            }
            TreeNode n = new TreeNode {
                uniqueID = this._uniqueID
            };
            this._uniqueID++;
            this.SetNodeParent(n, parent);
            n.groupID = g.uniqueID;
            n.group = g;
            g.nodeIDs = this.ArrayAdd(g.nodeIDs, n.uniqueID);
            g.nodes.Add(n);
            this.nodes = this.ArrayAdd(this.nodes, n);
            if (validate)
            {
                this.ValidateReferences();
            }
            return n;
        }

        private int[] ArrayAdd(int[] array, int value)
        {
            return new List<int>(array) { value }.ToArray();
        }

        private TreeGroup[] ArrayAdd(TreeGroup[] array, TreeGroup value)
        {
            return new List<TreeGroup>(array) { value }.ToArray();
        }

        private TreeGroupBranch[] ArrayAdd(TreeGroupBranch[] array, TreeGroupBranch value)
        {
            return new List<TreeGroupBranch>(array) { value }.ToArray();
        }

        private TreeGroupLeaf[] ArrayAdd(TreeGroupLeaf[] array, TreeGroupLeaf value)
        {
            return new List<TreeGroupLeaf>(array) { value }.ToArray();
        }

        private TreeNode[] ArrayAdd(TreeNode[] array, TreeNode value)
        {
            return new List<TreeNode>(array) { value }.ToArray();
        }

        private int[] ArrayRemove(int[] array, int value)
        {
            List<int> list = new List<int>(array);
            list.Remove(value);
            return list.ToArray();
        }

        private TreeGroup[] ArrayRemove(TreeGroup[] array, TreeGroup value)
        {
            List<TreeGroup> list = new List<TreeGroup>(array);
            list.Remove(value);
            return list.ToArray();
        }

        private TreeGroupBranch[] ArrayRemove(TreeGroupBranch[] array, TreeGroupBranch value)
        {
            List<TreeGroupBranch> list = new List<TreeGroupBranch>(array);
            list.Remove(value);
            return list.ToArray();
        }

        private TreeGroupLeaf[] ArrayRemove(TreeGroupLeaf[] array, TreeGroupLeaf value)
        {
            List<TreeGroupLeaf> list = new List<TreeGroupLeaf>(array);
            list.Remove(value);
            return list.ToArray();
        }

        private TreeNode[] ArrayRemove(TreeNode[] array, TreeNode value)
        {
            List<TreeNode> list = new List<TreeNode>(array);
            list.Remove(value);
            return list.ToArray();
        }

        public bool CheckExternalChanges()
        {
            this.ValidateReferences();
            return this.root.CheckExternalChanges();
        }

        public void ClearReferences()
        {
            for (int i = 0; i < this.branchGroups.Length; i++)
            {
                this.branchGroups[i].parentGroup = null;
                this.branchGroups[i].childGroups.Clear();
                this.branchGroups[i].nodes.Clear();
            }
            for (int j = 0; j < this.leafGroups.Length; j++)
            {
                this.leafGroups[j].parentGroup = null;
                this.leafGroups[j].childGroups.Clear();
                this.leafGroups[j].nodes.Clear();
            }
            for (int k = 0; k < this.nodes.Length; k++)
            {
                this.nodes[k].parent = null;
                this.nodes[k].group = null;
            }
        }

        private void CopyFields(object n, object n2)
        {
            if (n.GetType() == n2.GetType())
            {
                System.Reflection.FieldInfo[] fields = n.GetType().GetFields();
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i].IsPublic)
                    {
                        if (fields[i].FieldType == typeof(TreeSpline))
                        {
                            TreeSpline o = fields[i].GetValue(n) as TreeSpline;
                            fields[i].SetValue(n2, new TreeSpline(o));
                        }
                        else if (fields[i].FieldType == typeof(AnimationCurve))
                        {
                            AnimationCurve curve = fields[i].GetValue(n) as AnimationCurve;
                            AnimationCurve curve2 = new AnimationCurve(curve.keys) {
                                postWrapMode = curve.postWrapMode,
                                preWrapMode = curve.preWrapMode
                            };
                            fields[i].SetValue(n2, curve2);
                        }
                        else
                        {
                            fields[i].SetValue(n2, fields[i].GetValue(n));
                        }
                    }
                }
            }
        }

        public void DeleteGroup(TreeGroup g)
        {
            for (int i = g.nodes.Count - 1; i >= 0; i--)
            {
                this.DeleteNode(g.nodes[i], false);
            }
            if (g.GetType() == typeof(TreeGroupBranch))
            {
                this.branchGroups = this.ArrayRemove(this.branchGroups, g as TreeGroupBranch);
            }
            else if (g.GetType() == typeof(TreeGroupLeaf))
            {
                this.leafGroups = this.ArrayRemove(this.leafGroups, g as TreeGroupLeaf);
            }
            this.SetGroupParent(g, null);
        }

        public void DeleteNode(TreeNode n)
        {
            this.DeleteNode(n, true);
        }

        public void DeleteNode(TreeNode n, bool validate)
        {
            TreeGroup group = this.GetGroup(n.groupID);
            if (group != null)
            {
                group.nodeIDs = this.ArrayRemove(group.nodeIDs, n.uniqueID);
                group.nodes.Remove(n);
                for (int i = 0; i < group.childGroups.Count; i++)
                {
                    TreeGroup group2 = group.childGroups[i];
                    for (int j = group2.nodes.Count - 1; j >= 0; j--)
                    {
                        if ((group2.nodes[j] != null) && (group2.nodes[j].parentID == n.uniqueID))
                        {
                            this.DeleteNode(group2.nodes[j], false);
                        }
                    }
                }
            }
            n.group = null;
            n.groupID = 0;
            n.parent = null;
            n.parentID = 0;
            this.nodes = this.ArrayRemove(this.nodes, n);
            if (validate)
            {
                this.ValidateReferences();
            }
        }

        private void DrawTexture(Rect rect, Texture rgbTexture, Texture alphaTexture, Material material, Color color, int pass)
        {
            material.SetColor("_Color", color);
            material.SetTexture("_RGBSource", rgbTexture);
            material.SetTexture("_AlphaSource", alphaTexture);
            material.SetPass(pass);
            RenderTexture active = RenderTexture.active;
            Vector2 vector = (Vector2) (Vector2.Scale(active.GetTexelOffset(), new Vector2((float) active.width, (float) active.height)) * -1f);
            rect.x += vector.x;
            rect.y += vector.y;
            GL.Begin(7);
            GL.TexCoord(new Vector3(0f, 0f, 0f));
            GL.Vertex3(rect.x, rect.y, 0f);
            GL.TexCoord(new Vector3(1f, 0f, 0f));
            GL.Vertex3(rect.x + rect.width, rect.y, 0f);
            GL.TexCoord(new Vector3(1f, 1f, 0f));
            GL.Vertex3(rect.x + rect.width, rect.y + rect.height, 0f);
            GL.TexCoord(new Vector3(0f, 1f, 0f));
            GL.Vertex3(rect.x, rect.y + rect.height, 0f);
            GL.End();
        }

        public TreeGroup DuplicateGroup(TreeGroup g)
        {
            TreeGroup group = this.AddGroup(this.GetGroup(g.parentGroupID), g.GetType());
            this.CopyFields(g, group);
            group.childGroupIDs = new int[0];
            group.nodeIDs = new int[0];
            for (int i = 0; i < g.nodeIDs.Length; i++)
            {
                TreeNode n = this.GetNode(g.nodeIDs[i]);
                TreeNode node2 = this.AddNode(group, this.GetNode(n.parentID));
                this.CopyFields(n, node2);
                node2.groupID = group.uniqueID;
            }
            return group;
        }

        public TreeNode DuplicateNode(TreeNode n)
        {
            TreeGroup g = this.GetGroup(n.groupID);
            if (g == null)
            {
                return null;
            }
            TreeNode node = this.AddNode(g, this.GetNode(n.parentID));
            this.CopyFields(n, node);
            return node;
        }

        private static void ExtractOptimizedShaders(List<TreeMaterial> materials, out Shader optimizedSolidShader, out Shader optimizedCutoutShader)
        {
            List<Shader> list = new List<Shader>();
            List<Shader> list2 = new List<Shader>();
            foreach (TreeMaterial material in materials)
            {
                Material material2 = material.material;
                if ((material2 != null) && (material2.shader != null))
                {
                    if (TreeEditorHelper.IsTreeBarkShader(material2.shader))
                    {
                        list.Add(material2.shader);
                    }
                    else if (TreeEditorHelper.IsTreeLeafShader(material2.shader))
                    {
                        list2.Add(material2.shader);
                    }
                }
            }
            optimizedSolidShader = null;
            optimizedCutoutShader = null;
            if (list.Count > 0)
            {
                optimizedSolidShader = Shader.Find(TreeEditorHelper.GetOptimizedShaderName(list[0]));
            }
            if (list2.Count > 0)
            {
                optimizedCutoutShader = Shader.Find(TreeEditorHelper.GetOptimizedShaderName(list2[0]));
            }
            if (optimizedSolidShader == null)
            {
                optimizedSolidShader = TreeEditorHelper.DefaultOptimizedBarkShader;
            }
            if (optimizedCutoutShader == null)
            {
                optimizedCutoutShader = TreeEditorHelper.DefaultOptimizedLeafShader;
            }
        }

        public static int GetAdaptiveHeightSegments(float h, float adaptiveQuality)
        {
            return (int) Mathf.Max((float) (h * adaptiveQuality), (float) 2f);
        }

        public static int GetAdaptiveRadialSegments(float r, float adaptiveQuality)
        {
            int num = (((int) ((r * 24f) * adaptiveQuality)) / 2) * 2;
            return Mathf.Clamp(num, 4, 0x20);
        }

        public static List<float> GetAdaptiveSamples(TreeGroup group, TreeNode node, float adaptiveQuality)
        {
            List<float> list = new List<float>();
            if (node.spline != null)
            {
                float item = 1f - node.capRange;
                SplineNode[] nodes = node.spline.GetNodes();
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (nodes[i].time >= node.breakOffset)
                    {
                        list.Add(node.breakOffset);
                        break;
                    }
                    if (nodes[i].time > item)
                    {
                        list.Add(item);
                        break;
                    }
                    list.Add(nodes[i].time);
                }
                list.Sort();
                if (list.Count < 2)
                {
                    return list;
                }
                float radius = 1f;
                if (group.GetType() == typeof(TreeGroupBranch))
                {
                    radius = ((TreeGroupBranch) group).radius;
                }
                float num4 = Mathf.Lerp(0.999f, 0.99999f, adaptiveQuality);
                float num5 = Mathf.Lerp(0.5f, 0.985f, adaptiveQuality);
                float num6 = Mathf.Lerp(0.3f * radius, 0.1f * radius, adaptiveQuality);
                int num7 = 200;
                int num8 = 0;
                while (num8 < (list.Count - 1))
                {
                    for (int k = num8; k < (list.Count - 1); k++)
                    {
                        Quaternion rotationAtTime = node.spline.GetRotationAtTime(list[k]);
                        Quaternion quaternion2 = node.spline.GetRotationAtTime(list[k + 1]);
                        Vector3 lhs = (Vector3) (rotationAtTime * Vector3.up);
                        Vector3 rhs = (Vector3) (quaternion2 * Vector3.up);
                        Vector3 vector3 = (Vector3) (rotationAtTime * Vector3.right);
                        Vector3 vector4 = (Vector3) (quaternion2 * Vector3.right);
                        Vector3 vector5 = (Vector3) (rotationAtTime * Vector3.forward);
                        Vector3 vector6 = (Vector3) (quaternion2 * Vector3.forward);
                        float num10 = group.GetRadiusAtTime(node, list[k], true);
                        float num11 = group.GetRadiusAtTime(node, list[k + 1], true);
                        bool flag = false;
                        if (Vector3.Dot(lhs, rhs) < num5)
                        {
                            flag = true;
                        }
                        if (Vector3.Dot(vector3, vector4) < num5)
                        {
                            flag = true;
                        }
                        if (Vector3.Dot(vector5, vector6) < num5)
                        {
                            flag = true;
                        }
                        if (Mathf.Abs((float) (num10 - num11)) > num6)
                        {
                            flag = true;
                        }
                        if (flag)
                        {
                            num7--;
                            if (num7 > 0)
                            {
                                float num12 = (list[k] + list[k + 1]) * 0.5f;
                                list.Insert(k + 1, num12);
                                continue;
                            }
                        }
                        num8 = k + 1;
                    }
                }
                for (int j = 0; j < (list.Count - 2); j++)
                {
                    Vector3 positionAtTime = node.spline.GetPositionAtTime(list[j]);
                    Vector3 vector8 = node.spline.GetPositionAtTime(list[j + 1]);
                    Vector3 vector9 = node.spline.GetPositionAtTime(list[j + 2]);
                    float num14 = group.GetRadiusAtTime(node, list[j], true);
                    float num15 = group.GetRadiusAtTime(node, list[j + 1], true);
                    float num16 = group.GetRadiusAtTime(node, list[j + 2], true);
                    Vector3 vector12 = vector8 - positionAtTime;
                    Vector3 normalized = vector12.normalized;
                    Vector3 vector13 = vector9 - positionAtTime;
                    Vector3 vector11 = vector13.normalized;
                    bool flag2 = false;
                    if (Vector3.Dot(normalized, vector11) >= num4)
                    {
                        flag2 = true;
                    }
                    if (Mathf.Abs((float) (num14 - num15)) > num6)
                    {
                        flag2 = false;
                    }
                    if (Mathf.Abs((float) (num15 - num16)) > num6)
                    {
                        flag2 = false;
                    }
                    if (flag2)
                    {
                        list.RemoveAt(j + 1);
                        j--;
                    }
                }
                if (node.capRange > 0f)
                {
                    int num17 = 1 + Mathf.CeilToInt((node.capRange * 16f) * adaptiveQuality);
                    for (int m = 0; m < num17; m++)
                    {
                        float f = ((((float) (m + 1)) / ((float) num17)) * 3.141593f) * 0.5f;
                        float num20 = Mathf.Sin(f);
                        float num21 = item + (node.capRange * num20);
                        if (num21 < node.breakOffset)
                        {
                            list.Add(num21);
                        }
                    }
                    list.Sort();
                }
                if (1f <= node.breakOffset)
                {
                    if (list[list.Count - 1] < 1f)
                    {
                        list.Add(1f);
                        return list;
                    }
                    list[list.Count - 1] = 1f;
                }
            }
            return list;
        }

        public TreeGroup GetGroup(int id)
        {
            if (id == this.root.uniqueID)
            {
                return this.root;
            }
            for (int i = 0; i < this.branchGroups.Length; i++)
            {
                if (this.branchGroups[i].uniqueID == id)
                {
                    return this.branchGroups[i];
                }
            }
            for (int j = 0; j < this.leafGroups.Length; j++)
            {
                if (this.leafGroups[j].uniqueID == id)
                {
                    return this.leafGroups[j];
                }
            }
            return null;
        }

        private TreeGroup GetGroupAt(int i)
        {
            if (i == 0)
            {
                return this.root;
            }
            i--;
            if ((i >= 0) && (i < this.branchGroups.Length))
            {
                return this.branchGroups[i];
            }
            i -= this.branchGroups.Length;
            if ((i >= 0) && (i < this.leafGroups.Length))
            {
                return this.leafGroups[i];
            }
            return null;
        }

        private int GetGroupCount()
        {
            return ((1 + this.branchGroups.Length) + this.leafGroups.Length);
        }

        public TreeNode GetNode(int id)
        {
            for (int i = 0; i < this.nodes.Length; i++)
            {
                if (this.nodes[i].uniqueID == id)
                {
                    return this.nodes[i];
                }
            }
            return null;
        }

        private TreeNode GetNodeAt(int i)
        {
            if ((i >= 0) && (i < this.nodes.Length))
            {
                return this.nodes[i];
            }
            return null;
        }

        private int GetNodeCount()
        {
            return this.nodes.Length;
        }

        public void Initialize()
        {
            if (this.root == null)
            {
                this.branchGroups = new TreeGroupBranch[0];
                this.leafGroups = new TreeGroupLeaf[0];
                this.nodes = new TreeNode[0];
                this._uniqueID = 1;
                this.root = new TreeGroupRoot();
                this.root.uniqueID = this._uniqueID;
                this.root.distributionFrequency = 1;
                this._uniqueID++;
                this.UpdateFrequency(this.root.uniqueID);
                this.AddGroup(this.root, typeof(TreeGroupBranch));
            }
        }

        public bool IsAncestor(TreeGroup ancestor, TreeGroup g)
        {
            if (g != null)
            {
                for (TreeGroup group = this.GetGroup(g.parentGroupID); group != null; group = this.GetGroup(group.parentGroupID))
                {
                    if (group == ancestor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void LockGroup(TreeGroup g)
        {
            g.Lock();
        }

        public bool OptimizeMaterial(List<TreeMaterial> materials, List<TreeVertex> vertices, List<TreeTriangle> triangles)
        {
            Shader shader;
            Shader shader2;
            if ((this.optimizedSolidMaterial == null) || (this.optimizedCutoutMaterial == null))
            {
                Debug.LogError("Optimized materials haven't been assigned");
                return false;
            }
            ExtractOptimizedShaders(materials, out shader, out shader2);
            this.optimizedSolidMaterial.shader = shader;
            this.optimizedCutoutMaterial.shader = shader2;
            int targetWidth = 0x400;
            int targetHeight = 0x400;
            int padding = 0x20;
            Profiler.BeginSample("OptimizeMaterial");
            float[] numArray = new float[materials.Count];
            float num4 = 0f;
            float num5 = 0f;
            for (int i = 0; i < materials.Count; i++)
            {
                if (!materials[i].tileV)
                {
                    num5++;
                }
                else
                {
                    num4++;
                }
            }
            for (int j = 0; j < materials.Count; j++)
            {
                if (materials[j].tileV)
                {
                    numArray[j] = 1f;
                }
                else
                {
                    numArray[j] = 1f / num5;
                }
            }
            TextureAtlas atlas = new TextureAtlas();
            for (int k = 0; k < materials.Count; k++)
            {
                Texture2D diffuse = null;
                Texture2D normal = null;
                Texture2D gloss = null;
                Texture2D transtex = null;
                Texture2D shadowOffsetTex = null;
                Color diffuseColor = new Color(1f, 1f, 1f, 1f);
                float @float = 0.03f;
                Vector2 uvTiling = new Vector2(1f, 1f);
                Material material = materials[k].material;
                if (material != null)
                {
                    if (material.HasProperty("_Color"))
                    {
                        diffuseColor = material.GetColor("_Color");
                    }
                    if (material.HasProperty("_MainTex"))
                    {
                        diffuse = material.mainTexture as Texture2D;
                        uvTiling = material.GetTextureScale("_MainTex");
                    }
                    if (material.HasProperty("_BumpMap"))
                    {
                        normal = material.GetTexture("_BumpMap") as Texture2D;
                    }
                    if (material.HasProperty("_GlossMap"))
                    {
                        gloss = material.GetTexture("_GlossMap") as Texture2D;
                    }
                    if (material.HasProperty("_TranslucencyMap"))
                    {
                        transtex = material.GetTexture("_TranslucencyMap") as Texture2D;
                    }
                    if (material.HasProperty("_Shininess"))
                    {
                        @float = material.GetFloat("_Shininess");
                    }
                    if (material.HasProperty("_ShadowOffset"))
                    {
                        shadowOffsetTex = material.GetTexture("_ShadowOffset") as Texture2D;
                    }
                }
                @float = Mathf.Clamp(@float, 0.03f, 1f);
                Vector2 scale = new Vector2(numArray[k], numArray[k]);
                if (diffuse != null)
                {
                    scale.x *= ((float) targetWidth) / ((float) diffuse.width);
                    scale.y *= ((float) targetHeight) / ((float) diffuse.height);
                }
                bool tileV = materials[k].tileV;
                if (!tileV)
                {
                    uvTiling = new Vector2(1f, 1f);
                }
                atlas.AddTexture("tex" + k, diffuse, diffuseColor, normal, gloss, transtex, shadowOffsetTex, @float, scale, tileV, uvTiling);
            }
            atlas.Pack(ref targetWidth, targetHeight, padding, true);
            this.UpdateTextures(atlas, materials);
            Rect uVRect = new Rect();
            Vector2 texTiling = new Vector2(1f, 1f);
            int materialIndex = -1;
            for (int m = 0; m < triangles.Count; m++)
            {
                TreeTriangle triangle = triangles[m];
                if (triangle.materialIndex != materialIndex)
                {
                    materialIndex = triangle.materialIndex;
                    uVRect = atlas.GetUVRect("tex" + triangle.materialIndex);
                    texTiling = atlas.GetTexTiling("tex" + triangle.materialIndex);
                }
                for (int n = 0; n < 3; n++)
                {
                    TreeVertex vertex = vertices[triangle.v[n]];
                    if (!vertex.flag)
                    {
                        vertex.uv0.x = uVRect.x + (vertex.uv0.x * uVRect.width);
                        vertex.uv0.y = (uVRect.y + (vertex.uv0.y * uVRect.height)) * texTiling.y;
                        vertex.flag = true;
                    }
                }
                if (triangle.isCutout)
                {
                    triangle.materialIndex = 1;
                }
                else
                {
                    triangle.materialIndex = 0;
                }
            }
            Profiler.EndSample();
            return true;
        }

        public void PreviewMesh(Matrix4x4 worldToLocalMatrix, out Material[] outMaterials)
        {
            outMaterials = null;
            if (this.mesh == null)
            {
                Debug.LogError("TreeData must have mesh  assigned");
            }
            else
            {
                bool enableAmbientOcclusion = this.root.enableAmbientOcclusion;
                float adaptiveLODQuality = this.root.adaptiveLODQuality;
                this.root.enableMaterialOptimize = false;
                this.root.enableWelding = false;
                this.root.enableAmbientOcclusion = false;
                this.root.adaptiveLODQuality = 0f;
                this.UpdateMesh(worldToLocalMatrix, out outMaterials);
                this.root.enableWelding = true;
                this.root.enableMaterialOptimize = true;
                this.root.enableAmbientOcclusion = enableAmbientOcclusion;
                this.root.adaptiveLODQuality = adaptiveLODQuality;
                this.isInPreviewMode = true;
            }
        }

        public void SetGroupParent(TreeGroup g, TreeGroup parent)
        {
            TreeGroup group = this.GetGroup(g.parentGroupID);
            if (group != null)
            {
                group.childGroupIDs = this.ArrayRemove(group.childGroupIDs, g.uniqueID);
                group.childGroups.Remove(g);
            }
            if (parent != null)
            {
                g.parentGroup = parent;
                g.parentGroupID = parent.uniqueID;
                parent.childGroups.Add(g);
                parent.childGroupIDs = this.ArrayAdd(parent.childGroupIDs, g.uniqueID);
            }
            else
            {
                g.parentGroup = null;
                g.parentGroupID = 0;
            }
            this.ValidateReferences();
            this.UpdateFrequency(g.uniqueID);
        }

        public void SetNodeParent(TreeNode n, TreeNode parent)
        {
            if (parent != null)
            {
                n.parentID = parent.uniqueID;
                n.parent = parent;
            }
            else
            {
                n.parentID = 0;
                n.parent = null;
            }
        }

        public void UnlockGroup(TreeGroup g)
        {
            g.Unlock();
            this.UpdateFrequency(g.uniqueID);
        }

        public void UpdateDistribution(int id)
        {
            TreeGroup group = this.GetGroup(id);
            if (group != null)
            {
                int seed = UnityEngine.Random.seed;
                this.ClearReferences();
                this.ValidateReferences();
                group.UpdateDistribution(true, true);
                this.ClearReferences();
                UnityEngine.Random.seed = seed;
            }
        }

        public void UpdateFrequency(int id)
        {
            TreeGroup group = this.GetGroup(id);
            if (group != null)
            {
                int seed = UnityEngine.Random.seed;
                this.ClearReferences();
                this.ValidateReferences();
                group.UpdateFrequency(this);
                this.ClearReferences();
                UnityEngine.Random.seed = seed;
            }
        }

        public void UpdateMesh(Matrix4x4 worldToLocalMatrix, out Material[] outMaterials)
        {
            outMaterials = null;
            if (this.mesh == null)
            {
                Debug.LogError("TreeData must have mesh  assigned");
            }
            else
            {
                this.isInPreviewMode = false;
                List<TreeMaterial> materials = new List<TreeMaterial>();
                List<TreeVertex> verts = new List<TreeVertex>();
                List<TreeTriangle> tris = new List<TreeTriangle>();
                List<TreeAOSphere> aoSpheres = new List<TreeAOSphere>();
                int buildFlags = 0;
                if (this.root.enableAmbientOcclusion)
                {
                    buildFlags |= 1;
                }
                if (this.root.enableWelding)
                {
                    buildFlags |= 2;
                }
                this.UpdateMesh(worldToLocalMatrix, materials, verts, tris, aoSpheres, buildFlags, this.root.adaptiveLODQuality, this.root.aoDensity);
                if (verts.Count > 0xfde8)
                {
                    Debug.LogWarning("Tree mesh would exceed maximum vertex limit .. aborting");
                }
                else
                {
                    this.mesh.Clear();
                    if ((verts.Count != 0) && (tris.Count != 0))
                    {
                        this.OptimizeMaterial(materials, verts, tris);
                        Profiler.BeginSample("CopyMeshData");
                        Vector3[] vectorArray = new Vector3[verts.Count];
                        Vector3[] vectorArray2 = new Vector3[verts.Count];
                        Vector2[] vectorArray3 = new Vector2[verts.Count];
                        Vector2[] vectorArray4 = new Vector2[verts.Count];
                        Vector4[] vectorArray5 = new Vector4[verts.Count];
                        Color[] colorArray = new Color[verts.Count];
                        for (int i = 0; i < verts.Count; i++)
                        {
                            vectorArray[i] = verts[i].pos;
                            vectorArray2[i] = verts[i].nor;
                            vectorArray3[i] = verts[i].uv0;
                            vectorArray4[i] = verts[i].uv1;
                            vectorArray5[i] = verts[i].tangent;
                            colorArray[i] = verts[i].color;
                        }
                        this.mesh.vertices = vectorArray;
                        this.mesh.normals = vectorArray2;
                        this.mesh.uv = vectorArray3;
                        this.mesh.uv2 = vectorArray4;
                        this.mesh.tangents = vectorArray5;
                        this.mesh.colors = colorArray;
                        int[] numArray = new int[tris.Count * 3];
                        List<Material> list5 = new List<Material>(2);
                        this.mesh.subMeshCount = 2;
                        for (int j = 0; j < 2; j++)
                        {
                            int index = 0;
                            for (int k = 0; k < tris.Count; k++)
                            {
                                if (tris[k].materialIndex == j)
                                {
                                    numArray[index] = tris[k].v[0];
                                    numArray[index + 1] = tris[k].v[1];
                                    numArray[index + 2] = tris[k].v[2];
                                    index += 3;
                                }
                            }
                            if (index > 0)
                            {
                                int[] triangles = new int[index];
                                for (int m = 0; m < index; m++)
                                {
                                    triangles[m] = numArray[m];
                                }
                                this.mesh.SetTriangles(triangles, list5.Count);
                                if (j == 0)
                                {
                                    list5.Add(this.optimizedSolidMaterial);
                                }
                                else
                                {
                                    list5.Add(this.optimizedCutoutMaterial);
                                }
                            }
                        }
                        outMaterials = list5.ToArray();
                        this.mesh.subMeshCount = list5.Count;
                        Profiler.EndSample();
                        this.mesh.RecalculateBounds();
                    }
                }
            }
        }

        public void UpdateMesh(Matrix4x4 matrix, List<TreeMaterial> materials, List<TreeVertex> verts, List<TreeTriangle> tris, List<TreeAOSphere> aoSpheres, int buildFlags, float adaptiveQuality, float aoDensity)
        {
            int seed = UnityEngine.Random.seed;
            RingLoop.SetNoiseSeed(this.root.seed);
            this.ClearReferences();
            this.ValidateReferences();
            this.root.UpdateSeed();
            this.root.SetRootMatrix(matrix);
            this.root.UpdateDistribution(false, true);
            this.root.UpdateParameters();
            if ((buildFlags & 1) != 0)
            {
                this.root.BuildAOSpheres(aoSpheres);
            }
            this.root.UpdateMesh(materials, verts, tris, aoSpheres, buildFlags, this.root.adaptiveLODQuality, this.root.aoDensity);
            this.ClearReferences();
            UnityEngine.Random.seed = seed;
        }

        public void UpdateSeed(int id)
        {
            TreeGroup group = this.GetGroup(id);
            if (group != null)
            {
                int seed = UnityEngine.Random.seed;
                this.ClearReferences();
                this.ValidateReferences();
                group.UpdateSeed();
                group.UpdateDistribution(true, true);
                this.ClearReferences();
                UnityEngine.Random.seed = seed;
            }
        }

        private void UpdateShadowTexture(Texture2D shadowTexture, int texWidth, int texHeight)
        {
            if (shadowTexture != null)
            {
                string assetPath = AssetDatabase.GetAssetPath(shadowTexture);
                TextureImporter atPath = AssetImporter.GetAtPath(assetPath) as TextureImporter;
                int[] numArray = new int[] { 1, 2, 4, 8, 0x10 };
                int num = Mathf.Max(8, Mathf.ClosestPowerOfTwo(Mathf.Min(texWidth, texHeight) / numArray[this.root.shadowTextureQuality]));
                if (num != atPath.maxTextureSize)
                {
                    atPath.maxTextureSize = num;
                    atPath.mipmapEnabled = true;
                    AssetDatabase.ImportAsset(assetPath);
                }
            }
        }

        private bool UpdateTextures(TextureAtlas atlas, List<TreeMaterial> materials)
        {
            if (!this.root.enableMaterialOptimize)
            {
                return false;
            }
            bool flag = ((((this.optimizedSolidMaterial.GetTexture("_MainTex") != null) && (this.optimizedSolidMaterial.GetTexture("_BumpSpecMap") != null)) && ((this.optimizedSolidMaterial.GetTexture("_TranslucencyMap") != null) && (this.optimizedCutoutMaterial.GetTexture("_MainTex") != null))) && ((this.optimizedCutoutMaterial.GetTexture("_ShadowTex") != null) && (this.optimizedCutoutMaterial.GetTexture("_BumpSpecMap") != null))) && ((bool) this.optimizedCutoutMaterial.GetTexture("_TranslucencyMap"));
            UnityEngine.Object[] objects = new UnityEngine.Object[materials.Count];
            for (int i = 0; i < materials.Count; i++)
            {
                objects[i] = materials[i].material;
            }
            string str = InternalEditorUtility.CalculateHashForObjectsAndDependencies(objects) + atlas.GetHashCode();
            if ((this.materialHash == str) && flag)
            {
                this.UpdateShadowTexture(this.optimizedCutoutMaterial.GetTexture("_ShadowTex") as Texture2D, atlas.atlasWidth, atlas.atlasHeight);
                return false;
            }
            this.materialHash = str;
            int atlasWidth = atlas.atlasWidth;
            int atlasHeight = atlas.atlasHeight;
            int atlasPadding = atlas.atlasPadding;
            Texture2D textured = new Texture2D(atlasWidth, atlasHeight, TextureFormat.ARGB32, true);
            Texture2D textured2 = new Texture2D(atlasWidth, atlasHeight, TextureFormat.RGB24, true);
            Texture2D textured3 = new Texture2D(atlasWidth, atlasHeight, TextureFormat.ARGB32, true);
            Texture2D textured4 = new Texture2D(atlasWidth, atlasHeight, TextureFormat.ARGB32, true);
            textured.name = "diffuse";
            textured2.name = "shadow";
            textured3.name = "normal_specular";
            textured4.name = "translucency_gloss";
            SavedRenderTargetState state = new SavedRenderTargetState();
            EditorUtility.SetTemporarilyAllowIndieRenderTexture(true);
            RenderTexture temp = RenderTexture.GetTemporary(atlasWidth, atlasHeight, 0, RenderTextureFormat.ARGB32);
            Color white = Color.white;
            Color color = new Color(0.03f, 0.5f, 0f, 0.5f);
            Color color3 = new Color(0f, 0f, 0f, 0f);
            Texture2D textured5 = new Texture2D(1, 1);
            textured5.SetPixel(0, 0, white);
            textured5.Apply();
            Texture2D textured6 = new Texture2D(1, 1);
            textured6.SetPixel(0, 0, white);
            textured6.Apply();
            Texture2D textured7 = new Texture2D(1, 1);
            textured7.SetPixel(0, 0, color);
            textured7.Apply();
            Texture2D textured8 = new Texture2D(1, 1);
            textured8.SetPixel(0, 0, color3);
            textured8.Apply();
            Texture2D textured9 = textured8;
            Texture2D textured10 = new Texture2D(1, 1);
            textured10.SetPixel(0, 0, Color.white);
            textured10.Apply();
            Material material = EditorGUIUtility.LoadRequired("Inspectors/TreeCreator/TreeTextureCombinerMaterial.mat") as Material;
            for (int j = 0; j < 4; j++)
            {
                RenderTexture.active = temp;
                GL.LoadPixelMatrix(0f, (float) atlasWidth, 0f, (float) atlasHeight);
                material.SetVector("_TexSize", new Vector4((float) atlasWidth, (float) atlasHeight, 0f, 0f));
                switch (j)
                {
                    case 0:
                        GL.Clear(false, true, color);
                        break;

                    case 1:
                        GL.Clear(false, true, color3);
                        break;

                    case 2:
                        GL.Clear(false, true, color3);
                        break;

                    case 3:
                        GL.Clear(false, true, color3);
                        break;
                }
                for (int k = 0; k < atlas.nodes.Count; k++)
                {
                    TextureAtlas.TextureNode node = atlas.nodes[k];
                    Rect packedRect = node.packedRect;
                    Texture rgbTexture = null;
                    Texture alphaTexture = null;
                    Color diffuseColor = new Color();
                    switch (j)
                    {
                        case 0:
                            rgbTexture = node.normalTexture;
                            alphaTexture = node.shadowOffsetTexture;
                            diffuseColor = new Color(node.shininess, 0f, 0f, 0f);
                            if (rgbTexture == null)
                            {
                                rgbTexture = textured7;
                            }
                            if (alphaTexture == null)
                            {
                                alphaTexture = textured9;
                            }
                            break;

                        case 1:
                            rgbTexture = node.diffuseTexture;
                            diffuseColor = node.diffuseColor;
                            if (rgbTexture == null)
                            {
                                rgbTexture = textured5;
                            }
                            break;

                        case 2:
                            rgbTexture = node.translucencyTexture;
                            alphaTexture = node.glossTexture;
                            if (rgbTexture == null)
                            {
                                rgbTexture = textured10;
                            }
                            if (alphaTexture == null)
                            {
                                alphaTexture = textured8;
                            }
                            break;

                        case 3:
                            alphaTexture = node.diffuseTexture;
                            if (alphaTexture == null)
                            {
                                alphaTexture = textured5;
                            }
                            break;
                    }
                    if (node.tileV)
                    {
                        float x = packedRect.x;
                        float num8 = ((float) atlasPadding) / 2f;
                        for (float m = num8; m > 0f; m--)
                        {
                            Rect rect = new Rect(packedRect);
                            Rect rect3 = new Rect(packedRect);
                            rect.x = x - m;
                            rect3.x = x + m;
                            this.DrawTexture(rect, rgbTexture, alphaTexture, material, diffuseColor, j);
                            this.DrawTexture(rect3, rgbTexture, alphaTexture, material, diffuseColor, j);
                        }
                    }
                    this.DrawTexture(packedRect, rgbTexture, alphaTexture, material, diffuseColor, j);
                }
                switch (j)
                {
                    case 0:
                        textured3.ReadPixels(new Rect(0f, 0f, (float) atlasWidth, (float) atlasHeight), 0, 0);
                        textured3.Apply(true);
                        break;

                    case 1:
                        textured.ReadPixels(new Rect(0f, 0f, (float) atlasWidth, (float) atlasHeight), 0, 0);
                        textured.Apply(true);
                        break;

                    case 2:
                        textured4.ReadPixels(new Rect(0f, 0f, (float) atlasWidth, (float) atlasHeight), 0, 0);
                        textured4.Apply(true);
                        break;

                    case 3:
                        textured2.ReadPixels(new Rect(0f, 0f, (float) atlasWidth, (float) atlasHeight), 0, 0);
                        textured2.Apply(true);
                        break;
                }
            }
            state.Restore();
            this.optimizedSolidMaterial.SetPass(0);
            RenderTexture.ReleaseTemporary(temp);
            UnityEngine.Object.DestroyImmediate(textured5);
            UnityEngine.Object.DestroyImmediate(textured6);
            UnityEngine.Object.DestroyImmediate(textured10);
            UnityEngine.Object.DestroyImmediate(textured8);
            UnityEngine.Object.DestroyImmediate(textured7);
            EditorUtility.SetTemporarilyAllowIndieRenderTexture(false);
            Texture2D[] textures = new Texture2D[] { textured, textured3, textured4, textured2 };
            textures = WriteOptimizedTextures(AssetDatabase.GetAssetPath(this), textures);
            UnityEngine.Object.DestroyImmediate(textured);
            UnityEngine.Object.DestroyImmediate(textured3);
            UnityEngine.Object.DestroyImmediate(textured4);
            UnityEngine.Object.DestroyImmediate(textured2);
            this.optimizedSolidMaterial.SetTexture("_MainTex", textures[0]);
            this.optimizedSolidMaterial.SetTexture("_BumpSpecMap", textures[1]);
            this.optimizedSolidMaterial.SetTexture("_TranslucencyMap", textures[2]);
            this.optimizedCutoutMaterial.SetTexture("_MainTex", textures[0]);
            this.optimizedCutoutMaterial.SetTexture("_BumpSpecMap", textures[1]);
            this.optimizedCutoutMaterial.SetTexture("_TranslucencyMap", textures[2]);
            this.optimizedCutoutMaterial.SetTexture("_ShadowTex", textures[3]);
            this.UpdateShadowTexture(textures[3], atlas.atlasWidth, atlas.atlasHeight);
            return true;
        }

        public void ValidateReferences()
        {
            Profiler.BeginSample("ValidateReferences");
            int groupCount = this.GetGroupCount();
            for (int i = 0; i < groupCount; i++)
            {
                TreeGroup groupAt = this.GetGroupAt(i);
                groupAt.parentGroup = this.GetGroup(groupAt.parentGroupID);
                groupAt.childGroups.Clear();
                groupAt.nodes.Clear();
                for (int k = 0; k < groupAt.childGroupIDs.Length; k++)
                {
                    TreeGroup group = this.GetGroup(groupAt.childGroupIDs[k]);
                    groupAt.childGroups.Add(group);
                }
                for (int m = 0; m < groupAt.nodeIDs.Length; m++)
                {
                    TreeNode item = this.GetNode(groupAt.nodeIDs[m]);
                    groupAt.nodes.Add(item);
                }
            }
            int nodeCount = this.GetNodeCount();
            for (int j = 0; j < nodeCount; j++)
            {
                TreeNode nodeAt = this.GetNodeAt(j);
                nodeAt.parent = this.GetNode(nodeAt.parentID);
                nodeAt.group = this.GetGroup(nodeAt.groupID);
            }
            Profiler.EndSample();
        }

        private static Texture2D[] WriteOptimizedTextures(string treeAssetPath, Texture2D[] textures)
        {
            string[] strArray = new string[textures.Length];
            string path = Path.Combine(Path.GetDirectoryName(treeAssetPath), Path.GetFileNameWithoutExtension(treeAssetPath) + "_Textures");
            Directory.CreateDirectory(path);
            for (int i = 0; i < textures.Length; i++)
            {
                byte[] bytes = textures[i].EncodeToPNG();
                strArray[i] = Path.Combine(path, textures[i].name + ".png");
                File.WriteAllBytes(strArray[i], bytes);
            }
            AssetDatabase.Refresh();
            for (int j = 0; j < textures.Length; j++)
            {
                textures[j] = AssetDatabase.LoadMainAssetAtPath(strArray[j]) as Texture2D;
            }
            return textures;
        }
    }
}

