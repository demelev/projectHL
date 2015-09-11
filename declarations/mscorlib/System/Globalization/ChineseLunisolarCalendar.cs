﻿namespace System.Globalization
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable]
    public class ChineseLunisolarCalendar : EastAsianLunisolarCalendar
    {
        public const int ChineseEra = 1;
        internal const int MAX_GREGORIAN_DAY = 0x1c;
        internal const int MAX_GREGORIAN_MONTH = 1;
        internal const int MAX_GREGORIAN_YEAR = 0x835;
        internal const int MAX_LUNISOLAR_YEAR = 0x834;
        internal static DateTime maxDate;
        internal const int MIN_GREGORIAN_DAY = 0x13;
        internal const int MIN_GREGORIAN_MONTH = 2;
        internal const int MIN_GREGORIAN_YEAR = 0x76d;
        internal const int MIN_LUNISOLAR_YEAR = 0x76d;
        internal static DateTime minDate = new DateTime(0x76d, 2, 0x13);
        private static readonly int[,] yinfo;

        static ChineseLunisolarCalendar()
        {
            DateTime time = new DateTime(0x835, 1, 0x1c, 0x17, 0x3b, 0x3b, 0x3e7);
            maxDate = new DateTime(time.Ticks + 0x270fL);
            yinfo = new int[,] { 
                { 0, 2, 0x13, 0x4ae0 }, { 0, 2, 8, 0xa570 }, { 5, 1, 0x1d, 0x5268 }, { 0, 2, 0x10, 0xd260 }, { 0, 2, 4, 0xd950 }, { 4, 1, 0x19, 0x6aa8 }, { 0, 2, 13, 0x56a0 }, { 0, 2, 2, 0x9ad0 }, { 2, 1, 0x16, 0x4ae8 }, { 0, 2, 10, 0x4ae0 }, { 6, 1, 30, 0xa4d8 }, { 0, 2, 0x12, 0xa4d0 }, { 0, 2, 6, 0xd250 }, { 5, 1, 0x1a, 0xd528 }, { 0, 2, 14, 0xb540 }, { 0, 2, 3, 0xd6a0 }, 
                { 2, 1, 0x17, 0x96d0 }, { 0, 2, 11, 0x95b0 }, { 7, 2, 1, 0x49b8 }, { 0, 2, 20, 0x4970 }, { 0, 2, 8, 0xa4b0 }, { 5, 1, 0x1c, 0xb258 }, { 0, 2, 0x10, 0x6a50 }, { 0, 2, 5, 0x6d40 }, { 4, 1, 0x18, 0xada8 }, { 0, 2, 13, 0x2b60 }, { 0, 2, 2, 0x9570 }, { 2, 1, 0x17, 0x4978 }, { 0, 2, 10, 0x4970 }, { 6, 1, 30, 0x64b0 }, { 0, 2, 0x11, 0xd4a0 }, { 0, 2, 6, 0xea50 }, 
                { 5, 1, 0x1a, 0x6d48 }, { 0, 2, 14, 0x5ad0 }, { 0, 2, 4, 0x2b60 }, { 3, 1, 0x18, 0x9370 }, { 0, 2, 11, 0x92e0 }, { 7, 1, 0x1f, 0xc968 }, { 0, 2, 0x13, 0xc950 }, { 0, 2, 8, 0xd4a0 }, { 6, 1, 0x1b, 0xda50 }, { 0, 2, 15, 0xb550 }, { 0, 2, 5, 0x56a0 }, { 4, 1, 0x19, 0xaad8 }, { 0, 2, 13, 0x25d0 }, { 0, 2, 2, 0x92d0 }, { 2, 1, 0x16, 0xc958 }, { 0, 2, 10, 0xa950 }, 
                { 7, 1, 0x1d, 0xb4a8 }, { 0, 2, 0x11, 0x6ca0 }, { 0, 2, 6, 0xb550 }, { 5, 1, 0x1b, 0x55a8 }, { 0, 2, 14, 0x4da0 }, { 0, 2, 3, 0xa5b0 }, { 3, 1, 0x18, 0x52b8 }, { 0, 2, 12, 0x52b0 }, { 8, 1, 0x1f, 0xa950 }, { 0, 2, 0x12, 0xe950 }, { 0, 2, 8, 0x6aa0 }, { 6, 1, 0x1c, 0xad50 }, { 0, 2, 15, 0xab50 }, { 0, 2, 5, 0x4b60 }, { 4, 1, 0x19, 0xa570 }, { 0, 2, 13, 0xa570 }, 
                { 0, 2, 2, 0x5260 }, { 3, 1, 0x15, 0xe930 }, { 0, 2, 9, 0xd950 }, { 7, 1, 30, 0x5aa8 }, { 0, 2, 0x11, 0x56a0 }, { 0, 2, 6, 0x96d0 }, { 5, 1, 0x1b, 0x4ae8 }, { 0, 2, 15, 0x4ad0 }, { 0, 2, 3, 0xa4d0 }, { 4, 1, 0x17, 0xd268 }, { 0, 2, 11, 0xd250 }, { 8, 1, 0x1f, 0xd528 }, { 0, 2, 0x12, 0xb540 }, { 0, 2, 7, 0xb6a0 }, { 6, 1, 0x1c, 0x96d0 }, { 0, 2, 0x10, 0x95b0 }, 
                { 0, 2, 5, 0x49b0 }, { 4, 1, 0x19, 0xa4b8 }, { 0, 2, 13, 0xa4b0 }, { 10, 2, 2, 0xb258 }, { 0, 2, 20, 0x6a50 }, { 0, 2, 9, 0x6d40 }, { 6, 1, 0x1d, 0xada0 }, { 0, 2, 0x11, 0xab60 }, { 0, 2, 6, 0x9570 }, { 5, 1, 0x1b, 0x4978 }, { 0, 2, 15, 0x4970 }, { 0, 2, 4, 0x64b0 }, { 3, 1, 0x17, 0x6a50 }, { 0, 2, 10, 0xea50 }, { 8, 1, 0x1f, 0x6b28 }, { 0, 2, 0x13, 0x5ac0 }, 
                { 0, 2, 7, 0xab60 }, { 5, 1, 0x1c, 0x9368 }, { 0, 2, 0x10, 0x92e0 }, { 0, 2, 5, 0xc960 }, { 4, 1, 0x18, 0xd4a8 }, { 0, 2, 12, 0xd4a0 }, { 0, 2, 1, 0xda50 }, { 2, 1, 0x16, 0x5aa8 }, { 0, 2, 9, 0x56a0 }, { 7, 1, 0x1d, 0xaad8 }, { 0, 2, 0x12, 0x25d0 }, { 0, 2, 7, 0x92d0 }, { 5, 1, 0x1a, 0xc958 }, { 0, 2, 14, 0xa950 }, { 0, 2, 3, 0xb4a0 }, { 4, 1, 0x17, 0xb550 }, 
                { 0, 2, 10, 0xad50 }, { 9, 1, 0x1f, 0x55a8 }, { 0, 2, 0x13, 0x4ba0 }, { 0, 2, 8, 0xa5b0 }, { 6, 1, 0x1c, 0x52b8 }, { 0, 2, 0x10, 0x52b0 }, { 0, 2, 5, 0xa930 }, { 4, 1, 0x19, 0x74a8 }, { 0, 2, 12, 0x6aa0 }, { 0, 2, 1, 0xad50 }, { 2, 1, 0x16, 0x4da8 }, { 0, 2, 10, 0x4b60 }, { 6, 1, 0x1d, 0xa570 }, { 0, 2, 0x11, 0xa4e0 }, { 0, 2, 6, 0xd260 }, { 5, 1, 0x1a, 0xe930 }, 
                { 0, 2, 13, 0xd530 }, { 0, 2, 3, 0x5aa0 }, { 3, 1, 0x17, 0x6b50 }, { 0, 2, 11, 0x96d0 }, { 11, 1, 0x1f, 0x4ae8 }, { 0, 2, 0x13, 0x4ad0 }, { 0, 2, 8, 0xa4d0 }, { 6, 1, 0x1c, 0xd258 }, { 0, 2, 15, 0xd250 }, { 0, 2, 4, 0xd520 }, { 5, 1, 0x18, 0xdaa0 }, { 0, 2, 12, 0xb5a0 }, { 0, 2, 1, 0x56d0 }, { 2, 1, 0x16, 0x4ad8 }, { 0, 2, 10, 0x49b0 }, { 7, 1, 30, 0xa4b8 }, 
                { 0, 2, 0x11, 0xa4b0 }, { 0, 2, 6, 0xaa50 }, { 5, 1, 0x1a, 0xb528 }, { 0, 2, 14, 0x6d20 }, { 0, 2, 2, 0xada0 }, { 3, 1, 0x17, 0x55b0 }, { 0, 2, 11, 0x9370 }, { 8, 2, 1, 0x4978 }, { 0, 2, 0x13, 0x4970 }, { 0, 2, 8, 0x64b0 }, { 6, 1, 0x1c, 0x6a50 }, { 0, 2, 15, 0xea50 }, { 0, 2, 4, 0x6b20 }, { 4, 1, 0x18, 0xab60 }, { 0, 2, 12, 0xaae0 }, { 0, 2, 2, 0x92e0 }, 
                { 3, 1, 0x15, 0xc970 }, { 0, 2, 9, 0xc960 }, { 7, 1, 0x1d, 0xd4a8 }, { 0, 2, 0x11, 0xd4a0 }, { 0, 2, 5, 0xda50 }, { 5, 1, 0x1a, 0x5aa8 }, { 0, 2, 14, 0x56a0 }, { 0, 2, 3, 0xa6d0 }, { 4, 1, 0x17, 0x52e8 }, { 0, 2, 11, 0x52d0 }, { 8, 1, 0x1f, 0xa958 }, { 0, 2, 0x13, 0xa950 }, { 0, 2, 7, 0xb4a0 }, { 6, 1, 0x1b, 0xb550 }, { 0, 2, 15, 0xad50 }, { 0, 2, 5, 0x55a0 }, 
                { 4, 1, 0x18, 0xa5d0 }, { 0, 2, 12, 0xa5b0 }, { 0, 2, 2, 0x52b0 }, { 3, 1, 0x16, 0xa938 }, { 0, 2, 9, 0x6930 }, { 7, 1, 0x1d, 0x7298 }, { 0, 2, 0x11, 0x6aa0 }, { 0, 2, 6, 0xad50 }, { 5, 1, 0x1a, 0x4da8 }, { 0, 2, 14, 0x4b60 }, { 0, 2, 3, 0xa570 }, { 4, 1, 0x18, 0x5270 }, { 0, 2, 10, 0xd260 }, { 8, 1, 30, 0xe930 }, { 0, 2, 0x12, 0xd520 }, { 0, 2, 7, 0xdaa0 }, 
                { 6, 1, 0x1b, 0x6b50 }, { 0, 2, 15, 0x56d0 }, { 0, 2, 5, 0x4ae0 }, { 4, 1, 0x19, 0xa4e8 }, { 0, 2, 12, 0xa4d0 }, { 0, 2, 1, 0xd150 }, { 2, 1, 0x15, 0xd928 }, { 0, 2, 9, 0xd520 }
             };
        }

        [ComVisible(false)]
        public override int GetEra(DateTime time)
        {
            base.CheckTicksRange(time.Ticks);
            return 1;
        }

        internal override int GetGregorianYear(int year, int era)
        {
            if ((era != 0) && (era != 1))
            {
                throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
            }
            if ((year < 0x76d) || (year > 0x834))
            {
                throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), new object[] { 0x76d, 0x834 }));
            }
            return year;
        }

        internal override int GetYear(int year, DateTime time)
        {
            return year;
        }

        internal override int GetYearInfo(int LunarYear, int Index)
        {
            if ((LunarYear < 0x76d) || (LunarYear > 0x834))
            {
                throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), new object[] { 0x76d, 0x834 }));
            }
            return yinfo[LunarYear - 0x76d, Index];
        }

        internal override int BaseCalendarID
        {
            get
            {
                return 1;
            }
        }

        internal override EraInfo[] CalEraInfo
        {
            get
            {
                return null;
            }
        }

        [ComVisible(false)]
        public override int[] Eras
        {
            get
            {
                return new int[] { 1 };
            }
        }

        internal override int ID
        {
            get
            {
                return 15;
            }
        }

        internal override int MaxCalendarYear
        {
            get
            {
                return 0x834;
            }
        }

        internal override DateTime MaxDate
        {
            get
            {
                return maxDate;
            }
        }

        [ComVisible(false)]
        public override DateTime MaxSupportedDateTime
        {
            get
            {
                return maxDate;
            }
        }

        internal override int MinCalendarYear
        {
            get
            {
                return 0x76d;
            }
        }

        internal override DateTime MinDate
        {
            get
            {
                return minDate;
            }
        }

        [ComVisible(false)]
        public override DateTime MinSupportedDateTime
        {
            get
            {
                return minDate;
            }
        }
    }
}

