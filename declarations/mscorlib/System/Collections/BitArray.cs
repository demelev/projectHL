﻿namespace System.Collections
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;

    [Serializable, ComVisible(true)]
    public sealed class BitArray : ICollection, IEnumerable, ICloneable
    {
        private const int _ShrinkThreshold = 0x100;
        [NonSerialized]
        private object _syncRoot;
        private int _version;
        private int[] m_array;
        private int m_length;

        private BitArray()
        {
        }

        public BitArray(int length) : this(length, false)
        {
        }

        public BitArray(bool[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            this.m_array = new int[(values.Length + 0x1f) / 0x20];
            this.m_length = values.Length;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i])
                {
                    this.m_array[i / 0x20] |= ((int) 1) << (i % 0x20);
                }
            }
            this._version = 0;
        }

        public BitArray(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            this.m_array = new int[(bytes.Length + 3) / 4];
            this.m_length = bytes.Length * 8;
            int index = 0;
            int num2 = 0;
            while ((bytes.Length - num2) >= 4)
            {
                this.m_array[index++] = (((bytes[num2] & 0xff) | ((bytes[num2 + 1] & 0xff) << 8)) | ((bytes[num2 + 2] & 0xff) << 0x10)) | ((bytes[num2 + 3] & 0xff) << 0x18);
                num2 += 4;
            }
            switch ((bytes.Length - num2))
            {
                case 1:
                    goto Label_00DB;

                case 2:
                    break;

                case 3:
                    this.m_array[index] = (bytes[num2 + 2] & 0xff) << 0x10;
                    break;

                default:
                    goto Label_00FC;
            }
            this.m_array[index] |= (bytes[num2 + 1] & 0xff) << 8;
        Label_00DB:
            this.m_array[index] |= bytes[num2] & 0xff;
        Label_00FC:
            this._version = 0;
        }

        public BitArray(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            this.m_array = new int[values.Length];
            this.m_length = values.Length * 0x20;
            Array.Copy(values, this.m_array, values.Length);
            this._version = 0;
        }

        public BitArray(BitArray bits)
        {
            if (bits == null)
            {
                throw new ArgumentNullException("bits");
            }
            this.m_array = new int[(bits.m_length + 0x1f) / 0x20];
            this.m_length = bits.m_length;
            Array.Copy(bits.m_array, this.m_array, (int) ((bits.m_length + 0x1f) / 0x20));
            this._version = bits._version;
        }

        public BitArray(int length, bool defaultValue)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
            }
            this.m_array = new int[(length + 0x1f) / 0x20];
            this.m_length = length;
            int num = defaultValue ? -1 : 0;
            for (int i = 0; i < this.m_array.Length; i++)
            {
                this.m_array[i] = num;
            }
            this._version = 0;
        }

        public BitArray And(BitArray value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (this.m_length != value.m_length)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
            }
            int num = (this.m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                this.m_array[i] &= value.m_array[i];
            }
            this._version++;
            return this;
        }

        public object Clone()
        {
            return new BitArray(this.m_array) { _version = this._version, m_length = this.m_length };
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (array.Rank != 1)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
            }
            if (array is int[])
            {
                Array.Copy(this.m_array, 0, array, index, (this.m_length + 0x1f) / 0x20);
            }
            else if (array is byte[])
            {
                if ((array.Length - index) < ((this.m_length + 7) / 8))
                {
                    throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
                }
                byte[] buffer = (byte[]) array;
                for (int i = 0; i < ((this.m_length + 7) / 8); i++)
                {
                    buffer[index + i] = (byte) ((this.m_array[i / 4] >> ((i % 4) * 8)) & 0xff);
                }
            }
            else
            {
                if (!(array is bool[]))
                {
                    throw new ArgumentException(Environment.GetResourceString("Arg_BitArrayTypeUnsupported"));
                }
                if ((array.Length - index) < this.m_length)
                {
                    throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
                }
                bool[] flagArray = (bool[]) array;
                for (int j = 0; j < this.m_length; j++)
                {
                    flagArray[index + j] = ((this.m_array[j / 0x20] >> (j % 0x20)) & 1) != 0;
                }
            }
        }

        public bool Get(int index)
        {
            if ((index < 0) || (index >= this.m_length))
            {
                throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
            }
            return ((this.m_array[index / 0x20] & (((int) 1) << (index % 0x20))) != 0);
        }

        public IEnumerator GetEnumerator()
        {
            return new BitArrayEnumeratorSimple(this);
        }

        public BitArray Not()
        {
            int num = (this.m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                this.m_array[i] = ~this.m_array[i];
            }
            this._version++;
            return this;
        }

        public BitArray Or(BitArray value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (this.m_length != value.m_length)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
            }
            int num = (this.m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                this.m_array[i] |= value.m_array[i];
            }
            this._version++;
            return this;
        }

        public void Set(int index, bool value)
        {
            if ((index < 0) || (index >= this.m_length))
            {
                throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
            }
            if (value)
            {
                this.m_array[index / 0x20] |= ((int) 1) << (index % 0x20);
            }
            else
            {
                this.m_array[index / 0x20] &= ~(((int) 1) << (index % 0x20));
            }
            this._version++;
        }

        public void SetAll(bool value)
        {
            int num = value ? -1 : 0;
            int num2 = (this.m_length + 0x1f) / 0x20;
            for (int i = 0; i < num2; i++)
            {
                this.m_array[i] = num;
            }
            this._version++;
        }

        public BitArray Xor(BitArray value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (this.m_length != value.m_length)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
            }
            int num = (this.m_length + 0x1f) / 0x20;
            for (int i = 0; i < num; i++)
            {
                this.m_array[i] ^= value.m_array[i];
            }
            this._version++;
            return this;
        }

        public int Count
        {
            get
            {
                return this.m_length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public bool this[int index]
        {
            get
            {
                return this.Get(index);
            }
            set
            {
                this.Set(index, value);
            }
        }

        public int Length
        {
            get
            {
                return this.m_length;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
                }
                int num = (value + 0x1f) / 0x20;
                if ((num > this.m_array.Length) || ((num + 0x100) < this.m_array.Length))
                {
                    int[] destinationArray = new int[num];
                    Array.Copy(this.m_array, destinationArray, (num > this.m_array.Length) ? this.m_array.Length : num);
                    this.m_array = destinationArray;
                }
                if (value > this.m_length)
                {
                    int index = ((this.m_length + 0x1f) / 0x20) - 1;
                    int num3 = this.m_length % 0x20;
                    if (num3 > 0)
                    {
                        this.m_array[index] &= (((int) 1) << num3) - 1;
                    }
                    Array.Clear(this.m_array, index + 1, (num - index) - 1);
                }
                this.m_length = value;
                this._version++;
            }
        }

        public object SyncRoot
        {
            get
            {
                if (this._syncRoot == null)
                {
                    Interlocked.CompareExchange(ref this._syncRoot, new object(), null);
                }
                return this._syncRoot;
            }
        }

        [Serializable]
        private class BitArrayEnumeratorSimple : IEnumerator, ICloneable
        {
            private BitArray bitarray;
            private bool currentElement;
            private int index;
            private int version;

            internal BitArrayEnumeratorSimple(BitArray bitarray)
            {
                this.bitarray = bitarray;
                this.index = -1;
                this.version = bitarray._version;
            }

            public object Clone()
            {
                return base.MemberwiseClone();
            }

            public virtual bool MoveNext()
            {
                if (this.version != this.bitarray._version)
                {
                    throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
                }
                if (this.index < (this.bitarray.Count - 1))
                {
                    this.index++;
                    this.currentElement = this.bitarray.Get(this.index);
                    return true;
                }
                this.index = this.bitarray.Count;
                return false;
            }

            public void Reset()
            {
                if (this.version != this.bitarray._version)
                {
                    throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
                }
                this.index = -1;
            }

            public virtual object Current
            {
                get
                {
                    if (this.index == -1)
                    {
                        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
                    }
                    if (this.index >= this.bitarray.Count)
                    {
                        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
                    }
                    return this.currentElement;
                }
            }
        }
    }
}

