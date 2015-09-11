﻿namespace System.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [ComVisible(true)]
    public sealed class MethodBody
    {
        private ExceptionHandlingClause[] m_exceptionHandlingClauses;
        private byte[] m_IL;
        private bool m_initLocals;
        private int m_localSignatureMetadataToken;
        private LocalVariableInfo[] m_localVariables;
        private int m_maxStackSize;
        internal MethodBase m_methodBase;

        private MethodBody()
        {
        }

        public byte[] GetILAsByteArray()
        {
            return this.m_IL;
        }

        public IList<ExceptionHandlingClause> ExceptionHandlingClauses
        {
            get
            {
                return Array.AsReadOnly<ExceptionHandlingClause>(this.m_exceptionHandlingClauses);
            }
        }

        public bool InitLocals
        {
            get
            {
                return this.m_initLocals;
            }
        }

        public int LocalSignatureMetadataToken
        {
            get
            {
                return this.m_localSignatureMetadataToken;
            }
        }

        public IList<LocalVariableInfo> LocalVariables
        {
            get
            {
                return Array.AsReadOnly<LocalVariableInfo>(this.m_localVariables);
            }
        }

        public int MaxStackSize
        {
            get
            {
                return this.m_maxStackSize;
            }
        }
    }
}

