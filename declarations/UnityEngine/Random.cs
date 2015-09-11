﻿namespace UnityEngine
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public sealed class Random
    {
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void GetRandomUnitCircle(out Vector2 output);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_get_insideUnitSphere(out Vector3 value);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_get_onUnitSphere(out Vector3 value);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_get_rotation(out Quaternion value);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_get_rotationUniform(out Quaternion value);
        [Obsolete("Use Random.Range instead")]
        public static int RandomRange(int min, int max)
        {
            return Range(min, max);
        }

        [Obsolete("Use Random.Range instead")]
        public static float RandomRange(float min, float max)
        {
            return Range(min, max);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern int RandomRangeInt(int min, int max);
        public static int Range(int min, int max)
        {
            return RandomRangeInt(min, max);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern float Range(float min, float max);

        public static Vector2 insideUnitCircle
        {
            get
            {
                Vector2 vector;
                GetRandomUnitCircle(out vector);
                return vector;
            }
        }

        public static Vector3 insideUnitSphere
        {
            get
            {
                Vector3 vector;
                INTERNAL_get_insideUnitSphere(out vector);
                return vector;
            }
        }

        public static Vector3 onUnitSphere
        {
            get
            {
                Vector3 vector;
                INTERNAL_get_onUnitSphere(out vector);
                return vector;
            }
        }

        public static Quaternion rotation
        {
            get
            {
                Quaternion quaternion;
                INTERNAL_get_rotation(out quaternion);
                return quaternion;
            }
        }

        public static Quaternion rotationUniform
        {
            get
            {
                Quaternion quaternion;
                INTERNAL_get_rotationUniform(out quaternion);
                return quaternion;
            }
        }

        public static int seed { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public static float value { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; }
    }
}

