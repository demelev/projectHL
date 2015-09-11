namespace UnityEditorInternal
{
    using System;
    using System.Runtime.CompilerServices;
    using UnityEditor;
    using UnityEngine;

    internal class AddCurvesPopupHierarchyGUI : TreeViewGUI
    {
        public EditorWindow owner;
        private GUIStyle plusButtonBackgroundStyle;
        private GUIStyle plusButtonStyle;
        private const float plusButtonWidth = 17f;

        public AddCurvesPopupHierarchyGUI(TreeView treeView, AnimationWindowState state, EditorWindow owner) : base(treeView, true)
        {
            this.plusButtonStyle = new GUIStyle("OL Plus");
            this.plusButtonBackgroundStyle = new GUIStyle("Tag MenuItem");
            this.owner = owner;
            this.state = state;
        }

        public override bool BeginRename(TreeViewItem item, float delay)
        {
            return false;
        }

        protected override Texture GetIconForNode(TreeViewItem item)
        {
            if (item != null)
            {
                return item.icon;
            }
            return null;
        }

        protected override bool IsRenaming(int id)
        {
            return false;
        }

        public override Rect OnRowGUI(TreeViewItem node, int row, float rowWidth, bool selected, bool focused)
        {
            Rect rect = base.OnRowGUI(node, row, rowWidth, selected, focused);
            Rect position = new Rect(rowWidth - 17f, rect.yMin, 17f, this.plusButtonStyle.fixedHeight);
            AddCurvesPopupPropertyNode node2 = node as AddCurvesPopupPropertyNode;
            if (((node2 != null) && (node2.curveBindings != null)) && (node2.curveBindings.Length != 0))
            {
                GUI.Box(position, GUIContent.none, this.plusButtonBackgroundStyle);
                if (GUI.Button(position, GUIContent.none, this.plusButtonStyle))
                {
                    AddCurvesPopup.AddNewCurve(node2);
                    this.owner.Close();
                    base.m_TreeView.ReloadData();
                }
            }
            return rect;
        }

        protected override void RenameEnded()
        {
        }

        protected override void SyncFakeItem()
        {
        }

        public bool showPlusButton { get; set; }

        public AnimationWindowState state { get; set; }
    }
}

