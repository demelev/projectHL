﻿namespace System.Deployment.Internal.Isolation
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct StoreOperationSetDeploymentMetadata
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint Size;
        [MarshalAs(UnmanagedType.U4)]
        public OpFlags Flags;
        [MarshalAs(UnmanagedType.Interface)]
        public IDefinitionAppId Deployment;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr InstallerReference;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr cPropertiesToTest;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr PropertiesToTest;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr cPropertiesToSet;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr PropertiesToSet;
        public StoreOperationSetDeploymentMetadata(IDefinitionAppId Deployment, StoreApplicationReference Reference, StoreOperationMetadataProperty[] SetProperties) : this(Deployment, Reference, SetProperties, null)
        {
        }

        public StoreOperationSetDeploymentMetadata(IDefinitionAppId Deployment, StoreApplicationReference Reference, StoreOperationMetadataProperty[] SetProperties, StoreOperationMetadataProperty[] TestProperties)
        {
            this.Size = (uint) Marshal.SizeOf(typeof(StoreOperationSetDeploymentMetadata));
            this.Flags = OpFlags.Nothing;
            this.Deployment = Deployment;
            if (SetProperties != null)
            {
                this.PropertiesToSet = MarshalProperties(SetProperties);
                this.cPropertiesToSet = new IntPtr(SetProperties.Length);
            }
            else
            {
                this.PropertiesToSet = IntPtr.Zero;
                this.cPropertiesToSet = IntPtr.Zero;
            }
            if (TestProperties != null)
            {
                this.PropertiesToTest = MarshalProperties(TestProperties);
                this.cPropertiesToTest = new IntPtr(TestProperties.Length);
            }
            else
            {
                this.PropertiesToTest = IntPtr.Zero;
                this.cPropertiesToTest = IntPtr.Zero;
            }
            this.InstallerReference = Reference.ToIntPtr();
        }

        public void Destroy()
        {
            if (this.PropertiesToSet != IntPtr.Zero)
            {
                DestroyProperties(this.PropertiesToSet, (ulong) this.cPropertiesToSet.ToInt64());
                this.PropertiesToSet = IntPtr.Zero;
                this.cPropertiesToSet = IntPtr.Zero;
            }
            if (this.PropertiesToTest != IntPtr.Zero)
            {
                DestroyProperties(this.PropertiesToTest, (ulong) this.cPropertiesToTest.ToInt64());
                this.PropertiesToTest = IntPtr.Zero;
                this.cPropertiesToTest = IntPtr.Zero;
            }
            if (this.InstallerReference != IntPtr.Zero)
            {
                StoreApplicationReference.Destroy(this.InstallerReference);
                this.InstallerReference = IntPtr.Zero;
            }
        }

        private static void DestroyProperties(IntPtr rgItems, ulong iItems)
        {
            if (rgItems != IntPtr.Zero)
            {
                ulong num = (ulong) Marshal.SizeOf(typeof(StoreOperationMetadataProperty));
                for (ulong i = 0L; i < iItems; i += (ulong) 1L)
                {
                    Marshal.DestroyStructure(new IntPtr(((long) (i * num)) + rgItems.ToInt64()), typeof(StoreOperationMetadataProperty));
                }
                Marshal.FreeCoTaskMem(rgItems);
            }
        }

        private static IntPtr MarshalProperties(StoreOperationMetadataProperty[] Props)
        {
            if ((Props == null) || (Props.Length == 0))
            {
                return IntPtr.Zero;
            }
            int num = Marshal.SizeOf(typeof(StoreOperationMetadataProperty));
            IntPtr ptr = Marshal.AllocCoTaskMem(num * Props.Length);
            for (int i = 0; i != Props.Length; i++)
            {
                Marshal.StructureToPtr(Props[i], new IntPtr((i * num) + ptr.ToInt64()), false);
            }
            return ptr;
        }
        public enum Disposition
        {
            Failed = 0,
            Set = 2
        }

        [Flags]
        public enum OpFlags
        {
            Nothing
        }
    }
}

