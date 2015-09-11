﻿namespace UnityEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    [CustomEditor(typeof(AudioSource)), CanEditMultipleObjects]
    internal class AudioSourceInspector : Editor
    {
        [CompilerGenerated]
        private static Func<UnityEngine.Object, bool> <>f__am$cache20;
        private const float EPSILON = 0.0001f;
        internal static Color kLowPassCurveColor = new Color(0.8f, 0.25f, 0.9f, 1f);
        private const int kLowPassCurveID = 3;
        internal const float kMaxCutoffFrequency = 22000f;
        internal static Color kReverbZoneMixCurveColor = new Color(0.7f, 0.7f, 0.2f, 1f);
        private const int kReverbZoneMixCurveID = 4;
        internal static Color kRolloffCurveColor = new Color(0.9f, 0.3f, 0.2f, 1f);
        private const int kRolloffCurveID = 0;
        private const int kSpatialBlendCurveID = 1;
        internal static Color kSpatialCurveColor = new Color(0.25f, 0.7f, 0.2f, 1f);
        internal static Color kSpreadCurveColor = new Color(0.25f, 0.55f, 0.95f, 1f);
        private const int kSpreadCurveID = 2;
        private SerializedProperty m_AudioClip;
        private AudioCurveWrapper[] m_AudioCurves;
        private SerializedProperty m_BypassEffects;
        private SerializedProperty m_BypassListenerEffects;
        private SerializedProperty m_BypassReverbZones;
        private CurveEditor m_CurveEditor;
        private static CurveEditorSettings m_CurveEditorSettings = new CurveEditorSettings();
        private SerializedProperty m_DopplerLevel;
        private bool m_Expanded3D;
        private Vector3 m_LastListenerPosition;
        private SerializedProperty m_Loop;
        private SerializedObject m_LowpassObject;
        private SerializedProperty m_MaxDistance;
        private SerializedProperty m_MinDistance;
        private SerializedProperty m_Mute;
        private SerializedProperty m_OutputAudioMixerGroup;
        private SerializedProperty m_Pan2D;
        private SerializedProperty m_PanLevel;
        private SerializedProperty m_Pitch;
        private SerializedProperty m_PlayOnAwake;
        private SerializedProperty m_Priority;
        private bool m_RefreshCurveEditor;
        private SerializedProperty m_RolloffMode;
        internal bool[] m_SelectedCurves = new bool[0];
        private SerializedProperty m_Spatialize;
        private SerializedProperty m_Volume;
        private static Styles ms_Styles;

        internal static void AnimProp(GUIContent label, SerializedProperty prop, float min, float max, bool useNormalizedValue)
        {
            InitStyles();
            if (prop.hasMultipleDifferentValues)
            {
                EditorGUILayout.TargetChoiceField(prop, label, new GUILayoutOption[0]);
            }
            else
            {
                AnimationCurve animationCurveValue = prop.animationCurveValue;
                if (animationCurveValue == null)
                {
                    Debug.LogError(label.text + " curve is null!");
                }
                else if (animationCurveValue.length == 0)
                {
                    Debug.LogError(label.text + " curve has no keys!");
                }
                else
                {
                    if (animationCurveValue.length != 1)
                    {
                        EditorGUI.BeginDisabledGroup(true);
                        EditorGUILayout.LabelField(label.text, ms_Styles.controlledByCurveLabel, new GUILayoutOption[0]);
                        EditorGUI.EndDisabledGroup();
                    }
                    else
                    {
                        float v = !useNormalizedValue ? animationCurveValue.keys[0].value : Mathf.Lerp(min, max, animationCurveValue.keys[0].value);
                        v = MathUtils.DiscardLeastSignificantDecimal(v);
                        EditorGUI.BeginChangeCheck();
                        if (max > min)
                        {
                            v = EditorGUILayout.Slider(label, v, min, max, new GUILayoutOption[0]);
                        }
                        else
                        {
                            v = EditorGUILayout.Slider(label, v, max, min, new GUILayoutOption[0]);
                        }
                        if (EditorGUI.EndChangeCheck())
                        {
                            Keyframe key = animationCurveValue.keys[0];
                            key.time = 0f;
                            key.value = !useNormalizedValue ? v : Mathf.InverseLerp(min, max, v);
                            animationCurveValue.MoveKey(0, key);
                        }
                    }
                    prop.animationCurveValue = animationCurveValue;
                }
            }
        }

        private void Audio3DGUI()
        {
            EditorGUILayout.Slider(this.m_DopplerLevel, 0f, 5f, ms_Styles.dopplerLevelLabel, new GUILayoutOption[0]);
            EditorGUI.BeginChangeCheck();
            AnimProp(ms_Styles.spreadLabel, this.m_AudioCurves[2].curveProp, 0f, 360f, true);
            if (this.m_RolloffMode.hasMultipleDifferentValues || ((this.m_RolloffMode.enumValueIndex == 2) && this.m_AudioCurves[0].curveProp.hasMultipleDifferentValues))
            {
                EditorGUILayout.TargetChoiceField(this.m_AudioCurves[0].curveProp, ms_Styles.rolloffLabel, new TargetChoiceHandler.TargetChoiceMenuFunction(AudioSourceInspector.SetRolloffToTarget), new GUILayoutOption[0]);
            }
            else
            {
                EditorGUILayout.PropertyField(this.m_RolloffMode, ms_Styles.rolloffLabel, new GUILayoutOption[0]);
                if (this.m_RolloffMode.enumValueIndex != 2)
                {
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(this.m_MinDistance, new GUILayoutOption[0]);
                    if (EditorGUI.EndChangeCheck())
                    {
                        this.m_MinDistance.floatValue = Mathf.Clamp(this.m_MinDistance.floatValue, 0f, this.m_MaxDistance.floatValue / 1.01f);
                    }
                }
                else
                {
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.LabelField(this.m_MinDistance.displayName, ms_Styles.controlledByCurveLabel, new GUILayoutOption[0]);
                    EditorGUI.EndDisabledGroup();
                }
            }
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(this.m_MaxDistance, new GUILayoutOption[0]);
            if (EditorGUI.EndChangeCheck())
            {
                this.m_MaxDistance.floatValue = Mathf.Min(Mathf.Max(Mathf.Max(this.m_MaxDistance.floatValue, 0.01f), this.m_MinDistance.floatValue * 1.01f), 1000000f);
            }
            if (EditorGUI.EndChangeCheck())
            {
                this.m_RefreshCurveEditor = true;
            }
            Rect aspectRect = GUILayoutUtility.GetAspectRect(1.333f, GUI.skin.textField);
            aspectRect.xMin += EditorGUI.indent;
            if ((Event.current.type != EventType.Layout) && (Event.current.type != EventType.Used))
            {
                this.m_CurveEditor.rect = new Rect(aspectRect.x, aspectRect.y, aspectRect.width, aspectRect.height);
            }
            this.UpdateWrappersAndLegend();
            GUI.Label(this.m_CurveEditor.drawRect, GUIContent.none, "TextField");
            this.m_CurveEditor.hRangeLocked = Event.current.shift;
            this.m_CurveEditor.vRangeLocked = EditorGUI.actionKey;
            this.m_CurveEditor.OnGUI();
            if (base.targets.Length == 1)
            {
                AudioSource target = (AudioSource) this.target;
                AudioListener listener = (AudioListener) UnityEngine.Object.FindObjectOfType(typeof(AudioListener));
                if (listener != null)
                {
                    Vector3 vector = AudioUtil.GetListenerPos() - target.transform.position;
                    float magnitude = vector.magnitude;
                    this.DrawLabel("Listener", magnitude, aspectRect);
                }
            }
            this.DrawLegend();
            foreach (AudioCurveWrapper wrapper in this.m_AudioCurves)
            {
                if ((this.m_CurveEditor.getCurveWrapperById(wrapper.id) != null) && this.m_CurveEditor.getCurveWrapperById(wrapper.id).changed)
                {
                    AnimationCurve curve = this.m_CurveEditor.getCurveWrapperById(wrapper.id).curve;
                    if (curve.length > 0)
                    {
                        wrapper.curveProp.animationCurveValue = curve;
                        this.m_CurveEditor.getCurveWrapperById(wrapper.id).changed = false;
                        if (wrapper.type == AudioCurveType.Volume)
                        {
                            this.m_RolloffMode.enumValueIndex = 2;
                        }
                    }
                }
            }
        }

        private void DrawLabel(string label, float value, Rect r)
        {
            Vector2 vector = ms_Styles.labelStyle.CalcSize(new GUIContent(label));
            vector.x += 2f;
            Vector2 vector2 = this.m_CurveEditor.DrawingToViewTransformPoint(new Vector2(value / this.m_MaxDistance.floatValue, 0f));
            Vector2 vector3 = this.m_CurveEditor.DrawingToViewTransformPoint(new Vector2(value / this.m_MaxDistance.floatValue, 1f));
            GUI.BeginGroup(r);
            Color color = Handles.color;
            Handles.color = new Color(1f, 0f, 0f, 0.3f);
            Handles.DrawLine(new Vector3(vector2.x, vector2.y, 0f), new Vector3(vector3.x, vector3.y, 0f));
            Handles.DrawLine(new Vector3(vector2.x + 1f, vector2.y, 0f), new Vector3(vector3.x + 1f, vector3.y, 0f));
            Handles.color = color;
            GUI.Label(new Rect(Mathf.Floor(vector3.x - (vector.x / 2f)), 2f, vector.x, 15f), label, ms_Styles.labelStyle);
            GUI.EndGroup();
        }

        private void DrawLegend()
        {
            List<Rect> list = new List<Rect>();
            List<AudioCurveWrapper> shownAudioCurves = this.GetShownAudioCurves();
            Rect rect = GUILayoutUtility.GetRect((float) 10f, (float) 20f);
            rect.x += 4f + EditorGUI.indent;
            rect.width -= 8f + EditorGUI.indent;
            int num = Mathf.Min(0x4b, Mathf.FloorToInt(rect.width / ((float) shownAudioCurves.Count)));
            for (int i = 0; i < shownAudioCurves.Count; i++)
            {
                list.Add(new Rect(rect.x + (num * i), rect.y, (float) num, rect.height));
            }
            bool flag = false;
            if (shownAudioCurves.Count != this.m_SelectedCurves.Length)
            {
                this.m_SelectedCurves = new bool[shownAudioCurves.Count];
                flag = true;
            }
            if (EditorGUIExt.DragSelection(list.ToArray(), ref this.m_SelectedCurves, GUIStyle.none) || flag)
            {
                bool flag2 = false;
                for (int k = 0; k < shownAudioCurves.Count; k++)
                {
                    if (this.m_SelectedCurves[k])
                    {
                        flag2 = true;
                    }
                }
                if (!flag2)
                {
                    for (int m = 0; m < shownAudioCurves.Count; m++)
                    {
                        this.m_SelectedCurves[m] = true;
                    }
                }
                this.SyncShownCurvesToLegend(shownAudioCurves);
            }
            for (int j = 0; j < shownAudioCurves.Count; j++)
            {
                EditorGUI.DrawLegend(list[j], shownAudioCurves[j].color, shownAudioCurves[j].legend.text, this.m_SelectedCurves[j]);
                if (shownAudioCurves[j].curveProp.hasMultipleDifferentValues)
                {
                    Rect rect2 = list[j];
                    Rect rect3 = list[j];
                    Rect rect4 = list[j];
                    GUI.Button(new Rect(rect2.x, rect3.y + 20f, rect4.width, 20f), "Different");
                }
            }
        }

        public Vector2 GetAxisScalars()
        {
            return new Vector2(this.m_MaxDistance.floatValue, 1f);
        }

        private CurveWrapper GetCurveWrapper(AnimationCurve curve, AudioCurveWrapper audioCurve)
        {
            float r = EditorGUIUtility.isProSkin ? 1f : 0.9f;
            Color color = new Color(r, r, r, 1f);
            CurveWrapper wrapper = new CurveWrapper {
                id = audioCurve.id,
                groupId = -1,
                color = audioCurve.color * color,
                hidden = false,
                readOnly = false,
                renderer = new NormalCurveRenderer(curve)
            };
            wrapper.renderer.SetCustomRange(0f, 1f);
            wrapper.getAxisUiScalarsCallback = new CurveWrapper.GetAxisScalarsCallback(this.GetAxisScalars);
            return wrapper;
        }

        private CurveWrapper[] GetCurveWrapperArray()
        {
            List<CurveWrapper> list = new List<CurveWrapper>();
            foreach (AudioCurveWrapper wrapper in this.m_AudioCurves)
            {
                if (wrapper.curveProp != null)
                {
                    bool flag = false;
                    AnimationCurve animationCurveValue = wrapper.curveProp.animationCurveValue;
                    if (wrapper.type == AudioCurveType.Volume)
                    {
                        AudioRolloffMode enumValueIndex = (AudioRolloffMode) this.m_RolloffMode.enumValueIndex;
                        if (this.m_RolloffMode.hasMultipleDifferentValues)
                        {
                            flag = false;
                        }
                        else if (enumValueIndex == AudioRolloffMode.Custom)
                        {
                            flag = !wrapper.curveProp.hasMultipleDifferentValues;
                        }
                        else
                        {
                            flag = !this.m_MinDistance.hasMultipleDifferentValues && !this.m_MaxDistance.hasMultipleDifferentValues;
                            switch (enumValueIndex)
                            {
                                case AudioRolloffMode.Linear:
                                    animationCurveValue = AnimationCurve.Linear(this.m_MinDistance.floatValue / this.m_MaxDistance.floatValue, 1f, 1f, 0f);
                                    break;

                                case AudioRolloffMode.Logarithmic:
                                    animationCurveValue = Logarithmic(this.m_MinDistance.floatValue / this.m_MaxDistance.floatValue, 1f, 1f);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        flag = !wrapper.curveProp.hasMultipleDifferentValues;
                    }
                    if (flag)
                    {
                        if (animationCurveValue.length == 0)
                        {
                            Debug.LogError(wrapper.legend.text + " curve has no keys!");
                        }
                        else
                        {
                            list.Add(this.GetCurveWrapper(animationCurveValue, wrapper));
                        }
                    }
                }
            }
            return list.ToArray();
        }

        private List<AudioCurveWrapper> GetShownAudioCurves()
        {
            return (from f in this.m_AudioCurves
                where this.m_CurveEditor.getCurveWrapperById(f.id) != null
                select f).ToList<AudioCurveWrapper>();
        }

        private void HandleLowPassFilter()
        {
            AudioCurveWrapper wrapper = this.m_AudioCurves[3];
            AudioLowPassFilter[] objs = new AudioLowPassFilter[base.targets.Length];
            for (int i = 0; i < base.targets.Length; i++)
            {
                objs[i] = ((AudioSource) base.targets[i]).GetComponent<AudioLowPassFilter>();
                if (objs[i] == null)
                {
                    this.m_LowpassObject = null;
                    wrapper.curveProp = null;
                    return;
                }
            }
            if (wrapper.curveProp == null)
            {
                this.m_LowpassObject = new SerializedObject(objs);
                wrapper.curveProp = this.m_LowpassObject.FindProperty("lowpassLevelCustomCurve");
            }
        }

        private static void InitStyles()
        {
            if (ms_Styles == null)
            {
                ms_Styles = new Styles();
            }
        }

        private static AnimationCurve Logarithmic(float timeStart, float timeEnd, float logBase)
        {
            float num;
            float num2;
            float num3;
            List<Keyframe> list = new List<Keyframe>();
            float num4 = 2f;
            timeStart = Mathf.Max(timeStart, 0.0001f);
            for (float i = timeStart; i < timeEnd; i *= num4)
            {
                num = LogarithmicValue(i, timeStart, logBase);
                num3 = i / 50f;
                num2 = (LogarithmicValue(i + num3, timeStart, logBase) - LogarithmicValue(i - num3, timeStart, logBase)) / (num3 * 2f);
                list.Add(new Keyframe(i, num, num2, num2));
            }
            num = LogarithmicValue(timeEnd, timeStart, logBase);
            num3 = timeEnd / 50f;
            num2 = (LogarithmicValue(timeEnd + num3, timeStart, logBase) - LogarithmicValue(timeEnd - num3, timeStart, logBase)) / (num3 * 2f);
            list.Add(new Keyframe(timeEnd, num, num2, num2));
            return new AnimationCurve(list.ToArray());
        }

        private static float LogarithmicValue(float distance, float minDistance, float rolloffScale)
        {
            if ((distance > minDistance) && (rolloffScale != 1f))
            {
                distance -= minDistance;
                distance *= rolloffScale;
                distance += minDistance;
            }
            if (distance < 1E-06f)
            {
                distance = 1E-06f;
            }
            return (minDistance / distance);
        }

        private void OnDisable()
        {
            this.m_CurveEditor.OnDisable();
            Undo.undoRedoPerformed = (Undo.UndoRedoCallback) Delegate.Remove(Undo.undoRedoPerformed, new Undo.UndoRedoCallback(this.UndoRedoPerformed));
            EditorApplication.update = (EditorApplication.CallbackFunction) Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.Update));
            EditorPrefs.SetBool("AudioSourceExpanded3D", this.m_Expanded3D);
        }

        private void OnEnable()
        {
            this.m_AudioClip = base.serializedObject.FindProperty("m_audioClip");
            this.m_PlayOnAwake = base.serializedObject.FindProperty("m_PlayOnAwake");
            this.m_Volume = base.serializedObject.FindProperty("m_Volume");
            this.m_Pitch = base.serializedObject.FindProperty("m_Pitch");
            this.m_Loop = base.serializedObject.FindProperty("Loop");
            this.m_Mute = base.serializedObject.FindProperty("Mute");
            this.m_Spatialize = base.serializedObject.FindProperty("Spatialize");
            this.m_Priority = base.serializedObject.FindProperty("Priority");
            this.m_DopplerLevel = base.serializedObject.FindProperty("DopplerLevel");
            this.m_MinDistance = base.serializedObject.FindProperty("MinDistance");
            this.m_MaxDistance = base.serializedObject.FindProperty("MaxDistance");
            this.m_Pan2D = base.serializedObject.FindProperty("Pan2D");
            this.m_RolloffMode = base.serializedObject.FindProperty("rolloffMode");
            this.m_BypassEffects = base.serializedObject.FindProperty("BypassEffects");
            this.m_BypassListenerEffects = base.serializedObject.FindProperty("BypassListenerEffects");
            this.m_BypassReverbZones = base.serializedObject.FindProperty("BypassReverbZones");
            this.m_OutputAudioMixerGroup = base.serializedObject.FindProperty("OutputAudioMixerGroup");
            this.m_AudioCurves = new AudioCurveWrapper[] { new AudioCurveWrapper(AudioCurveType.Volume, "Volume", 0, kRolloffCurveColor, base.serializedObject.FindProperty("rolloffCustomCurve"), 0f, 1f), new AudioCurveWrapper(AudioCurveType.SpatialBlend, "Spatial Blend", 1, kSpatialCurveColor, base.serializedObject.FindProperty("panLevelCustomCurve"), 0f, 1f), new AudioCurveWrapper(AudioCurveType.Spread, "Spread", 2, kSpreadCurveColor, base.serializedObject.FindProperty("spreadCustomCurve"), 0f, 1f), new AudioCurveWrapper(AudioCurveType.Lowpass, "Low-Pass", 3, kLowPassCurveColor, null, 0f, 1f), new AudioCurveWrapper(AudioCurveType.ReverbZoneMix, "Reverb Zone Mix", 4, kReverbZoneMixCurveColor, base.serializedObject.FindProperty("reverbZoneMixCustomCurve"), 0f, 1.1f) };
            m_CurveEditorSettings.hRangeMin = 0f;
            m_CurveEditorSettings.vRangeMin = 0f;
            m_CurveEditorSettings.vRangeMax = 1.1f;
            m_CurveEditorSettings.hRangeMax = 1f;
            m_CurveEditorSettings.vSlider = false;
            m_CurveEditorSettings.hSlider = false;
            TickStyle style = new TickStyle {
                color = new Color(0f, 0f, 0f, 0.15f),
                distLabel = 30
            };
            m_CurveEditorSettings.hTickStyle = style;
            TickStyle style2 = new TickStyle {
                color = new Color(0f, 0f, 0f, 0.15f),
                distLabel = 20
            };
            m_CurveEditorSettings.vTickStyle = style2;
            this.m_CurveEditor = new CurveEditor(new Rect(0f, 0f, 1000f, 100f), new CurveWrapper[0], false);
            this.m_CurveEditor.settings = m_CurveEditorSettings;
            this.m_CurveEditor.margin = 25f;
            this.m_CurveEditor.SetShownHRangeInsideMargins(0f, 1f);
            this.m_CurveEditor.SetShownVRangeInsideMargins(0f, 1.1f);
            this.m_CurveEditor.ignoreScrollWheelUntilClicked = true;
            this.m_LastListenerPosition = AudioUtil.GetListenerPos();
            EditorApplication.update = (EditorApplication.CallbackFunction) Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.Update));
            Undo.undoRedoPerformed = (Undo.UndoRedoCallback) Delegate.Combine(Undo.undoRedoPerformed, new Undo.UndoRedoCallback(this.UndoRedoPerformed));
            this.m_Expanded3D = EditorPrefs.GetBool("AudioSourceExpanded3D", this.m_Expanded3D);
        }

        public override void OnInspectorGUI()
        {
            InitStyles();
            base.serializedObject.Update();
            if (this.m_LowpassObject != null)
            {
                this.m_LowpassObject.Update();
            }
            this.HandleLowPassFilter();
            foreach (AudioCurveWrapper wrapper in this.m_AudioCurves)
            {
                CurveWrapper wrapper2 = this.m_CurveEditor.getCurveWrapperById(wrapper.id);
                if (wrapper.curveProp != null)
                {
                    AnimationCurve animationCurveValue = wrapper.curveProp.animationCurveValue;
                    if ((wrapper2 == null) != wrapper.curveProp.hasMultipleDifferentValues)
                    {
                        this.m_RefreshCurveEditor = true;
                    }
                    else if (wrapper2 != null)
                    {
                        if (wrapper2.curve.length == 0)
                        {
                            this.m_RefreshCurveEditor = true;
                        }
                        else if ((animationCurveValue.length >= 1) && (animationCurveValue.keys[0].value != wrapper2.curve.keys[0].value))
                        {
                            this.m_RefreshCurveEditor = true;
                        }
                    }
                }
                else if (wrapper2 != null)
                {
                    this.m_RefreshCurveEditor = true;
                }
            }
            this.UpdateWrappersAndLegend();
            EditorGUILayout.PropertyField(this.m_AudioClip, ms_Styles.audioClipLabel, new GUILayoutOption[0]);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(this.m_OutputAudioMixerGroup, ms_Styles.outputMixerGroupLabel, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_Mute, new GUILayoutOption[0]);
            if (AudioUtil.canUseSpatializerEffect)
            {
                EditorGUILayout.PropertyField(this.m_Spatialize, new GUILayoutOption[0]);
            }
            EditorGUILayout.PropertyField(this.m_BypassEffects, new GUILayoutOption[0]);
            if (<>f__am$cache20 == null)
            {
                <>f__am$cache20 = t => (t as AudioSource).outputAudioMixerGroup != null;
            }
            bool flag = base.targets.Any<UnityEngine.Object>(<>f__am$cache20);
            if (flag)
            {
                EditorGUI.BeginDisabledGroup(true);
            }
            EditorGUILayout.PropertyField(this.m_BypassListenerEffects, new GUILayoutOption[0]);
            if (flag)
            {
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.PropertyField(this.m_BypassReverbZones, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_PlayOnAwake, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(this.m_Loop, new GUILayoutOption[0]);
            EditorGUILayout.Space();
            EditorGUIUtility.sliderLabels.SetLabels(ms_Styles.priorityLeftLabel, ms_Styles.priorityRightLabel);
            EditorGUILayout.IntSlider(this.m_Priority, 0, 0x100, ms_Styles.priorityLabel, new GUILayoutOption[0]);
            EditorGUIUtility.sliderLabels.SetLabels(null, null);
            EditorGUILayout.Space();
            EditorGUILayout.Slider(this.m_Volume, 0f, 1f, ms_Styles.volumeLabel, new GUILayoutOption[0]);
            EditorGUILayout.Space();
            EditorGUILayout.Slider(this.m_Pitch, -3f, 3f, ms_Styles.pitchLabel, new GUILayoutOption[0]);
            EditorGUILayout.Space();
            EditorGUIUtility.sliderLabels.SetLabels(ms_Styles.panLeftLabel, ms_Styles.panRightLabel);
            EditorGUILayout.Slider(this.m_Pan2D, -1f, 1f, ms_Styles.panStereoLabel, new GUILayoutOption[0]);
            EditorGUIUtility.sliderLabels.SetLabels(null, null);
            EditorGUILayout.Space();
            EditorGUIUtility.sliderLabels.SetLabels(ms_Styles.spatialLeftLabel, ms_Styles.spatialRightLabel);
            AnimProp(ms_Styles.spatialBlendLabel, this.m_AudioCurves[1].curveProp, 0f, 1f, false);
            EditorGUIUtility.sliderLabels.SetLabels(null, null);
            EditorGUILayout.Space();
            AnimProp(ms_Styles.reverbZoneMixLabel, this.m_AudioCurves[4].curveProp, 0f, 1.1f, false);
            EditorGUILayout.Space();
            this.m_Expanded3D = EditorGUILayout.Foldout(this.m_Expanded3D, "3D Sound Settings");
            if (this.m_Expanded3D)
            {
                EditorGUI.indentLevel++;
                this.Audio3DGUI();
                EditorGUI.indentLevel--;
            }
            base.serializedObject.ApplyModifiedProperties();
            if (this.m_LowpassObject != null)
            {
                this.m_LowpassObject.ApplyModifiedProperties();
            }
        }

        private void OnSceneGUI()
        {
            AudioSource target = (AudioSource) this.target;
            Color color = Handles.color;
            if (target.enabled)
            {
                Handles.color = new Color(0.5f, 0.7f, 1f, 0.5f);
            }
            else
            {
                Handles.color = new Color(0.3f, 0.4f, 0.6f, 0.5f);
            }
            Vector3 position = target.transform.position;
            EditorGUI.BeginChangeCheck();
            float num = Handles.RadiusHandle(Quaternion.identity, position, target.minDistance, true);
            float num2 = Handles.RadiusHandle(Quaternion.identity, position, target.maxDistance, true);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "AudioSource Distance");
                target.minDistance = num;
                target.maxDistance = num2;
                this.m_RefreshCurveEditor = true;
            }
            Handles.color = color;
        }

        private static void SetRolloffToTarget(SerializedProperty property, UnityEngine.Object target)
        {
            property.SetToValueOfTarget(target);
            property.serializedObject.FindProperty("rolloffMode").SetToValueOfTarget(target);
            property.serializedObject.ApplyModifiedProperties();
            EditorUtility.ForceReloadInspectors();
        }

        private void SyncShownCurvesToLegend(List<AudioCurveWrapper> curves)
        {
            if (curves.Count == this.m_SelectedCurves.Length)
            {
                for (int i = 0; i < curves.Count; i++)
                {
                    this.m_CurveEditor.getCurveWrapperById(curves[i].id).hidden = !this.m_SelectedCurves[i];
                }
                this.m_CurveEditor.animationCurves = this.m_CurveEditor.animationCurves;
            }
        }

        private void UndoRedoPerformed()
        {
            this.m_RefreshCurveEditor = true;
        }

        private void Update()
        {
            Vector3 listenerPos = AudioUtil.GetListenerPos();
            Vector3 vector2 = this.m_LastListenerPosition - listenerPos;
            if (vector2.sqrMagnitude > 0.0001f)
            {
                this.m_LastListenerPosition = listenerPos;
                base.Repaint();
            }
        }

        private void UpdateWrappersAndLegend()
        {
            if (this.m_RefreshCurveEditor)
            {
                this.m_CurveEditor.animationCurves = this.GetCurveWrapperArray();
                this.SyncShownCurvesToLegend(this.GetShownAudioCurves());
                this.m_RefreshCurveEditor = false;
            }
        }

        private enum AudioCurveType
        {
            Volume,
            SpatialBlend,
            Lowpass,
            Spread,
            ReverbZoneMix
        }

        private class AudioCurveWrapper
        {
            public Color color;
            public SerializedProperty curveProp;
            public int id;
            public GUIContent legend;
            public float rangeMax;
            public float rangeMin;
            public AudioSourceInspector.AudioCurveType type;

            public AudioCurveWrapper(AudioSourceInspector.AudioCurveType type, string legend, int id, Color color, SerializedProperty curveProp, float rangeMin, float rangeMax)
            {
                this.type = type;
                this.legend = new GUIContent(legend);
                this.id = id;
                this.color = color;
                this.curveProp = curveProp;
                this.rangeMin = rangeMin;
                this.rangeMax = rangeMax;
            }
        }

        private class Styles
        {
            public GUIContent audioClipLabel = new GUIContent("AudioClip", "The AudioClip asset played by the AudioSource. Can be undefined if the AudioSource is generating a live stream of audio via OnAudioFilterRead.");
            public string controlledByCurveLabel = "Controlled by curve";
            public GUIContent dopplerLevelLabel = new GUIContent("Doppler Level", "Specifies how much the pitch is changed based on the relative velocity between AudioListener and AudioSource.");
            public GUIStyle labelStyle = "ProfilerBadge";
            public GUIContent outputMixerGroupLabel = new GUIContent("Output", "Set whether the sound should play through an Audio Mixer first or directly to the Audio Listener");
            public GUIContent panLeftLabel = new GUIContent("Left");
            public GUIContent panRightLabel = new GUIContent("Right");
            public GUIContent panStereoLabel = new GUIContent("Stereo Pan", "Only valid for Mono and Stereo AudioClips. Mono sounds will be panned at constant power left and right. Stereo sounds will Stereo sounds have each left/right value faded up and down according to the specified pan value.");
            public GUIContent pitchLabel = new GUIContent("Pitch", "Sets the frequency of the sound. Use this to slow down or speed up the sound.");
            public GUIContent priorityLabel = new GUIContent("Priority", "Sets the priority of the source. Note that a sound with a larger priority value will more likely be stolen by sounds with smaller priority values.");
            public GUIContent priorityLeftLabel = new GUIContent("High");
            public GUIContent priorityRightLabel = new GUIContent("Low");
            public GUIContent reverbZoneMixLabel = new GUIContent("Reverb Zone Mix", "Sets how much of the signal this AudioSource is mixing into the global reverb associated with the zones. [0, 1] is a linear range (like volume) while [1, 1.1] lets you boost the reverb mix by 10 dB.");
            public GUIContent rolloffLabel = new GUIContent("Volume Rolloff", "Which type of rolloff curve to use");
            public GUIContent spatialBlendLabel = new GUIContent("Spatial Blend", "Sets how much this AudioSource is treated as a 3D source. 3D sources are affected by spatial position and spread. If 3D Pan Level is 0, all spatial attenuation is ignored.");
            public GUIContent spatialLeftLabel = new GUIContent("2D");
            public GUIContent spatialRightLabel = new GUIContent("3D");
            public GUIContent spreadLabel = new GUIContent("Spread", "Sets the spread of a 3d sound in speaker space");
            public GUIContent volumeLabel = new GUIContent("Volume", "Sets the overall volume of the sound.");
        }
    }
}

