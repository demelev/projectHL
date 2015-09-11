﻿namespace UnityEditor
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    internal class CollisionModuleUI : ModuleUI
    {
        private const int k_MaxNumPlanes = 6;
        private SerializedProperty m_Bounce;
        private SerializedProperty m_CollidesWith;
        private SerializedProperty m_CollisionMessages;
        private SerializedProperty m_Dampen;
        private SerializedProperty m_LifetimeLossOnCollision;
        private SerializedProperty m_MinKillSpeed;
        private SerializedProperty m_ParticleRadius;
        private SerializedProperty[] m_Planes;
        private PlaneVizType m_PlaneVisualizationType;
        private string[] m_PlaneVizTypeNames;
        private SerializedProperty m_Quality;
        private float m_ScaleGrid;
        private static Transform m_SelectedTransform;
        private SerializedProperty[] m_ShownPlanes;
        private SerializedProperty m_Type;
        private SerializedProperty m_VoxelSize;
        private static Texts s_Texts;

        public CollisionModuleUI(ParticleSystemUI owner, SerializedObject o, string displayName) : base(owner, o, "CollisionModule", displayName)
        {
            this.m_PlaneVizTypeNames = new string[] { "Grid", "Solid" };
            this.m_Planes = new SerializedProperty[6];
            this.m_PlaneVisualizationType = PlaneVizType.Solid;
            this.m_ScaleGrid = 1f;
            base.m_ToolTip = "Allows you to specify multiple collision planes that the particle can collide with.";
        }

        private static GameObject CreateEmptyGameObject(string name, ParticleSystem parentOfGameObject)
        {
            GameObject obj2 = new GameObject(name);
            if (obj2 == null)
            {
                return null;
            }
            if (parentOfGameObject != null)
            {
                obj2.transform.parent = parentOfGameObject.transform;
            }
            return obj2;
        }

        private void DoListOfPlanesGUI()
        {
            int index = base.GUIListOfFloatObjectToggleFields(s_Texts.planes, this.m_ShownPlanes, null, s_Texts.createPlane, true);
            if (index >= 0)
            {
                GameObject obj2 = CreateEmptyGameObject("Plane Transform " + (index + 1), base.m_ParticleSystemUI.m_ParticleSystem);
                obj2.transform.localPosition = new Vector3(0f, 0f, (float) (10 + index));
                obj2.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
                this.m_ShownPlanes[index].objectReferenceValue = obj2;
                this.SyncVisualization();
            }
            Rect position = GUILayoutUtility.GetRect((float) 0f, (float) 16f);
            position.x = (position.xMax - 24f) - 5f;
            position.width = 12f;
            if ((this.m_ShownPlanes.Length > 1) && ModuleUI.MinusButton(position))
            {
                this.m_ShownPlanes[this.m_ShownPlanes.Length - 1].objectReferenceValue = null;
                List<SerializedProperty> list = new List<SerializedProperty>(this.m_ShownPlanes);
                list.RemoveAt(list.Count - 1);
                this.m_ShownPlanes = list.ToArray();
            }
            if (this.m_ShownPlanes.Length < 6)
            {
                position.x += 17f;
                if (ModuleUI.PlusButton(position))
                {
                    List<SerializedProperty> list2;
                    this.m_ShownPlanes = new List<SerializedProperty>(this.m_ShownPlanes) { this.m_Planes[list2.Count] }.ToArray();
                }
            }
        }

        private void DrawGrid(Vector3 pos, Vector3 axis1, Vector3 axis2, Vector3 normal, Color color, int planeIndex)
        {
            if (Event.current.type == EventType.Repaint)
            {
                HandleUtility.ApplyWireMaterial();
                if (color.a > 0f)
                {
                    GL.Begin(1);
                    float num = 10f;
                    int num2 = 11;
                    num *= this.m_ScaleGrid;
                    num2 = (int) num;
                    num2 = Mathf.Clamp(num2, 10, 40);
                    if ((num2 % 2) == 0)
                    {
                        num2++;
                    }
                    float num3 = num * 0.5f;
                    float num4 = num / ((float) (num2 - 1));
                    Vector3 vector = (Vector3) (axis1 * num);
                    Vector3 vector2 = (Vector3) (axis2 * num);
                    Vector3 vector3 = (Vector3) (axis1 * num4);
                    Vector3 vector4 = (Vector3) (axis2 * num4);
                    Vector3 vector5 = (Vector3) ((pos - (axis1 * num3)) - (axis2 * num3));
                    for (int i = 0; i < num2; i++)
                    {
                        if ((i % 2) == 0)
                        {
                            GL.Color((Color) (color * 0.7f));
                        }
                        else
                        {
                            GL.Color(color);
                        }
                        GL.Vertex(vector5 + ((Vector3) (i * vector3)));
                        GL.Vertex((vector5 + ((Vector3) (i * vector3))) + vector2);
                        GL.Vertex(vector5 + ((Vector3) (i * vector4)));
                        GL.Vertex((vector5 + ((Vector3) (i * vector4))) + vector);
                    }
                    GL.Color(color);
                    GL.Vertex(pos);
                    GL.Vertex(pos + normal);
                    GL.End();
                }
            }
        }

        private void DrawSolidPlane(Vector3 pos, Quaternion rot, int planeIndex)
        {
        }

        protected override void Init()
        {
            if (this.m_Type == null)
            {
                this.m_Type = base.GetProperty("type");
                List<SerializedProperty> list = new List<SerializedProperty>();
                for (int i = 0; i < this.m_Planes.Length; i++)
                {
                    this.m_Planes[i] = base.GetProperty("plane" + i);
                    if ((i == 0) || (this.m_Planes[i].objectReferenceValue != null))
                    {
                        list.Add(this.m_Planes[i]);
                    }
                }
                this.m_ShownPlanes = list.ToArray();
                this.m_Dampen = base.GetProperty("dampen");
                this.m_Bounce = base.GetProperty("bounce");
                this.m_LifetimeLossOnCollision = base.GetProperty("energyLossOnCollision");
                this.m_MinKillSpeed = base.GetProperty("minKillSpeed");
                this.m_ParticleRadius = base.GetProperty("particleRadius");
                this.m_PlaneVisualizationType = (PlaneVizType) EditorPrefs.GetInt("PlaneColisionVizType", 1);
                this.m_ScaleGrid = EditorPrefs.GetFloat("ScalePlaneColision", 1f);
                this.m_CollidesWith = base.GetProperty("collidesWith");
                this.m_Quality = base.GetProperty("quality");
                this.m_VoxelSize = base.GetProperty("voxelSize");
                this.m_CollisionMessages = base.GetProperty("collisionMessages");
                this.SyncVisualization();
            }
        }

        public override void OnInspectorGUI(ParticleSystem s)
        {
            if (s_Texts == null)
            {
                s_Texts = new Texts();
            }
            string[] options = new string[] { "Planes", "World" };
            CollisionTypes types = (CollisionTypes) ModuleUI.GUIPopup(string.Empty, this.m_Type, options);
            if (types == CollisionTypes.Plane)
            {
                this.DoListOfPlanesGUI();
                EditorGUI.BeginChangeCheck();
                this.m_PlaneVisualizationType = (PlaneVizType) ModuleUI.GUIPopup(s_Texts.visualization, (int) this.m_PlaneVisualizationType, this.m_PlaneVizTypeNames);
                if (EditorGUI.EndChangeCheck())
                {
                    EditorPrefs.SetInt("PlaneColisionVizType", (int) this.m_PlaneVisualizationType);
                    if (this.m_PlaneVisualizationType == PlaneVizType.Solid)
                    {
                        this.SyncVisualization();
                    }
                    else
                    {
                        ParticleEffectUtils.ClearPlanes();
                    }
                }
                EditorGUI.BeginChangeCheck();
                this.m_ScaleGrid = ModuleUI.GUIFloat(s_Texts.scalePlane, this.m_ScaleGrid, "f2");
                if (EditorGUI.EndChangeCheck())
                {
                    this.m_ScaleGrid = Mathf.Max(0f, this.m_ScaleGrid);
                    EditorPrefs.SetFloat("ScalePlaneColision", this.m_ScaleGrid);
                    this.SyncVisualization();
                }
            }
            ModuleUI.GUIFloat(s_Texts.dampen, this.m_Dampen);
            ModuleUI.GUIFloat(s_Texts.bounce, this.m_Bounce);
            ModuleUI.GUIFloat(s_Texts.lifetimeLoss, this.m_LifetimeLossOnCollision);
            ModuleUI.GUIFloat(s_Texts.minKillSpeed, this.m_MinKillSpeed);
            if (types != CollisionTypes.World)
            {
                ModuleUI.GUIFloat(s_Texts.particleRadius, this.m_ParticleRadius);
            }
            if (types == CollisionTypes.World)
            {
                ModuleUI.GUILayerMask(s_Texts.collidesWith, this.m_CollidesWith);
                ModuleUI.GUIPopup(s_Texts.quality, this.m_Quality, s_Texts.qualitySettings);
                if (this.m_Quality.intValue > 0)
                {
                    ModuleUI.GUIFloat(s_Texts.voxelSize, this.m_VoxelSize);
                }
            }
            ModuleUI.GUIToggle(s_Texts.collisionMessages, this.m_CollisionMessages);
        }

        protected override void OnModuleDisable()
        {
            base.OnModuleDisable();
            ParticleEffectUtils.ClearPlanes();
        }

        protected override void OnModuleEnable()
        {
            base.OnModuleEnable();
            this.SyncVisualization();
        }

        public override void OnSceneGUI(ParticleSystem s, InitialModuleUI initial)
        {
            Event current = Event.current;
            EventType rawType = current.type;
            if ((current.type == EventType.Ignore) && (current.rawType == EventType.MouseUp))
            {
                rawType = current.rawType;
            }
            Color color = Handles.color;
            Color color2 = new Color(1f, 1f, 1f, 0.5f);
            Handles.color = color2;
            if (this.m_Type.intValue == 0)
            {
                for (int i = 0; i < this.m_ShownPlanes.Length; i++)
                {
                    UnityEngine.Object objectReferenceValue = this.m_ShownPlanes[i].objectReferenceValue;
                    if (objectReferenceValue != null)
                    {
                        Transform objB = objectReferenceValue as Transform;
                        if (objB != null)
                        {
                            Vector3 position = objB.position;
                            Quaternion rotation = objB.rotation;
                            Vector3 vector2 = (Vector3) (rotation * Vector3.right);
                            Vector3 normal = (Vector3) (rotation * Vector3.up);
                            Vector3 vector4 = (Vector3) (rotation * Vector3.forward);
                            if (object.ReferenceEquals(m_SelectedTransform, objB))
                            {
                                Tools.s_Hidden = true;
                                EditorGUI.BeginChangeCheck();
                                if (Tools.current == Tool.Move)
                                {
                                    objB.position = Handles.PositionHandle(position, rotation);
                                }
                                else if (Tools.current == Tool.Rotate)
                                {
                                    objB.rotation = Handles.RotationHandle(rotation, position);
                                }
                                if (EditorGUI.EndChangeCheck())
                                {
                                    if (this.m_PlaneVisualizationType == PlaneVizType.Solid)
                                    {
                                        GameObject plane = ParticleEffectUtils.GetPlane(i);
                                        plane.transform.position = position;
                                        plane.transform.rotation = rotation;
                                        plane.transform.localScale = new Vector3(this.m_ScaleGrid, this.m_ScaleGrid, this.m_ScaleGrid);
                                    }
                                    ParticleSystemEditorUtils.PerformCompleteResimulation();
                                }
                            }
                            else
                            {
                                int keyboardControl = GUIUtility.keyboardControl;
                                float size = HandleUtility.GetHandleSize(position) * 0.06f;
                                Handles.FreeMoveHandle(position, Quaternion.identity, size, Vector3.zero, new Handles.DrawCapFunction(Handles.RectangleCap));
                                if (((rawType == EventType.MouseDown) && (current.type == EventType.Used)) && (keyboardControl != GUIUtility.keyboardControl))
                                {
                                    m_SelectedTransform = objB;
                                    rawType = EventType.Used;
                                }
                            }
                            if (this.m_PlaneVisualizationType == PlaneVizType.Grid)
                            {
                                Color color3 = (Color) (Handles.s_ColliderHandleColor * 0.9f);
                                if (!base.enabled)
                                {
                                    color3 = new Color(0.7f, 0.7f, 0.7f, 0.7f);
                                }
                                this.DrawGrid(position, vector2, vector4, normal, color3, i);
                            }
                            else
                            {
                                this.DrawSolidPlane(position, rotation, i);
                            }
                        }
                        else
                        {
                            Debug.LogError("Not a transform: " + objectReferenceValue.GetType());
                        }
                    }
                }
            }
            Handles.color = color;
        }

        protected override void SetVisibilityState(ModuleUI.VisibilityState newState)
        {
            base.SetVisibilityState(newState);
            if (newState != ModuleUI.VisibilityState.VisibleAndFoldedOut)
            {
                Tools.s_Hidden = false;
                m_SelectedTransform = null;
                ParticleEffectUtils.ClearPlanes();
            }
            else
            {
                this.SyncVisualization();
            }
        }

        private void SyncVisualization()
        {
            if (base.enabled && (this.m_PlaneVisualizationType == PlaneVizType.Solid))
            {
                for (int i = 0; i < this.m_ShownPlanes.Length; i++)
                {
                    UnityEngine.Object objectReferenceValue = this.m_ShownPlanes[i].objectReferenceValue;
                    if (objectReferenceValue != null)
                    {
                        Transform transform = objectReferenceValue as Transform;
                        if (transform != null)
                        {
                            GameObject plane = ParticleEffectUtils.GetPlane(i);
                            plane.transform.position = transform.position;
                            plane.transform.rotation = transform.rotation;
                            plane.transform.localScale = new Vector3(this.m_ScaleGrid, this.m_ScaleGrid, this.m_ScaleGrid);
                        }
                    }
                }
            }
        }

        public override void UpdateCullingSupportedString(ref string text)
        {
            text = text + "\n\tCollision is enabled.";
        }

        private enum CollisionTypes
        {
            Plane,
            World
        }

        private enum PlaneVizType
        {
            Grid,
            Solid
        }

        private class Texts
        {
            public GUIContent bounce = new GUIContent("Bounce", "When particle collides, the bounce is scaled with this value. The bounce is the upwards motion in the plane normal direction.");
            public GUIContent collidesWith = new GUIContent("Collides With", "Collides the particles with colliders included in the layermask.");
            public GUIContent collisionMessages = new GUIContent("Send Collision Messages", "Send collision callback messages.");
            public GUIContent createPlane = new GUIContent(string.Empty, "Create an empty GameObject and assign it as a plane.");
            public GUIContent dampen = new GUIContent("Dampen", "When particle collides, it will lose this fraction of its speed. Unless this is set to 0.0, particle will become slower after collision.");
            public GUIContent lifetimeLoss = new GUIContent("Lifetime Loss", "When particle collides, it will lose this fraction of its Start Lifetime");
            public GUIContent minKillSpeed = new GUIContent("Min Kill Speed", "When particles collide and their speed is lower than this value, they are killed.");
            public GUIContent particleRadius = new GUIContent("Particle Radius", "The estimated size of a particle when colliding (to avoid clipping with collision shape.");
            public GUIContent planes = new GUIContent("Planes", "Planes are defined by assigning a reference to a transform. This transform can be any transform in the scene and can be animated. Multiple planes can be used. Note: the Y-axis is used as the plane normal.");
            public GUIContent quality = new GUIContent("Collision Quality", "Quality of world collisions. Medium and low quality are approximate and may leak particles.");
            public string[] qualitySettings = new string[] { "High", "Medium", "Low" };
            public GUIContent scalePlane = new GUIContent("Scale Plane", "Resizes the visualization planes.");
            public GUIContent visualization = new GUIContent("Visualization", "Only used for visualizing the planes: Wireframe or Solid.");
            public GUIContent voxelSize = new GUIContent("Voxel Size", "Size of voxels in the collision cache.");
        }
    }
}

