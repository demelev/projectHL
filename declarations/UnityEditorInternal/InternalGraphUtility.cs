namespace UnityEditorInternal
{
    using System;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public sealed class InternalGraphUtility
    {
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern int[] AllGraphsInScene();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern int[] AllGraphsOnGameObject(GameObject go);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern string GenerateGraphName();
    }
}

