﻿namespace UnityEditor
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;

    internal class EditorCache : IDisposable
    {
        private Dictionary<UnityEngine.Object, EditorWrapper> m_EditorCache;
        private EditorFeatures m_Requirements;
        private Dictionary<UnityEngine.Object, bool> m_UsedEditors;

        public EditorCache() : this(EditorFeatures.None)
        {
        }

        public EditorCache(EditorFeatures requirements)
        {
            this.m_Requirements = requirements;
            this.m_EditorCache = new Dictionary<UnityEngine.Object, EditorWrapper>();
            this.m_UsedEditors = new Dictionary<UnityEngine.Object, bool>();
        }

        public void CleanupAllEditors()
        {
            this.m_UsedEditors.Clear();
            this.CleanupUntouchedEditors();
        }

        public void CleanupUntouchedEditors()
        {
            List<UnityEngine.Object> list = new List<UnityEngine.Object>();
            foreach (UnityEngine.Object obj2 in this.m_EditorCache.Keys)
            {
                if (!this.m_UsedEditors.ContainsKey(obj2))
                {
                    list.Add(obj2);
                }
            }
            if (this.m_EditorCache != null)
            {
                foreach (UnityEngine.Object obj3 in list)
                {
                    EditorWrapper wrapper = this.m_EditorCache[obj3];
                    this.m_EditorCache.Remove(obj3);
                    if (wrapper != null)
                    {
                        wrapper.Dispose();
                    }
                }
            }
            this.m_UsedEditors.Clear();
        }

        public void Dispose()
        {
            this.CleanupAllEditors();
            GC.SuppressFinalize(this);
        }

        ~EditorCache()
        {
            Debug.LogError("Failed to dispose EditorCache.");
        }

        public EditorWrapper this[UnityEngine.Object o]
        {
            get
            {
                this.m_UsedEditors[o] = true;
                if (this.m_EditorCache.ContainsKey(o))
                {
                    return this.m_EditorCache[o];
                }
                EditorWrapper wrapper2 = EditorWrapper.Make(o, this.m_Requirements);
                this.m_EditorCache[o] = wrapper2;
                return wrapper2;
            }
        }
    }
}

