﻿namespace UnityEditor
{
    using System;
    using UnityEngine;

    [CustomEditor(typeof(ParticleRenderer)), CanEditMultipleObjects]
    internal class ParticleRendererEditor : RendererEditorBase
    {
        public override void OnEnable()
        {
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            base.serializedObject.Update();
            Editor.DrawPropertiesExcluding(base.serializedObject, new string[0]);
            base.serializedObject.ApplyModifiedProperties();
        }
    }
}

