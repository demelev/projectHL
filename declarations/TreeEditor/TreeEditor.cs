namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEditor;
    using UnityEditor.AnimatedValues;
    using UnityEngine;
    using UnityEngine.Events;

    [CustomEditor(typeof(Tree))]
    internal class TreeEditor : Editor
    {
        private static string alphaCutoffString = LocalizationDatabase.GetLocalizedString("Alpha Cutoff|Alpha values from the base texture smaller than the alpha cutoff are clipped creating a cutout.");
        private static string ambientOcclusionString = LocalizationDatabase.GetLocalizedString("Ambient Occlusion|Toggles ambient occlusion on or off.");
        private static string aoDensityString = LocalizationDatabase.GetLocalizedString("AO Density|Adjusts the density of ambient occlusion.");
        private static string areaSpreadString = LocalizationDatabase.GetLocalizedString("Area Spread|Adjusts the spread of trunk nodes. Has an effect only if you have more than one trunk.");
        private static string branchMaterialString = LocalizationDatabase.GetLocalizedString("Branch Material|The primary material for the branches.");
        private static string breakChanceString = LocalizationDatabase.GetLocalizedString("Break Chance|Chance of a branch breaking, i.e. 0 = no branches are broken, 0.5 = half of the branches are broken, 1.0 = all the branches are broken.");
        private static string breakLocationString = LocalizationDatabase.GetLocalizedString("Break Location|This range defines where the branches will be broken. Relative to the length of the branch.");
        private static string breakMaterialString = LocalizationDatabase.GetLocalizedString("Break Material|Material for capping broken branches.");
        private static string capSmoothingString = LocalizationDatabase.GetLocalizedString("Cap Smoothing|Defines the roundness of the cap/tip of the branches. Useful for cacti.");
        private static string[] categoryNamesOptions = new string[] { LocalizationDatabase.GetLocalizedString("Branch Only|"), LocalizationDatabase.GetLocalizedString("Branch + Fronds|"), LocalizationDatabase.GetLocalizedString("Fronds Only|") };
        private static string createNewTreeString = LocalizationDatabase.GetLocalizedString("Create New Tree");
        private static string createWindZoneString = LocalizationDatabase.GetLocalizedString("Create Wind Zone");
        private static string crinklynessString = LocalizationDatabase.GetLocalizedString("Crinkliness|Adjusts how crinkly/crooked the branches are, use the curve to fine-tune.");
        private Vector2 dragClickPos;
        private HierachyNode dragNode;
        private HierachyNode dropNode;
        private static string flareHeightString = LocalizationDatabase.GetLocalizedString("Flare Height|Defines how far up the trunk the flares start.");
        private static string flareNoiseString = LocalizationDatabase.GetLocalizedString("Flare Noise|Defines the noise of the flares, lower values will give a more wobbly look, while higher values gives a more stochastic look.");
        private static string flareRadiusString = LocalizationDatabase.GetLocalizedString("Flare Radius|The radius of the flares, this is added to the main radius, so a zero value means no flares.");
        private static string frondCountString = LocalizationDatabase.GetLocalizedString("Frond Count|Defines the number of fronds per branch. Fronds are always evenly spaced around the branch.");
        private static string frondCreaseString = LocalizationDatabase.GetLocalizedString("Frond Crease|Adjust to crease / fold the fronds.");
        private static string frondMaterialString = LocalizationDatabase.GetLocalizedString("Frond Material|Material for the fronds.");
        private static string frondRangeString = LocalizationDatabase.GetLocalizedString("Frond Range|Defines the starting and ending point of the fronds.");
        private static string frondRotationString = LocalizationDatabase.GetLocalizedString("Frond Rotation|Defines rotation around the parent branch.");
        private static string frondWidthString = LocalizationDatabase.GetLocalizedString("Frond Width|The width of the fronds, use the curve to adjust the specific shape along the length of the branch.");
        private static string geometryModeLeafString = LocalizationDatabase.GetLocalizedString("Geometry Mode|The type of geometry created. You can use a custom mesh, by selecting the Mesh option, ideal for flowers, fruits, etc.");
        private static string[] geometryModeOptions = new string[] { LocalizationDatabase.GetLocalizedString("Plane|"), LocalizationDatabase.GetLocalizedString("Cross|"), LocalizationDatabase.GetLocalizedString("TriCross|"), LocalizationDatabase.GetLocalizedString("Billboard|"), LocalizationDatabase.GetLocalizedString("Mesh|") };
        private static string geometryModeString = LocalizationDatabase.GetLocalizedString("Geometry Mode|Type of geometry for this branch group.");
        private static string groundOffsetString = LocalizationDatabase.GetLocalizedString("Ground Offset|Adjusts the offset of trunk nodes on Y axis.");
        private Rect hierachyDisplayRect = new Rect(0f, 0f, 0f, 0f);
        private Vector2 hierachyNodeSize = new Vector2(40f, 48f);
        private Vector2 hierachyNodeSpace = new Vector2(16f, 16f);
        private Rect hierachyRect = new Rect(0f, 0f, 0f, 0f);
        private Vector2 hierachyScroll = new Vector2();
        private Vector2 hierachySpread = new Vector2(32f, 32f);
        private Rect hierachyView = new Rect(0f, 0f, 0f, 0f);
        private static string horizontalAlignString = LocalizationDatabase.GetLocalizedString("Horizontal Align|Adjusts whether the leaves are aligned horizontally.");
        private static string[] inspectorDistributionPopupOptions = new string[] { LocalizationDatabase.GetLocalizedString("Random|"), LocalizationDatabase.GetLocalizedString("Alternate|"), LocalizationDatabase.GetLocalizedString("Opposite|"), LocalizationDatabase.GetLocalizedString("Whorled|") };
        private bool isDragging;
        private const float kCurveSpace = 50f;
        private const float kIndentSpace = 16f;
        private const float kSectionSpace = 10f;
        private static string[] leafMaterialOptions = new string[] { LocalizationDatabase.GetLocalizedString("Full Res|"), LocalizationDatabase.GetLocalizedString("Half Res|"), LocalizationDatabase.GetLocalizedString("Quarter Res|"), LocalizationDatabase.GetLocalizedString("One-8th Res|"), LocalizationDatabase.GetLocalizedString("One-16th Res|") };
        private static string lengthString = LocalizationDatabase.GetLocalizedString("Length|Adjusts the length of the branches.");
        private static string lodMultiplierString = LocalizationDatabase.GetLocalizedString("LOD Multiplier|Adjusts the quality of this group relative to tree's LOD Quality, so that it is of either higher or lower quality than the rest of the tree.");
        private static string lodQualityString = LocalizationDatabase.GetLocalizedString("LOD Quality|Defines the level-of-detail for the entire tree. A low value will make the tree less complex, a high value will make the tree more complex. Check the statistics in the hierarchy view to see the current complexity of the mesh.");
        private readonly Rect m_CurveRangesA = new Rect(0f, 0f, 1f, 1f);
        private readonly Rect m_CurveRangesB = new Rect(0f, -1f, 1f, 2f);
        private Quaternion m_GlobalToolRotation = Quaternion.identity;
        private Vector3 m_LockedWorldPos = Vector3.zero;
        private readonly AnimBool[] m_SectionAnimators = new AnimBool[6];
        private bool m_SectionHasCurves = true;
        private Matrix4x4 m_StartMatrix = Matrix4x4.identity;
        private Quaternion m_StartPointRotation = Quaternion.identity;
        private bool m_StartPointRotationDirty;
        private TreeSpline m_TempSpline;
        private readonly TreeEditorHelper m_TreeEditorHelper = new TreeEditorHelper();
        private bool m_WantCompleteUpdate;
        private bool m_WantedCompleteUpdateInPreviousFrame;
        private static string materialLeafString = LocalizationDatabase.GetLocalizedString("Material|Material used for the leaves.");
        private static string meshString = LocalizationDatabase.GetLocalizedString("Mesh|Mesh used for the leaves.");
        private static string noiseScaleUString = LocalizationDatabase.GetLocalizedString("Noise Scale U|Scale of the noise around the branch, lower values will give a more wobbly look, while higher values gives a more stochastic look.");
        private static string noiseScaleVString = LocalizationDatabase.GetLocalizedString("Noise Scale V|Scale of the noise along the branch, lower values will give a more wobbly look, while higher values gives a more stochastic look.");
        private static string noiseString = LocalizationDatabase.GetLocalizedString("Noise|Overall noise factor, use the curve to fine-tune.");
        private static string perpendicularAlignString = LocalizationDatabase.GetLocalizedString("Perpendicular Align|Adjusts whether the leaves are aligned perpendicular to the parent branch.");
        private static string radiusString = LocalizationDatabase.GetLocalizedString("Radius|Adjusts the radius of the branches, use the curve to fine-tune the radius along the length of the branches.");
        private static string relativeLengthString = LocalizationDatabase.GetLocalizedString("Relative Length|Determines whether the radius of a branch is affected by its length.");
        private static TreeGroupRoot s_CopyPasteGroup;
        private static float s_CutoutMaterialHashBeforeUndo;
        private static EditMode s_EditMode = EditMode.MoveNode;
        private static readonly Color s_GroupColor = new Color(1f, 0f, 1f, 1f);
        private static readonly Color s_NormalColor = new Color(1f, 1f, 0f, 1f);
        private static string s_SavedSourceMaterialsHash;
        private static TreeGroup s_SelectedGroup;
        private static TreeNode s_SelectedNode;
        private static int s_SelectedPoint = -1;
        private static int s_ShowCategory = -1;
        private static Vector3 s_StartPosition;
        private static string seekSunString = LocalizationDatabase.GetLocalizedString("Seek Sun|Use the curve to adjust how the branches are bent upwards/downwards and the slider to change the scale.");
        private static string shadowCasterResString = LocalizationDatabase.GetLocalizedString("Shadow Caster Res.|Defines the resolution of the texture atlas containing alpha values from source diffuse textures. The atlas is used when the leaves are rendered as shadow casters. Using lower resolution might increase performance.");
        private static string shadowOffsetString = LocalizationDatabase.GetLocalizedString("Shadow Offset|Scales the values from the Shadow Offset texture set in the source material. It is used to offset the position of the leaves when collecting the shadows, so that the leaves appear as if they were not placed on one quad. It's especially important for billboarded leaves and they should have brighter values in the center of the texture and darker ones at the border. Start out with a black texture and add different shades of gray per leaf.");
        private static string shadowStrengthString = LocalizationDatabase.GetLocalizedString("Shadow Strength|Makes the shadows on the leaves less harsh. Since it scales all the shadowing that the leaves receive, it should be used with care for trees that are e.g. in a shadow of a mountain.");
        private static string sizeString = LocalizationDatabase.GetLocalizedString("Size|Adjusts the size of the leaves, use the range to adjust the minimum and the maximum size.");
        private static string spreadBottomString = LocalizationDatabase.GetLocalizedString("Spread Bottom|Weld's spread factor on the bottom-side of the branch, relative to it's parent branch. Zero means no spread.");
        private static string spreadTopString = LocalizationDatabase.GetLocalizedString("Spread Top|Weld's spread factor on the top-side of the branch, relative to it's parent branch. Zero means no spread.");
        public static Styles styles;
        private static string[] toolbarContentStringsBranch = new string[] { LocalizationDatabase.GetLocalizedString("Move Branch|Select a branch spline point and drag to move it."), LocalizationDatabase.GetLocalizedString("Rotate Branch|Select a branch spline point and drag to rotate it."), LocalizationDatabase.GetLocalizedString("Free Hand|Click on a branch spline node and drag to draw a new shape.") };
        private static string[] toolbarContentStringsLeaf = new string[] { LocalizationDatabase.GetLocalizedString("Move Leaf|Select a leaf spline point and drag to move it."), LocalizationDatabase.GetLocalizedString("Rotate Leaf|Select a leaf spline point and drag to rotate it.") };
        private static string[] toolbarIconStringsBranch = new string[] { "TreeEditor.BranchTranslate", "TreeEditor.BranchRotate", "TreeEditor.BranchFreeHand" };
        private static string[] toolbarIconStringsLeaf = new string[] { "TreeEditor.LeafTranslate", "TreeEditor.LeafRotate" };
        private static string translucencyColorString = LocalizationDatabase.GetLocalizedString("Translucency Color|The color that will be multiplied in when the leaves are backlit.");
        private static string transViewDepString = LocalizationDatabase.GetLocalizedString("Trans. View Dep.|Translucency view dependency. Fully view dependent translucency is relative to the angle between the view direction and the light direction. View independent is relative to the angle between the leaf's normal vector and the light direction.");
        private static string treeSeedString = LocalizationDatabase.GetLocalizedString("Tree Seed|The global seed that affects the entire tree. Use it to randomize your tree, while keeping the general structure of it.");
        private static string weldLengthString = LocalizationDatabase.GetLocalizedString("Weld Length|Defines how far up the branch the weld spread starts.");

        private static void AssignMaterials(Renderer renderer, Material[] materials, bool applyToPrefab)
        {
            if (renderer != null)
            {
                if (materials == null)
                {
                    materials = new Material[0];
                }
                if (applyToPrefab)
                {
                    Renderer prefabParent = PrefabUtility.GetPrefabParent(renderer) as Renderer;
                    if (prefabParent != null)
                    {
                        prefabParent.sharedMaterials = materials;
                        SerializedObject obj2 = new SerializedObject(renderer);
                        obj2.FindProperty("m_Materials").prefabOverride = false;
                        obj2.ApplyModifiedProperties();
                    }
                }
                else
                {
                    renderer.sharedMaterials = materials;
                }
            }
        }

        private static void BeginSettingsSection(int nr, GUIContent[] names)
        {
            GUILayout.Space(5f);
            GUILayout.Label(names[nr].text, EditorStyles.boldLabel, new GUILayoutOption[0]);
        }

        private void BuildHierachyNodes(TreeData treeData, List<HierachyNode> nodes, TreeGroup group, int depth)
        {
            HierachyNode item = new HierachyNode {
                group = group,
                pos = new Vector3(0f, depth * this.hierachySpread.y, 0f)
            };
            nodes.Add(item);
            for (int i = 0; i < group.childGroupIDs.Length; i++)
            {
                TreeGroup group2 = treeData.GetGroup(group.childGroupIDs[i]);
                this.BuildHierachyNodes(treeData, nodes, group2, depth - 1);
            }
        }

        private static GUIContent[] BuildToolbarContent(string[] iconStrings, string[] contentStrings, int selection)
        {
            GUIContent[] contentArray = new GUIContent[contentStrings.Length];
            for (int i = 0; i < contentStrings.Length; i++)
            {
                string str = (selection != i) ? string.Empty : " On";
                string tooltip = TreeEditorHelper.ExtractLabel(TreeEditorHelper.GetUIString(contentStrings[i]));
                contentArray[i] = EditorGUIUtility.IconContent(iconStrings[i] + str, tooltip);
            }
            return contentArray;
        }

        private Bounds CalcBounds(TreeData treeData, Matrix4x4 objMatrix, TreeNode node)
        {
            Matrix4x4 matrixx = objMatrix * node.matrix;
            if (((treeData.GetGroup(node.groupID).GetType() == typeof(TreeGroupBranch)) && (node.spline != null)) && (node.spline.nodes.Length > 0))
            {
                Bounds bounds = new Bounds(matrixx.MultiplyPoint(node.spline.nodes[0].point), Vector3.zero);
                for (int i = 1; i < node.spline.nodes.Length; i++)
                {
                    bounds.Encapsulate(matrixx.MultiplyPoint(node.spline.nodes[i].point));
                }
                return bounds;
            }
            return new Bounds(matrixx.MultiplyPoint(Vector3.zero), Vector3.zero);
        }

        private static GameObject CreateDefaultWindZone()
        {
            System.Type[] components = new System.Type[] { typeof(WindZone) };
            GameObject objectToUndo = new GameObject("WindZone", components);
            Undo.RegisterCreatedObjectUndo(objectToUndo, createWindZoneString);
            return objectToUndo;
        }

        [UnityEditor.MenuItem("GameObject/3D Object/Tree", false, 0xbb9)]
        private static void CreateNewTree(MenuCommand menuCommand)
        {
            Material[] materialArray;
            Mesh objectToAdd = new Mesh {
                name = "Mesh"
            };
            Material material = new Material(TreeEditorHelper.DefaultOptimizedBarkShader) {
                name = "Optimized Bark Material",
                hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector
            };
            Material material2 = new Material(TreeEditorHelper.DefaultOptimizedLeafShader) {
                name = "Optimized Leaf Material",
                hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector
            };
            System.Type[] components = new System.Type[] { typeof(Tree), typeof(MeshFilter), typeof(MeshRenderer) };
            GameObject go = new GameObject("OptimizedTree", components);
            go.GetComponent<MeshFilter>().sharedMesh = objectToAdd;
            string path = "Assets/Tree.prefab";
            UnityEngine.Object assetObject = PrefabUtility.CreateEmptyPrefab(AssetDatabase.GenerateUniqueAssetPath(path));
            AssetDatabase.AddObjectToAsset(objectToAdd, assetObject);
            AssetDatabase.AddObjectToAsset(material, assetObject);
            AssetDatabase.AddObjectToAsset(material2, assetObject);
            TreeData data = ScriptableObject.CreateInstance<TreeData>();
            data.name = "Tree Data";
            data.Initialize();
            data.optimizedSolidMaterial = material;
            data.optimizedCutoutMaterial = material2;
            data.mesh = objectToAdd;
            go.GetComponent<Tree>().data = data;
            AssetDatabase.AddObjectToAsset(data, assetObject);
            GameObject target = PrefabUtility.ReplacePrefab(go, assetObject, ReplacePrefabOptions.Default);
            UnityEngine.Object.DestroyImmediate(go, false);
            GameObject child = PrefabUtility.InstantiatePrefab(target) as GameObject;
            GameObjectUtility.SetParentAndAlign(child, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(child, createNewTreeString);
            data.UpdateMesh(child.transform.worldToLocalMatrix, out materialArray);
            AssignMaterials(child.GetComponent<Renderer>(), materialArray, true);
            Selection.activeObject = child;
        }

        [UnityEditor.MenuItem("GameObject/3D Object/Wind Zone", false, 0xbba)]
        private static void CreateWindZone(MenuCommand menuCommand)
        {
            GameObject child = CreateDefaultWindZone();
            GameObjectUtility.SetParentAndAlign(child, menuCommand.context as GameObject);
            Selection.activeObject = child;
        }

        private void DeleteSelected(TreeData treeData)
        {
            this.UndoStoreSelected(EditMode.Delete);
            if (s_SelectedNode != null)
            {
                if (s_SelectedPoint >= 1)
                {
                    if (s_SelectedNode.spline.nodes.Length > 2)
                    {
                        if (s_SelectedGroup.lockFlags == 0)
                        {
                            s_SelectedGroup.Lock();
                        }
                        s_SelectedNode.spline.RemoveNode(s_SelectedPoint);
                        s_SelectedPoint = Mathf.Max(s_SelectedPoint - 1, 0);
                    }
                }
                else
                {
                    if ((s_SelectedGroup != null) && (s_SelectedGroup.nodeIDs.Length == 1))
                    {
                        s_SelectedNode = null;
                        this.DeleteSelected(treeData);
                        return;
                    }
                    treeData.DeleteNode(s_SelectedNode);
                    s_SelectedGroup.Lock();
                    this.SelectGroup(s_SelectedGroup);
                }
            }
            else if (s_SelectedGroup != null)
            {
                TreeGroup group = treeData.GetGroup(s_SelectedGroup.parentGroupID);
                if (group == null)
                {
                    return;
                }
                treeData.DeleteGroup(s_SelectedGroup);
                this.SelectGroup(group);
            }
            this.m_WantCompleteUpdate = true;
            UpdateMesh(this.target as Tree);
            this.m_WantCompleteUpdate = false;
        }

        private Vector3 DoPositionHandle(Vector3 position, Quaternion rotation, bool hide)
        {
            Color color = Handles.color;
            Handles.color = Handles.xAxisColor;
            position = Handles.Slider(position, (Vector3) (rotation * Vector3.right));
            Handles.color = Handles.yAxisColor;
            position = Handles.Slider(position, (Vector3) (rotation * Vector3.up));
            Handles.color = Handles.zAxisColor;
            position = Handles.Slider(position, (Vector3) (rotation * Vector3.forward));
            Handles.color = color;
            return position;
        }

        private void DrawHierachy(TreeData treeData, Renderer renderer, Rect sizeRect)
        {
            if (styles == null)
            {
                styles = new Styles();
            }
            this.hierachySpread = this.hierachyNodeSize + this.hierachyNodeSpace;
            this.hierachyView = sizeRect;
            Event event2 = new Event(Event.current);
            List<HierachyNode> nodes = new List<HierachyNode>();
            this.BuildHierachyNodes(treeData, nodes, treeData.root, 0);
            this.LayoutHierachyNodes(nodes, sizeRect);
            float num = 16f;
            Vector2 zero = Vector2.zero;
            if (sizeRect.width < this.hierachyRect.width)
            {
                zero.y -= 16f;
            }
            bool changed = GUI.changed;
            this.hierachyDisplayRect = GUILayoutUtility.GetRect(sizeRect.width, this.hierachyRect.height + num);
            this.hierachyDisplayRect.width = sizeRect.width;
            GUI.Box(this.hierachyDisplayRect, GUIContent.none, styles.nodeBackground);
            this.hierachyScroll = GUI.BeginScrollView(this.hierachyDisplayRect, this.hierachyScroll, this.hierachyRect, false, false);
            GUI.changed = changed;
            this.HandleDragHierachyNodes(treeData, nodes);
            this.DrawHierachyNodes(treeData, nodes, treeData.root, (Vector2) (zero / 2f), 1f, 1f);
            if ((this.dragNode != null) && this.isDragging)
            {
                Vector2 vector2 = Event.current.mousePosition - this.dragClickPos;
                this.DrawHierachyNodes(treeData, nodes, this.dragNode.group, vector2 + ((Vector2) (zero / 2f)), 0.5f, 0.5f);
            }
            GUI.EndScrollView();
            MeshFilter component = renderer.GetComponent<MeshFilter>();
            if (((component != null) && (component.sharedMesh != null)) && (renderer != null))
            {
                int length = component.sharedMesh.vertices.Length;
                int num3 = component.sharedMesh.triangles.Length / 3;
                int num4 = renderer.sharedMaterials.Length;
                Rect position = new Rect((this.hierachyDisplayRect.xMax - 80f) - 4f, ((this.hierachyDisplayRect.yMax + zero.y) - 40f) - 4f, 80f, 40f);
                string text = TreeEditorHelper.GetGUIContent("Hierachy Stats").text.Replace("[v]", length.ToString()).Replace("[t]", num3.ToString()).Replace("[m]", num4.ToString()).Replace(" / ", "\n");
                GUI.Label(position, text, EditorStyles.helpBox);
            }
            if ((event2.type == EventType.ScrollWheel) && (Event.current.type == EventType.Used))
            {
                Event.current = event2;
            }
        }

        private void DrawHierachyNodes(TreeData treeData, List<HierachyNode> nodes, TreeGroup group, Vector2 offset, float alpha, float fade)
        {
            if (((this.dragNode != null) && this.isDragging) && (this.dragNode.group == group))
            {
                alpha = 0.5f;
                fade = 0.75f;
            }
            Vector3 vector = new Vector3(0f, this.hierachyNodeSize.y * 0.5f, 0f);
            Vector3 vector2 = new Vector3(offset.x, offset.y);
            Handles.color = new Color(0f, 0f, 0f, 0.5f * alpha);
            if (EditorGUIUtility.isProSkin)
            {
                Handles.color = new Color(0.4f, 0.4f, 0.4f, 0.5f * alpha);
            }
            HierachyNode node = null;
            for (int i = 0; i < nodes.Count; i++)
            {
                if (group == nodes[i].group)
                {
                    node = nodes[i];
                    break;
                }
            }
            if (node != null)
            {
                for (int j = 0; j < group.childGroupIDs.Length; j++)
                {
                    TreeGroup group2 = treeData.GetGroup(group.childGroupIDs[j]);
                    for (int m = 0; m < nodes.Count; m++)
                    {
                        if (nodes[m].group == group2)
                        {
                            Handles.DrawLine((node.pos + vector2) - vector, (nodes[m].pos + vector2) + vector);
                        }
                    }
                }
                Rect position = node.rect;
                position.x += offset.x;
                position.y += offset.y;
                int index = 0;
                if (node == this.dropNode)
                {
                    index = 1;
                }
                else if (s_SelectedGroup == node.group)
                {
                    if (s_SelectedNode != null)
                    {
                        index = 1;
                    }
                    else
                    {
                        index = 1;
                    }
                }
                GUI.backgroundColor = new Color(1f, 1f, 1f, alpha);
                GUI.contentColor = new Color(1f, 1f, 1f, alpha);
                GUI.Label(position, GUIContent.none, styles.nodeBoxes[index]);
                Rect rect2 = new Rect((position.x + (position.width / 2f)) - 4f, position.y - 2f, 0f, 0f);
                Rect rect3 = new Rect((position.x + (position.width / 2f)) - 4f, (position.y + position.height) - 2f, 0f, 0f);
                Rect rect4 = new Rect(position.x + 1f, position.yMax - 36f, 32f, 32f);
                Rect rect5 = new Rect(position.xMax - 18f, position.yMax - 18f, 16f, 16f);
                Rect rect6 = new Rect(position.x, position.y, position.width - 2f, 16f);
                bool flag = true;
                int num5 = 0;
                GUIContent gUIContent = new GUIContent();
                System.Type type = group.GetType();
                if (type == typeof(TreeGroupBranch))
                {
                    gUIContent = TreeEditorHelper.GetGUIContent("|Branch Group");
                    TreeGroupBranch branch = (TreeGroupBranch) group;
                    switch (branch.geometryMode)
                    {
                        case TreeGroupBranch.GeometryMode.Branch:
                            num5 = 1;
                            break;

                        case TreeGroupBranch.GeometryMode.BranchFrond:
                            num5 = 0;
                            break;

                        case TreeGroupBranch.GeometryMode.Frond:
                            num5 = 2;
                            break;
                    }
                }
                else if (type == typeof(TreeGroupLeaf))
                {
                    gUIContent = TreeEditorHelper.GetGUIContent("|Leaf Group");
                    num5 = 3;
                }
                else if (type == typeof(TreeGroupRoot))
                {
                    gUIContent = TreeEditorHelper.GetGUIContent("|Tree Root Node");
                    num5 = 4;
                    flag = false;
                }
                if (flag)
                {
                    Rect hierachyNodeVisRect = this.GetHierachyNodeVisRect(position);
                    GUIContent content = TreeEditorHelper.GetGUIContent("|Show / Hide Group");
                    content.image = styles.visibilityIcons[!group.visible ? 1 : 0].image;
                    GUI.contentColor = new Color(1f, 1f, 1f, 0.7f);
                    if (GUI.Button(hierachyNodeVisRect, content, GUIStyle.none))
                    {
                        group.visible = !group.visible;
                        GUI.changed = true;
                    }
                    GUI.contentColor = Color.white;
                }
                gUIContent.image = styles.nodeIcons[num5].image;
                GUI.contentColor = new Color(1f, 1f, 1f, !group.visible ? 0.5f : 1f);
                if (GUI.Button(rect4, gUIContent, GUIStyle.none) || (this.dragNode == node))
                {
                    TreeGroup group3 = s_SelectedGroup;
                    this.SelectGroup(group);
                    if (group3 == s_SelectedGroup)
                    {
                        Tree target = this.target as Tree;
                        this.FrameSelected(target);
                    }
                }
                GUI.contentColor = Color.white;
                if (group.CanHaveSubGroups())
                {
                    GUI.Label(rect2, GUIContent.none, styles.pinLabel);
                }
                if (flag)
                {
                    GUIContent content3 = TreeEditorHelper.GetGUIContent("|Node Count");
                    content3.text = group.nodeIDs.Length.ToString();
                    GUI.Label(rect6, content3, styles.nodeLabelTop);
                    if (this.m_TreeEditorHelper.NodeHasWrongMaterial(group))
                    {
                        GUI.DrawTexture(rect5, ConsoleWindow.iconErrorSmall);
                    }
                    else if (group.lockFlags != 0)
                    {
                        GUI.DrawTexture(rect5, styles.warningIcon.image);
                    }
                    GUI.Label(rect3, GUIContent.none, styles.pinLabel);
                }
                for (int k = 0; k < group.childGroupIDs.Length; k++)
                {
                    TreeGroup group4 = treeData.GetGroup(group.childGroupIDs[k]);
                    this.DrawHierachyNodes(treeData, nodes, group4, offset, alpha * fade, fade);
                }
                GUI.backgroundColor = Color.white;
                GUI.contentColor = Color.white;
            }
        }

        private void DuplicateSelected(TreeData treeData)
        {
            this.UndoStoreSelected(EditMode.Duplicate);
            if (s_SelectedNode != null)
            {
                s_SelectedNode = treeData.DuplicateNode(s_SelectedNode);
                s_SelectedGroup.Lock();
            }
            else
            {
                this.SelectGroup(treeData.DuplicateGroup(s_SelectedGroup));
            }
            this.m_WantCompleteUpdate = true;
            UpdateMesh(this.target as Tree);
            this.m_WantCompleteUpdate = false;
        }

        private static void EndSettingsSection()
        {
            GUI.enabled = true;
            GUILayout.Space(5f);
        }

        private float FindClosestOffset(TreeData data, Matrix4x4 objMatrix, TreeNode node, Ray mouseRay, ref float rotation)
        {
            TreeGroup group = data.GetGroup(node.groupID);
            if (group == null)
            {
                return 0f;
            }
            if (group.GetType() != typeof(TreeGroupBranch))
            {
                return 0f;
            }
            data.ValidateReferences();
            Matrix4x4 matrixx = objMatrix * node.matrix;
            float num = 1f / (node.spline.GetNodeCount() * 10f);
            float time = 0f;
            float num3 = 1E+07f;
            Vector3 zero = Vector3.zero;
            Vector3 closestRay = Vector3.zero;
            Vector3 vector3 = matrixx.MultiplyPoint(node.spline.GetPositionAtTime(0f));
            for (float i = num; i <= 1f; i += num)
            {
                Vector3 vector4 = matrixx.MultiplyPoint(node.spline.GetPositionAtTime(i));
                float squaredDist = 0f;
                float s = 0f;
                zero = MathUtils.ClosestPtSegmentRay(vector3, vector4, mouseRay, out squaredDist, out s, out closestRay);
                if (squaredDist < num3)
                {
                    time = (i - num) + (num * s);
                    num3 = squaredDist;
                    float radiusAtTime = node.GetRadiusAtTime(time);
                    float t = 0f;
                    if (MathUtils.ClosestPtRaySphere(mouseRay, zero, radiusAtTime, ref t, ref closestRay))
                    {
                        Matrix4x4 matrixx3 = matrixx * node.GetLocalMatrixAtTime(time);
                        Matrix4x4 inverse = matrixx3.inverse;
                        Vector3 v = closestRay - zero;
                        v = inverse.MultiplyVector(v);
                        rotation = Mathf.Atan2(v.x, v.z) * 57.29578f;
                    }
                }
                vector3 = vector4;
            }
            data.ClearReferences();
            return time;
        }

        private void FrameSelected(Tree tree)
        {
            TreeData treeData = GetTreeData(tree);
            Matrix4x4 localToWorldMatrix = tree.transform.localToWorldMatrix;
            Bounds bounds = new Bounds(localToWorldMatrix.MultiplyPoint(Vector3.zero), Vector3.zero);
            if (s_SelectedGroup != null)
            {
                if (s_SelectedGroup.GetType() == typeof(TreeGroupRoot))
                {
                    MeshFilter component = tree.GetComponent<MeshFilter>();
                    if ((component == null) || (s_SelectedGroup.childGroupIDs.Length == 0))
                    {
                        float rootSpread = s_SelectedGroup.GetRootSpread();
                        Vector3 introduced14 = localToWorldMatrix.MultiplyPoint(Vector3.zero);
                        bounds = new Bounds(introduced14, localToWorldMatrix.MultiplyVector(new Vector3(rootSpread, rootSpread, rootSpread)));
                    }
                    else
                    {
                        Vector3 introduced15 = localToWorldMatrix.MultiplyPoint(component.sharedMesh.bounds.center);
                        bounds = new Bounds(introduced15, localToWorldMatrix.MultiplyVector(component.sharedMesh.bounds.size));
                    }
                }
                else if (s_SelectedNode != null)
                {
                    if ((s_SelectedGroup.GetType() == typeof(TreeGroupLeaf)) && (s_SelectedPoint >= 0))
                    {
                        Matrix4x4 matrixx2 = localToWorldMatrix * s_SelectedNode.matrix;
                        bounds = new Bounds(matrixx2.MultiplyPoint(s_SelectedNode.spline.nodes[s_SelectedPoint].point), Vector3.zero);
                    }
                    else
                    {
                        bounds = this.CalcBounds(treeData, localToWorldMatrix, s_SelectedNode);
                    }
                }
                else
                {
                    for (int i = 0; i < s_SelectedGroup.nodeIDs.Length; i++)
                    {
                        Bounds bounds2 = this.CalcBounds(treeData, localToWorldMatrix, treeData.GetNode(s_SelectedGroup.nodeIDs[i]));
                        if (i == 0)
                        {
                            bounds = bounds2;
                        }
                        else
                        {
                            bounds.Encapsulate(bounds2);
                        }
                    }
                }
            }
            Vector3 center = bounds.center;
            float newSize = bounds.size.magnitude + 1f;
            SceneView lastActiveSceneView = SceneView.lastActiveSceneView;
            if (lastActiveSceneView != null)
            {
                lastActiveSceneView.LookAt(center, lastActiveSceneView.rotation, newSize);
            }
        }

        private static float GenerateMaterialHash(Material material)
        {
            float num = 0f;
            Color color = material.GetColor("_TranslucencyColor");
            num += ((color.r + color.g) + color.b) + color.a;
            num += GetMaterialFloat(material, "_Cutoff");
            num += GetMaterialFloat(material, "_TranslucencyViewDependency");
            num += GetMaterialFloat(material, "_ShadowStrength");
            return (num + GetMaterialFloat(material, "_ShadowOffsetScale"));
        }

        private Rect GetHierachyNodeVisRect(Rect rect)
        {
            return new Rect(((rect.x + rect.width) - 13f) - 1f, rect.y + 11f, 13f, 11f);
        }

        private static float GetMaterialFloat(Material material, string propertyID)
        {
            bool flag;
            return GetMaterialFloat(material, propertyID, out flag);
        }

        private static float GetMaterialFloat(Material material, string propertyID, out bool success)
        {
            success = false;
            if (!material.HasProperty(propertyID))
            {
                return 0f;
            }
            success = true;
            return material.GetFloat(propertyID);
        }

        private static TreeData GetTreeData(Tree tree)
        {
            if (tree == null)
            {
                return null;
            }
            return (tree.data as TreeData);
        }

        private bool GUICurve(PropertyType prop, AnimationCurve curve, Rect ranges)
        {
            bool changed = GUI.changed;
            GUILayoutOption[] options = new GUILayoutOption[] { GUILayout.Width(50f) };
            EditorGUILayout.CurveField(curve, Color.green, ranges, options);
            this.GUIPropEnd(false);
            if (changed == GUI.changed)
            {
                return false;
            }
            if (GUIUtility.hotControl == 0)
            {
                this.m_WantCompleteUpdate = true;
            }
            this.GUIHandlePropertyChange(prop);
            return true;
        }

        private void GUIHandlePropertyChange(PropertyType prop)
        {
            switch (prop)
            {
                case PropertyType.Normal:
                    this.UndoStoreSelected(EditMode.Parameter);
                    break;

                case PropertyType.FullUndo:
                    this.UndoStoreSelected(EditMode.Everything);
                    break;

                case PropertyType.FullUpdate:
                    this.UndoStoreSelected(EditMode.Parameter);
                    this.m_WantCompleteUpdate = true;
                    break;

                case PropertyType.FullUndoUpdate:
                    this.UndoStoreSelected(EditMode.Everything);
                    this.m_WantCompleteUpdate = true;
                    break;
            }
        }

        private int GUIIntSlider(PropertyType prop, string contentID, int value, int minimum, int maximum, bool hasCurve)
        {
            this.GUIPropBegin();
            int num = EditorGUILayout.IntSlider(TreeEditorHelper.GetGUIContent(contentID), value, minimum, maximum, new GUILayoutOption[0]);
            if (num != value)
            {
                this.GUIHandlePropertyChange(prop);
            }
            if (!hasCurve)
            {
                this.GUIPropEnd();
            }
            return num;
        }

        private bool GUIMaterialColor(Material material, string propertyID, string contentID)
        {
            bool flag = false;
            this.GUIPropBegin();
            Color color = material.GetColor(propertyID);
            Color color2 = EditorGUILayout.ColorField(TreeEditorHelper.GetGUIContent(contentID), color, new GUILayoutOption[0]);
            if (color2 != color)
            {
                Undo.RegisterCompleteObjectUndo(material, "Material");
                material.SetColor(propertyID, color2);
                flag = true;
            }
            this.GUIPropEnd();
            return flag;
        }

        private Material GUIMaterialField(PropertyType prop, int uniqueNodeID, string contentID, Material value, TreeEditorHelper.NodeType nodeType)
        {
            string uniqueID = uniqueNodeID + "_" + contentID;
            this.GUIPropBegin();
            Material material = EditorGUILayout.ObjectField(TreeEditorHelper.GetGUIContent(contentID), value, typeof(Material), false, new GUILayoutOption[0]) as Material;
            this.GUIPropEnd();
            bool flag = this.m_TreeEditorHelper.GUIWrongShader(uniqueID, material, nodeType);
            if ((material != value) || flag)
            {
                this.GUIHandlePropertyChange(prop);
                this.m_WantCompleteUpdate = true;
            }
            return material;
        }

        private bool GUIMaterialFloatField(Material material, string propertyID, string contentID)
        {
            bool flag;
            float num = GetMaterialFloat(material, propertyID, out flag);
            if (!flag)
            {
                return false;
            }
            bool flag2 = false;
            this.GUIPropBegin();
            float num2 = EditorGUILayout.FloatField(TreeEditorHelper.GetGUIContent(contentID), num, new GUILayoutOption[0]);
            if (num2 != num)
            {
                Undo.RegisterCompleteObjectUndo(material, "Material");
                material.SetFloat(propertyID, num2);
                flag2 = true;
            }
            this.GUIPropEnd();
            return flag2;
        }

        private bool GUIMaterialSlider(Material material, string propertyID, string contentID)
        {
            bool flag = false;
            this.GUIPropBegin();
            float @float = material.GetFloat(propertyID);
            float num2 = EditorGUILayout.Slider(TreeEditorHelper.GetGUIContent(contentID), @float, 0f, 1f, new GUILayoutOption[0]);
            if (num2 != @float)
            {
                Undo.RegisterCompleteObjectUndo(material, "Material");
                material.SetFloat(propertyID, num2);
                flag = true;
            }
            this.GUIPropEnd();
            return flag;
        }

        private Vector2 GUIMinMaxSlider(PropertyType prop, string contentID, Vector2 value, float minimum, float maximum, bool hasCurve)
        {
            this.GUIPropBegin();
            Vector2 vector = new Vector2(Mathf.Min(value.x, value.y), Mathf.Max(value.x, value.y));
            GUIContent gUIContent = TreeEditorHelper.GetGUIContent(contentID);
            bool changed = GUI.changed;
            Rect position = GUILayoutUtility.GetRect(gUIContent, "Button");
            EditorGUI.MinMaxSlider(gUIContent, position, ref vector.x, ref vector.y, minimum, maximum);
            if (changed != GUI.changed)
            {
                this.GUIHandlePropertyChange(prop);
            }
            if (!hasCurve)
            {
                this.GUIPropEnd();
            }
            return vector;
        }

        private UnityEngine.Object GUIObjectField(PropertyType prop, string contentID, UnityEngine.Object value, System.Type type, bool hasCurve)
        {
            this.GUIPropBegin();
            UnityEngine.Object obj2 = EditorGUILayout.ObjectField(TreeEditorHelper.GetGUIContent(contentID), value, type, false, new GUILayoutOption[0]);
            if (obj2 != value)
            {
                this.GUIHandlePropertyChange(prop);
                this.m_WantCompleteUpdate = true;
            }
            if (!hasCurve)
            {
                this.GUIPropEnd();
            }
            return obj2;
        }

        private int GUIPopup(PropertyType prop, string contentID, string[] optionIDs, int value, bool hasCurve)
        {
            this.GUIPropBegin();
            GUIContent[] displayedOptions = new GUIContent[optionIDs.Length];
            for (int i = 0; i < optionIDs.Length; i++)
            {
                displayedOptions[i] = TreeEditorHelper.GetGUIContent(optionIDs[i]);
            }
            int num2 = EditorGUILayout.Popup(TreeEditorHelper.GetGUIContent(contentID), value, displayedOptions, new GUILayoutOption[0]);
            if (num2 != value)
            {
                this.GUIHandlePropertyChange(prop);
                this.m_WantCompleteUpdate = true;
            }
            if (!hasCurve)
            {
                this.GUIPropEnd();
            }
            return num2;
        }

        private Rect GUIPropBegin()
        {
            return EditorGUILayout.BeginHorizontal(new GUILayoutOption[0]);
        }

        private void GUIPropEnd()
        {
            this.GUIPropEnd(true);
        }

        private void GUIPropEnd(bool addSpace)
        {
            if (addSpace)
            {
                GUILayout.Space(!this.m_SectionHasCurves ? 0f : 54f);
            }
            EditorGUILayout.EndHorizontal();
        }

        private float GUISlider(PropertyType prop, string contentID, float value, float minimum, float maximum, bool hasCurve)
        {
            this.GUIPropBegin();
            float num = EditorGUILayout.Slider(TreeEditorHelper.GetGUIContent(contentID), value, minimum, maximum, new GUILayoutOption[0]);
            if (num != value)
            {
                this.GUIHandlePropertyChange(prop);
            }
            if (!hasCurve)
            {
                this.GUIPropEnd();
            }
            return num;
        }

        private bool GUIToggle(PropertyType prop, string contentID, bool value, bool hasCurve)
        {
            this.GUIPropBegin();
            bool flag = EditorGUILayout.Toggle(TreeEditorHelper.GetGUIContent(contentID), value, new GUILayoutOption[0]);
            if (flag != value)
            {
                this.GUIHandlePropertyChange(prop);
                this.m_WantCompleteUpdate = true;
            }
            if (!hasCurve)
            {
                this.GUIPropEnd();
            }
            return flag;
        }

        private int GUItoolbar(int selection, GUIContent[] names)
        {
            GUI.enabled = true;
            bool changed = GUI.changed;
            EditorGUILayout.BeginHorizontal(new GUILayoutOption[0]);
            GUILayout.FlexibleSpace();
            for (int i = 0; i < names.Length; i++)
            {
                GUIStyle style = new GUIStyle("ButtonMid");
                if (i == 0)
                {
                    style = new GUIStyle("ButtonLeft");
                }
                if (i == (names.Length - 1))
                {
                    style = new GUIStyle("ButtonRight");
                }
                if ((names[i] != null) && GUILayout.Toggle(selection == i, names[i], style, new GUILayoutOption[0]))
                {
                    selection = i;
                }
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            GUI.changed = changed;
            return selection;
        }

        private void GUIunlockbox(TreeData treeData)
        {
            GUILayout.BeginVertical(EditorStyles.helpBox, new GUILayoutOption[0]);
            GUIContent gUIContent = TreeEditorHelper.GetGUIContent("This group has been edited by hand. Some parameters may not be available.|");
            gUIContent.image = styles.warningIcon.image;
            GUILayout.Label(gUIContent, EditorStyles.wordWrappedMiniLabel, new GUILayoutOption[0]);
            GUIStyle style = new GUIStyle("minibutton") {
                wordWrap = true
            };
            if (GUILayout.Button(TreeEditorHelper.GetGUIContent("Convert to procedural group. All hand editing will be lost!|"), style, new GUILayoutOption[0]))
            {
                treeData.UnlockGroup(s_SelectedGroup);
                this.m_WantCompleteUpdate = true;
            }
            GUILayout.EndVertical();
        }

        private void HandleDragHierachyNodes(TreeData treeData, List<HierachyNode> nodes)
        {
            if (this.dragNode == null)
            {
                this.isDragging = false;
                this.dropNode = null;
            }
            int controlID = GUIUtility.GetControlID(FocusType.Passive);
            EventType typeForControl = Event.current.GetTypeForControl(controlID);
            if ((typeForControl == EventType.MouseDown) && (Event.current.button == 0))
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if ((nodes[i].rect.Contains(Event.current.mousePosition) && !this.GetHierachyNodeVisRect(nodes[i].rect).Contains(Event.current.mousePosition)) && !(nodes[i].group is TreeGroupRoot))
                    {
                        this.dragClickPos = Event.current.mousePosition;
                        this.dragNode = nodes[i];
                        GUIUtility.hotControl = controlID;
                        Event.current.Use();
                        break;
                    }
                }
            }
            if (this.dragNode != null)
            {
                this.dropNode = null;
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (nodes[j].rect.Contains(Event.current.mousePosition))
                    {
                        TreeGroup ancestor = this.dragNode.group;
                        TreeGroup group = nodes[j].group;
                        if (((group != ancestor) && group.CanHaveSubGroups()) && ((treeData.GetGroup(ancestor.parentGroupID) != group) && !treeData.IsAncestor(ancestor, group)))
                        {
                            this.dropNode = nodes[j];
                            break;
                        }
                    }
                }
                switch (typeForControl)
                {
                    case EventType.MouseMove:
                    case EventType.MouseDrag:
                    {
                        Vector2 vector = this.dragClickPos - Event.current.mousePosition;
                        if (vector.magnitude > 10f)
                        {
                            this.isDragging = true;
                        }
                        Event.current.Use();
                        break;
                    }
                    default:
                        if ((typeForControl == EventType.MouseUp) && (GUIUtility.hotControl == controlID))
                        {
                            if (this.dropNode != null)
                            {
                                this.UndoStoreSelected(EditMode.Everything);
                                TreeGroup g = this.dragNode.group;
                                TreeGroup parent = this.dropNode.group;
                                treeData.SetGroupParent(g, parent);
                                this.m_WantCompleteUpdate = true;
                            }
                            else
                            {
                                base.Repaint();
                            }
                            this.dragNode = null;
                            this.dropNode = null;
                            GUIUtility.hotControl = 0;
                            Event.current.Use();
                        }
                        break;
                }
            }
        }

        public void InspectorAnimation(TreeData treeData, TreeGroup group)
        {
            if (group != null)
            {
                this.PrepareSpacing(false);
                group.animationPrimary = this.GUISlider(PropertyType.Normal, group.MainWindString, group.animationPrimary, 0f, 1f, false);
                if (treeData.GetGroup(group.parentGroupID) != treeData.root)
                {
                    group.animationSecondary = this.GUISlider(PropertyType.Normal, group.MainTurbulenceString, group.animationSecondary, 0f, 1f, false);
                }
                GUI.enabled = true;
                if (!(group is TreeGroupBranch) || ((group as TreeGroupBranch).geometryMode != TreeGroupBranch.GeometryMode.Branch))
                {
                    group.animationEdge = this.GUISlider(PropertyType.Normal, group.EdgeTurbulenceString, group.animationEdge, 0f, 1f, false);
                }
                this.GUIPropBegin();
                if (GUILayout.Button(TreeEditorHelper.GetGUIContent("Create Wind Zone|Creates a default wind zone, which is required for animating trees while playing the game."), new GUILayoutOption[0]))
                {
                    CreateDefaultWindZone();
                }
                this.GUIPropEnd();
            }
        }

        public void InspectorBranch(TreeData treeData, TreeGroupBranch group)
        {
            this.InspectorEditTools(this.target as Tree);
            GUIContent[] names = new GUIContent[] { TreeEditorHelper.GetGUIContent("Distribution|Adjusts the count and placement of branches in the group. Use the curves to fine tune position, rotation and scale. The curves are relative to the parent branch or to the area spread in case of a trunk."), TreeEditorHelper.GetGUIContent("Geometry|Select what type of geometry is generated for this branch group and which materials are applied. LOD Multiplier allows you to adjust the quality of this group relative to tree's LOD Quality."), TreeEditorHelper.GetGUIContent("Shape|Adjusts the shape and growth of the branches. Use the curves to fine tune the shape, all curves are relative to the branch itself."), TreeEditorHelper.GetGUIContent("Fronds|"), TreeEditorHelper.GetGUIContent("Wind|Adjusts the parameters used for animating this group of branches. The wind zones are only active in Play Mode.") };
            bool enabled = GUI.enabled;
            if (s_SelectedGroup.lockFlags != 0)
            {
                this.GUIunlockbox(treeData);
            }
            BeginSettingsSection(0, names);
            this.InspectorDistribution(treeData, group);
            EndSettingsSection();
            BeginSettingsSection(1, names);
            this.PrepareSpacing(false);
            group.lodQualityMultiplier = this.GUISlider(PropertyType.Normal, lodMultiplierString, group.lodQualityMultiplier, 0f, 2f, false);
            group.geometryMode = (TreeGroupBranch.GeometryMode) this.GUIPopup(PropertyType.FullUpdate, geometryModeString, categoryNamesOptions, (int) group.geometryMode, false);
            if (group.geometryMode != TreeGroupBranch.GeometryMode.Frond)
            {
                group.materialBranch = this.GUIMaterialField(PropertyType.FullUpdate, group.uniqueID, branchMaterialString, group.materialBranch, TreeEditorHelper.NodeType.BarkNode);
            }
            group.materialBreak = this.GUIMaterialField(PropertyType.FullUpdate, group.uniqueID, breakMaterialString, group.materialBreak, TreeEditorHelper.NodeType.BarkNode);
            if (group.geometryMode != TreeGroupBranch.GeometryMode.Branch)
            {
                group.materialFrond = this.GUIMaterialField(PropertyType.FullUpdate, group.uniqueID, frondMaterialString, group.materialFrond, TreeEditorHelper.NodeType.BarkNode);
            }
            EndSettingsSection();
            BeginSettingsSection(2, names);
            this.PrepareSpacing(true);
            GUI.enabled = group.lockFlags == 0;
            group.height = this.GUIMinMaxSlider(PropertyType.Normal, lengthString, group.height, 0.1f, 50f, false);
            GUI.enabled = group.geometryMode != TreeGroupBranch.GeometryMode.Frond;
            group.radiusMode = this.GUIToggle(PropertyType.Normal, relativeLengthString, group.radiusMode, false);
            GUI.enabled = group.geometryMode != TreeGroupBranch.GeometryMode.Frond;
            group.radius = this.GUISlider(PropertyType.Normal, radiusString, group.radius, 0.1f, 5f, true);
            AnimationCurve radiusCurve = group.radiusCurve;
            if (this.GUICurve(PropertyType.Normal, radiusCurve, this.m_CurveRangesA))
            {
                group.radiusCurve = radiusCurve;
            }
            GUI.enabled = group.geometryMode != TreeGroupBranch.GeometryMode.Frond;
            group.capSmoothing = this.GUISlider(PropertyType.Normal, capSmoothingString, group.capSmoothing, 0f, 1f, false);
            GUI.enabled = true;
            EditorGUILayout.Space();
            GUI.enabled = group.lockFlags == 0;
            group.crinklyness = this.GUISlider(PropertyType.Normal, crinklynessString, group.crinklyness, 0f, 1f, true);
            radiusCurve = group.crinkCurve;
            if (this.GUICurve(PropertyType.Normal, radiusCurve, this.m_CurveRangesA))
            {
                group.crinkCurve = radiusCurve;
            }
            GUI.enabled = group.lockFlags == 0;
            group.seekBlend = this.GUISlider(PropertyType.Normal, seekSunString, group.seekBlend, 0f, 1f, true);
            radiusCurve = group.seekCurve;
            if (this.GUICurve(PropertyType.Normal, radiusCurve, this.m_CurveRangesB))
            {
                group.seekCurve = radiusCurve;
            }
            GUI.enabled = true;
            EditorGUILayout.Space();
            GUI.enabled = group.geometryMode != TreeGroupBranch.GeometryMode.Frond;
            group.noise = this.GUISlider(PropertyType.Normal, noiseString, group.noise, 0f, 1f, true);
            radiusCurve = group.noiseCurve;
            if (this.GUICurve(PropertyType.Normal, radiusCurve, this.m_CurveRangesA))
            {
                group.noiseCurve = radiusCurve;
            }
            group.noiseScaleU = this.GUISlider(PropertyType.Normal, noiseScaleUString, group.noiseScaleU, 0f, 1f, false);
            group.noiseScaleV = this.GUISlider(PropertyType.Normal, noiseScaleVString, group.noiseScaleV, 0f, 1f, false);
            EditorGUILayout.Space();
            GUI.enabled = group.geometryMode != TreeGroupBranch.GeometryMode.Frond;
            if (treeData.GetGroup(group.parentGroupID) == treeData.root)
            {
                group.flareSize = this.GUISlider(PropertyType.Normal, flareRadiusString, group.flareSize, 0f, 5f, false);
                group.flareHeight = this.GUISlider(PropertyType.Normal, flareHeightString, group.flareHeight, 0f, 1f, false);
                group.flareNoise = this.GUISlider(PropertyType.Normal, flareNoiseString, group.flareNoise, 0f, 1f, false);
            }
            else
            {
                group.weldHeight = this.GUISlider(PropertyType.Normal, weldLengthString, group.weldHeight, 0.01f, 1f, false);
                group.weldSpreadTop = this.GUISlider(PropertyType.Normal, spreadTopString, group.weldSpreadTop, 0f, 1f, false);
                group.weldSpreadBottom = this.GUISlider(PropertyType.Normal, spreadBottomString, group.weldSpreadBottom, 0f, 1f, false);
            }
            EditorGUILayout.Space();
            group.breakingChance = this.GUISlider(PropertyType.Normal, breakChanceString, group.breakingChance, 0f, 1f, false);
            group.breakingSpot = this.GUIMinMaxSlider(PropertyType.Normal, breakLocationString, group.breakingSpot, 0f, 1f, false);
            EndSettingsSection();
            if (group.geometryMode != TreeGroupBranch.GeometryMode.Branch)
            {
                BeginSettingsSection(3, names);
                this.PrepareSpacing(true);
                group.frondCount = this.GUIIntSlider(PropertyType.Normal, frondCountString, group.frondCount, 1, 0x10, false);
                group.frondWidth = this.GUISlider(PropertyType.Normal, frondWidthString, group.frondWidth, 0.1f, 10f, true);
                radiusCurve = group.frondCurve;
                if (this.GUICurve(PropertyType.Normal, radiusCurve, this.m_CurveRangesA))
                {
                    group.frondCurve = radiusCurve;
                }
                group.frondRange = this.GUIMinMaxSlider(PropertyType.Normal, frondRangeString, group.frondRange, 0f, 1f, false);
                group.frondRotation = this.GUISlider(PropertyType.Normal, frondRotationString, group.frondRotation, 0f, 1f, false);
                group.frondCrease = this.GUISlider(PropertyType.Normal, frondCreaseString, group.frondCrease, -1f, 1f, false);
                GUI.enabled = true;
                EndSettingsSection();
            }
            BeginSettingsSection(4, names);
            this.InspectorAnimation(treeData, group);
            EndSettingsSection();
            GUI.enabled = enabled;
            EditorGUILayout.Space();
        }

        public void InspectorDistribution(TreeData treeData, TreeGroup group)
        {
            if (group != null)
            {
                this.PrepareSpacing(true);
                bool flag = true;
                if (group.lockFlags != 0)
                {
                    flag = false;
                }
                GUI.enabled = flag;
                int seed = group.seed;
                group.seed = this.GUIIntSlider(PropertyType.Normal, group.GroupSeedString, group.seed, 0, 0xf423f, false);
                if (group.seed != seed)
                {
                    treeData.UpdateSeed(group.uniqueID);
                }
                seed = group.distributionFrequency;
                group.distributionFrequency = this.GUIIntSlider(PropertyType.FullUndo, group.FrequencyString, group.distributionFrequency, 1, 100, false);
                if (group.distributionFrequency != seed)
                {
                    treeData.UpdateFrequency(group.uniqueID);
                }
                seed = (int) group.distributionMode;
                group.distributionMode = (TreeGroup.DistributionMode) this.GUIPopup(PropertyType.Normal, group.DistributionModeString, inspectorDistributionPopupOptions, (int) group.distributionMode, true);
                if (group.distributionMode != seed)
                {
                    treeData.UpdateDistribution(group.uniqueID);
                }
                AnimationCurve distributionCurve = group.distributionCurve;
                if (this.GUICurve(PropertyType.Normal, distributionCurve, this.m_CurveRangesA))
                {
                    group.distributionCurve = distributionCurve;
                    treeData.UpdateDistribution(group.uniqueID);
                }
                if (group.distributionMode != TreeGroup.DistributionMode.Random)
                {
                    float distributionTwirl = group.distributionTwirl;
                    group.distributionTwirl = this.GUISlider(PropertyType.Normal, group.TwirlString, group.distributionTwirl, -1f, 1f, false);
                    if (group.distributionTwirl != distributionTwirl)
                    {
                        treeData.UpdateDistribution(group.uniqueID);
                    }
                }
                if (group.distributionMode == TreeGroup.DistributionMode.Whorled)
                {
                    seed = group.distributionNodes;
                    group.distributionNodes = this.GUIIntSlider(PropertyType.Normal, group.WhorledStepString, group.distributionNodes, 1, 0x15, false);
                    if (group.distributionNodes != seed)
                    {
                        treeData.UpdateDistribution(group.uniqueID);
                    }
                }
                group.distributionScale = this.GUISlider(PropertyType.Normal, group.GrowthScaleString, group.distributionScale, 0f, 1f, true);
                distributionCurve = group.distributionScaleCurve;
                if (this.GUICurve(PropertyType.Normal, distributionCurve, this.m_CurveRangesA))
                {
                    group.distributionScaleCurve = distributionCurve;
                }
                group.distributionPitch = this.GUISlider(PropertyType.Normal, group.GrowthAngleString, group.distributionPitch, 0f, 1f, true);
                distributionCurve = group.distributionPitchCurve;
                if (this.GUICurve(PropertyType.Normal, distributionCurve, this.m_CurveRangesB))
                {
                    group.distributionPitchCurve = distributionCurve;
                }
                GUI.enabled = true;
                EditorGUILayout.Space();
            }
        }

        public void InspectorEditTools(Tree obj)
        {
            if (!EditorUtility.IsPersistent(obj))
            {
                string[] toolbarIconStringsBranch;
                string[] toolbarContentStringsBranch;
                if (s_SelectedGroup is TreeGroupBranch)
                {
                    toolbarIconStringsBranch = TreeEditor.TreeEditor.toolbarIconStringsBranch;
                    toolbarContentStringsBranch = TreeEditor.TreeEditor.toolbarContentStringsBranch;
                }
                else
                {
                    toolbarIconStringsBranch = toolbarIconStringsLeaf;
                    toolbarContentStringsBranch = toolbarContentStringsLeaf;
                    if (TreeEditor.TreeEditor.editMode == EditMode.Freehand)
                    {
                        TreeEditor.TreeEditor.editMode = EditMode.None;
                    }
                }
                EditMode editMode = TreeEditor.TreeEditor.editMode;
                TreeEditor.TreeEditor.editMode = (EditMode) this.GUItoolbar((int) TreeEditor.TreeEditor.editMode, BuildToolbarContent(toolbarIconStringsBranch, toolbarContentStringsBranch, (int) TreeEditor.TreeEditor.editMode));
                if (editMode != TreeEditor.TreeEditor.editMode)
                {
                    SceneView.RepaintAll();
                }
                EditorGUILayout.BeginVertical(EditorStyles.helpBox, new GUILayoutOption[0]);
                if (TreeEditor.TreeEditor.editMode == EditMode.None)
                {
                    GUILayout.Label("No Tool Selected", new GUILayoutOption[0]);
                    GUILayout.Label("Please select a tool", EditorStyles.wordWrappedMiniLabel, new GUILayoutOption[0]);
                }
                else
                {
                    string uIString = TreeEditorHelper.GetUIString(toolbarContentStringsBranch[(int) TreeEditor.TreeEditor.editMode]);
                    GUILayout.Label(TreeEditorHelper.ExtractLabel(uIString), new GUILayoutOption[0]);
                    GUILayout.Label(TreeEditorHelper.ExtractTooltip(uIString), EditorStyles.wordWrappedMiniLabel, new GUILayoutOption[0]);
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
            }
        }

        public void InspectorHierachy(TreeData treeData, Renderer renderer)
        {
            if (s_SelectedGroup == null)
            {
                Debug.Log("NO GROUP SELECTED!");
            }
            else
            {
                EditorGUILayout.BeginHorizontal(new GUILayoutOption[0]);
                GUILayout.BeginVertical(new GUILayoutOption[0]);
                bool changed = GUI.changed;
                Rect sizeRect = this.GUIPropBegin();
                this.DrawHierachy(treeData, renderer, sizeRect);
                if (GUI.changed != changed)
                {
                    this.m_WantCompleteUpdate = true;
                }
                this.GUIPropEnd(false);
                this.GUIPropBegin();
                int num = -1;
                GUILayout.BeginHorizontal(styles.toolbar, new GUILayoutOption[0]);
                if (GUILayout.Button(styles.iconRefresh, styles.toolbarButton, new GUILayoutOption[0]))
                {
                    TreeGroupLeaf.s_TextureHullsDirty = true;
                    UpdateMesh(this.target as Tree);
                }
                GUILayout.FlexibleSpace();
                GUI.enabled = s_SelectedGroup.CanHaveSubGroups();
                if (GUILayout.Button(styles.iconAddLeaves, styles.toolbarButton, new GUILayoutOption[0]))
                {
                    num = 0;
                }
                if (GUILayout.Button(styles.iconAddBranches, styles.toolbarButton, new GUILayoutOption[0]))
                {
                    num = 1;
                }
                GUI.enabled = true;
                if (s_SelectedGroup == treeData.root)
                {
                    GUI.enabled = false;
                }
                if (GUILayout.Button(styles.iconDuplicate, styles.toolbarButton, new GUILayoutOption[0]))
                {
                    num = 3;
                }
                if (GUILayout.Button(styles.iconTrash, styles.toolbarButton, new GUILayoutOption[0]))
                {
                    num = 2;
                }
                GUI.enabled = true;
                GUILayout.EndHorizontal();
                switch (num)
                {
                    case 0:
                    {
                        this.UndoStoreSelected(EditMode.CreateGroup);
                        TreeGroup group = treeData.AddGroup(s_SelectedGroup, typeof(TreeGroupLeaf));
                        this.SelectGroup(group);
                        this.m_WantCompleteUpdate = true;
                        Event.current.Use();
                        break;
                    }
                    case 1:
                    {
                        this.UndoStoreSelected(EditMode.CreateGroup);
                        TreeGroup group2 = treeData.AddGroup(s_SelectedGroup, typeof(TreeGroupBranch));
                        this.SelectGroup(group2);
                        this.m_WantCompleteUpdate = true;
                        Event.current.Use();
                        break;
                    }
                    case 2:
                        this.DeleteSelected(treeData);
                        Event.current.Use();
                        break;

                    case 3:
                        this.DuplicateSelected(treeData);
                        Event.current.Use();
                        break;
                }
                this.GUIPropEnd(false);
                GUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
            }
        }

        public void InspectorLeaf(TreeData treeData, TreeGroupLeaf group)
        {
            this.InspectorEditTools(this.target as Tree);
            GUIContent[] contentArray1 = new GUIContent[6];
            contentArray1[0] = TreeEditorHelper.GetGUIContent("Distribution|Adjusts the count and placement of leaves in the group. Use the curves to fine tune position, rotation and scale. The curves are relative to the parent branch.");
            contentArray1[1] = TreeEditorHelper.GetGUIContent("Geometry|Select what type of geometry is generated for this leaf group and which materials are applied. If you use a custom mesh, its materials will be used.");
            contentArray1[2] = TreeEditorHelper.GetGUIContent("Shape|Adjusts the shape and growth of the leaves.");
            contentArray1[5] = TreeEditorHelper.GetGUIContent("Wind|Adjusts the parameters used for animating this group of leaves. Wind zones are only active in Play Mode. If you select too high values for Main Wind and Main Turbulence the leaves may float away from the branches.");
            GUIContent[] names = contentArray1;
            bool enabled = GUI.enabled;
            if (s_SelectedGroup.lockFlags != 0)
            {
                this.GUIunlockbox(treeData);
            }
            BeginSettingsSection(0, names);
            this.InspectorDistribution(treeData, group);
            EndSettingsSection();
            BeginSettingsSection(1, names);
            this.PrepareSpacing(false);
            group.geometryMode = this.GUIPopup(PropertyType.FullUpdate, geometryModeLeafString, geometryModeOptions, group.geometryMode, false);
            if (group.geometryMode != 4)
            {
                group.materialLeaf = this.GUIMaterialField(PropertyType.FullUpdate, group.uniqueID, materialLeafString, group.materialLeaf, TreeEditorHelper.NodeType.LeafNode);
            }
            if (group.geometryMode == 4)
            {
                group.instanceMesh = this.GUIObjectField(PropertyType.FullUpdate, meshString, group.instanceMesh, typeof(GameObject), false) as GameObject;
            }
            EndSettingsSection();
            BeginSettingsSection(2, names);
            this.PrepareSpacing(false);
            group.size = this.GUIMinMaxSlider(PropertyType.Normal, sizeString, group.size, 0.1f, 2f, false);
            group.perpendicularAlign = this.GUISlider(PropertyType.Normal, perpendicularAlignString, group.perpendicularAlign, 0f, 1f, false);
            group.horizontalAlign = this.GUISlider(PropertyType.Normal, horizontalAlignString, group.horizontalAlign, 0f, 1f, false);
            EndSettingsSection();
            BeginSettingsSection(5, names);
            this.PrepareSpacing(false);
            this.InspectorAnimation(treeData, group);
            EndSettingsSection();
            GUI.enabled = enabled;
            EditorGUILayout.Space();
        }

        public void InspectorRoot(TreeData treeData, TreeGroupRoot group)
        {
            GUIContent[] contentArray1 = new GUIContent[6];
            contentArray1[0] = TreeEditorHelper.GetGUIContent("Distribution|");
            contentArray1[1] = TreeEditorHelper.GetGUIContent("Geometry|");
            contentArray1[2] = TreeEditorHelper.GetGUIContent("Material|Controls global material properties of the tree.");
            GUIContent[] names = contentArray1;
            bool enabled = GUI.enabled;
            BeginSettingsSection(0, names);
            this.PrepareSpacing(false);
            int seed = group.seed;
            group.seed = this.GUIIntSlider(PropertyType.Normal, treeSeedString, group.seed, 0, 0x98967f, false);
            if (group.seed != seed)
            {
                treeData.UpdateSeed(group.uniqueID);
            }
            group.rootSpread = this.GUISlider(PropertyType.Normal, areaSpreadString, group.rootSpread, 0f, 10f, false);
            group.groundOffset = this.GUISlider(PropertyType.Normal, groundOffsetString, group.groundOffset, 0f, 10f, false);
            EndSettingsSection();
            BeginSettingsSection(1, names);
            this.PrepareSpacing(false);
            group.adaptiveLODQuality = this.GUISlider(PropertyType.FullUndo, lodQualityString, group.adaptiveLODQuality, 0f, 1f, false);
            group.enableAmbientOcclusion = this.GUIToggle(PropertyType.FullUndo, ambientOcclusionString, group.enableAmbientOcclusion, false);
            GUI.enabled = group.enableAmbientOcclusion;
            group.aoDensity = this.GUISlider(PropertyType.Normal, aoDensityString, group.aoDensity, 0f, 1f, false);
            GUI.enabled = true;
            EndSettingsSection();
            Material optimizedCutoutMaterial = treeData.optimizedCutoutMaterial;
            if (optimizedCutoutMaterial != null)
            {
                BeginSettingsSection(2, names);
                this.PrepareSpacing(false);
                bool changed = GUI.changed;
                bool flag3 = this.GUIMaterialColor(optimizedCutoutMaterial, "_TranslucencyColor", translucencyColorString) | this.GUIMaterialSlider(optimizedCutoutMaterial, "_TranslucencyViewDependency", transViewDepString);
                flag3 |= this.GUIMaterialSlider(optimizedCutoutMaterial, "_Cutoff", alphaCutoffString);
                flag3 |= this.GUIMaterialSlider(optimizedCutoutMaterial, "_ShadowStrength", shadowStrengthString);
                if (flag3 | this.GUIMaterialFloatField(optimizedCutoutMaterial, "_ShadowOffsetScale", shadowOffsetString))
                {
                    s_CutoutMaterialHashBeforeUndo = GenerateMaterialHash(treeData.optimizedCutoutMaterial);
                }
                group.shadowTextureQuality = this.GUIPopup(PropertyType.FullUpdate, shadowCasterResString, leafMaterialOptions, group.shadowTextureQuality, false);
                GUI.changed = changed;
                EndSettingsSection();
            }
            GUI.enabled = enabled;
            EditorGUILayout.Space();
        }

        private void LayoutHierachyNodes(List<HierachyNode> nodes, Rect sizeRect)
        {
            Vector3 vector;
            Bounds bounds = new Bounds();
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int k = i + 1; k < nodes.Count; k++)
                {
                    if (nodes[i].pos.y == nodes[k].pos.y)
                    {
                        nodes[i].pos.x -= this.hierachySpread.x * 0.5f;
                        nodes[k].pos.x = nodes[i].pos.x + this.hierachySpread.x;
                    }
                }
                bounds.Encapsulate(nodes[i].pos);
            }
            bounds.Expand((Vector3) this.hierachySpread);
            this.hierachyRect = new Rect(0f, 0f, bounds.size.x, bounds.size.y);
            this.hierachyRect.width = Mathf.Max(this.hierachyRect.width, this.hierachyView.width);
            vector = new Vector3((this.hierachyRect.xMax + this.hierachyRect.xMin) * 0.5f, (this.hierachyRect.yMax + this.hierachyRect.yMin) * 0.5f, 0f) {
                y = vector.y + 8f
            };
            for (int j = 0; j < nodes.Count; j++)
            {
                HierachyNode local1 = nodes[j];
                local1.pos -= bounds.center;
                nodes[j].pos.x += vector.x;
                nodes[j].pos.y += vector.y;
                nodes[j].rect = new Rect(nodes[j].pos.x - (this.hierachyNodeSize.x * 0.5f), nodes[j].pos.y - (this.hierachyNodeSize.y * 0.5f), this.hierachyNodeSize.x, this.hierachyNodeSize.y);
            }
        }

        private bool OnCheckHotkeys(TreeData treeData, bool checkFrameSelected)
        {
            switch (Event.current.type)
            {
                case EventType.ValidateCommand:
                    if (((Event.current.commandName == "SoftDelete") || (Event.current.commandName == "Delete")) && ((s_SelectedGroup != null) && (s_SelectedGroup != treeData.root)))
                    {
                        Event.current.Use();
                    }
                    if ((Event.current.commandName == "FrameSelected") && checkFrameSelected)
                    {
                        Event.current.Use();
                    }
                    if (Event.current.commandName == "UndoRedoPerformed")
                    {
                        Event.current.Use();
                    }
                    break;

                case EventType.ExecuteCommand:
                    if (((Event.current.commandName == "SoftDelete") || (Event.current.commandName == "Delete")) && ((s_SelectedGroup != null) && (s_SelectedGroup != treeData.root)))
                    {
                        this.DeleteSelected(treeData);
                        Event.current.Use();
                    }
                    if ((Event.current.commandName == "FrameSelected") && checkFrameSelected)
                    {
                        this.FrameSelected(this.target as Tree);
                        Event.current.Use();
                    }
                    if (Event.current.commandName == "UndoRedoPerformed")
                    {
                        float num = GenerateMaterialHash(treeData.optimizedCutoutMaterial);
                        if (s_CutoutMaterialHashBeforeUndo != num)
                        {
                            s_CutoutMaterialHashBeforeUndo = num;
                        }
                        else
                        {
                            treeData.materialHash = s_SavedSourceMaterialsHash;
                            this.m_StartPointRotationDirty = true;
                            UpdateMesh(this.target as Tree);
                        }
                        Event.current.Use();
                        return true;
                    }
                    if (Event.current.commandName == "CurveChangeCompleted")
                    {
                        UpdateMesh(this.target as Tree);
                        Event.current.Use();
                        return true;
                    }
                    break;
            }
            return false;
        }

        private void OnDisable()
        {
            Tools.s_Hidden = false;
            Tree target = this.target as Tree;
            if (target != null)
            {
                EditorUtility.SetSelectedWireframeHidden(target.GetComponent<Renderer>(), false);
            }
        }

        private void OnEnable()
        {
            Tree target = this.target as Tree;
            if (target != null)
            {
                TreeData treeData = GetTreeData(target);
                if (treeData != null)
                {
                    this.m_TreeEditorHelper.OnEnable(treeData);
                    this.m_TreeEditorHelper.SetAnimsCallback(new UnityAction(this.RepaintGUIView));
                    for (int i = 0; i < this.m_SectionAnimators.Length; i++)
                    {
                        this.m_SectionAnimators[i] = new AnimBool(s_ShowCategory == i, new UnityAction(this.Repaint));
                    }
                    EditorUtility.SetSelectedWireframeHidden(target.GetComponent<Renderer>(), !(s_SelectedGroup is TreeGroupRoot));
                }
            }
        }

        public override void OnInspectorGUI()
        {
            Tree target = this.target as Tree;
            TreeData treeData = GetTreeData(target);
            if (treeData != null)
            {
                Renderer component = target.GetComponent<Renderer>();
                this.VerifySelection(treeData);
                if (s_SelectedGroup != null)
                {
                    this.m_WantCompleteUpdate = false;
                    EventType typeForControl = Event.current.GetTypeForControl(GUIUtility.hotControl);
                    if ((((typeForControl == EventType.MouseUp) || ((typeForControl == EventType.KeyUp) && (Event.current.keyCode == KeyCode.Return))) || ((typeForControl == EventType.ExecuteCommand) && (Event.current.commandName == "OnLostFocus"))) && treeData.isInPreviewMode)
                    {
                        this.m_WantCompleteUpdate = true;
                    }
                    if (!this.OnCheckHotkeys(treeData, true))
                    {
                        this.m_TreeEditorHelper.RefreshAllTreeShaders();
                        if (this.m_TreeEditorHelper.GUITooManyShaders())
                        {
                            this.m_WantCompleteUpdate = true;
                        }
                        EditorGUILayout.Space();
                        EditorGUILayout.BeginVertical(EditorStyles.inspectorFullWidthMargins, new GUILayoutOption[0]);
                        this.InspectorHierachy(treeData, component);
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins, new GUILayoutOption[0]);
                        if (s_SelectedGroup != null)
                        {
                            if (s_SelectedGroup.GetType() == typeof(TreeGroupBranch))
                            {
                                this.InspectorBranch(treeData, (TreeGroupBranch) s_SelectedGroup);
                            }
                            else if (s_SelectedGroup.GetType() == typeof(TreeGroupLeaf))
                            {
                                this.InspectorLeaf(treeData, (TreeGroupLeaf) s_SelectedGroup);
                            }
                            else if (s_SelectedGroup.GetType() == typeof(TreeGroupRoot))
                            {
                                this.InspectorRoot(treeData, (TreeGroupRoot) s_SelectedGroup);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        if (this.m_WantedCompleteUpdateInPreviousFrame)
                        {
                            this.m_WantCompleteUpdate = true;
                        }
                        this.m_WantedCompleteUpdateInPreviousFrame = false;
                        if (this.m_WantCompleteUpdate)
                        {
                            GUI.changed = true;
                        }
                        if (GUI.changed)
                        {
                            if (!this.m_TreeEditorHelper.AreShadersCorrect())
                            {
                                this.m_WantedCompleteUpdateInPreviousFrame = this.m_WantCompleteUpdate;
                            }
                            else if (this.m_WantCompleteUpdate)
                            {
                                UpdateMesh(target);
                                this.m_WantCompleteUpdate = false;
                            }
                            else
                            {
                                PreviewMesh(target);
                            }
                        }
                    }
                }
            }
        }

        private void OnSceneGUI()
        {
            Tree target = this.target as Tree;
            TreeData treeData = GetTreeData(target);
            if (treeData != null)
            {
                this.VerifySelection(treeData);
                if (s_SelectedGroup != null)
                {
                    this.OnCheckHotkeys(treeData, true);
                    Transform transform = target.transform;
                    Matrix4x4 localToWorldMatrix = target.transform.localToWorldMatrix;
                    Event current = Event.current;
                    if (s_SelectedGroup.GetType() == typeof(TreeGroupRoot))
                    {
                        Tools.s_Hidden = false;
                        Handles.color = s_NormalColor;
                        Handles.DrawWireDisc(transform.position, transform.up, treeData.root.rootSpread);
                    }
                    else
                    {
                        Tools.s_Hidden = true;
                        Handles.color = Handles.secondaryColor;
                        Handles.DrawWireDisc(transform.position, transform.up, treeData.root.rootSpread);
                    }
                    if ((s_SelectedGroup != null) && (s_SelectedGroup.GetType() == typeof(TreeGroupBranch)))
                    {
                        EventType rawType = current.type;
                        if ((current.type == EventType.Ignore) && (current.rawType == EventType.MouseUp))
                        {
                            rawType = current.rawType;
                        }
                        Handles.DrawLine(Vector3.zero, Vector3.zero);
                        GL.Begin(1);
                        for (int i = 0; i < s_SelectedGroup.nodeIDs.Length; i++)
                        {
                            TreeNode node = treeData.GetNode(s_SelectedGroup.nodeIDs[i]);
                            TreeSpline spline = node.spline;
                            if (spline != null)
                            {
                                Handles.color = (node != s_SelectedNode) ? s_GroupColor : s_NormalColor;
                                Matrix4x4 matrixx2 = localToWorldMatrix * node.matrix;
                                Vector3 v = matrixx2.MultiplyPoint(spline.GetPositionAtTime(0f));
                                GL.Color(Handles.color);
                                for (float k = 0.01f; k <= 1f; k += 0.01f)
                                {
                                    Vector3 vector2 = matrixx2.MultiplyPoint(spline.GetPositionAtTime(k));
                                    GL.Vertex(v);
                                    GL.Vertex(vector2);
                                    v = vector2;
                                }
                            }
                        }
                        GL.End();
                        for (int j = 0; j < s_SelectedGroup.nodeIDs.Length; j++)
                        {
                            TreeNode node2 = treeData.GetNode(s_SelectedGroup.nodeIDs[j]);
                            TreeSpline spline2 = node2.spline;
                            if (spline2 != null)
                            {
                                Handles.color = (node2 != s_SelectedNode) ? s_GroupColor : s_NormalColor;
                                Matrix4x4 m = localToWorldMatrix * node2.matrix;
                                for (int n = 0; n < spline2.nodes.Length; n++)
                                {
                                    SplineNode node3 = spline2.nodes[n];
                                    Vector3 position = m.MultiplyPoint(node3.point);
                                    float size = HandleUtility.GetHandleSize(position) * 0.08f;
                                    Handles.color = Handles.centerColor;
                                    int keyboardControl = GUIUtility.keyboardControl;
                                    switch (editMode)
                                    {
                                        case EditMode.MoveNode:
                                            if (n != 0)
                                            {
                                                break;
                                            }
                                            position = Handles.FreeMoveHandle(position, Quaternion.identity, size, Vector3.zero, new Handles.DrawCapFunction(Handles.CircleCap));
                                            goto Label_0325;

                                        case EditMode.RotateNode:
                                            Handles.FreeMoveHandle(position, Quaternion.identity, size, Vector3.zero, new Handles.DrawCapFunction(Handles.CircleCap));
                                            if (((rawType == EventType.MouseDown) && (current.type == EventType.Used)) && (keyboardControl != GUIUtility.keyboardControl))
                                            {
                                                this.SelectNode(node2, treeData);
                                                s_SelectedPoint = n;
                                                this.m_GlobalToolRotation = Quaternion.identity;
                                                this.m_TempSpline = new TreeSpline(node2.spline);
                                            }
                                            GUI.changed = false;
                                            goto Label_0874;

                                        case EditMode.Freehand:
                                            Handles.FreeMoveHandle(position, Quaternion.identity, size, Vector3.zero, new Handles.DrawCapFunction(Handles.CircleCap));
                                            if (((rawType == EventType.MouseDown) && (current.type == EventType.Used)) && (keyboardControl != GUIUtility.keyboardControl))
                                            {
                                                Undo.RegisterCompleteObjectUndo(treeData, "Free Hand");
                                                this.SelectNode(node2, treeData);
                                                s_SelectedPoint = n;
                                                s_StartPosition = position;
                                                int c = Mathf.Max(2, s_SelectedPoint + 1);
                                                node2.spline.SetNodeCount(c);
                                                current.Use();
                                            }
                                            if (((s_SelectedPoint == n) && (s_SelectedNode == node2)) && (rawType == EventType.MouseDrag))
                                            {
                                                Ray ray2 = HandleUtility.GUIPointToWorldRay(current.mousePosition);
                                                Vector3 forward = Camera.current.transform.forward;
                                                Plane plane2 = new Plane(forward, s_StartPosition);
                                                float enter = 0f;
                                                if (plane2.Raycast(ray2, out enter))
                                                {
                                                    Vector3 vector7 = ray2.origin + ((Vector3) (enter * ray2.direction));
                                                    if (s_SelectedPoint == 0)
                                                    {
                                                        s_SelectedPoint = 1;
                                                    }
                                                    s_SelectedGroup.Lock();
                                                    s_SelectedNode.spline.nodes[s_SelectedPoint].point = m.inverse.MultiplyPoint(vector7);
                                                    Vector3 vector8 = s_SelectedNode.spline.nodes[s_SelectedPoint].point - s_SelectedNode.spline.nodes[s_SelectedPoint - 1].point;
                                                    if (vector8.magnitude > 1f)
                                                    {
                                                        s_SelectedNode.spline.nodes[s_SelectedPoint].point = s_SelectedNode.spline.nodes[s_SelectedPoint - 1].point + vector8;
                                                        s_SelectedPoint++;
                                                        if (s_SelectedPoint >= s_SelectedNode.spline.nodes.Length)
                                                        {
                                                            s_SelectedNode.spline.AddPoint(m.inverse.MultiplyPoint(vector7), 1.1f);
                                                        }
                                                    }
                                                    s_SelectedNode.spline.UpdateTime();
                                                    s_SelectedNode.spline.UpdateRotations();
                                                    current.Use();
                                                    PreviewMesh(target);
                                                }
                                            }
                                            goto Label_0874;

                                        default:
                                            goto Label_0874;
                                    }
                                    position = Handles.FreeMoveHandle(position, Quaternion.identity, size, Vector3.zero, new Handles.DrawCapFunction(Handles.RectangleCap));
                                Label_0325:
                                    if (((rawType == EventType.MouseDown) && (current.type == EventType.Used)) && (keyboardControl != GUIUtility.keyboardControl))
                                    {
                                        this.SelectNode(node2, treeData);
                                        s_SelectedPoint = n;
                                        this.m_StartPointRotation = MathUtils.QuaternionFromMatrix(m) * node3.rot;
                                    }
                                    if (((rawType == EventType.MouseDown) || (rawType == EventType.MouseUp)) && (current.type == EventType.Used))
                                    {
                                        this.m_StartPointRotation = MathUtils.QuaternionFromMatrix(m) * node3.rot;
                                    }
                                    if (((rawType == EventType.MouseUp) && (current.type == EventType.Used)) && treeData.isInPreviewMode)
                                    {
                                        UpdateMesh(target);
                                    }
                                    if (GUI.changed)
                                    {
                                        Undo.RegisterCompleteObjectUndo(treeData, "Move");
                                        s_SelectedGroup.Lock();
                                        float baseAngle = node2.baseAngle;
                                        if (n == 0)
                                        {
                                            TreeNode node4 = treeData.GetNode(s_SelectedNode.parentID);
                                            Ray mouseRay = HandleUtility.GUIPointToWorldRay(current.mousePosition);
                                            float num8 = 0f;
                                            if (node4 != null)
                                            {
                                                TreeGroup group = treeData.GetGroup(s_SelectedGroup.parentGroupID);
                                                if (group.GetType() == typeof(TreeGroupBranch))
                                                {
                                                    s_SelectedNode.offset = this.FindClosestOffset(treeData, localToWorldMatrix, node4, mouseRay, ref baseAngle);
                                                    position = m.MultiplyPoint(Vector3.zero);
                                                }
                                                else if (group.GetType() == typeof(TreeGroupRoot))
                                                {
                                                    Vector3 inPoint = localToWorldMatrix.MultiplyPoint(Vector3.zero);
                                                    Plane plane = new Plane(localToWorldMatrix.MultiplyVector(Vector3.up), inPoint);
                                                    if (plane.Raycast(mouseRay, out num8))
                                                    {
                                                        position = mouseRay.origin + ((Vector3) (mouseRay.direction * num8));
                                                        Vector3 vector5 = position - inPoint;
                                                        vector5 = localToWorldMatrix.inverse.MultiplyVector(vector5);
                                                        s_SelectedNode.offset = Mathf.Clamp01(vector5.magnitude / treeData.root.rootSpread);
                                                        baseAngle = Mathf.Atan2(vector5.z, vector5.x) * 57.29578f;
                                                        position = m.MultiplyPoint(Vector3.zero);
                                                    }
                                                    else
                                                    {
                                                        position = m.MultiplyPoint(node3.point);
                                                    }
                                                }
                                            }
                                        }
                                        node2.baseAngle = baseAngle;
                                        node3.point = m.inverse.MultiplyPoint(position);
                                        spline2.UpdateTime();
                                        spline2.UpdateRotations();
                                        PreviewMesh(target);
                                        GUI.changed = false;
                                    }
                                Label_0874:
                                    if (((s_SelectedPoint == n) && (s_SelectedNode == node2)) && this.m_StartPointRotationDirty)
                                    {
                                        spline2.UpdateTime();
                                        spline2.UpdateRotations();
                                        this.m_StartPointRotation = MathUtils.QuaternionFromMatrix(m) * node3.rot;
                                        this.m_GlobalToolRotation = Quaternion.identity;
                                        this.m_StartPointRotationDirty = false;
                                    }
                                }
                            }
                        }
                        if ((rawType == EventType.MouseUp) && (editMode == EditMode.Freehand))
                        {
                            s_SelectedPoint = -1;
                            if (treeData.isInPreviewMode)
                            {
                                UpdateMesh(target);
                            }
                        }
                        if (((s_SelectedPoint > 0) && (editMode == EditMode.MoveNode)) && (s_SelectedNode != null))
                        {
                            TreeNode node5 = s_SelectedNode;
                            SplineNode node6 = node5.spline.nodes[s_SelectedPoint];
                            Matrix4x4 matrixx4 = localToWorldMatrix * node5.matrix;
                            Vector3 vector9 = matrixx4.MultiplyPoint(node6.point);
                            Quaternion identity = Quaternion.identity;
                            if (Tools.pivotRotation == PivotRotation.Local)
                            {
                                switch (rawType)
                                {
                                    case EventType.MouseUp:
                                    case EventType.MouseDown:
                                        this.m_StartPointRotation = MathUtils.QuaternionFromMatrix(matrixx4) * node6.rot;
                                        break;
                                }
                                identity = this.m_StartPointRotation;
                            }
                            vector9 = this.DoPositionHandle(vector9, identity, false);
                            if (GUI.changed)
                            {
                                Undo.RegisterCompleteObjectUndo(treeData, "Move");
                                s_SelectedGroup.Lock();
                                node6.point = matrixx4.inverse.MultiplyPoint(vector9);
                                node5.spline.UpdateTime();
                                node5.spline.UpdateRotations();
                                PreviewMesh(target);
                            }
                            if (((rawType == EventType.MouseUp) && (current.type == EventType.Used)) && treeData.isInPreviewMode)
                            {
                                UpdateMesh(target);
                            }
                        }
                        if (((s_SelectedPoint >= 0) && (editMode == EditMode.RotateNode)) && (s_SelectedNode != null))
                        {
                            TreeNode node7 = s_SelectedNode;
                            SplineNode node8 = node7.spline.nodes[s_SelectedPoint];
                            Matrix4x4 matrixx5 = localToWorldMatrix * node7.matrix;
                            if (this.m_TempSpline == null)
                            {
                                this.m_TempSpline = new TreeSpline(node7.spline);
                            }
                            Vector3 vector10 = matrixx5.MultiplyPoint(node8.point);
                            Quaternion globalToolRotation = Quaternion.identity;
                            this.m_GlobalToolRotation = Handles.RotationHandle(this.m_GlobalToolRotation, vector10);
                            globalToolRotation = this.m_GlobalToolRotation;
                            if (GUI.changed)
                            {
                                Undo.RegisterCompleteObjectUndo(treeData, "Move");
                                s_SelectedGroup.Lock();
                                for (int num11 = s_SelectedPoint + 1; num11 < this.m_TempSpline.nodes.Length; num11++)
                                {
                                    Vector3 vector11 = this.m_TempSpline.nodes[num11].point - node8.point;
                                    vector11 = matrixx5.MultiplyVector(vector11);
                                    vector11 = (Vector3) (globalToolRotation * vector11);
                                    vector11 = matrixx5.inverse.MultiplyVector(vector11);
                                    Vector3 vector12 = node8.point + vector11;
                                    s_SelectedNode.spline.nodes[num11].point = vector12;
                                }
                                node7.spline.UpdateTime();
                                node7.spline.UpdateRotations();
                                PreviewMesh(target);
                            }
                            if (((rawType == EventType.MouseUp) && (current.type == EventType.Used)) && treeData.isInPreviewMode)
                            {
                                UpdateMesh(target);
                            }
                        }
                    }
                    if ((s_SelectedGroup != null) && (s_SelectedGroup.GetType() == typeof(TreeGroupLeaf)))
                    {
                        for (int num12 = 0; num12 < s_SelectedGroup.nodeIDs.Length; num12++)
                        {
                            TreeNode node9 = treeData.GetNode(s_SelectedGroup.nodeIDs[num12]);
                            Matrix4x4 matrixx6 = localToWorldMatrix * node9.matrix;
                            Vector3 vector13 = matrixx6.MultiplyPoint(Vector3.zero);
                            float num13 = HandleUtility.GetHandleSize(vector13) * 0.08f;
                            Handles.color = Handles.centerColor;
                            EventType type = current.type;
                            int num14 = GUIUtility.keyboardControl;
                            switch (editMode)
                            {
                                case EditMode.MoveNode:
                                    Handles.FreeMoveHandle(vector13, Quaternion.identity, num13, Vector3.zero, new Handles.DrawCapFunction(Handles.CircleCap));
                                    if (((type == EventType.MouseDown) && (current.type == EventType.Used)) && (num14 != GUIUtility.keyboardControl))
                                    {
                                        this.SelectNode(node9, treeData);
                                        this.m_GlobalToolRotation = MathUtils.QuaternionFromMatrix(matrixx6);
                                        this.m_StartMatrix = matrixx6;
                                        this.m_StartPointRotation = node9.rotation;
                                        this.m_LockedWorldPos = new Vector3(this.m_StartMatrix.m03, this.m_StartMatrix.m13, this.m_StartMatrix.m23);
                                    }
                                    if (((type == EventType.MouseUp) && (current.type == EventType.Used)) && treeData.isInPreviewMode)
                                    {
                                        UpdateMesh(target);
                                    }
                                    if (GUI.changed)
                                    {
                                        s_SelectedGroup.Lock();
                                        TreeNode node10 = treeData.GetNode(node9.parentID);
                                        TreeGroup group2 = treeData.GetGroup(s_SelectedGroup.parentGroupID);
                                        Ray ray3 = HandleUtility.GUIPointToWorldRay(current.mousePosition);
                                        float num15 = 0f;
                                        float rotation = node9.baseAngle;
                                        if (group2.GetType() == typeof(TreeGroupBranch))
                                        {
                                            node9.offset = this.FindClosestOffset(treeData, localToWorldMatrix, node10, ray3, ref rotation);
                                            node9.baseAngle = rotation;
                                            PreviewMesh(target);
                                            break;
                                        }
                                        if (group2.GetType() == typeof(TreeGroupRoot))
                                        {
                                            Vector3 vector14 = localToWorldMatrix.MultiplyPoint(Vector3.zero);
                                            Plane plane3 = new Plane(localToWorldMatrix.MultiplyVector(Vector3.up), vector14);
                                            if (plane3.Raycast(ray3, out num15))
                                            {
                                                vector13 = ray3.origin + ((Vector3) (ray3.direction * num15));
                                                Vector3 vector15 = vector13 - vector14;
                                                vector15 = localToWorldMatrix.inverse.MultiplyVector(vector15);
                                                node9.offset = Mathf.Clamp01(vector15.magnitude / treeData.root.rootSpread);
                                                rotation = Mathf.Atan2(vector15.z, vector15.x) * 57.29578f;
                                            }
                                            node9.baseAngle = rotation;
                                            PreviewMesh(target);
                                        }
                                    }
                                    break;

                                case EditMode.RotateNode:
                                    Handles.FreeMoveHandle(vector13, Quaternion.identity, num13, Vector3.zero, new Handles.DrawCapFunction(Handles.CircleCap));
                                    if (((type == EventType.MouseDown) && (current.type == EventType.Used)) && (num14 != GUIUtility.keyboardControl))
                                    {
                                        this.SelectNode(node9, treeData);
                                        this.m_GlobalToolRotation = MathUtils.QuaternionFromMatrix(matrixx6);
                                        this.m_StartMatrix = matrixx6;
                                        this.m_StartPointRotation = node9.rotation;
                                        this.m_LockedWorldPos = new Vector3(matrixx6.m03, matrixx6.m13, matrixx6.m23);
                                    }
                                    if (s_SelectedNode == node9)
                                    {
                                        type = current.GetTypeForControl(GUIUtility.hotControl);
                                        this.m_GlobalToolRotation = Handles.RotationHandle(this.m_GlobalToolRotation, this.m_LockedWorldPos);
                                        if ((type == EventType.MouseUp) && (current.type == EventType.Used))
                                        {
                                            this.m_LockedWorldPos = new Vector3(matrixx6.m03, matrixx6.m13, matrixx6.m23);
                                            if (treeData.isInPreviewMode)
                                            {
                                                UpdateMesh(target);
                                            }
                                        }
                                        if (GUI.changed)
                                        {
                                            s_SelectedGroup.Lock();
                                            Quaternion quaternion3 = Quaternion.Inverse(MathUtils.QuaternionFromMatrix(this.m_StartMatrix));
                                            node9.rotation = this.m_StartPointRotation * (quaternion3 * this.m_GlobalToolRotation);
                                            MathUtils.QuaternionNormalize(ref node9.rotation);
                                            PreviewMesh(target);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void PrepareSpacing(bool hasCurves)
        {
            this.m_SectionHasCurves = hasCurves;
            EditorGUIUtility.labelWidth = !hasCurves ? ((float) 120) : ((float) 100);
        }

        private static void PreviewMesh(Tree tree)
        {
            PreviewMesh(tree, true);
        }

        private static void PreviewMesh(Tree tree, bool callExitGUI)
        {
            TreeData treeData = GetTreeData(tree);
            if (treeData != null)
            {
                Material[] materialArray;
                Profiler.BeginSample("TreeEditor.PreviewMesh");
                treeData.PreviewMesh(tree.transform.worldToLocalMatrix, out materialArray);
                AssignMaterials(tree.GetComponent<Renderer>(), materialArray, false);
                Profiler.EndSample();
                if (callExitGUI)
                {
                    GUIUtility.ExitGUI();
                }
            }
        }

        private void RepaintGUIView()
        {
            GUIView.current.Repaint();
        }

        private void SelectGroup(TreeGroup group)
        {
            if (group == null)
            {
                Debug.Log("GROUP SELECTION IS NULL!");
            }
            if (this.m_TreeEditorHelper.NodeHasWrongMaterial(group))
            {
                s_ShowCategory = 1;
            }
            s_SelectedGroup = group;
            s_SelectedNode = null;
            s_SelectedPoint = -1;
            EditorUtility.SetDirty(this.target);
            Tree target = this.target as Tree;
            if (target != null)
            {
                EditorUtility.SetSelectedWireframeHidden(target.GetComponent<Renderer>(), !(s_SelectedGroup is TreeGroupRoot));
            }
        }

        private void SelectNode(TreeNode node, TreeData treeData)
        {
            this.SelectGroup((node != null) ? treeData.GetGroup(node.groupID) : treeData.root);
            s_SelectedNode = node;
            s_SelectedPoint = -1;
        }

        private void UndoStoreSelected(EditMode mode)
        {
            TreeData treeData = GetTreeData(this.target as Tree);
            if (treeData != null)
            {
                UnityEngine.Object[] objectsToUndo = new UnityEngine.Object[] { treeData };
                EditorUtility.SetDirty(treeData);
                switch (mode)
                {
                    case EditMode.MoveNode:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Move");
                        break;

                    case EditMode.RotateNode:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Rotate");
                        break;

                    case EditMode.Freehand:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Freehand Drawing");
                        break;

                    case EditMode.Parameter:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Parameter Change");
                        break;

                    case EditMode.Everything:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Parameter Change");
                        break;

                    case EditMode.Delete:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Delete");
                        break;

                    case EditMode.CreateGroup:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Create Group");
                        break;

                    case EditMode.Duplicate:
                        Undo.RegisterCompleteObjectUndo(objectsToUndo, "Duplicate");
                        break;
                }
            }
        }

        private static void UpdateMesh(Tree tree)
        {
            UpdateMesh(tree, true);
        }

        private static void UpdateMesh(Tree tree, bool callExitGUI)
        {
            TreeData treeData = GetTreeData(tree);
            if (treeData != null)
            {
                Material[] materialArray;
                Profiler.BeginSample("TreeEditor.UpdateMesh");
                treeData.UpdateMesh(tree.transform.worldToLocalMatrix, out materialArray);
                AssignMaterials(tree.GetComponent<Renderer>(), materialArray, true);
                s_SavedSourceMaterialsHash = treeData.materialHash;
                Profiler.EndSample();
                if (callExitGUI)
                {
                    GUIUtility.ExitGUI();
                }
            }
        }

        public override bool UseDefaultMargins()
        {
            return false;
        }

        private void VerifySelection(TreeData treeData)
        {
            TreeGroup g = s_SelectedGroup;
            TreeNode node = s_SelectedNode;
            if (g != null)
            {
                g = treeData.GetGroup(g.uniqueID);
            }
            if (node != null)
            {
                node = treeData.GetNode(node.uniqueID);
            }
            if (((g != treeData.root) && (g != null)) && !treeData.IsAncestor(treeData.root, g))
            {
                g = null;
                node = null;
            }
            if ((node != null) && (treeData.GetGroup(node.groupID) != g))
            {
                node = null;
            }
            if (g == null)
            {
                g = treeData.root;
            }
            if ((s_SelectedGroup == null) || (g != s_SelectedGroup))
            {
                this.SelectGroup(g);
                if (node != null)
                {
                    this.SelectNode(node, treeData);
                }
            }
        }

        public static EditMode editMode
        {
            get
            {
                switch (Tools.current)
                {
                    case Tool.View:
                        s_EditMode = EditMode.None;
                        break;

                    case Tool.Move:
                        s_EditMode = EditMode.MoveNode;
                        break;

                    case Tool.Rotate:
                        s_EditMode = EditMode.RotateNode;
                        break;

                    case Tool.Scale:
                        s_EditMode = EditMode.None;
                        break;
                }
                return s_EditMode;
            }
            set
            {
                EditMode mode = value;
                switch ((mode + 1))
                {
                    case EditMode.MoveNode:
                        break;

                    case EditMode.RotateNode:
                        Tools.current = Tool.Move;
                        break;

                    case EditMode.Freehand:
                        Tools.current = Tool.Rotate;
                        break;

                    default:
                        Tools.current = Tool.None;
                        break;
                }
                s_EditMode = value;
            }
        }

        public enum EditMode
        {
            CreateGroup = 6,
            Delete = 5,
            Duplicate = 7,
            Everything = 4,
            Freehand = 2,
            MoveNode = 0,
            None = -1,
            Parameter = 3,
            RotateNode = 1
        }

        internal class HierachyNode
        {
            internal TreeGroup group;
            internal Vector3 pos;
            internal Rect rect;
        }

        private enum PropertyType
        {
            Normal,
            FullUndo,
            FullUpdate,
            FullUndoUpdate
        }

        public class Styles
        {
            public GUIContent iconAddBranches = EditorGUIUtility.IconContent("TreeEditor.AddBranches", "Add Branch Group");
            public GUIContent iconAddLeaves = EditorGUIUtility.IconContent("TreeEditor.AddLeaves", "Add Leaf Group");
            public GUIContent iconDuplicate = EditorGUIUtility.IconContent("TreeEditor.Duplicate", "Duplicate Selected Group");
            public GUIContent iconRefresh = EditorGUIUtility.IconContent("TreeEditor.Refresh", "Recompute Tree");
            public GUIContent iconTrash = EditorGUIUtility.IconContent("TreeEditor.Trash", "Delete Selected Group");
            public GUIStyle nodeBackground = "TE NodeBackground";
            public GUIStyle[] nodeBoxes = new GUIStyle[] { "TE NodeBox", "TE NodeBoxSelected" };
            public GUIContent[] nodeIcons = new GUIContent[] { EditorGUIUtility.IconContent("tree_icon_branch_frond"), EditorGUIUtility.IconContent("tree_icon_branch"), EditorGUIUtility.IconContent("tree_icon_frond"), EditorGUIUtility.IconContent("tree_icon_leaf"), EditorGUIUtility.IconContent("tree_icon") };
            public GUIStyle nodeLabelBot = "TE NodeLabelBot";
            public GUIStyle nodeLabelTop = "TE NodeLabelTop";
            public GUIStyle pinLabel = "TE PinLabel";
            public GUIStyle toolbar = "TE Toolbar";
            public GUIStyle toolbarButton = "TE toolbarbutton";
            public GUIContent[] visibilityIcons = new GUIContent[] { EditorGUIUtility.IconContent("animationvisibilitytoggleon"), EditorGUIUtility.IconContent("animationvisibilitytoggleoff") };
            public GUIContent warningIcon = EditorGUIUtility.IconContent("editicon.sml");
        }
    }
}

