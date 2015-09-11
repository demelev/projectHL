﻿namespace UnityEditorInternal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using UnityEditor;
    using UnityEngine;

    internal class IL2CPPUtils
    {
        [CompilerGenerated]
        private static Func<string, bool> <>f__am$cache0;
        [CompilerGenerated]
        private static Func<string, bool> <>f__am$cache1;

        internal static void CopyEmbeddedResourceFiles(string tempFolder, string destinationFolder)
        {
            if (<>f__am$cache0 == null)
            {
                <>f__am$cache0 = f => f.EndsWith("-resources.dat");
            }
            IEnumerator<string> enumerator = Directory.GetFiles(Path.Combine(IL2CPPBuilder.GetCppOutputPath(tempFolder), "Resources")).Where<string>(<>f__am$cache0).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    string current = enumerator.Current;
                    File.Copy(current, Path.Combine(destinationFolder, Path.GetFileName(current)), true);
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
        }

        internal static void CopyMetadataFiles(string tempFolder, string destinationFolder)
        {
            if (<>f__am$cache1 == null)
            {
                <>f__am$cache1 = f => f.EndsWith("-metadata.dat");
            }
            IEnumerator<string> enumerator = Directory.GetFiles(Path.Combine(IL2CPPBuilder.GetCppOutputPath(tempFolder), "Metadata")).Where<string>(<>f__am$cache1).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    string current = enumerator.Current;
                    File.Copy(current, Path.Combine(destinationFolder, Path.GetFileName(current)), true);
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
        }

        internal static void CopySymmapFile(string tempFolder, string destinationFolder)
        {
            string path = Path.Combine(tempFolder, "SymbolMap");
            if (File.Exists(path))
            {
                File.Copy(path, Path.Combine(destinationFolder, "SymbolMap"), true);
            }
        }

        internal static IIl2CppPlatformProvider PlatformProviderForNotModularPlatform(BuildTarget target, bool developmentBuild)
        {
            throw new Exception("Platform unsupported, or already modular.");
        }

        internal static IL2CPPBuilder RunIl2Cpp(string stagingAreaData, IIl2CppPlatformProvider platformProvider, Action<string> modifyOutputBeforeCompile, RuntimeClassRegistry runtimeClassRegistry)
        {
            IL2CPPBuilder builder = new IL2CPPBuilder(stagingAreaData, stagingAreaData, platformProvider, modifyOutputBeforeCompile, runtimeClassRegistry);
            builder.Run();
            return builder;
        }

        internal static IL2CPPBuilder RunIl2Cpp(string tempFolder, string stagingAreaData, IIl2CppPlatformProvider platformProvider, Action<string> modifyOutputBeforeCompile, RuntimeClassRegistry runtimeClassRegistry)
        {
            IL2CPPBuilder builder = new IL2CPPBuilder(tempFolder, stagingAreaData, platformProvider, modifyOutputBeforeCompile, runtimeClassRegistry);
            builder.Run();
            return builder;
        }

        internal static string editorIl2cppFolder
        {
            get
            {
                string str = (Application.platform != RuntimePlatform.OSXEditor) ? "il2cpp" : "Frameworks/il2cpp";
                return Path.GetFullPath(Path.Combine(EditorApplication.applicationContentsPath, str));
            }
        }
    }
}

