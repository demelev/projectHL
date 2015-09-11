﻿namespace System.Deployment.Internal.Isolation
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, Guid("0af57545-a72a-4fbe-813c-8554ed7d4528"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IActContext
    {
        void GetAppId([MarshalAs(UnmanagedType.Interface)] out object AppId);
        void EnumCategories([In] uint Flags, [In] IReferenceIdentity CategoryToMatch, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object EnumOut);
        void EnumSubcategories([In] uint Flags, [In] IDefinitionIdentity CategoryId, [In, MarshalAs(UnmanagedType.LPWStr)] string SubcategoryPattern, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object EnumOut);
        void EnumCategoryInstances([In] uint Flags, [In] IDefinitionIdentity CategoryId, [In, MarshalAs(UnmanagedType.LPWStr)] string Subcategory, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object EnumOut);
        void ReplaceStringMacros([In] uint Flags, [In, MarshalAs(UnmanagedType.LPWStr)] string Culture, [In, MarshalAs(UnmanagedType.LPWStr)] string ReplacementPattern, [MarshalAs(UnmanagedType.LPWStr)] out string Replaced);
        void GetComponentStringTableStrings([In] uint Flags, [In, MarshalAs(UnmanagedType.SysUInt)] IntPtr ComponentIndex, [In, MarshalAs(UnmanagedType.SysUInt)] IntPtr StringCount, [Out, MarshalAs(UnmanagedType.LPArray)] string[] SourceStrings, [MarshalAs(UnmanagedType.LPArray)] out string[] DestinationStrings, [In, MarshalAs(UnmanagedType.SysUInt)] IntPtr CultureFallbacks);
        void GetApplicationProperties([In] uint Flags, [In] UIntPtr cProperties, [In, MarshalAs(UnmanagedType.LPArray)] string[] PropertyNames, [MarshalAs(UnmanagedType.LPArray)] out string[] PropertyValues, [MarshalAs(UnmanagedType.LPArray)] out UIntPtr[] ComponentIndicies);
        void ApplicationBasePath([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] out string ApplicationPath);
        void GetComponentManifest([In] uint Flags, [In] IDefinitionIdentity ComponentId, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ManifestInteface);
        void GetComponentPayloadPath([In] uint Flags, [In] IDefinitionIdentity ComponentId, [MarshalAs(UnmanagedType.LPWStr)] out string PayloadPath);
        void FindReferenceInContext([In] uint dwFlags, [In] IReferenceIdentity Reference, [MarshalAs(UnmanagedType.Interface)] out object MatchedDefinition);
        void CreateActContextFromCategoryInstance([In] uint dwFlags, [In] ref CATEGORY_INSTANCE CategoryInstance, [MarshalAs(UnmanagedType.Interface)] out object ppCreatedAppContext);
        void EnumComponents([In] uint dwFlags, [MarshalAs(UnmanagedType.Interface)] out object ppIdentityEnum);
        void PrepareForExecution([In, MarshalAs(UnmanagedType.SysInt)] IntPtr Inputs, [In, MarshalAs(UnmanagedType.SysInt)] IntPtr Outputs);
        void SetApplicationRunningState([In] uint dwFlags, [In] uint ulState, out uint ulDisposition);
        void GetApplicationStateFilesystemLocation([In] uint dwFlags, [In] UIntPtr Component, [In, MarshalAs(UnmanagedType.SysInt)] IntPtr pCoordinateList, [MarshalAs(UnmanagedType.LPWStr)] out string ppszPath);
        void FindComponentsByDefinition([In] uint dwFlags, [In] UIntPtr ComponentCount, [In, MarshalAs(UnmanagedType.LPArray)] IDefinitionIdentity[] Components, [Out, MarshalAs(UnmanagedType.LPArray)] UIntPtr[] Indicies, [Out, MarshalAs(UnmanagedType.LPArray)] uint[] Dispositions);
        void FindComponentsByReference([In] uint dwFlags, [In] UIntPtr Components, [In, MarshalAs(UnmanagedType.LPArray)] IReferenceIdentity[] References, [Out, MarshalAs(UnmanagedType.LPArray)] UIntPtr[] Indicies, [Out, MarshalAs(UnmanagedType.LPArray)] uint[] Dispositions);
    }
}

