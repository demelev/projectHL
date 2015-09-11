﻿namespace UnityEngine.Networking
{
    using System;
    using System.Runtime.InteropServices;

    internal class ULocalConnectionToServer : NetworkConnection
    {
        private NetworkServer m_LocalServer;

        public ULocalConnectionToServer(NetworkServer localServer)
        {
            base.address = "localServer";
            this.m_LocalServer = localServer;
        }

        public override void GetStatsIn(out int numMsgs, out int numBytes)
        {
            numMsgs = 0;
            numBytes = 0;
        }

        public override void GetStatsOut(out int numMsgs, out int numBufferedMsgs, out int numBytes, out int lastBufferedPerSecond)
        {
            numMsgs = 0;
            numBufferedMsgs = 0;
            numBytes = 0;
            lastBufferedPerSecond = 0;
        }

        public override bool Send(short msgType, MessageBase msg)
        {
            return this.m_LocalServer.InvokeHandlerOnServer(this, msgType, msg, 0);
        }

        public override bool SendByChannel(short msgType, MessageBase msg, int channelId)
        {
            return this.m_LocalServer.InvokeHandlerOnServer(this, msgType, msg, channelId);
        }

        public override bool SendBytes(byte[] bytes, int numBytes, int channelId)
        {
            return this.m_LocalServer.InvokeBytes(this, bytes, numBytes, channelId);
        }

        public override bool SendUnreliable(short msgType, MessageBase msg)
        {
            return this.m_LocalServer.InvokeHandlerOnServer(this, msgType, msg, 1);
        }

        public override bool SendWriter(NetworkWriter writer, int channelId)
        {
            return this.m_LocalServer.InvokeBytes(this, writer.AsArray(), (short) writer.AsArray().Length, channelId);
        }
    }
}

