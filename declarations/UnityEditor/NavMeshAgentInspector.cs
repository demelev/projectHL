﻿namespace UnityEditor
{
    using System;
    using UnityEngine;

    [CanEditMultipleObjects, CustomEditor(typeof(NavMeshAgent))]
    internal class NavMeshAgentInspector : Editor
    {
        private SerializedProperty m_Acceleration;
        private SerializedProperty m_AngularSpeed;
        private SerializedProperty m_AutoBraking;
        private SerializedProperty m_AutoRepath;
        private SerializedProperty m_AutoTraverseOffMeshLink;
        private SerializedProperty m_AvoidancePriority;
        private SerializedProperty m_BaseOffset;
        private SerializedProperty m_Height;
        private SerializedProperty m_ObstacleAvoidanceType;
        private SerializedProperty m_Radius;
        private SerializedProperty m_Speed;
        private SerializedProperty m_StoppingDistance;
        private SerializedProperty m_WalkableMask;
        private static Styles s_Styles;

        private void OnEnable()
        {
            this.m_WalkableMask = base.serializedObject.FindProperty("m_WalkableMask");
            this.m_Radius = base.serializedObject.FindProperty("m_Radius");
            this.m_Speed = base.serializedObject.FindProperty("m_Speed");
            this.m_Acceleration = base.serializedObject.FindProperty("m_Acceleration");
            this.m_AngularSpeed = base.serializedObject.FindProperty("m_AngularSpeed");
            this.m_StoppingDistance = base.serializedObject.FindProperty("m_StoppingDistance");
            this.m_AutoTraverseOffMeshLink = base.serializedObject.FindProperty("m_AutoTraverseOffMeshLink");
            this.m_AutoBraking = base.serializedObject.FindProperty("m_AutoBraking");
            this.m_AutoRepath = base.serializedObject.FindProperty("m_AutoRepath");
            this.m_Height = base.serializedObject.FindProperty("m_Height");
            this.m_BaseOffset = base.serializedObject.FindProperty("m_BaseOffset");
            this.m_ObstacleAvoidanceType = base.serializedObject.FindProperty("m_ObstacleAvoidanceType");
            this.m_AvoidancePriority = base.serializedObject.FindProperty("avoidancePriority");
        }

        public override void OnInspectorGUI()
        {
            if (s_Styles == null)
            {
                s_Styles = new Styles();
            }
            base.serializedObject.Update();
            EditorGUILayout.LabelField(s_Styles.m_AgentSizeHeader, EditorStyles.boldLabel, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_Radius, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_Height, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_BaseOffset, new GUILayoutOption[0]);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(s_Styles.m_AgentSteeringHeader, EditorStyles.boldLabel, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_Speed, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_AngularSpeed, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_Acceleration, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_StoppingDistance, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_AutoBraking, new GUILayoutOption[0]);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(s_Styles.m_AgentAvoidanceHeader, EditorStyles.boldLabel, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_ObstacleAvoidanceType, GUIContent.Temp("Quality"), new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_AvoidancePriority, GUIContent.Temp("Priority"), new GUILayoutOption[0]);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(s_Styles.m_AgentPathFindingHeader, EditorStyles.boldLabel, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_AutoTraverseOffMeshLink, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_AutoRepath, new GUILayoutOption[0]);
            string[] navMeshAreaNames = GameObjectUtility.GetNavMeshAreaNames();
            long longValue = this.m_WalkableMask.longValue;
            int mask = 0;
            for (int i = 0; i < navMeshAreaNames.Length; i++)
            {
                int navMeshAreaFromName = GameObjectUtility.GetNavMeshAreaFromName(navMeshAreaNames[i]);
                if (((((int) 1) << navMeshAreaFromName) & longValue) != 0)
                {
                    mask |= ((int) 1) << i;
                }
            }
            Rect position = GUILayoutUtility.GetRect(EditorGUILayout.kLabelFloatMinW, EditorGUILayout.kLabelFloatMaxW, 16f, 16f, EditorStyles.layerMaskField);
            EditorGUI.BeginChangeCheck();
            EditorGUI.showMixedValue = this.m_WalkableMask.hasMultipleDifferentValues;
            int num6 = EditorGUI.MaskField(position, "Area Mask", mask, navMeshAreaNames, EditorStyles.layerMaskField);
            EditorGUI.showMixedValue = false;
            if (EditorGUI.EndChangeCheck())
            {
                if (num6 == -1)
                {
                    this.m_WalkableMask.longValue = 0xffffffffL;
                }
                else
                {
                    uint num7 = 0;
                    for (int j = 0; j < navMeshAreaNames.Length; j++)
                    {
                        if (((num6 >> j) & 1) != 0)
                        {
                            num7 |= ((uint) 1) << GameObjectUtility.GetNavMeshAreaFromName(navMeshAreaNames[j]);
                        }
                    }
                    this.m_WalkableMask.longValue = num7;
                }
            }
            base.serializedObject.ApplyModifiedProperties();
        }

        private class Styles
        {
            public readonly GUIContent m_AgentAvoidanceHeader = new GUIContent("Obstacle Avoidance");
            public readonly GUIContent m_AgentPathFindingHeader = new GUIContent("Path Finding");
            public readonly GUIContent m_AgentSizeHeader = new GUIContent("Agent Size");
            public readonly GUIContent m_AgentSteeringHeader = new GUIContent("Steering");
        }
    }
}

