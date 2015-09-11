﻿namespace UnityEditor
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public sealed class AssetsItem
    {
        public string guid;
        public string parentGuid;
        public string pathName;
        public string message;
        public string exportedAssetPath;
        public string guidFolder;
        public int enabled;
        public int assetIsDir;
        public int changeFlags;
        public string previewPath;
        public int exists;
    }
}

