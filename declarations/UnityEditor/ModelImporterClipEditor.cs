﻿namespace UnityEditor
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEditor.Animations;
    using UnityEditorInternal;
    using UnityEngine;

    internal class ModelImporterClipEditor : AssetImporterInspector
    {
        private static bool importMessageFoldout;
        private const int kFrameColumnWidth = 0x2d;
        private AnimationClipEditor m_AnimationClipEditor;
        private SerializedProperty m_AnimationCompression;
        private SerializedProperty m_AnimationDoRetargetingWarnings;
        private SerializedProperty m_AnimationImportErrors;
        private SerializedProperty m_AnimationImportWarnings;
        private SerializedProperty m_AnimationPositionError;
        private SerializedProperty m_AnimationRetargetingWarnings;
        private SerializedProperty m_AnimationRotationError;
        private SerializedProperty m_AnimationScaleError;
        private SerializedProperty m_AnimationType;
        private SerializedProperty m_AnimationWrapMode;
        private SerializedProperty m_BakeSimulation;
        private SerializedProperty m_ClipAnimations;
        private ReorderableList m_ClipList;
        private SerializedObject m_DefaultClipsSerializedObject;
        private SerializedProperty m_ImportAnimation;
        private SerializedProperty m_LegacyGenerateAnimations;
        private GUIContent[] m_MotionNodeList;
        private SerializedProperty m_MotionNodeName;
        private SerializedProperty m_PivotNodeName;
        public int m_SelectedClipIndexDoNotUseDirectly = -1;
        private static bool motionNodeFoldout;
        private static Styles styles;

        private void AddClip(TakeInfo takeInfo)
        {
            this.m_ClipAnimations.InsertArrayElementAtIndex(this.m_ClipAnimations.arraySize);
            AnimationClipInfoProperties animationClipInfoAtIndex = this.GetAnimationClipInfoAtIndex(this.m_ClipAnimations.arraySize - 1);
            animationClipInfoAtIndex.name = this.MakeUniqueClipName(takeInfo.defaultClipName, -1);
            this.SetupTakeNameAndFrames(animationClipInfoAtIndex, takeInfo);
            animationClipInfoAtIndex.wrapMode = 0;
            animationClipInfoAtIndex.loop = false;
            animationClipInfoAtIndex.orientationOffsetY = 0f;
            animationClipInfoAtIndex.level = 0f;
            animationClipInfoAtIndex.cycleOffset = 0f;
            animationClipInfoAtIndex.loopTime = false;
            animationClipInfoAtIndex.loopBlend = false;
            animationClipInfoAtIndex.loopBlendOrientation = false;
            animationClipInfoAtIndex.loopBlendPositionY = false;
            animationClipInfoAtIndex.loopBlendPositionXZ = false;
            animationClipInfoAtIndex.keepOriginalOrientation = false;
            animationClipInfoAtIndex.keepOriginalPositionY = true;
            animationClipInfoAtIndex.keepOriginalPositionXZ = false;
            animationClipInfoAtIndex.heightFromFeet = false;
            animationClipInfoAtIndex.mirror = false;
            animationClipInfoAtIndex.maskType = ClipAnimationMaskType.CreateFromThisModel;
            AvatarMask mask = new AvatarMask();
            string[] humanTransforms = null;
            SerializedObject serializedObject = animationClipInfoAtIndex.maskTypeProperty.serializedObject;
            ModelImporter targetObject = serializedObject.targetObject as ModelImporter;
            if ((this.animationType == ModelImporterAnimationType.Human) && !targetObject.isAssetOlderOr42)
            {
                humanTransforms = AvatarMaskUtility.GetAvatarHumanTransform(serializedObject, targetObject.transformPaths);
                if (humanTransforms == null)
                {
                    return;
                }
            }
            AvatarMaskUtility.UpdateTransformMask(mask, targetObject.transformPaths, humanTransforms);
            animationClipInfoAtIndex.MaskToClip(mask);
            animationClipInfoAtIndex.ClearEvents();
            animationClipInfoAtIndex.ClearCurves();
            UnityEngine.Object.DestroyImmediate(mask);
        }

        private void AddClipInList(ReorderableList list)
        {
            if (this.m_DefaultClipsSerializedObject != null)
            {
                this.TransferDefaultClipsToCustomClips();
            }
            int index = 0;
            if ((0 < this.selectedClipIndex) && (this.selectedClipIndex < this.m_ClipAnimations.arraySize))
            {
                AnimationClipInfoProperties animationClipInfoAtIndex = this.GetAnimationClipInfoAtIndex(this.selectedClipIndex);
                for (int i = 0; i < this.singleImporter.importedTakeInfos.Length; i++)
                {
                    if (this.singleImporter.importedTakeInfos[i].name == animationClipInfoAtIndex.takeName)
                    {
                        index = i;
                        break;
                    }
                }
            }
            this.AddClip(this.singleImporter.importedTakeInfos[index]);
            this.UpdateList();
            this.SelectClip(list.list.Count - 1);
        }

        private void AnimationClipGUI()
        {
            string stringValue = this.m_AnimationImportErrors.stringValue;
            string message = this.m_AnimationImportWarnings.stringValue;
            string str3 = this.m_AnimationRetargetingWarnings.stringValue;
            if (stringValue.Length > 0)
            {
                EditorGUILayout.HelpBox("Error(s) found while importing animation this file. Open \"Import Messages\" foldout below for more details", MessageType.Error);
            }
            else if (message.Length > 0)
            {
                EditorGUILayout.HelpBox("Warning(s) found while importing this animation file. Open \"Import Messages\" foldout below for more details", MessageType.Warning);
            }
            this.AnimationSettings();
            Profiler.BeginSample("Clip inspector");
            EditorGUILayout.Space();
            if (base.targets.Length == 1)
            {
                this.AnimationSplitTable();
            }
            else
            {
                GUILayout.Label(styles.clipMultiEditInfo, EditorStyles.helpBox, new GUILayoutOption[0]);
            }
            Profiler.EndSample();
            this.RootMotionNodeSettings();
            importMessageFoldout = EditorGUILayout.Foldout(importMessageFoldout, styles.ImportMessages);
            if (importMessageFoldout)
            {
                if (stringValue.Length > 0)
                {
                    EditorGUILayout.HelpBox(stringValue, MessageType.Error);
                }
                if (message.Length > 0)
                {
                    EditorGUILayout.HelpBox(message, MessageType.Warning);
                }
                if (this.animationType == ModelImporterAnimationType.Human)
                {
                    EditorGUILayout.PropertyField(this.m_AnimationDoRetargetingWarnings, styles.GenerateRetargetingWarnings, new GUILayoutOption[0]);
                    if (this.m_AnimationDoRetargetingWarnings.boolValue)
                    {
                        if (str3.Length > 0)
                        {
                            EditorGUILayout.HelpBox(str3, MessageType.Info);
                        }
                    }
                    else
                    {
                        EditorGUILayout.HelpBox("Retargeting Quality compares retargeted with original animation. It reports average and maximum position/orientation difference for body parts. It may slow down import time of this file.", MessageType.Info);
                    }
                }
            }
        }

        private void AnimationSettings()
        {
            EditorGUILayout.Space();
            bool flag = true;
            foreach (ModelImporter importer in base.targets)
            {
                if (!importer.isBakeIKSupported)
                {
                    flag = false;
                }
            }
            EditorGUI.BeginDisabledGroup(!flag);
            EditorGUILayout.PropertyField(this.m_BakeSimulation, styles.BakeIK, new GUILayoutOption[0]);
            EditorGUI.EndDisabledGroup();
            if (this.animationType == ModelImporterAnimationType.Legacy)
            {
                EditorGUI.showMixedValue = this.m_AnimationWrapMode.hasMultipleDifferentValues;
                EditorGUILayout.Popup(this.m_AnimationWrapMode, styles.AnimWrapModeOpt, styles.AnimWrapModeLabel, new GUILayoutOption[0]);
                EditorGUI.showMixedValue = false;
                int[] numArray1 = new int[3];
                numArray1[1] = 1;
                numArray1[2] = 2;
                int[] optionValues = numArray1;
                EditorGUILayout.IntPopup(this.m_AnimationCompression, styles.AnimCompressionOptLegacy, optionValues, styles.AnimCompressionLabel, new GUILayoutOption[0]);
            }
            else
            {
                int[] numArray3 = new int[3];
                numArray3[1] = 1;
                numArray3[2] = 3;
                int[] numArray2 = numArray3;
                EditorGUILayout.IntPopup(this.m_AnimationCompression, styles.AnimCompressionOpt, numArray2, styles.AnimCompressionLabel, new GUILayoutOption[0]);
            }
            if (this.m_AnimationCompression.intValue > 0)
            {
                EditorGUILayout.PropertyField(this.m_AnimationRotationError, styles.AnimRotationErrorLabel, new GUILayoutOption[0]);
                EditorGUILayout.PropertyField(this.m_AnimationPositionError, styles.AnimPositionErrorLabel, new GUILayoutOption[0]);
                EditorGUILayout.PropertyField(this.m_AnimationScaleError, styles.AnimScaleErrorLabel, new GUILayoutOption[0]);
                GUILayout.Label(styles.AnimationCompressionHelp, EditorStyles.helpBox, new GUILayoutOption[0]);
            }
        }

        private void AnimationSplitTable()
        {
            if (this.m_ClipList == null)
            {
                this.m_ClipList = new ReorderableList(new List<AnimationClipInfoProperties>(), typeof(string), false, true, true, true);
                this.m_ClipList.onAddCallback = new ReorderableList.AddCallbackDelegate(this.AddClipInList);
                this.m_ClipList.onSelectCallback = new ReorderableList.SelectCallbackDelegate(this.SelectClipInList);
                this.m_ClipList.onRemoveCallback = new ReorderableList.RemoveCallbackDelegate(this.RemoveClipInList);
                this.m_ClipList.drawElementCallback = new ReorderableList.ElementCallbackDelegate(this.DrawClipElement);
                this.m_ClipList.drawHeaderCallback = new ReorderableList.HeaderCallbackDelegate(this.DrawClipHeader);
                this.m_ClipList.elementHeight = 16f;
                this.UpdateList();
                this.m_ClipList.index = this.selectedClipIndex;
            }
            this.m_ClipList.DoLayoutList();
            EditorGUI.BeginChangeCheck();
            AnimationClipInfoProperties selectedClipInfo = this.GetSelectedClipInfo();
            if (selectedClipInfo != null)
            {
                if ((this.m_AnimationClipEditor != null) && (this.selectedClipIndex != -1))
                {
                    GUILayout.Space(5f);
                    AnimationClip target = this.m_AnimationClipEditor.target as AnimationClip;
                    if (!target.legacy)
                    {
                        this.GetSelectedClipInfo().AssignToPreviewClip(target);
                    }
                    TakeInfo[] importedTakeInfos = this.singleImporter.importedTakeInfos;
                    string[] array = new string[importedTakeInfos.Length];
                    for (int i = 0; i < importedTakeInfos.Length; i++)
                    {
                        array[i] = importedTakeInfos[i].name;
                    }
                    EditorGUI.BeginChangeCheck();
                    string name = selectedClipInfo.name;
                    int index = ArrayUtility.IndexOf<string>(array, selectedClipInfo.takeName);
                    this.m_AnimationClipEditor.takeNames = array;
                    this.m_AnimationClipEditor.takeIndex = ArrayUtility.IndexOf<string>(array, selectedClipInfo.takeName);
                    this.m_AnimationClipEditor.DrawHeader();
                    if (EditorGUI.EndChangeCheck())
                    {
                        if (selectedClipInfo.name != name)
                        {
                            this.TransferDefaultClipsToCustomClips();
                            PatchImportSettingRecycleID.Patch(base.serializedObject, 0x4a, name, selectedClipInfo.name);
                        }
                        int takeIndex = this.m_AnimationClipEditor.takeIndex;
                        if ((takeIndex != -1) && (takeIndex != index))
                        {
                            selectedClipInfo.name = this.MakeUniqueClipName(array[takeIndex], -1);
                            this.SetupTakeNameAndFrames(selectedClipInfo, importedTakeInfos[takeIndex]);
                            GUIUtility.keyboardControl = 0;
                            this.SelectClip(this.selectedClipIndex);
                            target = this.m_AnimationClipEditor.target as AnimationClip;
                        }
                    }
                    this.m_AnimationClipEditor.OnInspectorGUI();
                    if (!target.legacy)
                    {
                        this.GetSelectedClipInfo().ExtractFromPreviewClip(target);
                    }
                }
                if (EditorGUI.EndChangeCheck())
                {
                    this.TransferDefaultClipsToCustomClips();
                }
            }
        }

        private void DrawClipElement(Rect rect, int index, bool selected, bool focused)
        {
            AnimationClipInfoProperties properties = this.m_ClipList.list[index] as AnimationClipInfoProperties;
            rect.xMax -= 90f;
            GUI.Label(rect, properties.name, EditorStyles.label);
            rect.x = rect.xMax;
            rect.width = 45f;
            GUI.Label(rect, properties.firstFrame.ToString("0.0"), styles.numberStyle);
            rect.x = rect.xMax;
            GUI.Label(rect, properties.lastFrame.ToString("0.0"), styles.numberStyle);
        }

        private void DrawClipHeader(Rect rect)
        {
            rect.xMax -= 90f;
            GUI.Label(rect, "Clips", EditorStyles.label);
            rect.x = rect.xMax;
            rect.width = 45f;
            GUI.Label(rect, "Start", styles.numberStyle);
            rect.x = rect.xMax;
            GUI.Label(rect, "End", styles.numberStyle);
        }

        private AnimationClipInfoProperties GetAnimationClipInfoAtIndex(int index)
        {
            return new AnimationClipInfoProperties(this.m_ClipAnimations.GetArrayElementAtIndex(index));
        }

        private AnimationClipInfoProperties GetSelectedClipInfo()
        {
            if ((this.selectedClipIndex >= 0) && (this.selectedClipIndex < this.m_ClipAnimations.arraySize))
            {
                return this.GetAnimationClipInfoAtIndex(this.selectedClipIndex);
            }
            return null;
        }

        public override bool HasPreviewGUI()
        {
            return ((this.m_AnimationClipEditor != null) && this.m_AnimationClipEditor.HasPreviewGUI());
        }

        private bool IsDeprecatedMultiAnimationRootImport()
        {
            return ((this.animationType == ModelImporterAnimationType.Legacy) && ((this.legacyGenerateAnimations == ModelImporterGenerateAnimations.InOriginalRoots) || (this.legacyGenerateAnimations == ModelImporterGenerateAnimations.InNodes)));
        }

        private string MakeUniqueClipName(string name, int row)
        {
            int num2;
            string str = name;
            int num = 0;
            do
            {
                num2 = 0;
                for (num2 = 0; num2 < this.m_ClipAnimations.arraySize; num2++)
                {
                    AnimationClipInfoProperties animationClipInfoAtIndex = this.GetAnimationClipInfoAtIndex(num2);
                    if ((str == animationClipInfoAtIndex.name) && (row != num2))
                    {
                        str = name + num.ToString();
                        num++;
                        break;
                    }
                }
            }
            while (num2 != this.m_ClipAnimations.arraySize);
            return str;
        }

        public void OnDestroy()
        {
            UnityEngine.Object.DestroyImmediate(this.m_AnimationClipEditor);
        }

        public void OnEnable()
        {
            this.m_ClipAnimations = base.serializedObject.FindProperty("m_ClipAnimations");
            this.m_AnimationType = base.serializedObject.FindProperty("m_AnimationType");
            this.m_LegacyGenerateAnimations = base.serializedObject.FindProperty("m_LegacyGenerateAnimations");
            this.m_ImportAnimation = base.serializedObject.FindProperty("m_ImportAnimation");
            this.m_BakeSimulation = base.serializedObject.FindProperty("m_BakeSimulation");
            this.m_AnimationCompression = base.serializedObject.FindProperty("m_AnimationCompression");
            this.m_AnimationRotationError = base.serializedObject.FindProperty("m_AnimationRotationError");
            this.m_AnimationPositionError = base.serializedObject.FindProperty("m_AnimationPositionError");
            this.m_AnimationScaleError = base.serializedObject.FindProperty("m_AnimationScaleError");
            this.m_AnimationWrapMode = base.serializedObject.FindProperty("m_AnimationWrapMode");
            if (this.m_ClipAnimations.arraySize == 0)
            {
                this.SetupDefaultClips();
            }
            this.selectedClipIndex = EditorPrefs.GetInt("ModelImporterClipEditor.ActiveClipIndex", 0);
            this.ValidateClipSelectionIndex();
            EditorPrefs.SetInt("ModelImporterClipEditor.ActiveClipIndex", this.selectedClipIndex);
            if ((this.m_AnimationClipEditor != null) && (this.selectedClipIndex >= 0))
            {
                this.SyncClipEditor();
            }
            if (this.m_ClipAnimations.arraySize != 0)
            {
                this.SelectClip(this.selectedClipIndex);
            }
            string[] transformPaths = this.singleImporter.transformPaths;
            this.m_MotionNodeList = new GUIContent[transformPaths.Length + 1];
            this.m_MotionNodeList[0] = new GUIContent("<None>");
            for (int i = 0; i < transformPaths.Length; i++)
            {
                if (i == 0)
                {
                    this.m_MotionNodeList[1] = new GUIContent("<Root Transform>");
                }
                else
                {
                    this.m_MotionNodeList[i + 1] = new GUIContent(transformPaths[i]);
                }
            }
            this.m_MotionNodeName = base.serializedObject.FindProperty("m_MotionNodeName");
            this.motionNodeIndex = ArrayUtility.FindIndex<GUIContent>(this.m_MotionNodeList, content => content.text == this.m_MotionNodeName.stringValue);
            this.motionNodeIndex = (this.motionNodeIndex >= 1) ? this.motionNodeIndex : 0;
            this.m_AnimationImportErrors = base.serializedObject.FindProperty("m_AnimationImportErrors");
            this.m_AnimationImportWarnings = base.serializedObject.FindProperty("m_AnimationImportWarnings");
            this.m_AnimationRetargetingWarnings = base.serializedObject.FindProperty("m_AnimationRetargetingWarnings");
            this.m_AnimationDoRetargetingWarnings = base.serializedObject.FindProperty("m_AnimationDoRetargetingWarnings");
        }

        public override void OnInspectorGUI()
        {
            if (styles == null)
            {
                styles = new Styles();
            }
            EditorGUILayout.PropertyField(this.m_ImportAnimation, styles.ImportAnimations, new GUILayoutOption[0]);
            if (this.m_ImportAnimation.boolValue && !this.m_ImportAnimation.hasMultipleDifferentValues)
            {
                bool flag = (base.targets.Length == 1) && (this.singleImporter.importedTakeInfos.Length == 0);
                if (this.IsDeprecatedMultiAnimationRootImport())
                {
                    EditorGUILayout.HelpBox("Animation data was imported using a deprecated Generation option in the Rig tab. Please switch to a non-deprecated import mode in the Rig tab to be able to edit the animation import settings.", MessageType.Info);
                }
                else if (flag)
                {
                    if (base.serializedObject.hasModifiedProperties)
                    {
                        EditorGUILayout.HelpBox("The animations settings can be edited after clicking Apply.", MessageType.Info);
                    }
                    else
                    {
                        EditorGUILayout.HelpBox("No animation data available in this model.", MessageType.Info);
                    }
                }
                else if (this.m_AnimationType.hasMultipleDifferentValues)
                {
                    EditorGUILayout.HelpBox("The rigs of the selected models have different animation types.", MessageType.Info);
                }
                else if (this.animationType == ModelImporterAnimationType.None)
                {
                    EditorGUILayout.HelpBox("The rigs is not setup to handle animation. Edit the settings in the Rig tab.", MessageType.Info);
                }
                else if (this.m_ImportAnimation.boolValue && !this.m_ImportAnimation.hasMultipleDifferentValues)
                {
                    this.AnimationClipGUI();
                }
            }
            base.ApplyRevertGUI();
        }

        public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
        {
            if (this.m_AnimationClipEditor != null)
            {
                this.m_AnimationClipEditor.OnInteractivePreviewGUI(r, background);
            }
        }

        public override void OnPreviewSettings()
        {
            if (this.m_AnimationClipEditor != null)
            {
                this.m_AnimationClipEditor.OnPreviewSettings();
            }
        }

        private void PatchDefaultClipTakeNamesToSplitClipNames()
        {
            foreach (TakeInfo info in this.singleImporter.importedTakeInfos)
            {
                PatchImportSettingRecycleID.Patch(base.serializedObject, 0x4a, info.name, info.defaultClipName);
            }
        }

        private void RemoveClip(int index)
        {
            this.m_ClipAnimations.DeleteArrayElementAtIndex(index);
            if (this.m_ClipAnimations.arraySize == 0)
            {
                this.SetupDefaultClips();
                this.m_ImportAnimation.boolValue = false;
            }
        }

        private void RemoveClipInList(ReorderableList list)
        {
            this.TransferDefaultClipsToCustomClips();
            this.RemoveClip(list.index);
            this.UpdateList();
            this.SelectClip(Mathf.Min(list.index, list.count - 1));
        }

        internal override void ResetValues()
        {
            base.ResetValues();
            this.m_ClipAnimations = base.serializedObject.FindProperty("m_ClipAnimations");
            this.m_AnimationType = base.serializedObject.FindProperty("m_AnimationType");
            this.m_DefaultClipsSerializedObject = null;
            if (this.m_ClipAnimations.arraySize == 0)
            {
                this.SetupDefaultClips();
            }
            this.ValidateClipSelectionIndex();
            this.UpdateList();
            this.SelectClip(this.selectedClipIndex);
        }

        private void RootMotionNodeSettings()
        {
            if ((this.animationType == ModelImporterAnimationType.Human) || (this.animationType == ModelImporterAnimationType.Generic))
            {
                motionNodeFoldout = EditorGUILayout.Foldout(motionNodeFoldout, styles.MotionSetting);
                if (motionNodeFoldout)
                {
                    EditorGUI.BeginChangeCheck();
                    this.motionNodeIndex = EditorGUILayout.Popup(styles.MotionNode, this.motionNodeIndex, this.m_MotionNodeList, new GUILayoutOption[0]);
                    if (EditorGUI.EndChangeCheck())
                    {
                        if ((this.motionNodeIndex > 0) && (this.motionNodeIndex < this.m_MotionNodeList.Length))
                        {
                            this.m_MotionNodeName.stringValue = this.m_MotionNodeList[this.motionNodeIndex].text;
                        }
                        else
                        {
                            this.m_MotionNodeName.stringValue = string.Empty;
                        }
                    }
                }
            }
        }

        private void SelectClip(int selected)
        {
            if ((EditorGUI.s_DelayedTextEditor != null) && (Event.current != null))
            {
                EditorGUI.s_DelayedTextEditor.EndGUI(Event.current.type);
            }
            UnityEngine.Object.DestroyImmediate(this.m_AnimationClipEditor);
            this.m_AnimationClipEditor = null;
            this.selectedClipIndex = selected;
            if ((this.selectedClipIndex < 0) || (this.selectedClipIndex >= this.m_ClipAnimations.arraySize))
            {
                this.selectedClipIndex = -1;
            }
            else
            {
                AnimationClipInfoProperties animationClipInfoAtIndex = this.GetAnimationClipInfoAtIndex(selected);
                AnimationClip previewAnimationClipForTake = this.singleImporter.GetPreviewAnimationClipForTake(animationClipInfoAtIndex.takeName);
                if (previewAnimationClipForTake != null)
                {
                    this.m_AnimationClipEditor = (AnimationClipEditor) Editor.CreateEditor(previewAnimationClipForTake);
                    this.SyncClipEditor();
                }
            }
        }

        private void SelectClipInList(ReorderableList list)
        {
            this.SelectClip(list.index);
        }

        private void SetupDefaultClips()
        {
            this.m_DefaultClipsSerializedObject = new SerializedObject(this.target);
            this.m_ClipAnimations = this.m_DefaultClipsSerializedObject.FindProperty("m_ClipAnimations");
            this.m_AnimationType = this.m_DefaultClipsSerializedObject.FindProperty("m_AnimationType");
            this.m_ClipAnimations.arraySize = 0;
            foreach (TakeInfo info in this.singleImporter.importedTakeInfos)
            {
                this.AddClip(info);
            }
        }

        private void SetupTakeNameAndFrames(AnimationClipInfoProperties info, TakeInfo takeInfo)
        {
            info.takeName = takeInfo.name;
            info.firstFrame = (int) Mathf.Round(takeInfo.bakeStartTime * takeInfo.sampleRate);
            info.lastFrame = (int) Mathf.Round(takeInfo.bakeStopTime * takeInfo.sampleRate);
        }

        private void SyncClipEditor()
        {
            if (this.m_AnimationClipEditor != null)
            {
                this.m_AnimationClipEditor.ShowRange(this.GetAnimationClipInfoAtIndex(this.selectedClipIndex));
                this.m_AnimationClipEditor.referenceTransformPaths = this.singleImporter.transformPaths;
            }
        }

        private void TransferDefaultClipsToCustomClips()
        {
            if (this.m_DefaultClipsSerializedObject != null)
            {
                if (base.serializedObject.FindProperty("m_ClipAnimations").arraySize != 0)
                {
                    Debug.LogError("Transferring default clips failed, target already has clips");
                }
                base.serializedObject.CopyFromSerializedProperty(this.m_ClipAnimations);
                this.m_ClipAnimations = base.serializedObject.FindProperty("m_ClipAnimations");
                this.m_DefaultClipsSerializedObject = null;
                this.PatchDefaultClipTakeNamesToSplitClipNames();
                this.SyncClipEditor();
            }
        }

        private void UpdateList()
        {
            if (this.m_ClipList != null)
            {
                List<AnimationClipInfoProperties> list = new List<AnimationClipInfoProperties>();
                for (int i = 0; i < this.m_ClipAnimations.arraySize; i++)
                {
                    list.Add(this.GetAnimationClipInfoAtIndex(i));
                }
                this.m_ClipList.list = list;
            }
        }

        private void ValidateClipSelectionIndex()
        {
            if (this.selectedClipIndex > (this.m_ClipAnimations.arraySize - 1))
            {
                this.selectedClipIndex = 0;
            }
        }

        private ModelImporterAnimationType animationType
        {
            get
            {
                return (ModelImporterAnimationType) this.m_AnimationType.intValue;
            }
            set
            {
                this.m_AnimationType.intValue = (int) value;
            }
        }

        private ModelImporterGenerateAnimations legacyGenerateAnimations
        {
            get
            {
                return (ModelImporterGenerateAnimations) this.m_LegacyGenerateAnimations.intValue;
            }
            set
            {
                this.m_LegacyGenerateAnimations.intValue = (int) value;
            }
        }

        public int motionNodeIndex { get; set; }

        public int pivotNodeIndex { get; set; }

        public int selectedClipIndex
        {
            get
            {
                return this.m_SelectedClipIndexDoNotUseDirectly;
            }
            set
            {
                this.m_SelectedClipIndexDoNotUseDirectly = value;
                if (this.m_ClipList != null)
                {
                    this.m_ClipList.index = value;
                }
            }
        }

        private ModelImporter singleImporter
        {
            get
            {
                return (base.targets[0] as ModelImporter);
            }
        }

        private class Styles
        {
            public GUIContent AnimationCompressionHelp = EditorGUIUtility.TextContent("Rotation error is defined as maximum angle deviation allowed in degrees, for others it is defined as maximum distance/delta deviation allowed in percents");
            public GUIContent AnimCompressionLabel = EditorGUIUtility.TextContent("Anim. Compression|The type of compression that will be applied to this mesh's animation(s).");
            public GUIContent[] AnimCompressionOpt = new GUIContent[] { EditorGUIUtility.TextContent("Off|Disables animation compression. This means that Unity doesn't reduce keyframe count on import, which leads to the highest precision animations, but slower performance and bigger file and runtime memory size. It is generally not advisable to use this option - if you need higher precision animation, you should enable keyframe reduction and lower allowed Animation Compression Error values instead."), EditorGUIUtility.TextContent("Keyframe Reduction|Reduces keyframes on import. If selected, the Animation Compression Errors options are displayed."), EditorGUIUtility.TextContent("Optimal|Reduces keyframes on import and choose between different curve representations to reduce memory usage at runtime. This affects the runtime memory size and how curves are evaluated.") };
            public GUIContent[] AnimCompressionOptLegacy = new GUIContent[] { EditorGUIUtility.TextContent("Off|Disables animation compression. This means that Unity doesn't reduce keyframe count on import, which leads to the highest precision animations, but slower performance and bigger file and runtime memory size. It is generally not advisable to use this option - if you need higher precision animation, you should enable keyframe reduction and lower allowed Animation Compression Error values instead."), EditorGUIUtility.TextContent("Keyframe Reduction|Reduces keyframes on import. If selected, the Animation Compression Errors options are displayed."), EditorGUIUtility.TextContent("Keyframe Reduction and Compression|Reduces keyframes on import and compresses keyframes when storing animations in files. This affects only file size - the runtime memory size is the same as Keyframe Reduction. If selected, the Animation Compression Errors options are displayed.") };
            public GUIContent AnimPositionErrorLabel = EditorGUIUtility.TextContent("Position Error|Defines how much position curves should be reduced. The smaller value you use - the higher precision you get.");
            public GUIContent AnimRotationErrorLabel = EditorGUIUtility.TextContent("Rotation Error|Defines how much rotation curves should be reduced. The smaller value you use - the higher precision you get.");
            public GUIContent AnimScaleErrorLabel = EditorGUIUtility.TextContent("Scale Error|Defines how much scale curves should be reduced. The smaller value you use - the higher precision you get.");
            public GUIContent AnimWrapModeLabel = EditorGUIUtility.TextContent("Wrap Mode|The default Wrap Mode for the animation in the mesh being imported.");
            public GUIContent[] AnimWrapModeOpt = new GUIContent[] { EditorGUIUtility.TextContent("Default|The animation plays as specified in the animation splitting options below."), EditorGUIUtility.TextContent("Once|The animation plays through to the end once and then stops."), EditorGUIUtility.TextContent("Loop|The animation plays through and then restarts when the end is reached."), EditorGUIUtility.TextContent("PingPong|The animation plays through and then plays in reverse from the end to the start, and so on."), EditorGUIUtility.TextContent("ClampForever|The animation plays through but the last frame is repeated indefinitely. This is not the same as Once mode because playback does not technically stop at the last frame (which is useful when blending animations).") };
            public GUIContent BakeIK = EditorGUIUtility.TextContent("Bake Animations|Enable this when using IK or simulation in your animation package. Unity will convert to forward kinematics on import. This option is available only for Maya, 3dsMax and Cinema4D files.");
            public GUIContent clipMultiEditInfo = new GUIContent("Multi-object editing of clips not supported.");
            public GUIContent GenerateRetargetingWarnings = EditorGUIUtility.TextContent("Generate Retargeting Quality Report");
            public GUIContent ImportAnimations = EditorGUIUtility.TextContent("Import Animation|Controls if animations are imported.");
            public GUIContent ImportMessages = EditorGUIUtility.TextContent("Import Messages");
            public GUIContent MotionNode = EditorGUIUtility.TextContent("Root Motion Node|Define a transform node that will be used to create root motion curves");
            public GUIContent MotionSetting = EditorGUIUtility.TextContent("Motion|Advanced setting for root motion and blending pivot");
            public GUIStyle numberStyle = new GUIStyle(EditorStyles.label);
            public GUIContent updateMuscleDefinitionFromSource = EditorGUIUtility.TextContent("Update|Update the copy of the muscle definition from the source.");

            public Styles()
            {
                this.numberStyle.alignment = TextAnchor.UpperRight;
            }
        }
    }
}

