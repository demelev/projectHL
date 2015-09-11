﻿namespace UnityEditor
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public sealed class Undo
    {
        public static PostprocessModifications postprocessModifications;
        public static UndoRedoCallback undoRedoPerformed;
        public static WillFlushUndoRecord willFlushUndoRecord;

        public static T AddComponent<T>(GameObject gameObject) where T: Component
        {
            return (AddComponent(gameObject, typeof(T)) as T);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern Component AddComponent(GameObject gameObject, System.Type type);
        [Obsolete("Use Undo.RecordObject instead")]
        public static void ClearSnapshotTarget()
        {
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ClearUndo(UnityEngine.Object identifier);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void CollapseUndoOperations(int groupIndex);
        [Obsolete("Use Undo.RecordObject instead")]
        public static void CreateSnapshot()
        {
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DestroyObjectImmediate(UnityEngine.Object objectToUndo);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void FlushUndoRecordObjects();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int GetCurrentGroup();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetCurrentGroupName();
        internal static void GetRecords(List<string> undoRecords, List<string> redoRecords)
        {
            GetRecordsInternal(undoRecords, redoRecords);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void GetRecordsInternal(object undoRecords, object redoRecords);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void IncrementCurrentGroup();
        private static void Internal_CallUndoRedoPerformed()
        {
            if (undoRedoPerformed != null)
            {
                undoRedoPerformed();
            }
        }

        private static void Internal_CallWillFlushUndoRecord()
        {
            if (willFlushUndoRecord != null)
            {
                willFlushUndoRecord();
            }
        }

        private static UndoPropertyModification[] InvokePostprocessModifications(UndoPropertyModification[] modifications)
        {
            if (postprocessModifications != null)
            {
                return postprocessModifications(modifications);
            }
            return modifications;
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void PerformRedo();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void PerformUndo();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RecordObject(UnityEngine.Object objectToUndo, string name);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RecordObjects(UnityEngine.Object[] objectsToUndo, string name);
        public static void RegisterCompleteObjectUndo(UnityEngine.Object objectToUndo, string name)
        {
            UnityEngine.Object[] objectsToUndo = new UnityEngine.Object[] { objectToUndo };
            RegisterCompleteObjectUndoMultiple(objectToUndo, objectsToUndo, name, 0);
        }

        public static void RegisterCompleteObjectUndo(UnityEngine.Object[] objectsToUndo, string name)
        {
            if (objectsToUndo.Length > 0)
            {
                RegisterCompleteObjectUndoMultiple(objectsToUndo[0], objectsToUndo, name, 0);
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void RegisterCompleteObjectUndoMultiple(UnityEngine.Object identifier, UnityEngine.Object[] objectsToUndo, string name, int namePriority);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RegisterCreatedObjectUndo(UnityEngine.Object objectToUndo, string name);
        [Obsolete("Use Undo.RegisterFullObjectHierarchyUndo(Object, string) instead")]
        public static void RegisterFullObjectHierarchyUndo(UnityEngine.Object objectToUndo)
        {
            RegisterFullObjectHierarchyUndo(objectToUndo, "Full Object Hierarchy");
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RegisterFullObjectHierarchyUndo(UnityEngine.Object objectToUndo, string name);
        [Obsolete("Use DestroyObjectImmediate, RegisterCreatedObjectUndo or RegisterUndo instead.")]
        public static void RegisterSceneUndo(string name)
        {
        }

        [Obsolete("Use Undo.RecordObject instead")]
        public static void RegisterSnapshot()
        {
        }

        [Obsolete("Use Undo.RecordObject instead")]
        public static void RegisterUndo(UnityEngine.Object objectToUndo, string name)
        {
            RegisterCompleteObjectUndo(objectToUndo, name);
        }

        [Obsolete("Use Undo.RecordObjects instead")]
        public static void RegisterUndo(UnityEngine.Object[] objectsToUndo, string name)
        {
            RegisterCompleteObjectUndo(objectsToUndo, name);
        }

        [Obsolete("Use Undo.RecordObject instead")]
        public static void RestoreSnapshot()
        {
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RevertAllDownToGroup(int group);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RevertAllInCurrentGroup();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetCurrentGroupName(string name);
        [Obsolete("Use Undo.RecordObject instead")]
        public static void SetSnapshotTarget(UnityEngine.Object objectToUndo, string name)
        {
        }

        [Obsolete("Use Undo.RecordObject instead")]
        public static void SetSnapshotTarget(UnityEngine.Object[] objectsToUndo, string name)
        {
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetTransformParent(Transform transform, Transform newParent, string name);

        public delegate UndoPropertyModification[] PostprocessModifications(UndoPropertyModification[] modifications);

        public delegate void UndoRedoCallback();

        public delegate void WillFlushUndoRecord();
    }
}

