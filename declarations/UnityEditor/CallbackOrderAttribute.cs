﻿namespace UnityEditor
{
    using System;

    public abstract class CallbackOrderAttribute : Attribute
    {
        protected int m_CallbackOrder;

        protected CallbackOrderAttribute()
        {
        }

        internal int callbackOrder
        {
            get
            {
                return this.m_CallbackOrder;
            }
        }
    }
}

