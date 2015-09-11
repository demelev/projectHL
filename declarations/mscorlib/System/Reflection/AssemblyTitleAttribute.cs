﻿namespace System.Reflection
{
    using System;
    using System.Runtime.InteropServices;

    [AttributeUsage(AttributeTargets.Assembly, Inherited=false), ComVisible(true)]
    public sealed class AssemblyTitleAttribute : Attribute
    {
        private string m_title;

        public AssemblyTitleAttribute(string title)
        {
            this.m_title = title;
        }

        public string Title
        {
            get
            {
                return this.m_title;
            }
        }
    }
}

