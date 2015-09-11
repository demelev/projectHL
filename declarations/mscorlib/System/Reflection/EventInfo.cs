﻿namespace System.Reflection
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;

    [Serializable, ClassInterface(ClassInterfaceType.None), ComDefaultInterface(typeof(_EventInfo)), ComVisible(true), PermissionSet(SecurityAction.InheritanceDemand, Name="FullTrust")]
    public abstract class EventInfo : MemberInfo, _EventInfo
    {
        protected EventInfo()
        {
        }

        [DebuggerStepThrough, DebuggerHidden]
        public void AddEventHandler(object target, Delegate handler)
        {
            MethodInfo addMethod = this.GetAddMethod();
            if (addMethod == null)
            {
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoPublicAddMethod"));
            }
            addMethod.Invoke(target, new object[] { handler });
        }

        public MethodInfo GetAddMethod()
        {
            return this.GetAddMethod(false);
        }

        public abstract MethodInfo GetAddMethod(bool nonPublic);
        public MethodInfo[] GetOtherMethods()
        {
            return this.GetOtherMethods(false);
        }

        public virtual MethodInfo[] GetOtherMethods(bool nonPublic)
        {
            throw new NotImplementedException();
        }

        public MethodInfo GetRaiseMethod()
        {
            return this.GetRaiseMethod(false);
        }

        public abstract MethodInfo GetRaiseMethod(bool nonPublic);
        public MethodInfo GetRemoveMethod()
        {
            return this.GetRemoveMethod(false);
        }

        public abstract MethodInfo GetRemoveMethod(bool nonPublic);
        [DebuggerStepThrough, DebuggerHidden]
        public void RemoveEventHandler(object target, Delegate handler)
        {
            MethodInfo removeMethod = this.GetRemoveMethod();
            if (removeMethod == null)
            {
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoPublicRemoveMethod"));
            }
            removeMethod.Invoke(target, new object[] { handler });
        }

        void _EventInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
        {
            throw new NotImplementedException();
        }

        Type _EventInfo.GetType()
        {
            return base.GetType();
        }

        void _EventInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
        {
            throw new NotImplementedException();
        }

        void _EventInfo.GetTypeInfoCount(out uint pcTInfo)
        {
            throw new NotImplementedException();
        }

        void _EventInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
        {
            throw new NotImplementedException();
        }

        public abstract EventAttributes Attributes { get; }

        public Type EventHandlerType
        {
            get
            {
                ParameterInfo[] parametersNoCopy = this.GetAddMethod(true).GetParametersNoCopy();
                Type c = typeof(Delegate);
                for (int i = 0; i < parametersNoCopy.Length; i++)
                {
                    Type parameterType = parametersNoCopy[i].ParameterType;
                    if (parameterType.IsSubclassOf(c))
                    {
                        return parameterType;
                    }
                }
                return null;
            }
        }

        public bool IsMulticast
        {
            get
            {
                Type eventHandlerType = this.EventHandlerType;
                Type type2 = typeof(MulticastDelegate);
                return type2.IsAssignableFrom(eventHandlerType);
            }
        }

        public bool IsSpecialName
        {
            get
            {
                return ((this.Attributes & EventAttributes.SpecialName) != EventAttributes.None);
            }
        }

        public override MemberTypes MemberType
        {
            get
            {
                return MemberTypes.Event;
            }
        }
    }
}

