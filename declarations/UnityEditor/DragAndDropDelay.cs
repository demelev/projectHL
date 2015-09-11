﻿namespace UnityEditor
{
    using System;
    using UnityEngine;

    internal class DragAndDropDelay
    {
        public Vector2 mouseDownPosition;

        public bool CanStartDrag()
        {
            return (Vector2.Distance(this.mouseDownPosition, Event.current.mousePosition) > 6f);
        }
    }
}

