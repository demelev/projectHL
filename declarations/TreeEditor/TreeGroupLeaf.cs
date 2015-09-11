namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditorInternal;
    using UnityEngine;

    [Serializable]
    public class TreeGroupLeaf : TreeGroup
    {
        private static Mesh cloneMesh;
        private static MeshFilter cloneMeshFilter;
        private static Vector3[] cloneNormals;
        private static Renderer cloneRenderer;
        private static Vector4[] cloneTangents;
        private static Vector2[] cloneUVs;
        private static Vector3[] cloneVerts;
        private static string distributionModeString = LocalizationDatabase.GetLocalizedString("Distribution|Select the way the leaves are distributed along their parent.");
        private static string edgeTurbulenceString = LocalizationDatabase.GetLocalizedString("Edge Turbulence|Defines how much wind turbulence occurs along the edges of the leaves.");
        private static string frequencyString = LocalizationDatabase.GetLocalizedString("Frequency|Adjusts the number of leaves created for each parent branch.");
        public int geometryMode;
        private static string groupSeedString = LocalizationDatabase.GetLocalizedString("Group Seed|The seed for this group of leaves. Modify to vary procedural generation.");
        private static string growthAngleString = LocalizationDatabase.GetLocalizedString("Growth Angle|Defines the initial angle of growth relative to the parent. Use the curve to adjust and the slider to fade the effect in and out.");
        private static string growthScaleString = LocalizationDatabase.GetLocalizedString("Growth Scale|Defines the scale of nodes along the parent node. Use the curve to adjust and the slider to fade the effect in and out.");
        public float horizontalAlign;
        public GameObject instanceMesh;
        private static string mainTurbulenceString = LocalizationDatabase.GetLocalizedString("Main Turbulence|Secondary turbulence effect. For leaves this should usually be kept as a low value.");
        private static string mainWindString = LocalizationDatabase.GetLocalizedString("Main Wind|Primary wind effect. Usually this should be kept as a low value to avoid leaves floating away from the parent branch.");
        public Material materialLeaf;
        public float perpendicularAlign;
        internal static Dictionary<Texture, Vector2[]> s_TextureHulls;
        internal static bool s_TextureHullsDirty;
        public Vector2 size = Vector2.one;
        private static string twirlString = LocalizationDatabase.GetLocalizedString("Twirl|Twirl around the parent branch.");
        private static string whorledStepString = LocalizationDatabase.GetLocalizedString("Whorled Step|Defines how many nodes are in each whorled step when using Whorled distribution. For real plants this is normally a Fibonacci number.");

        public override void BuildAOSpheres(List<TreeAOSphere> aoSpheres)
        {
            if (base.visible)
            {
                float num = 0.75f;
                for (int i = 0; i < base.nodes.Count; i++)
                {
                    TreeNode node = base.nodes[i];
                    if (node.visible)
                    {
                        Vector3 pos = node.matrix.MultiplyPoint(new Vector3(0f, 0f, 0f));
                        float radius = node.scale * num;
                        aoSpheres.Add(new TreeAOSphere(pos, radius, 0.5f));
                    }
                }
            }
            base.BuildAOSpheres(aoSpheres);
        }

        public override bool CanHaveSubGroups()
        {
            return false;
        }

        private static TreeVertex CreateBillboardVertex(TreeNode node, Quaternion billboardRotation, Vector3 normalBase, float normalFix, Vector3 tangentBase, Vector2 uv)
        {
            TreeVertex vertex = new TreeVertex {
                pos = node.matrix.MultiplyPoint(Vector3.zero),
                uv0 = uv
            };
            uv = ((Vector2) (2f * uv)) - Vector2.one;
            vertex.nor = (Vector3) (billboardRotation * new Vector3(uv.x * node.scale, uv.y * node.scale, 0f));
            vertex.nor.z = normalFix;
            Vector3 vector2 = (Vector3) (billboardRotation * new Vector3(uv.x * normalBase.x, uv.y * normalBase.y, normalBase.z));
            Vector3 normalized = vector2.normalized;
            Vector3 vector3 = tangentBase - ((Vector3) (normalized * Vector3.Dot(tangentBase, normalized)));
            vertex.tangent = vector3.normalized;
            vertex.tangent.w = 0f;
            return vertex;
        }

        private Vector2[] GetPlaneHullVertices(Material mat)
        {
            if (mat == null)
            {
                return null;
            }
            if (!mat.HasProperty("_MainTex"))
            {
                return null;
            }
            Texture mainTexture = mat.mainTexture;
            if (mainTexture == null)
            {
                return null;
            }
            if ((s_TextureHulls == null) || s_TextureHullsDirty)
            {
                s_TextureHulls = new Dictionary<Texture, Vector2[]>();
                s_TextureHullsDirty = false;
            }
            if (s_TextureHulls.ContainsKey(mainTexture))
            {
                return s_TextureHulls[mainTexture];
            }
            Vector2[] vectorArray = MeshUtility.ComputeTextureBoundingHull(mainTexture, 4);
            Vector2 vector = vectorArray[1];
            vectorArray[1] = vectorArray[3];
            vectorArray[3] = vector;
            s_TextureHulls.Add(mainTexture, vectorArray);
            return vectorArray;
        }

        internal override bool HasExternalChanges()
        {
            string str;
            if (this.geometryMode == 4)
            {
                UnityEngine.Object[] objects = new UnityEngine.Object[] { this.instanceMesh };
                str = InternalEditorUtility.CalculateHashForObjectsAndDependencies(objects);
            }
            else
            {
                UnityEngine.Object[] objArray2 = new UnityEngine.Object[] { this.materialLeaf };
                str = InternalEditorUtility.CalculateHashForObjectsAndDependencies(objArray2);
            }
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
            else
            {
                TreeGroupRoot parentGroup = base.parentGroup as TreeGroupRoot;
                for (int j = 0; j < base.nodes.Count; j++)
                {
                    Vector3 vector3;
                    TreeNode node2 = base.nodes[j];
                    Vector3 pos = new Vector3();
                    Quaternion rot = new Quaternion();
                    float rad = 0f;
                    float surfaceAngleAtTime = 0f;
                    if (parentGroup != null)
                    {
                        float num5 = node2.offset * base.GetRootSpread();
                        float f = node2.angle * 0.01745329f;
                        pos = new Vector3(Mathf.Cos(f) * num5, -parentGroup.groundOffset, Mathf.Sin(f) * num5);
                        rot = Quaternion.Euler(node2.pitch * -Mathf.Sin(f), 0f, node2.pitch * Mathf.Cos(f)) * Quaternion.Euler(0f, node2.angle, 0f);
                    }
                    else
                    {
                        node2.parent.GetPropertiesAtTime(node2.offset, out pos, out rot, out rad);
                        surfaceAngleAtTime = node2.parent.GetSurfaceAngleAtTime(node2.offset);
                    }
                    Quaternion q = Quaternion.Euler(90f, node2.angle, 0f);
                    Matrix4x4 matrixx = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
                    Matrix4x4 matrixx2 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(node2.pitch + surfaceAngleAtTime, 0f, 0f), Vector3.one);
                    node2.matrix = ((node2.parent.matrix * Matrix4x4.TRS(pos, rot, Vector3.one)) * matrixx) * matrixx2;
                    node2.matrix *= Matrix4x4.TRS(new Vector3(0f, 0f, 0f), node2.rotation, new Vector3(1f, 1f, 1f));
                    if (this.horizontalAlign > 0f)
                    {
                        Vector4 column = node2.matrix.GetColumn(3);
                        Quaternion b = Quaternion.Euler(90f, node2.angle, 0f);
                        Quaternion quaternion4 = Quaternion.Slerp(MathUtils.QuaternionFromMatrix(node2.matrix), b, this.horizontalAlign);
                        node2.matrix = Matrix4x4.TRS(Vector3.zero, quaternion4, Vector3.one);
                        node2.matrix.SetColumn(3, column);
                    }
                    if (this.geometryMode == 4)
                    {
                        vector3 = node2.matrix.MultiplyPoint(new Vector3(0f, rad, 0f));
                        node2.matrix *= Matrix4x4.Scale(new Vector3(node2.scale, node2.scale, node2.scale));
                    }
                    else
                    {
                        vector3 = node2.matrix.MultiplyPoint(new Vector3(0f, rad + node2.scale, 0f));
                    }
                    node2.matrix.m03 = vector3.x;
                    node2.matrix.m13 = vector3.y;
                    node2.matrix.m23 = vector3.z;
                }
            }
            base.UpdateMatrix();
        }

        public override void UpdateMesh(List<TreeMaterial> materials, List<TreeVertex> verts, List<TreeTriangle> tris, List<TreeAOSphere> aoSpheres, int buildFlags, float adaptiveQuality, float aoDensity)
        {
            if (this.geometryMode == 4)
            {
                if (this.instanceMesh != null)
                {
                    cloneMeshFilter = this.instanceMesh.GetComponent<MeshFilter>();
                    if (cloneMeshFilter != null)
                    {
                        cloneMesh = cloneMeshFilter.sharedMesh;
                        if (cloneMesh != null)
                        {
                            Vector3 extents = cloneMesh.bounds.extents;
                            float num = Mathf.Max(extents.x, extents.z) * 0.5f;
                            cloneVerts = cloneMesh.vertices;
                            cloneNormals = cloneMesh.normals;
                            cloneUVs = cloneMesh.uv;
                            cloneTangents = cloneMesh.tangents;
                            for (int j = 0; j < cloneVerts.Length; j++)
                            {
                                cloneVerts[j].x /= num;
                                cloneVerts[j].y /= num;
                                cloneVerts[j].z /= num;
                            }
                        }
                    }
                    if (this.instanceMesh.GetComponent<Renderer>() != null)
                    {
                        Material[] sharedMaterials = this.instanceMesh.GetComponent<Renderer>().sharedMaterials;
                        for (int k = 0; k < sharedMaterials.Length; k++)
                        {
                            TreeGroup.GetMaterialIndex(sharedMaterials[k], materials, false);
                        }
                    }
                }
            }
            else
            {
                TreeGroup.GetMaterialIndex(this.materialLeaf, materials, false);
            }
            for (int i = 0; i < base.nodes.Count; i++)
            {
                this.UpdateNodeMesh(base.nodes[i], materials, verts, tris, aoSpheres, buildFlags, adaptiveQuality, aoDensity);
            }
            cloneMesh = null;
            cloneMeshFilter = null;
            cloneVerts = null;
            cloneNormals = null;
            cloneUVs = null;
            cloneTangents = null;
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
                Profiler.BeginSample("TreeGroupLeaf.UpdateNodeMesh");
                Vector2 vector = base.ComputeWindFactor(node, node.offset);
                if (this.geometryMode == 4)
                {
                    if (cloneMesh == null)
                    {
                        return;
                    }
                    if (cloneVerts == null)
                    {
                        return;
                    }
                    if (cloneNormals == null)
                    {
                        return;
                    }
                    if (cloneTangents == null)
                    {
                        return;
                    }
                    if (cloneUVs == null)
                    {
                        return;
                    }
                    Matrix4x4 localToWorldMatrix = this.instanceMesh.transform.localToWorldMatrix;
                    Matrix4x4 matrixx2 = node.matrix * localToWorldMatrix;
                    int count = verts.Count;
                    float num2 = 5f;
                    for (int i = 0; i < cloneVerts.Length; i++)
                    {
                        TreeVertex item = new TreeVertex {
                            pos = matrixx2.MultiplyPoint(cloneVerts[i]),
                            nor = matrixx2.MultiplyVector(cloneNormals[i]).normalized,
                            uv0 = new Vector2(cloneUVs[i].x, cloneUVs[i].y)
                        };
                        Vector3 normalized = matrixx2.MultiplyVector(new Vector3(cloneTangents[i].x, cloneTangents[i].y, cloneTangents[i].z)).normalized;
                        item.tangent = new Vector4(normalized.x, normalized.y, normalized.z, cloneTangents[i].w);
                        float edgeFactor = (cloneVerts[i].magnitude / num2) * base.animationEdge;
                        item.SetAnimationProperties(vector.x, vector.y, edgeFactor, node.animSeed);
                        if ((buildFlags & 1) != 0)
                        {
                            item.SetAmbientOcclusion(TreeGroup.ComputeAmbientOcclusion(item.pos, item.nor, aoSpheres, aoDensity));
                        }
                        verts.Add(item);
                    }
                    for (int j = 0; j < cloneMesh.subMeshCount; j++)
                    {
                        int num6;
                        int[] triangles = cloneMesh.GetTriangles(j);
                        if ((this.instanceMesh.GetComponent<Renderer>() != null) && (j < this.instanceMesh.GetComponent<Renderer>().sharedMaterials.Length))
                        {
                            num6 = TreeGroup.GetMaterialIndex(this.instanceMesh.GetComponent<Renderer>().sharedMaterials[j], materials, false);
                        }
                        else
                        {
                            num6 = TreeGroup.GetMaterialIndex(null, materials, false);
                        }
                        for (int k = 0; k < triangles.Length; k += 3)
                        {
                            TreeTriangle triangle = new TreeTriangle(num6, triangles[k] + count, triangles[k + 1] + count, triangles[k + 2] + count);
                            tris.Add(triangle);
                        }
                    }
                }
                else if (this.geometryMode == 3)
                {
                    Vector3 eulerAngles = node.rotation.eulerAngles;
                    eulerAngles.z = eulerAngles.x * 2f;
                    eulerAngles.x = 0f;
                    eulerAngles.y = 0f;
                    Quaternion billboardRotation = Quaternion.Euler(eulerAngles);
                    Vector3 normalBase = new Vector3(TreeGroup.GenerateBendBillboardNormalFactor, TreeGroup.GenerateBendBillboardNormalFactor, 1f);
                    Vector3 tangentBase = (Vector3) (billboardRotation * new Vector3(1f, 0f, 0f));
                    float normalFix = node.scale / (TreeGroup.GenerateBendBillboardNormalFactor * TreeGroup.GenerateBendBillboardNormalFactor);
                    TreeVertex vertex2 = CreateBillboardVertex(node, billboardRotation, normalBase, normalFix, tangentBase, new Vector2(0f, 1f));
                    TreeVertex vertex3 = CreateBillboardVertex(node, billboardRotation, normalBase, normalFix, tangentBase, new Vector2(0f, 0f));
                    TreeVertex vertex4 = CreateBillboardVertex(node, billboardRotation, normalBase, normalFix, tangentBase, new Vector2(1f, 0f));
                    TreeVertex vertex5 = CreateBillboardVertex(node, billboardRotation, normalBase, normalFix, tangentBase, new Vector2(1f, 1f));
                    vertex2.SetAnimationProperties(vector.x, vector.y, base.animationEdge, node.animSeed);
                    vertex3.SetAnimationProperties(vector.x, vector.y, base.animationEdge, node.animSeed);
                    vertex4.SetAnimationProperties(vector.x, vector.y, base.animationEdge, node.animSeed);
                    vertex5.SetAnimationProperties(vector.x, vector.y, base.animationEdge, node.animSeed);
                    if ((buildFlags & 1) != 0)
                    {
                        Vector3 vector6 = (Vector3) (Vector3.right * node.scale);
                        Vector3 vector7 = (Vector3) (Vector3.forward * node.scale);
                        float ao = 0f;
                        ao = TreeGroup.ComputeAmbientOcclusion(vertex2.pos + vector6, Vector3.right, aoSpheres, aoDensity) + TreeGroup.ComputeAmbientOcclusion(vertex2.pos - vector6, -Vector3.right, aoSpheres, aoDensity);
                        ao += TreeGroup.ComputeAmbientOcclusion(vertex2.pos + vector7, Vector3.forward, aoSpheres, aoDensity);
                        ao += TreeGroup.ComputeAmbientOcclusion(vertex2.pos - vector7, -Vector3.forward, aoSpheres, aoDensity);
                        ao /= 4f;
                        vertex2.SetAmbientOcclusion(ao);
                        vertex3.SetAmbientOcclusion(ao);
                        vertex4.SetAmbientOcclusion(ao);
                        vertex5.SetAmbientOcclusion(ao);
                    }
                    int num10 = verts.Count;
                    verts.Add(vertex2);
                    verts.Add(vertex3);
                    verts.Add(vertex4);
                    verts.Add(vertex5);
                    int material = TreeGroup.GetMaterialIndex(this.materialLeaf, materials, false);
                    tris.Add(new TreeTriangle(material, num10, num10 + 2, num10 + 1, true));
                    tris.Add(new TreeTriangle(material, num10, num10 + 3, num10 + 2, true));
                }
                else
                {
                    int num12 = 0;
                    switch (this.geometryMode)
                    {
                        case 0:
                            num12 = 1;
                            break;

                        case 1:
                            num12 = 2;
                            break;

                        case 2:
                            num12 = 3;
                            break;
                    }
                    int num13 = TreeGroup.GetMaterialIndex(this.materialLeaf, materials, false);
                    Vector2[] vectorArray = new Vector2[] { new Vector2(0f, 1f), new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(1f, 1f) };
                    Vector2[] planeHullVertices = this.GetPlaneHullVertices(this.materialLeaf);
                    if (planeHullVertices == null)
                    {
                        planeHullVertices = vectorArray;
                    }
                    float scale = node.scale;
                    Vector3[] vectorArray3 = new Vector3[] { new Vector3(-scale, 0f, -scale), new Vector3(-scale, 0f, scale), new Vector3(scale, 0f, scale), new Vector3(scale, 0f, -scale) };
                    Vector3 vector8 = new Vector3(TreeGroup.GenerateBendNormalFactor, 1f - TreeGroup.GenerateBendNormalFactor, TreeGroup.GenerateBendNormalFactor);
                    Vector3[] vectorArray6 = new Vector3[4];
                    Vector3 vector12 = new Vector3(-vector8.x, vector8.y, -vector8.z);
                    vectorArray6[0] = vector12.normalized;
                    Vector3 vector13 = new Vector3(-vector8.x, vector8.y, 0f);
                    vectorArray6[1] = vector13.normalized;
                    Vector3 vector14 = new Vector3(vector8.x, vector8.y, 0f);
                    vectorArray6[2] = vector14.normalized;
                    Vector3 vector15 = new Vector3(vector8.x, vector8.y, -vector8.z);
                    vectorArray6[3] = vector15.normalized;
                    Vector3[] vectorArray4 = vectorArray6;
                    for (int m = 0; m < num12; m++)
                    {
                        Quaternion rot = Quaternion.Euler(new Vector3(90f, 0f, 0f));
                        switch (m)
                        {
                            case 1:
                                rot = Quaternion.Euler(new Vector3(90f, 90f, 0f));
                                break;

                            case 2:
                                rot = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                                break;
                        }
                        TreeVertex[] tv = new TreeVertex[] { new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex() };
                        for (int n = 0; n < 4; n++)
                        {
                            tv[n].pos = node.matrix.MultiplyPoint((Vector3) (rot * vectorArray3[n]));
                            tv[n].nor = node.matrix.MultiplyVector((Vector3) (rot * vectorArray4[n]));
                            tv[n].tangent = TreeGroup.CreateTangent(node, rot, tv[n].nor);
                            tv[n].uv0 = planeHullVertices[n];
                            tv[n].SetAnimationProperties(vector.x, vector.y, base.animationEdge, node.animSeed);
                            if ((buildFlags & 1) != 0)
                            {
                                tv[n].SetAmbientOcclusion(TreeGroup.ComputeAmbientOcclusion(tv[n].pos, tv[n].nor, aoSpheres, aoDensity));
                            }
                        }
                        for (int num17 = 0; num17 < 4; num17++)
                        {
                            tv[num17 + 4].Lerp4(tv, planeHullVertices[num17]);
                            tv[num17 + 4].uv0 = tv[num17].uv0;
                            tv[num17 + 4].uv1 = tv[num17].uv1;
                            tv[num17 + 4].flag = tv[num17].flag;
                        }
                        int num18 = verts.Count;
                        for (int num19 = 0; num19 < 4; num19++)
                        {
                            verts.Add(tv[num19 + 4]);
                        }
                        tris.Add(new TreeTriangle(num13, num18, num18 + 1, num18 + 2));
                        tris.Add(new TreeTriangle(num13, num18, num18 + 2, num18 + 3));
                        Vector3 inNormal = node.matrix.MultiplyVector((Vector3) (rot * new Vector3(0f, 1f, 0f)));
                        if (TreeGroup.GenerateDoubleSidedGeometry)
                        {
                            TreeVertex[] vertexArray2 = new TreeVertex[] { new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex(), new TreeVertex() };
                            for (int num20 = 0; num20 < 4; num20++)
                            {
                                vertexArray2[num20].pos = tv[num20].pos;
                                vertexArray2[num20].nor = Vector3.Reflect(tv[num20].nor, inNormal);
                                vertexArray2[num20].tangent = Vector3.Reflect((Vector3) tv[num20].tangent, inNormal);
                                vertexArray2[num20].tangent.w = -1f;
                                vertexArray2[num20].uv0 = tv[num20].uv0;
                                vertexArray2[num20].SetAnimationProperties(vector.x, vector.y, base.animationEdge, node.animSeed);
                                if ((buildFlags & 1) != 0)
                                {
                                    vertexArray2[num20].SetAmbientOcclusion(TreeGroup.ComputeAmbientOcclusion(vertexArray2[num20].pos, vertexArray2[num20].nor, aoSpheres, aoDensity));
                                }
                            }
                            for (int num21 = 0; num21 < 4; num21++)
                            {
                                vertexArray2[num21 + 4].Lerp4(vertexArray2, planeHullVertices[num21]);
                                vertexArray2[num21 + 4].uv0 = vertexArray2[num21].uv0;
                                vertexArray2[num21 + 4].uv1 = vertexArray2[num21].uv1;
                                vertexArray2[num21 + 4].flag = vertexArray2[num21].flag;
                            }
                            int num22 = verts.Count;
                            for (int num23 = 0; num23 < 4; num23++)
                            {
                                verts.Add(vertexArray2[num23 + 4]);
                            }
                            tris.Add(new TreeTriangle(num13, num22, num22 + 2, num22 + 1));
                            tris.Add(new TreeTriangle(num13, num22, num22 + 3, num22 + 2));
                        }
                    }
                }
                node.triEnd = tris.Count;
                node.vertEnd = verts.Count;
                Profiler.EndSample();
            }
        }

        public override void UpdateParameters()
        {
            if (base.lockFlags == 0)
            {
                for (int i = 0; i < base.nodes.Count; i++)
                {
                    TreeNode node = base.nodes[i];
                    UnityEngine.Random.seed = node.seed;
                    for (int j = 0; j < 5; j++)
                    {
                        node.scale *= this.size.x + ((this.size.y - this.size.x) * UnityEngine.Random.value);
                    }
                    for (int k = 0; k < 5; k++)
                    {
                        float x = ((UnityEngine.Random.value - 0.5f) * 180f) * (1f - this.perpendicularAlign);
                        float y = ((UnityEngine.Random.value - 0.5f) * 180f) * (1f - this.perpendicularAlign);
                        float z = 0f;
                        node.rotation = Quaternion.Euler(x, y, z);
                    }
                }
            }
            this.UpdateMatrix();
            base.UpdateParameters();
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
            PLANE,
            CROSS,
            TRI_CROSS,
            BILLBOARD,
            MESH
        }
    }
}

