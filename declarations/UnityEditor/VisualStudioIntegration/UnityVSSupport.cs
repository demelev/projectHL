﻿namespace UnityEditor.VisualStudioIntegration
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using UnityEditor;
    using UnityEditor.Utils;
    using UnityEditorInternal;
    using UnityEngine;

    internal class UnityVSSupport
    {
        [CompilerGenerated]
        private static Func<Assembly, bool> <>f__am$cache3;
        private static bool m_ShouldUnityVSBeActive;
        private static string s_AboutLabel;
        public static string s_LoadedUnityVS;

        private static string CalculateAboutWindowLabel()
        {
            if (!m_ShouldUnityVSBeActive)
            {
                return string.Empty;
            }
            if (<>f__am$cache3 == null)
            {
                <>f__am$cache3 = a => a.Location == s_LoadedUnityVS;
            }
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault<Assembly>(<>f__am$cache3);
            if (assembly == null)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder("Microsoft Visual Studio Tools for Unity ");
            builder.Append(assembly.GetName().Version);
            builder.Append(" enabled");
            return builder.ToString();
        }

        public static string GetAboutWindowLabel()
        {
            if (s_AboutLabel == null)
            {
                s_AboutLabel = CalculateAboutWindowLabel();
            }
            return s_AboutLabel;
        }

        private static string GetVstuBridgeAssembly(VisualStudioVersion version)
        {
            try
            {
                string str = string.Empty;
                switch (version)
                {
                    case VisualStudioVersion.VisualStudio2010:
                        str = "2010";
                        break;

                    case VisualStudioVersion.VisualStudio2012:
                        str = "2012";
                        break;

                    case VisualStudioVersion.VisualStudio2013:
                        str = "2013";
                        break;

                    case VisualStudioVersion.VisualStudio2015:
                        str = "2015";
                        break;
                }
                return (string) Registry.GetValue(string.Format(@"HKEY_CURRENT_USER\Software\Microsoft\Microsoft Visual Studio {0} Tools for Unity", str), "UnityExtensionPath", null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Initialize()
        {
            Initialize(null);
        }

        public static void Initialize(string editorPath)
        {
            <Initialize>c__AnonStoreyAC yac = new <Initialize>c__AnonStoreyAC();
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (editorPath == null)
                {
                }
                yac.externalEditor = EditorPrefs.GetString("kScriptsDefaultApp");
                if (yac.externalEditor.EndsWith("UnityVS.OpenFile.exe"))
                {
                    yac.externalEditor = SyncVS.FindBestVisualStudio();
                    if (yac.externalEditor != null)
                    {
                        EditorPrefs.SetString("kScriptsDefaultApp", yac.externalEditor);
                    }
                }
                KeyValuePair<VisualStudioVersion, string>[] pairArray = SyncVS.InstalledVisualStudios.Where<KeyValuePair<VisualStudioVersion, string>>(new Func<KeyValuePair<VisualStudioVersion, string>, bool>(yac.<>m__1FD)).ToArray<KeyValuePair<VisualStudioVersion, string>>();
                bool flag = pairArray.Length > 0;
                m_ShouldUnityVSBeActive = flag;
                if (flag)
                {
                    string vstuBridgeAssembly = GetVstuBridgeAssembly(pairArray[0].Key);
                    if (vstuBridgeAssembly == null)
                    {
                        Console.WriteLine("Unable to find bridge dll in registry for Microsoft Visual Studio Tools for Unity for " + yac.externalEditor);
                    }
                    else if (!File.Exists(vstuBridgeAssembly))
                    {
                        Console.WriteLine("Unable to find bridge dll on disk for Microsoft Visual Studio Tools for Unity for " + vstuBridgeAssembly);
                    }
                    else
                    {
                        s_LoadedUnityVS = vstuBridgeAssembly;
                        InternalEditorUtility.SetupCustomDll(Path.GetFileNameWithoutExtension(vstuBridgeAssembly), vstuBridgeAssembly);
                    }
                }
            }
        }

        public static void ScriptEditorChanged(string editorPath)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                Initialize(editorPath);
                InternalEditorUtility.RequestScriptReload();
            }
        }

        public static bool ShouldUnityVSBeActive()
        {
            return m_ShouldUnityVSBeActive;
        }

        [CompilerGenerated]
        private sealed class <Initialize>c__AnonStoreyAC
        {
            internal string externalEditor;

            internal bool <>m__1FD(KeyValuePair<VisualStudioVersion, string> kvp)
            {
                return Paths.AreEqual(kvp.Value, this.externalEditor, true);
            }
        }
    }
}

