﻿namespace UnityEditor
{
    using System;
    using UnityEngine;

    [CustomEditor(typeof(RenderSettings))]
    internal class OtherRenderingEditor : Editor
    {
        private const string kShowEditorKey = "ShowOtherRenderingEditorFoldout";
        protected SerializedProperty m_FlareFadeSpeed;
        protected SerializedProperty m_FlareStrength;
        protected SerializedProperty m_HaloStrength;
        protected SerializedProperty m_HaloTexture;
        private bool m_ShowEditor;
        protected SerializedProperty m_SpotCookie;

        public virtual void OnDisable()
        {
            SessionState.SetBool("ShowOtherRenderingEditorFoldout", this.m_ShowEditor);
        }

        public virtual void OnEnable()
        {
            this.m_HaloStrength = base.serializedObject.FindProperty("m_HaloStrength");
            this.m_FlareStrength = base.serializedObject.FindProperty("m_FlareStrength");
            this.m_FlareFadeSpeed = base.serializedObject.FindProperty("m_FlareFadeSpeed");
            this.m_HaloTexture = base.serializedObject.FindProperty("m_HaloTexture");
            this.m_SpotCookie = base.serializedObject.FindProperty("m_SpotCookie");
            this.m_ShowEditor = SessionState.GetBool("ShowOtherRenderingEditorFoldout", false);
        }

        public override void OnInspectorGUI()
        {
            base.serializedObject.Update();
            EditorGUILayout.Space();
            this.m_ShowEditor = EditorGUILayout.FoldoutTitlebar(this.m_ShowEditor, Styles.otherHeader);
            if (this.m_ShowEditor)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(this.m_HaloTexture, new GUILayoutOption[0]);
                EditorGUILayout.Slider(this.m_HaloStrength, 0f, 1f, new GUILayoutOption[0]);
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(this.m_FlareFadeSpeed, new GUILayoutOption[0]);
                EditorGUILayout.Slider(this.m_FlareStrength, 0f, 1f, new GUILayoutOption[0]);
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(this.m_SpotCookie, new GUILayoutOption[0]);
                EditorGUI.indentLevel--;
                base.serializedObject.ApplyModifiedProperties();
            }
        }

        internal class Styles
        {
            public static readonly GUIContent otherHeader = EditorGUIUtility.TextContent("Other Settings");
        }
    }
}

