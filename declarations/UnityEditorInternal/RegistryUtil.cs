namespace UnityEditorInternal
{
    using System;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public sealed class RegistryUtil
    {
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetRegistryStringValue32(string subKey, string valueName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern uint GetRegistryUInt32Value32(string subKey, string valueName);
    }
}

