﻿namespace System.Deployment.Internal.Isolation
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct BLOB : IDisposable
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint Size;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr BlobData;
        public void Dispose()
        {
            if (this.BlobData != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(this.BlobData);
                this.BlobData = IntPtr.Zero;
            }
        }
    }
}

