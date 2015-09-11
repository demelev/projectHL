namespace UnityEditorInternal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using UnityEditor;
    using UnityEditor.Utils;
    using UnityEngine;

    internal class AssemblyStripper
    {
        private readonly string[] _assemblies;
        private readonly string[] _searchDirs;
        [CompilerGenerated]
        private static Func<string, string> <>f__am$cache2;
        [CompilerGenerated]
        private static Func<string, string> <>f__am$cache3;
        [CompilerGenerated]
        private static Func<string, string> <>f__am$cache4;
        [CompilerGenerated]
        private static Func<string, string> <>f__am$cache5;
        [CompilerGenerated]
        private static Func<string, string> <>f__am$cache6;
        [CompilerGenerated]
        private static Func<string, string, string> <>f__am$cache7;

        private AssemblyStripper(string[] assemblies, string[] searchDirs)
        {
            this._assemblies = assemblies;
            this._searchDirs = searchDirs;
        }

        private void BackupInputFolderIfNeeded(string outputFolder)
        {
            <BackupInputFolderIfNeeded>c__AnonStorey66 storey = new <BackupInputFolderIfNeeded>c__AnonStorey66 {
                fullOutput = FullPathOf(outputFolder)
            };
            if (<>f__am$cache2 == null)
            {
                <>f__am$cache2 = a => FullPathOf(Path.GetDirectoryName(a));
            }
            if (!this._assemblies.Select<string, string>(<>f__am$cache2).All<string>(new Func<string, bool>(storey.<>m__D8)))
            {
                string dir = Path.Combine(outputFolder, "not-stripped");
                FileUtil.CreateOrCleanDirectory(dir);
                foreach (string str2 in Directory.GetFiles(outputFolder))
                {
                    File.Copy(str2, Path.Combine(dir, Path.GetFileName(str2)));
                }
            }
        }

        private static string FullPathOf(string dir)
        {
            char[] trimChars = new char[] { '\\' };
            return Path.GetFullPath(dir).TrimEnd(trimChars);
        }

        private static bool RunAssemblyLinker(IEnumerable<string> args, out string @out, out string err, string linkerPath, string workingDirectory)
        {
            if (<>f__am$cache7 == null)
            {
                <>f__am$cache7 = (buff, s) => buff + " " + s;
            }
            string str = args.Aggregate<string>(<>f__am$cache7);
            Console.WriteLine("Invoking UnusedByteCodeStripper2 with arguments: " + str);
            Runner.RunManagedProgram(linkerPath, str, workingDirectory, null);
            @out = string.Empty;
            err = string.Empty;
            return true;
        }

        private bool Strip(string outputFolder, string workingDirectory, out string output, out string error, string monoLinkerPath, string descriptorsFolder, IEnumerable<string> additionalBlacklist)
        {
            this.BackupInputFolderIfNeeded(outputFolder);
            return this.StripAssembliesTo(outputFolder, workingDirectory, out output, out error, monoLinkerPath, descriptorsFolder, additionalBlacklist);
        }

        internal static bool Strip(string[] assemblies, string[] searchDirs, string outputFolder, string workingDirectory, out string output, out string error, string monoLinkerPath, string descriptorsFolder, IEnumerable<string> additionalBlacklist)
        {
            return new AssemblyStripper(assemblies, searchDirs).Strip(outputFolder, workingDirectory, out output, out error, monoLinkerPath, descriptorsFolder, additionalBlacklist);
        }

        private bool StripAssembliesTo(string outputFolder, string workingDirectory, out string output, out string error, string linkerPath, string descriptorsFolder, IEnumerable<string> additionalBlacklist)
        {
            <StripAssembliesTo>c__AnonStorey67 storey = new <StripAssembliesTo>c__AnonStorey67 {
                workingDirectory = workingDirectory
            };
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            additionalBlacklist = additionalBlacklist.Select<string, string>(new Func<string, string>(storey.<>m__D9)).Where<string>(new Func<string, bool>(File.Exists));
            if (<>f__am$cache3 == null)
            {
                <>f__am$cache3 = s => Path.Combine(Directory.GetCurrentDirectory(), s);
            }
            IEnumerable<string> second = Directory.GetFiles("Assets", "link.xml", SearchOption.AllDirectories).Select<string, string>(<>f__am$cache3);
            IEnumerator<string> enumerator = second.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine("UserBlackList: " + enumerator.Current);
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            additionalBlacklist = additionalBlacklist.Concat<string>(second);
            List<string> args = new List<string> {
                "-out \"" + outputFolder + "\"",
                "-l none",
                "-c link",
                "-x \"" + BlacklistPath + "\"",
                "-f \"" + descriptorsFolder + "\""
            };
            if (<>f__am$cache4 == null)
            {
                <>f__am$cache4 = path => "-x \"" + path + "\"";
            }
            args.AddRange(additionalBlacklist.Select<string, string>(<>f__am$cache4));
            if (<>f__am$cache5 == null)
            {
                <>f__am$cache5 = d => "-d \"" + d + "\"";
            }
            args.AddRange(this._searchDirs.Select<string, string>(<>f__am$cache5));
            if (<>f__am$cache6 == null)
            {
                <>f__am$cache6 = assembly => "-a  \"" + Path.GetFullPath(assembly) + "\"";
            }
            args.AddRange(this._assemblies.Select<string, string>(<>f__am$cache6));
            return RunAssemblyLinker(args, out output, out error, linkerPath, storey.workingDirectory);
        }

        internal static string BlacklistPath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(MonoLinkerPath), "native_link.xml");
            }
        }

        internal static string MonoLinker2Path
        {
            get
            {
                return Path.Combine(MonoInstallationFinder.GetFrameWorksFolder(), "Tools/UnusedByteCodeStripper2/UnusedBytecodeStripper2.exe");
            }
        }

        internal static string MonoLinkerPath
        {
            get
            {
                if (Application.platform != RuntimePlatform.WindowsEditor)
                {
                    return Path.Combine(MonoInstallationFinder.GetFrameWorksFolder(), "Tools/UnusedByteCodeStripper/UnusedBytecodeStripper.exe");
                }
                return Path.Combine(MonoInstallationFinder.GetFrameWorksFolder(), "Tools/UnusedBytecodeStripper.exe");
            }
        }

        [CompilerGenerated]
        private sealed class <BackupInputFolderIfNeeded>c__AnonStorey66
        {
            internal string fullOutput;

            internal bool <>m__D8(string p)
            {
                return (string.Compare(p, this.fullOutput) != 0);
            }
        }

        [CompilerGenerated]
        private sealed class <StripAssembliesTo>c__AnonStorey67
        {
            internal string workingDirectory;

            internal string <>m__D9(string s)
            {
                return (!Path.IsPathRooted(s) ? Path.Combine(this.workingDirectory, s) : s);
            }
        }
    }
}

