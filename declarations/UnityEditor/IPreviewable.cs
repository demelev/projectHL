﻿namespace UnityEditor
{
    using System;
    using UnityEngine;

    internal interface IPreviewable
    {
        void DrawPreview(Rect previewArea);
        string GetInfoString();
        GUIContent GetPreviewTitle();
        bool HasPreviewGUI();
        void Initialize(UnityEngine.Object[] targets);
        bool MoveNextTarget();
        void OnInteractivePreviewGUI(Rect r, GUIStyle background);
        void OnPreviewGUI(Rect r, GUIStyle background);
        void OnPreviewSettings();
        void ReloadPreviewInstances();
        void ResetTarget();

        UnityEngine.Object target { get; }
    }
}

