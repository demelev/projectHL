﻿namespace UnityEditor
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using UnityEngine;

    internal sealed class PolygonEditor
    {
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ApplyEditing(Collider2D collider);
        public static bool GetNearestEdge(Vector2 point, out int pathIndex, out int pointIndex0, out int pointIndex1, out float distance, bool loop)
        {
            return INTERNAL_CALL_GetNearestEdge(ref point, out pathIndex, out pointIndex0, out pointIndex1, out distance, loop);
        }

        public static bool GetNearestPoint(Vector2 point, out int pathIndex, out int pointIndex, out float distance)
        {
            return INTERNAL_CALL_GetNearestPoint(ref point, out pathIndex, out pointIndex, out distance);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int GetPathCount();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool GetPoint(int pathIndex, int pointIndex, out Vector2 point);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int GetPointCount(int pathIndex);
        public static void InsertPoint(int pathIndex, int pointIndex, Vector2 value)
        {
            INTERNAL_CALL_InsertPoint(pathIndex, pointIndex, ref value);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern bool INTERNAL_CALL_GetNearestEdge(ref Vector2 point, out int pathIndex, out int pointIndex0, out int pointIndex1, out float distance, bool loop);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern bool INTERNAL_CALL_GetNearestPoint(ref Vector2 point, out int pathIndex, out int pointIndex, out float distance);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_CALL_InsertPoint(int pathIndex, int pointIndex, ref Vector2 value);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_CALL_SetPoint(int pathIndex, int pointIndex, ref Vector2 value);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_CALL_TestPointMove(int pathIndex, int pointIndex, ref Vector2 movePosition, out bool leftIntersect, out bool rightIntersect, bool loop);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RemovePoint(int pathIndex, int pointIndex);
        public static void SetPoint(int pathIndex, int pointIndex, Vector2 value)
        {
            INTERNAL_CALL_SetPoint(pathIndex, pointIndex, ref value);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void StartEditing(Collider2D collider);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void StopEditing();
        public static void TestPointMove(int pathIndex, int pointIndex, Vector2 movePosition, out bool leftIntersect, out bool rightIntersect, bool loop)
        {
            INTERNAL_CALL_TestPointMove(pathIndex, pointIndex, ref movePosition, out leftIntersect, out rightIntersect, loop);
        }
    }
}

