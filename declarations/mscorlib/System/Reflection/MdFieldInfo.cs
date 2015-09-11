﻿namespace System.Reflection
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.Serialization;

    [Serializable]
    internal sealed class MdFieldInfo : RuntimeFieldInfo, ISerializable
    {
        private FieldAttributes m_fieldAttributes;
        private Type m_fieldType;
        private string m_name;
        private int m_tkField;

        internal MdFieldInfo(int tkField, FieldAttributes fieldAttributes, RuntimeTypeHandle declaringTypeHandle, RuntimeType.RuntimeTypeCache reflectedTypeCache, BindingFlags bindingFlags) : base(reflectedTypeCache, declaringTypeHandle.GetRuntimeType(), bindingFlags)
        {
            this.m_tkField = tkField;
            this.m_name = null;
            this.m_fieldAttributes = fieldAttributes;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        internal override bool CacheEquals(object o)
        {
            MdFieldInfo info = o as MdFieldInfo;
            if (info == null)
            {
                return false;
            }
            return ((info.m_tkField == this.m_tkField) && base.m_declaringType.GetTypeHandleInternal().GetModuleHandle().Equals(info.m_declaringType.GetTypeHandleInternal().GetModuleHandle()));
        }

        public override Type[] GetOptionalCustomModifiers()
        {
            return new Type[0];
        }

        public override object GetRawConstantValue()
        {
            return this.GetValue(true);
        }

        public override Type[] GetRequiredCustomModifiers()
        {
            return new Type[0];
        }

        internal object GetValue(bool raw)
        {
            object obj2 = MdConstant.GetValue(this.Module.MetadataImport, this.m_tkField, this.FieldType.GetTypeHandleInternal(), raw);
            if (obj2 == DBNull.Value)
            {
                throw new NotSupportedException(Environment.GetResourceString("Arg_EnumLitValueNotFound"));
            }
            return obj2;
        }

        [DebuggerStepThrough, DebuggerHidden]
        public override object GetValue(object obj)
        {
            return this.GetValue(false);
        }

        [DebuggerStepThrough, DebuggerHidden]
        public override object GetValueDirect(TypedReference obj)
        {
            return this.GetValue(null);
        }

        [DebuggerStepThrough, DebuggerHidden]
        public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
        {
            throw new FieldAccessException(Environment.GetResourceString("Acc_ReadOnly"));
        }

        [DebuggerStepThrough, DebuggerHidden]
        public override void SetValueDirect(TypedReference obj, object value)
        {
            throw new FieldAccessException(Environment.GetResourceString("Acc_ReadOnly"));
        }

        public override FieldAttributes Attributes
        {
            get
            {
                return this.m_fieldAttributes;
            }
        }

        public override RuntimeFieldHandle FieldHandle
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override Type FieldType
        {
            get
            {
                if (this.m_fieldType == null)
                {
                    ConstArray sigOfFieldDef = this.Module.MetadataImport.GetSigOfFieldDef(this.m_tkField);
                    void* pCorSig = sigOfFieldDef.Signature.ToPointer();
                    this.m_fieldType = new Signature(pCorSig, sigOfFieldDef.Length, base.m_declaringType.GetTypeHandleInternal()).FieldTypeHandle.GetRuntimeType();
                }
                return this.m_fieldType;
            }
        }

        public override int MetadataToken
        {
            get
            {
                return this.m_tkField;
            }
        }

        public override System.Reflection.Module Module
        {
            get
            {
                return base.m_declaringType.Module;
            }
        }

        public override string Name
        {
            get
            {
                if (this.m_name == null)
                {
                    this.m_name = this.Module.MetadataImport.GetName(this.m_tkField).ToString();
                }
                return this.m_name;
            }
        }
    }
}

