﻿namespace System
{
    using System.Reflection;
    using System.Runtime.InteropServices;

    [AttributeUsage(AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Class, Inherited=false), ComVisible(true)]
    public sealed class SerializableAttribute : Attribute
    {
        internal static Attribute GetCustomAttribute(Type type)
        {
            if ((type.Attributes & TypeAttributes.Serializable) != TypeAttributes.Serializable)
            {
                return null;
            }
            return new SerializableAttribute();
        }

        internal static bool IsDefined(Type type)
        {
            return type.IsSerializable;
        }
    }
}

