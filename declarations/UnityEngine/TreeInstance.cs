﻿namespace UnityEngine
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TreeInstance
    {
        public Vector3 position;
        public float widthScale;
        public float heightScale;
        public float rotation;
        public Color32 color;
        public Color32 lightmapColor;
        public int prototypeIndex;
        internal float temporaryDistance;
    }
}

