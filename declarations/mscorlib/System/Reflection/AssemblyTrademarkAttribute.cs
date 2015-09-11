﻿namespace System.Reflection
{
    using System;
    using System.Runtime.InteropServices;

    [ComVisible(true), AttributeUsage(AttributeTargets.Assembly, Inherited=false)]
    public sealed class AssemblyTrademarkAttribute : Attribute
    {
        private string m_trademark;

        public AssemblyTrademarkAttribute(string trademark)
        {
            this.m_trademark = trademark;
        }

        public string Trademark
        {
            get
            {
                return this.m_trademark;
            }
        }
    }
}

