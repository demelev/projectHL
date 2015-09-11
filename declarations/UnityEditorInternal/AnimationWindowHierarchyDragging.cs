namespace UnityEditorInternal
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEditor;
    using UnityEngine;

    internal class AnimationWindowHierarchyDragging : ITreeViewDragging
    {
        public void DragCleanup(bool revertExpanded)
        {
        }

        public bool DragElement(TreeViewItem targetItem, Rect targetItemRect, bool firstItem)
        {
            return false;
        }

        public int GetDropTargetControlID()
        {
            return 0;
        }

        public int GetRowMarkerControlID()
        {
            return 0;
        }

        public void StartDrag(TreeViewItem draggedItem, List<int> draggedItemIDs)
        {
        }

        public bool drawRowMarkerAbove { get; set; }
    }
}

