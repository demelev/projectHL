﻿namespace UnityEditor
{
    using System;
    using System.Runtime.InteropServices;
    using UnityEngine;

    [StructLayout(LayoutKind.Sequential)]
    public sealed class PropertyModification
    {
        public UnityEngine.Object target;
        public string propertyPath;
        public string value;
        public UnityEngine.Object objectReference;
    }
}

