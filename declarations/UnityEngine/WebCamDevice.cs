﻿namespace UnityEngine
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct WebCamDevice
    {
        internal string m_Name;
        internal int m_Flags;
        public string name
        {
            get
            {
                return this.m_Name;
            }
        }
        public bool isFrontFacing
        {
            get
            {
                return ((this.m_Flags & 1) == 1);
            }
        }
    }
}

