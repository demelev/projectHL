﻿namespace UnityEditor.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal class ProcessOutputStreamReader
    {
        private readonly Func<bool> hostProcessExited;
        internal List<string> lines;
        private readonly StreamReader stream;
        private Thread thread;

        internal ProcessOutputStreamReader(Process p, StreamReader stream) : this(new Func<bool>(ya.<>m__1F4), stream)
        {
            <ProcessOutputStreamReader>c__AnonStoreyA7 ya = new <ProcessOutputStreamReader>c__AnonStoreyA7 {
                p = p
            };
        }

        internal ProcessOutputStreamReader(Func<bool> hostProcessExited, StreamReader stream)
        {
            this.hostProcessExited = hostProcessExited;
            this.stream = stream;
            this.lines = new List<string>();
            this.thread = new Thread(new ThreadStart(this.ThreadFunc));
            this.thread.Start();
        }

        internal string[] GetOutput()
        {
            if (this.hostProcessExited())
            {
                this.thread.Join();
            }
            List<string> lines = this.lines;
            lock (lines)
            {
                return this.lines.ToArray();
            }
        }

        private void ThreadFunc()
        {
            if (this.hostProcessExited())
            {
                return;
            }
            while (this.stream.BaseStream != null)
            {
                string item = this.stream.ReadLine();
                if (item == null)
                {
                    return;
                }
                List<string> lines = this.lines;
                lock (lines)
                {
                    this.lines.Add(item);
                }
            }
            return;
        }

        [CompilerGenerated]
        private sealed class <ProcessOutputStreamReader>c__AnonStoreyA7
        {
            internal Process p;

            internal bool <>m__1F4()
            {
                return this.p.HasExited;
            }
        }
    }
}

