﻿namespace System.Deployment.Internal.Isolation.Manifest
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal class MuiResourceTypeIdStringEntry : IDisposable
    {
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr StringIds;
        public uint StringIdsSize;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr IntegerIds;
        public uint IntegerIdsSize;
        ~MuiResourceTypeIdStringEntry()
        {
            this.Dispose(false);
        }

        void IDisposable.Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool fDisposing)
        {
            if (this.StringIds != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(this.StringIds);
                this.StringIds = IntPtr.Zero;
            }
            if (this.IntegerIds != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(this.IntegerIds);
                this.IntegerIds = IntPtr.Zero;
            }
            if (fDisposing)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}

