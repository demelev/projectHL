﻿namespace UnityEditor
{
    using System;
    using System.Runtime.CompilerServices;
    using UnityEditorInternal;
    using UnityEngine;

    internal class AssetPopupBackend
    {
        public static void AssetPopup<T>(SerializedProperty serializedProperty, GUIContent label, string fileExtension) where T: UnityEngine.Object, new()
        {
            GUIContent mixedValueContent;
            Rect rect;
            bool showMixedValue = EditorGUI.showMixedValue;
            EditorGUI.showMixedValue = serializedProperty.hasMultipleDifferentValues;
            string objectReferenceTypeString = serializedProperty.objectReferenceTypeString;
            if (serializedProperty.hasMultipleDifferentValues)
            {
                mixedValueContent = EditorGUI.mixedValueContent;
            }
            else if (serializedProperty.objectReferenceValue != null)
            {
                mixedValueContent = GUIContent.Temp(serializedProperty.objectReferenceStringValue);
            }
            else
            {
                mixedValueContent = GUIContent.Temp("Default");
            }
            if (AudioMixerEffectGUI.PopupButton(label, mixedValueContent, EditorStyles.popup, out rect, new GUILayoutOption[0]))
            {
                ShowAssetsPopupMenu<T>(rect, objectReferenceTypeString, serializedProperty, fileExtension);
            }
            EditorGUI.showMixedValue = showMixedValue;
        }

        private static void AssetPopupMenuCallback(object userData)
        {
            object[] objArray = userData as object[];
            int instanceID = (int) objArray[0];
            SerializedProperty property = (SerializedProperty) objArray[1];
            property.objectReferenceValue = EditorUtility.InstanceIDToObject(instanceID);
            property.m_SerializedObject.ApplyModifiedProperties();
        }

        private static void ShowAssetsPopupMenu<T>(Rect buttonRect, string typeName, SerializedProperty serializedProperty, string fileExtension) where T: UnityEngine.Object, new()
        {
            <ShowAssetsPopupMenu>c__AnonStorey6A<T> storeya = new <ShowAssetsPopupMenu>c__AnonStorey6A<T> {
                typeName = typeName,
                fileExtension = fileExtension,
                serializedProperty = serializedProperty
            };
            GenericMenu menu = new GenericMenu();
            int num = (storeya.serializedProperty.objectReferenceValue == null) ? 0 : storeya.serializedProperty.objectReferenceValue.GetInstanceID();
            object[] userData = new object[] { 0, storeya.serializedProperty };
            menu.AddItem(new GUIContent("Default"), num == 0, new GenericMenu.MenuFunction2(AssetPopupBackend.AssetPopupMenuCallback), userData);
            HierarchyProperty property = new HierarchyProperty(HierarchyType.Assets);
            SearchFilter filter2 = new SearchFilter();
            filter2.classNames = new string[] { storeya.typeName };
            SearchFilter filter = filter2;
            property.SetSearchFilter(filter);
            property.Reset();
            while (property.Next(null))
            {
                object[] objArray2 = new object[] { property.instanceID, storeya.serializedProperty };
                menu.AddItem(new GUIContent(property.name), property.instanceID == num, new GenericMenu.MenuFunction2(AssetPopupBackend.AssetPopupMenuCallback), objArray2);
            }
            int classID = BaseObjectTools.StringToClassID(storeya.typeName);
            if (classID > 0)
            {
                foreach (BuiltinResource resource in EditorGUIUtility.GetBuiltinResourceList(classID))
                {
                    object[] objArray3 = new object[] { resource.m_InstanceID, storeya.serializedProperty };
                    menu.AddItem(new GUIContent(resource.m_Name), resource.m_InstanceID == num, new GenericMenu.MenuFunction2(AssetPopupBackend.AssetPopupMenuCallback), objArray3);
                }
            }
            menu.AddSeparator(string.Empty);
            menu.AddItem(new GUIContent("Create New..."), false, new GenericMenu.MenuFunction(storeya.<>m__EB));
            menu.DropDown(buttonRect);
        }

        [CompilerGenerated]
        private sealed class <ShowAssetsPopupMenu>c__AnonStorey6A<T> where T: UnityEngine.Object, new()
        {
            internal string fileExtension;
            internal SerializedProperty serializedProperty;
            internal string typeName;

            internal void <>m__EB()
            {
                T asset = Activator.CreateInstance<T>();
                ProjectWindowUtil.CreateAsset(asset, "New " + this.typeName + "." + this.fileExtension);
                this.serializedProperty.objectReferenceValue = asset;
                this.serializedProperty.m_SerializedObject.ApplyModifiedProperties();
            }
        }
    }
}

