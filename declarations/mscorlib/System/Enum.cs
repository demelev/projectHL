﻿namespace System
{
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    [Serializable, ComVisible(true)]
    public abstract class Enum : ValueType, IComparable, IFormattable, IConvertible
    {
        private const string enumSeperator = ", ";
        private static char[] enumSeperatorCharArray;
        private static Hashtable fieldInfoHash;
        private static Type intType;
        private const int maxHashElements = 100;
        private static Type stringType;

        static Enum()
        {
            enumSeperatorCharArray = new char[] { ',' };
            intType = typeof(int);
            stringType = typeof(string);
            fieldInfoHash = Hashtable.Synchronized(new Hashtable());
        }

        protected Enum()
        {
        }

        private static int BinarySearch(ulong[] array, ulong value)
        {
            int num = 0;
            int num2 = array.Length - 1;
            while (num <= num2)
            {
                int index = (num + num2) >> 1;
                ulong num4 = array[index];
                if (value == num4)
                {
                    return index;
                }
                if (num4 < value)
                {
                    num = index + 1;
                }
                else
                {
                    num2 = index - 1;
                }
            }
            return ~num;
        }

        public int CompareTo(object target)
        {
            if (this == 0)
            {
                throw new NullReferenceException();
            }
            int num = InternalCompareTo(this, target);
            if (num < 2)
            {
                return num;
            }
            if (num == 2)
            {
                Type type = base.GetType();
                Type type2 = target.GetType();
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_EnumAndObjectMustBeSameType"), new object[] { type2.ToString(), type.ToString() }));
            }
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern bool Equals(object obj);
        [ComVisible(true)]
        public static string Format(Type enumType, object value, string format)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            Type type = value.GetType();
            if (!(type is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "valueType");
            }
            Type underlyingType = GetUnderlyingType(enumType);
            if (type.IsEnum)
            {
                Type type3 = GetUnderlyingType(type);
                if (type != enumType)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_EnumAndObjectMustBeSameType"), new object[] { type.ToString(), enumType.ToString() }));
                }
                type = type3;
                value = ((Enum) value).GetValue();
            }
            else if (type != underlyingType)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_EnumFormatUnderlyingTypeAndObjectMustBeSameType"), new object[] { type.ToString(), underlyingType.ToString() }));
            }
            if (format.Length != 1)
            {
                throw new FormatException(Environment.GetResourceString("Format_InvalidEnumFormatSpecification"));
            }
            char ch = format[0];
            switch (ch)
            {
                case 'D':
                case 'd':
                    return value.ToString();

                case 'X':
                case 'x':
                    return InternalFormattedHexString(value);

                case 'G':
                case 'g':
                    return InternalFormat(enumType, value);
            }
            if ((ch != 'F') && (ch != 'f'))
            {
                throw new FormatException(Environment.GetResourceString("Format_InvalidEnumFormatSpecification"));
            }
            return InternalFlagsFormat(enumType, value);
        }

        public override int GetHashCode()
        {
            return this.GetValue().GetHashCode();
        }

        private static HashEntry GetHashEntry(Type enumType)
        {
            HashEntry entry = (HashEntry) fieldInfoHash[enumType];
            if (entry == null)
            {
                if (fieldInfoHash.Count > 100)
                {
                    fieldInfoHash.Clear();
                }
                ulong[] values = null;
                string[] names = null;
                if (enumType.BaseType == typeof(Enum))
                {
                    InternalGetEnumValues(enumType, ref values, ref names);
                }
                else
                {
                    FieldInfo[] fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
                    values = new ulong[fields.Length];
                    names = new string[fields.Length];
                    for (int i = 0; i < fields.Length; i++)
                    {
                        names[i] = fields[i].Name;
                        values[i] = ToUInt64(fields[i].GetValue(null));
                    }
                    for (int j = 1; j < values.Length; j++)
                    {
                        int index = j;
                        string str = names[j];
                        ulong num4 = values[j];
                        bool flag = false;
                        while (values[index - 1] > num4)
                        {
                            names[index] = names[index - 1];
                            values[index] = values[index - 1];
                            index--;
                            flag = true;
                            if (index == 0)
                            {
                                break;
                            }
                        }
                        if (flag)
                        {
                            names[index] = str;
                            values[index] = num4;
                        }
                    }
                }
                entry = new HashEntry(names, values);
                fieldInfoHash[enumType] = entry;
            }
            return entry;
        }

        [ComVisible(true)]
        public static string GetName(Type enumType, object value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            Type type = value.GetType();
            if (((!type.IsEnum && (type != intType)) && ((type != typeof(short)) && (type != typeof(ushort)))) && (((type != typeof(byte)) && (type != typeof(sbyte))) && (((type != typeof(uint)) && (type != typeof(long))) && (type != typeof(ulong)))))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), "value");
            }
            return InternalGetValueAsString(enumType, value);
        }

        [ComVisible(true)]
        public static string[] GetNames(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            string[] names = GetHashEntry(enumType).names;
            string[] destinationArray = new string[names.Length];
            Array.Copy(names, destinationArray, names.Length);
            return destinationArray;
        }

        public TypeCode GetTypeCode()
        {
            Type underlyingType = GetUnderlyingType(base.GetType());
            if (underlyingType == typeof(int))
            {
                return TypeCode.Int32;
            }
            if (underlyingType == typeof(sbyte))
            {
                return TypeCode.SByte;
            }
            if (underlyingType == typeof(short))
            {
                return TypeCode.Int16;
            }
            if (underlyingType == typeof(long))
            {
                return TypeCode.Int64;
            }
            if (underlyingType == typeof(uint))
            {
                return TypeCode.UInt32;
            }
            if (underlyingType == typeof(byte))
            {
                return TypeCode.Byte;
            }
            if (underlyingType == typeof(ushort))
            {
                return TypeCode.UInt16;
            }
            if (underlyingType != typeof(ulong))
            {
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
            }
            return TypeCode.UInt64;
        }

        [ComVisible(true)]
        public static Type GetUnderlyingType(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (enumType is EnumBuilder)
            {
                return ((EnumBuilder) enumType).UnderlyingSystemType;
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalGetUnderlyingType(enumType);
        }

        private object GetValue()
        {
            return this.InternalGetValue();
        }

        private static FieldInfo GetValueField(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if ((fields == null) || (fields.Length != 1))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_EnumMustHaveUnderlyingValueField"));
            }
            return fields[0];
        }

        [ComVisible(true)]
        public static Array GetValues(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            ulong[] values = GetHashEntry(enumType).values;
            Array array = Array.CreateInstance(enumType, values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                object obj2 = ToObject(enumType, values[i]);
                array.SetValue(obj2, i);
            }
            return array;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern object InternalBoxEnum(Type enumType, long value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int InternalCompareTo(object o1, object o2);
        private static string InternalFlagsFormat(Type eT, object value)
        {
            ulong num = ToUInt64(value);
            HashEntry hashEntry = GetHashEntry(eT);
            string[] names = hashEntry.names;
            ulong[] values = hashEntry.values;
            int index = values.Length - 1;
            StringBuilder builder = new StringBuilder();
            bool flag = true;
            ulong num3 = num;
            while (index >= 0)
            {
                if ((index == 0) && (values[index] == 0L))
                {
                    break;
                }
                if ((num & values[index]) == values[index])
                {
                    num -= values[index];
                    if (!flag)
                    {
                        builder.Insert(0, ", ");
                    }
                    builder.Insert(0, names[index]);
                    flag = false;
                }
                index--;
            }
            if (num != 0L)
            {
                return value.ToString();
            }
            if (num3 != 0L)
            {
                return builder.ToString();
            }
            if (values[0] == 0L)
            {
                return names[0];
            }
            return "0";
        }

        private static string InternalFormat(Type eT, object value)
        {
            if (eT.IsDefined(typeof(FlagsAttribute), false))
            {
                return InternalFlagsFormat(eT, value);
            }
            string valueAsString = InternalGetValueAsString(eT, value);
            if (valueAsString == null)
            {
                return value.ToString();
            }
            return valueAsString;
        }

        private static string InternalFormattedHexString(object value)
        {
            switch (Convert.GetTypeCode(value))
            {
                case TypeCode.SByte:
                {
                    byte num = (byte) ((sbyte) value);
                    return num.ToString("X2", null);
                }
                case TypeCode.Byte:
                {
                    byte num2 = (byte) value;
                    return num2.ToString("X2", null);
                }
                case TypeCode.Int16:
                {
                    ushort num3 = (ushort) ((short) value);
                    return num3.ToString("X4", null);
                }
                case TypeCode.UInt16:
                {
                    ushort num4 = (ushort) value;
                    return num4.ToString("X4", null);
                }
                case TypeCode.Int32:
                {
                    uint num6 = (uint) ((int) value);
                    return num6.ToString("X8", null);
                }
                case TypeCode.UInt32:
                {
                    uint num5 = (uint) value;
                    return num5.ToString("X8", null);
                }
                case TypeCode.Int64:
                {
                    ulong num8 = (ulong) ((long) value);
                    return num8.ToString("X16", null);
                }
                case TypeCode.UInt64:
                {
                    ulong num7 = (ulong) value;
                    return num7.ToString("X16", null);
                }
            }
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void InternalGetEnumValues(Type enumType, ref ulong[] values, ref string[] names);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Type InternalGetUnderlyingType(Type enumType);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern object InternalGetValue();
        private static string InternalGetValueAsString(Type enumType, object value)
        {
            HashEntry hashEntry = GetHashEntry(enumType);
            Type underlyingType = GetUnderlyingType(enumType);
            if ((((underlyingType == intType) || (underlyingType == typeof(short))) || ((underlyingType == typeof(long)) || (underlyingType == typeof(ushort)))) || (((underlyingType == typeof(byte)) || (underlyingType == typeof(sbyte))) || ((underlyingType == typeof(uint)) || (underlyingType == typeof(ulong)))))
            {
                ulong num = ToUInt64(value);
                int index = BinarySearch(hashEntry.values, num);
                if (index >= 0)
                {
                    return hashEntry.names[index];
                }
            }
            return null;
        }

        [ComVisible(true)]
        public static bool IsDefined(Type enumType, object value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            Type type = value.GetType();
            if (!(type is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "valueType");
            }
            Type underlyingType = GetUnderlyingType(enumType);
            if (type.IsEnum)
            {
                Type type3 = GetUnderlyingType(type);
                if (type != enumType)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_EnumAndObjectMustBeSameType"), new object[] { type.ToString(), enumType.ToString() }));
                }
                type = type3;
            }
            else if ((type != underlyingType) && (type != stringType))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_EnumUnderlyingTypeAndObjectMustBeSameType"), new object[] { type.ToString(), underlyingType.ToString() }));
            }
            if (type == stringType)
            {
                string[] names = GetHashEntry(enumType).names;
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i].Equals((string) value))
                    {
                        return true;
                    }
                }
                return false;
            }
            ulong[] values = GetHashEntry(enumType).values;
            if ((((type != intType) && (type != typeof(short))) && ((type != typeof(ushort)) && (type != typeof(byte)))) && (((type != typeof(sbyte)) && (type != typeof(uint))) && ((type != typeof(long)) && (type != typeof(ulong)))))
            {
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
            }
            ulong num2 = ToUInt64(value);
            return (BinarySearch(values, num2) >= 0);
        }

        [ComVisible(true)]
        public static object Parse(Type enumType, string value)
        {
            return Parse(enumType, value, false);
        }

        [ComVisible(true)]
        public static object Parse(Type enumType, string value, bool ignoreCase)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            value = value.Trim();
            if (value.Length == 0)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustContainEnumInfo"));
            }
            ulong num = 0L;
            if ((char.IsDigit(value[0]) || (value[0] == '-')) || (value[0] == '+'))
            {
                Type underlyingType = GetUnderlyingType(enumType);
                try
                {
                    object obj2 = Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture);
                    return ToObject(enumType, obj2);
                }
                catch (FormatException)
                {
                }
            }
            string[] strArray = value.Split(enumSeperatorCharArray);
            HashEntry hashEntry = GetHashEntry(enumType);
            string[] names = hashEntry.names;
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = strArray[i].Trim();
                bool flag = false;
                for (int j = 0; j < names.Length; j++)
                {
                    ulong num4;
                    if (ignoreCase)
                    {
                        if (string.Compare(names[j], strArray[i], StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            goto Label_0122;
                        }
                        continue;
                    }
                    if (!names[j].Equals(strArray[i]))
                    {
                        continue;
                    }
                Label_0122:
                    num4 = hashEntry.values[j];
                    num |= num4;
                    flag = true;
                    break;
                }
                if (!flag)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_EnumValueNotFound"), new object[] { value }));
                }
            }
            return ToObject(enumType, num);
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(this.GetValue(), CultureInfo.CurrentCulture);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(this.GetValue(), CultureInfo.CurrentCulture);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(this.GetValue(), CultureInfo.CurrentCulture);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("InvalidCast_FromTo"), new object[] { "Enum", "DateTime" }));
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(this.GetValue(), CultureInfo.CurrentCulture);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(this.GetValue(), CultureInfo.CurrentCulture);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(this.GetValue(), CultureInfo.CurrentCulture);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(this.GetValue(), CultureInfo.CurrentCulture);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(this.GetValue(), CultureInfo.CurrentCulture);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(this.GetValue(), CultureInfo.CurrentCulture);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(this.GetValue(), CultureInfo.CurrentCulture);
        }

        object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return Convert.DefaultToType(this, type, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(this.GetValue(), CultureInfo.CurrentCulture);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(this.GetValue(), CultureInfo.CurrentCulture);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(this.GetValue(), CultureInfo.CurrentCulture);
        }

        private string ToHexString()
        {
            return InternalFormattedHexString(((RtFieldInfo) GetValueField(base.GetType())).InternalGetValue(this, false));
        }

        [ComVisible(true)]
        public static object ToObject(Type enumType, byte value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, (long) value);
        }

        [ComVisible(true)]
        public static object ToObject(Type enumType, short value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, (long) value);
        }

        [ComVisible(true)]
        public static object ToObject(Type enumType, int value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, (long) value);
        }

        [ComVisible(true)]
        public static object ToObject(Type enumType, long value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, value);
        }

        [ComVisible(true)]
        public static object ToObject(Type enumType, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            switch (Convert.GetTypeCode(value))
            {
                case TypeCode.SByte:
                    return ToObject(enumType, (sbyte) value);

                case TypeCode.Byte:
                    return ToObject(enumType, (byte) value);

                case TypeCode.Int16:
                    return ToObject(enumType, (short) value);

                case TypeCode.UInt16:
                    return ToObject(enumType, (ushort) value);

                case TypeCode.Int32:
                    return ToObject(enumType, (int) value);

                case TypeCode.UInt32:
                    return ToObject(enumType, (uint) value);

                case TypeCode.Int64:
                    return ToObject(enumType, (long) value);

                case TypeCode.UInt64:
                    return ToObject(enumType, (ulong) value);
            }
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), "value");
        }

        [ComVisible(true), CLSCompliant(false)]
        public static object ToObject(Type enumType, sbyte value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, (long) value);
        }

        [ComVisible(true), CLSCompliant(false)]
        public static object ToObject(Type enumType, ushort value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, (long) value);
        }

        [CLSCompliant(false), ComVisible(true)]
        public static object ToObject(Type enumType, uint value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, (long) value);
        }

        [CLSCompliant(false), ComVisible(true)]
        public static object ToObject(Type enumType, ulong value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!(enumType is RuntimeType))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            }
            return InternalBoxEnum(enumType, (long) value);
        }

        public override string ToString()
        {
            Type type = base.GetType();
            object obj2 = ((RtFieldInfo) GetValueField(type)).InternalGetValue(this, false);
            return InternalFormat(type, obj2);
        }

        [Obsolete("The provider argument is not used. Please use ToString().")]
        public string ToString(IFormatProvider provider)
        {
            return this.ToString();
        }

        public string ToString(string format)
        {
            if ((format == null) || (format.Length == 0))
            {
                format = "G";
            }
            if (string.Compare(format, "G", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return this.ToString();
            }
            if (string.Compare(format, "D", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return this.GetValue().ToString();
            }
            if (string.Compare(format, "X", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return this.ToHexString();
            }
            if (string.Compare(format, "F", StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new FormatException(Environment.GetResourceString("Format_InvalidEnumFormatSpecification"));
            }
            return InternalFlagsFormat(base.GetType(), this.GetValue());
        }

        [Obsolete("The provider argument is not used. Please use ToString(String).")]
        public string ToString(string format, IFormatProvider provider)
        {
            return this.ToString(format);
        }

        private static ulong ToUInt64(object value)
        {
            switch (Convert.GetTypeCode(value))
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return (ulong) Convert.ToInt64(value, CultureInfo.InvariantCulture);

                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Convert.ToUInt64(value, CultureInfo.InvariantCulture);
            }
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
        }

        private class HashEntry
        {
            public string[] names;
            public ulong[] values;

            public HashEntry(string[] names, ulong[] values)
            {
                this.names = names;
                this.values = values;
            }
        }
    }
}

