namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.AnimatedValues;
    using UnityEngine;
    using UnityEngine.Events;

    public class TreeEditorHelper
    {
        private const string kDefaultBarkShaderName = "Nature/Tree Creator Bark";
        private const string kDefaultLeafShaderName = "Nature/Tree Creator Leaves Fast";
        private const string kDefaultOptimizedBarkShaderName = "Hidden/Nature/Tree Creator Bark Optimized";
        private const string kDefaultOptimizedLeafShaderName = "Hidden/Nature/Tree Creator Leaves Optimized";
        private const string kOptimizedShaderDependency = "OptimizedShader";
        private readonly Dictionary<string, AnimBool> m_AnimBools = new Dictionary<string, AnimBool>();
        private readonly List<string> m_BarkShaders = new List<string>();
        private readonly List<string> m_LeafShaders = new List<string>();
        private readonly Dictionary<string, int> m_SelectedShader = new Dictionary<string, int>();
        private TreeData m_TreeData;
        private readonly HashSet<string> m_WrongShaders = new HashSet<string>();
        private static readonly Dictionary<string, GUIContent> s_Dictionary = new Dictionary<string, GUIContent>();

        private static void AddShaderFromMaterial(Material material, List<string> barkShaders, List<string> leafShaders)
        {
            if ((material != null) && (material.shader != null))
            {
                Shader shader = material.shader;
                if (IsTreeBarkShader(shader) && !barkShaders.Contains(shader.name))
                {
                    barkShaders.Add(shader.name);
                }
                else if (IsTreeLeafShader(material.shader) && !leafShaders.Contains(shader.name))
                {
                    leafShaders.Add(shader.name);
                }
            }
        }

        public bool AreShadersCorrect()
        {
            bool flag = (this.m_BarkShaders.Count + this.m_LeafShaders.Count) > 2;
            return ((this.m_WrongShaders.Count == 0) && !flag);
        }

        private static void ChangeShaderOnMaterial(Material material, Shader shader)
        {
            if ((material != null) && (shader != null))
            {
                material.shader = shader;
            }
        }

        private static void ChangeShaderOnMaterials(TreeData treeData, Shader shader, TreeGroup group, NodeType nodeType)
        {
            if ((group is TreeGroupBranch) && (nodeType == NodeType.BarkNode))
            {
                TreeGroupBranch branch = group as TreeGroupBranch;
                ChangeShaderOnMaterial(branch.materialBranch, shader);
                ChangeShaderOnMaterial(branch.materialBreak, shader);
                ChangeShaderOnMaterial(branch.materialFrond, shader);
            }
            else if ((group is TreeGroupLeaf) && (nodeType == NodeType.LeafNode))
            {
                TreeGroupLeaf leaf = group as TreeGroupLeaf;
                ChangeShaderOnMaterial(leaf.materialLeaf, shader);
            }
            foreach (int num in group.childGroupIDs)
            {
                TreeGroup group2 = treeData.GetGroup(num);
                ChangeShaderOnMaterials(treeData, shader, group2, nodeType);
            }
        }

        private bool CheckForTooManyShaders(NodeType nodeType)
        {
            List<string> shadersListForNodeType = this.GetShadersListForNodeType(nodeType);
            List<string> shadersListOppositeToNodeType = this.GetShadersListOppositeToNodeType(nodeType);
            if ((shadersListForNodeType.Count <= 2) && ((shadersListForNodeType.Count != 2) || (shadersListOppositeToNodeType.Count <= 0)))
            {
                return false;
            }
            return true;
        }

        private void DisableAnimBool(string contentID)
        {
            if (this.m_AnimBools.ContainsKey(contentID))
            {
                this.m_AnimBools[contentID].target = false;
            }
        }

        public static string ExtractLabel(string uiString)
        {
            char[] separator = new char[] { '|' };
            return uiString.Split(separator)[0].Trim();
        }

        public static string ExtractTooltip(string uiString)
        {
            char[] separator = new char[] { '|' };
            string[] strArray = uiString.Split(separator);
            if (strArray.Length > 1)
            {
                return strArray[1].Trim();
            }
            return string.Empty;
        }

        private static void GetAllTreeShaders(TreeData treeData, List<string> barkShaders, List<string> leafShaders, TreeGroup group)
        {
            if (group is TreeGroupBranch)
            {
                TreeGroupBranch branch = group as TreeGroupBranch;
                AddShaderFromMaterial(branch.materialBranch, barkShaders, leafShaders);
                AddShaderFromMaterial(branch.materialBreak, barkShaders, leafShaders);
                AddShaderFromMaterial(branch.materialFrond, barkShaders, leafShaders);
            }
            else if (group is TreeGroupLeaf)
            {
                TreeGroupLeaf leaf = group as TreeGroupLeaf;
                AddShaderFromMaterial(leaf.materialLeaf, barkShaders, leafShaders);
            }
            foreach (int num in group.childGroupIDs)
            {
                TreeGroup group2 = treeData.GetGroup(num);
                GetAllTreeShaders(treeData, barkShaders, leafShaders, group2);
            }
        }

        private static string GetDefaultShader(NodeType nodeType)
        {
            if (nodeType == NodeType.BarkNode)
            {
                return "Nature/Tree Creator Bark";
            }
            return "Nature/Tree Creator Leaves Fast";
        }

        public static GUIContent GetGUIContent(string id)
        {
            if (s_Dictionary.ContainsKey(id))
            {
                return s_Dictionary[id];
            }
            string uIString = GetUIString(id);
            if (uIString == null)
            {
                return new GUIContent(id, string.Empty);
            }
            GUIContent content = new GUIContent(ExtractLabel(uIString), ExtractTooltip(uIString));
            s_Dictionary.Add(id, content);
            return content;
        }

        public static string GetOptimizedShaderName(Shader shader)
        {
            if (shader != null)
            {
                return ShaderUtil.GetDependency(shader, "OptimizedShader");
            }
            return null;
        }

        private List<string> GetRecommendedShaders(NodeType nodeType)
        {
            List<string> list = new List<string>(3);
            List<string> shadersListForNodeType = this.GetShadersListForNodeType(nodeType);
            List<string> shadersListOppositeToNodeType = this.GetShadersListOppositeToNodeType(nodeType);
            if ((shadersListForNodeType.Count == 1) || ((shadersListForNodeType.Count == 2) && (shadersListOppositeToNodeType.Count == 0)))
            {
                foreach (string str in shadersListForNodeType)
                {
                    list.Add(str);
                }
            }
            if (shadersListForNodeType.Count == 0)
            {
                list.Add(GetDefaultShader(nodeType));
            }
            return list;
        }

        private int GetSelectedIndex(string contentID)
        {
            if (!this.m_SelectedShader.ContainsKey(contentID))
            {
                this.m_SelectedShader.Add(contentID, 0);
            }
            return this.m_SelectedShader[contentID];
        }

        private List<string> GetShadersListForNodeType(NodeType nodeType)
        {
            if (nodeType == NodeType.BarkNode)
            {
                return this.m_BarkShaders;
            }
            return this.m_LeafShaders;
        }

        private List<string> GetShadersListOppositeToNodeType(NodeType nodeType)
        {
            if (nodeType == NodeType.BarkNode)
            {
                return this.GetShadersListForNodeType(NodeType.LeafNode);
            }
            return this.GetShadersListForNodeType(NodeType.BarkNode);
        }

        public static string GetUIString(string id)
        {
            return LocalizationDatabase.GetLocalizedString(id);
        }

        private int GUIShowError(string uniqueID, List<string> list, GUIContent message, GUIContent button, Texture2D icon)
        {
            int num = -1;
            if (this.m_AnimBools.ContainsKey(uniqueID))
            {
                if (EditorGUILayout.BeginFadeGroup(this.m_AnimBools[uniqueID].faded))
                {
                    GUILayout.BeginVertical(EditorStyles.helpBox, new GUILayoutOption[0]);
                    GUIContent content = message;
                    content.image = icon;
                    GUILayout.Label(content, EditorStyles.wordWrappedMiniLabel, new GUILayoutOption[0]);
                    GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                    int num2 = EditorGUILayout.Popup(this.GetSelectedIndex(uniqueID), list.ToArray(), new GUILayoutOption[0]);
                    this.SetSelectedIndex(uniqueID, num2);
                    if (GUILayout.Button(button, EditorStyles.miniButton, new GUILayoutOption[0]))
                    {
                        num = num2;
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.EndVertical();
                }
                EditorGUILayout.EndFadeGroup();
            }
            return num;
        }

        public bool GUITooManyShaders()
        {
            bool flag = this.GUITooManyShaders(NodeType.BarkNode) | this.GUITooManyShaders(NodeType.LeafNode);
            if (flag)
            {
                this.RefreshAllTreeShaders();
            }
            return flag;
        }

        private bool GUITooManyShaders(NodeType nodeType)
        {
            string contentID = nodeType.ToString();
            if (this.CheckForTooManyShaders(nodeType))
            {
                this.SetAnimBool(contentID, true, true);
            }
            List<string> shadersListForNodeType = this.GetShadersListForNodeType(nodeType);
            GUIContent message = (nodeType != NodeType.BarkNode) ? GetGUIContent("This tree uses multiple leaf shaders but only one leaf shader can be used on a tree. Select which leaf shader to apply to all the leaf materials used by this tree.|") : GetGUIContent("This tree uses multiple bark shaders but only one bark shader can be used on a tree. Select which bark shader to apply to all the bark materials used by this tree.|");
            GUIContent gUIContent = GetGUIContent("Apply|Will change the shader in all the materials on that node type to the one selected.");
            int num = this.GUIShowError(contentID, shadersListForNodeType, message, gUIContent, ConsoleWindow.iconError);
            if (num >= 0)
            {
                Shader shader = Shader.Find(shadersListForNodeType[num]);
                ChangeShaderOnMaterials(this.m_TreeData, shader, this.m_TreeData.root, nodeType);
                this.DisableAnimBool(contentID);
                this.RemoveSelectedIndex(contentID);
                return true;
            }
            return false;
        }

        public bool GUIWrongShader(string uniqueID, Material value, NodeType nodeType)
        {
            GUIContent gUIContent = GetGUIContent("This material does not use a tree shader. A tree shader has to contain the word 'leaves' or 'bark' in the name and the line: Dependency \"OptimizedShader\" = \"OPTIMIZED_SHADER_NAME\" in the code.|");
            GUIContent button = GetGUIContent("Apply|Will change the shader in the material to the one selected.");
            if (!IsMaterialCorrect(value))
            {
                List<string> recommendedShaders = this.GetRecommendedShaders(nodeType);
                this.m_WrongShaders.Add(uniqueID);
                this.SetAnimBool(uniqueID, true, true);
                int num = this.GUIShowError(uniqueID, recommendedShaders, gUIContent, button, ConsoleWindow.iconError);
                if (num >= 0)
                {
                    value.shader = Shader.Find(recommendedShaders[num]);
                    this.m_WrongShaders.Remove(uniqueID);
                    this.DisableAnimBool(uniqueID);
                    this.RemoveSelectedIndex(uniqueID);
                    return true;
                }
            }
            return false;
        }

        private static bool HasOptimizedShaderAndNameContains(Shader shader, string name)
        {
            return ((GetOptimizedShaderName(shader) != null) && shader.name.ToLower().Contains(name));
        }

        private static bool IsMaterialCorrect(Material material)
        {
            if ((material != null) && !IsTreeShader(material.shader))
            {
                return false;
            }
            return true;
        }

        public static bool IsTreeBarkShader(Shader shader)
        {
            return HasOptimizedShaderAndNameContains(shader, "bark");
        }

        public static bool IsTreeLeafShader(Shader shader)
        {
            return HasOptimizedShaderAndNameContains(shader, "leaves");
        }

        private static bool IsTreeShader(Shader shader)
        {
            return (IsTreeBarkShader(shader) || IsTreeLeafShader(shader));
        }

        public bool NodeHasWrongMaterial(TreeGroup group)
        {
            bool flag = false;
            if (group is TreeGroupBranch)
            {
                TreeGroupBranch branch = group as TreeGroupBranch;
                flag |= !IsMaterialCorrect(branch.materialBranch);
                flag |= !IsMaterialCorrect(branch.materialBreak);
                return (flag | !IsMaterialCorrect(branch.materialFrond));
            }
            if (group is TreeGroupLeaf)
            {
                TreeGroupLeaf leaf = group as TreeGroupLeaf;
                flag |= !IsMaterialCorrect(leaf.materialLeaf);
            }
            return flag;
        }

        public void OnEnable(TreeData treeData)
        {
            this.m_TreeData = treeData;
        }

        public void RefreshAllTreeShaders()
        {
            this.m_BarkShaders.Clear();
            this.m_LeafShaders.Clear();
            GetAllTreeShaders(this.m_TreeData, this.m_BarkShaders, this.m_LeafShaders, this.m_TreeData.root);
        }

        private void RemoveSelectedIndex(string contentID)
        {
            this.m_SelectedShader.Remove(contentID);
        }

        private void SetAnimBool(string contentID, bool target)
        {
            AnimBool @bool;
            if (!this.m_AnimBools.ContainsKey(contentID))
            {
                @bool = new AnimBool();
                this.m_AnimBools.Add(contentID, @bool);
            }
            else
            {
                @bool = this.m_AnimBools[contentID];
            }
            @bool.target = target;
        }

        private void SetAnimBool(string contentID, bool target, bool value)
        {
            this.SetAnimBool(contentID, target);
            this.m_AnimBools[contentID].value = value;
        }

        internal void SetAnimsCallback(UnityAction callback)
        {
            foreach (KeyValuePair<string, AnimBool> pair in this.m_AnimBools)
            {
                pair.Value.valueChanged.AddListener(callback);
            }
        }

        private void SetSelectedIndex(string contentID, int value)
        {
            if (this.m_SelectedShader.ContainsKey(contentID))
            {
                this.m_SelectedShader[contentID] = value;
            }
            else
            {
                this.m_SelectedShader.Add(contentID, value);
            }
        }

        internal static Shader DefaultOptimizedBarkShader
        {
            get
            {
                return Shader.Find("Hidden/Nature/Tree Creator Bark Optimized");
            }
        }

        internal static Shader DefaultOptimizedLeafShader
        {
            get
            {
                return Shader.Find("Hidden/Nature/Tree Creator Leaves Optimized");
            }
        }

        public enum NodeType
        {
            BarkNode,
            LeafNode
        }
    }
}

