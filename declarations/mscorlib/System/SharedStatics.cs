﻿namespace System
{
    using System.Runtime.CompilerServices;
    using System.Runtime.ConstrainedExecution;
    using System.Security.Util;
    using System.Threading;

    internal sealed class SharedStatics
    {
        private Tokenizer.StringMaker _maker = null;
        private long _memFailPointReservedMemory;
        private string _Remoting_Identity_IDGuid = null;
        private int _Remoting_Identity_IDSeqNum = 0x40;
        internal static SharedStatics _sharedStatics;

        private SharedStatics()
        {
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        internal static long AddMemoryFailPointReservation(long size)
        {
            return Interlocked.Add(ref _sharedStatics._memFailPointReservedMemory, size);
        }

        public static Tokenizer.StringMaker GetSharedStringMaker()
        {
            Tokenizer.StringMaker maker = null;
            bool tookLock = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Monitor.ReliableEnter(_sharedStatics, ref tookLock);
                if (_sharedStatics._maker != null)
                {
                    maker = _sharedStatics._maker;
                    _sharedStatics._maker = null;
                }
            }
            finally
            {
                if (tookLock)
                {
                    Monitor.Exit(_sharedStatics);
                }
            }
            if (maker == null)
            {
                maker = new Tokenizer.StringMaker();
            }
            return maker;
        }

        public static void ReleaseSharedStringMaker(ref Tokenizer.StringMaker maker)
        {
            bool tookLock = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Monitor.ReliableEnter(_sharedStatics, ref tookLock);
                _sharedStatics._maker = maker;
                maker = null;
            }
            finally
            {
                if (tookLock)
                {
                    Monitor.Exit(_sharedStatics);
                }
            }
        }

        internal static int Remoting_Identity_GetNextSeqNum()
        {
            return Interlocked.Increment(ref _sharedStatics._Remoting_Identity_IDSeqNum);
        }

        internal static ulong MemoryFailPointReservedMemory
        {
            get
            {
                return (ulong) _sharedStatics._memFailPointReservedMemory;
            }
        }

        public static string Remoting_Identity_IDGuid
        {
            get
            {
                if (_sharedStatics._Remoting_Identity_IDGuid == null)
                {
                    bool tookLock = false;
                    RuntimeHelpers.PrepareConstrainedRegions();
                    try
                    {
                        Monitor.ReliableEnter(_sharedStatics, ref tookLock);
                        if (_sharedStatics._Remoting_Identity_IDGuid == null)
                        {
                            _sharedStatics._Remoting_Identity_IDGuid = Guid.NewGuid().ToString().Replace('-', '_');
                        }
                    }
                    finally
                    {
                        if (tookLock)
                        {
                            Monitor.Exit(_sharedStatics);
                        }
                    }
                }
                return _sharedStatics._Remoting_Identity_IDGuid;
            }
        }
    }
}

