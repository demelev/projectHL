﻿namespace System
{
    using System.Runtime.Serialization;

    [Serializable]
    internal sealed class Empty : ISerializable
    {
        public static readonly Empty Value = new Empty();

        private Empty()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            UnitySerializationHolder.GetUnitySerializationInfo(info, 1, null, null);
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}

