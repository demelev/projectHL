namespace UnityEditorInternal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using UnityEditor;
    using UnityEditor.Scripting.Compilers;

    internal class IL2CPPBuilder
    {
        [CompilerGenerated]
        private static Func<string, string> <>f__am$cache5;
        [CompilerGenerated]
        private static Func<string, string> <>f__am$cache6;
        [CompilerGenerated]
        private static Func<string, string, string> <>f__am$cache7;
        [CompilerGenerated]
        private static Func<RuntimeClassRegistry.MethodDescription, string> <>f__am$cache8;
        [CompilerGenerated]
        private static Func<RuntimeClassRegistry.MethodDescription, string> <>f__am$cache9;
        private readonly Action<string> m_ModifyOutputBeforeCompile;
        private readonly IIl2CppPlatformProvider m_PlatformProvider;
        private readonly RuntimeClassRegistry m_RuntimeClassRegistry;
        private readonly string m_StagingAreaData;
        private readonly string m_TempFolder;

        public IL2CPPBuilder(string tempFolder, string stagingAreaData, IIl2CppPlatformProvider platformProvider, Action<string> modifyOutputBeforeCompile, RuntimeClassRegistry runtimeClassRegistry)
        {
            this.m_TempFolder = tempFolder;
            this.m_StagingAreaData = stagingAreaData;
            this.m_PlatformProvider = platformProvider;
            this.m_ModifyOutputBeforeCompile = modifyOutputBeforeCompile;
            this.m_RuntimeClassRegistry = runtimeClassRegistry;
        }

        private void ConvertPlayerDlltoCpp(ICollection<string> userAssemblies, string outputDirectory, string workingDirectory)
        {
            FileUtil.CreateOrCleanDirectory(outputDirectory);
            if (userAssemblies.Count != 0)
            {
                if (<>f__am$cache5 == null)
                {
                    <>f__am$cache5 = s => Path.Combine(Directory.GetCurrentDirectory(), s);
                }
                string[] strArray = Directory.GetFiles("Assets", "il2cpp_extra_types.txt", SearchOption.AllDirectories).Select<string, string>(<>f__am$cache5).ToArray<string>();
                string exe = this.GetIl2CppExe();
                List<string> source = new List<string> { "--copy-level=None" };
                if (this.m_PlatformProvider.usePrecompiledHeader)
                {
                    source.Add("--use-precompiled-header");
                }
                if (this.m_PlatformProvider.emitNullChecks)
                {
                    source.Add("--emit-null-checks");
                }
                if (this.m_PlatformProvider.enableStackTraces)
                {
                    source.Add("--enable-stacktrace");
                }
                if (this.m_PlatformProvider.enableArrayBoundsCheck)
                {
                    source.Add("--enable-array-bounds-check");
                }
                if (this.m_PlatformProvider.compactMode)
                {
                    source.Add("--output-format=Compact");
                }
                if (this.m_PlatformProvider.loadSymbols)
                {
                    source.Add("--enable-symbol-loading");
                }
                if (this.m_PlatformProvider.developmentMode)
                {
                    source.Add("--development-mode");
                }
                if (strArray.Length > 0)
                {
                    foreach (string str2 in strArray)
                    {
                        source.Add(string.Format("--extra-types.file=\"{0}\"", str2));
                    }
                }
                string path = Path.Combine(this.m_PlatformProvider.il2CppFolder, "il2cpp_default_extra_types.txt");
                if (File.Exists(path))
                {
                    source.Add(string.Format("--extra-types.file=\"{0}\"", path));
                }
                string str4 = string.Empty;
                if (PlayerSettings.GetPropertyOptionalString("additionalIl2CppArgs", ref str4))
                {
                    source.Add(str4);
                }
                List<string> list2 = new List<string>(userAssemblies);
                if (<>f__am$cache6 == null)
                {
                    <>f__am$cache6 = arg => "--assembly=\"" + Path.GetFullPath(arg) + "\"";
                }
                source.AddRange(list2.Select<string, string>(<>f__am$cache6));
                source.Add(string.Format("--generatedcppdir=\"{0}\"", Path.GetFullPath(outputDirectory)));
                source.Add("--builder=none");
                if (<>f__am$cache7 == null)
                {
                    <>f__am$cache7 = (current, arg) => current + arg + " ";
                }
                string args = source.Aggregate<string, string>(string.Empty, <>f__am$cache7);
                Console.WriteLine("Invoking il2cpp with arguments: " + args);
                Runner.RunManagedProgram(exe, args, workingDirectory, new Il2CppOutputParser());
            }
        }

        public string GetCppOutputDirectoryInStagingArea()
        {
            return GetCppOutputPath(this.m_TempFolder);
        }

        public static string GetCppOutputPath(string tempFolder)
        {
            return Path.Combine(tempFolder, "il2cppOutput");
        }

        private string GetIl2CppExe()
        {
            return (this.m_PlatformProvider.il2CppFolder + "/build/il2cpp.exe");
        }

        private string GetMethodPreserveBlacklistContents()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<linker>");
            if (<>f__am$cache8 == null)
            {
                <>f__am$cache8 = m => m.assembly;
            }
            IEnumerator<IGrouping<string, RuntimeClassRegistry.MethodDescription>> enumerator = this.m_RuntimeClassRegistry.GetMethodsToPreserve().GroupBy<RuntimeClassRegistry.MethodDescription, string>(<>f__am$cache8).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    IGrouping<string, RuntimeClassRegistry.MethodDescription> current = enumerator.Current;
                    builder.AppendLine(string.Format("\t<assembly fullname=\"{0}\">", current.Key));
                    if (<>f__am$cache9 == null)
                    {
                        <>f__am$cache9 = m => m.fullTypeName;
                    }
                    IEnumerator<IGrouping<string, RuntimeClassRegistry.MethodDescription>> enumerator2 = current.GroupBy<RuntimeClassRegistry.MethodDescription, string>(<>f__am$cache9).GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            IGrouping<string, RuntimeClassRegistry.MethodDescription> grouping2 = enumerator2.Current;
                            builder.AppendLine(string.Format("\t\t<type fullname=\"{0}\">", grouping2.Key));
                            IEnumerator<RuntimeClassRegistry.MethodDescription> enumerator3 = grouping2.GetEnumerator();
                            try
                            {
                                while (enumerator3.MoveNext())
                                {
                                    RuntimeClassRegistry.MethodDescription description = enumerator3.Current;
                                    builder.AppendLine(string.Format("\t\t\t<method name=\"{0}\"/>", description.methodName));
                                }
                            }
                            finally
                            {
                                if (enumerator3 == null)
                                {
                                }
                                enumerator3.Dispose();
                            }
                            builder.AppendLine("\t\t</type>");
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    builder.AppendLine("\t</assembly>");
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            builder.AppendLine("</linker>");
            return builder.ToString();
        }

        private List<string> GetUserAssemblies(string managedDir)
        {
            <GetUserAssemblies>c__AnonStorey68 storey = new <GetUserAssemblies>c__AnonStorey68 {
                managedDir = managedDir,
                <>f__this = this
            };
            return this.m_RuntimeClassRegistry.GetUserAssemblies().Where<string>(new Func<string, bool>(storey.<>m__E1)).Select<string, string>(new Func<string, string>(storey.<>m__E2)).ToList<string>();
        }

        internal List<string> GetUserAssembliesToConvert(string managedDir)
        {
            List<string> userAssemblies = this.GetUserAssemblies(managedDir);
            userAssemblies.Add(Directory.GetFiles(managedDir, "UnityEngine.dll", SearchOption.TopDirectoryOnly).Single<string>());
            return userAssemblies;
        }

        public void Run()
        {
            string cppOutputDirectoryInStagingArea = this.GetCppOutputDirectoryInStagingArea();
            string fullPath = Path.GetFullPath(Path.Combine(this.m_StagingAreaData, "Managed"));
            foreach (string str3 in Directory.GetFiles(fullPath))
            {
                FileInfo info = new FileInfo(str3) {
                    IsReadOnly = false
                };
            }
            this.StripAssemblies(this.GetUserAssemblies(fullPath), fullPath);
            this.ConvertPlayerDlltoCpp(this.GetUserAssembliesToConvert(fullPath), cppOutputDirectoryInStagingArea, fullPath);
            if (this.m_ModifyOutputBeforeCompile != null)
            {
                this.m_ModifyOutputBeforeCompile(cppOutputDirectoryInStagingArea);
            }
            if (this.m_PlatformProvider.CreateNativeCompiler() != null)
            {
                string path = Path.Combine(this.m_StagingAreaData, "Native");
                Directory.CreateDirectory(path);
                path = Path.Combine(path, this.m_PlatformProvider.nativeLibraryFileName);
                List<string> includePaths = new List<string>(this.m_PlatformProvider.includePaths) {
                    cppOutputDirectoryInStagingArea
                };
                this.m_PlatformProvider.CreateNativeCompiler().CompileDynamicLibrary(path, NativeCompiler.AllSourceFilesIn(cppOutputDirectoryInStagingArea), includePaths, this.m_PlatformProvider.libraryPaths, new string[0]);
            }
        }

        private void RunAssemblyStripper(IEnumerable assemblies, string managedAssemblyFolderPath, string[] assembliesToStrip, string[] searchDirs, string monoLinkerPath)
        {
            bool flag2;
            bool flag = ((this.m_RuntimeClassRegistry != null) && PlayerSettings.stripEngineCode) && this.m_PlatformProvider.supportsEngineStripping;
            IEnumerable<string> first = this.Il2CppBlacklistPaths;
            if (this.m_RuntimeClassRegistry != null)
            {
                string[] second = new string[] { this.WriteMethodsToPreserveBlackList() };
                first = first.Concat<string>(second);
            }
            if (!flag)
            {
                foreach (string str3 in Directory.GetFiles(Path.GetDirectoryName(AssemblyStripper.MonoLinkerPath), "*.xml"))
                {
                    string[] textArray2 = new string[] { str3 };
                    first = first.Concat<string>(textArray2);
                }
            }
            string outputFolder = Path.Combine(managedAssemblyFolderPath, "tempStrip");
            do
            {
                string str;
                string str2;
                flag2 = false;
                if (!AssemblyStripper.Strip(assembliesToStrip, searchDirs, outputFolder, managedAssemblyFolderPath, out str, out str2, monoLinkerPath, Path.Combine(this.m_PlatformProvider.il2CppFolder, "LinkerDescriptors"), first))
                {
                    object[] objArray1 = new object[] { "Error in stripping assemblies: ", assemblies, ", ", str2 };
                    throw new Exception(string.Concat(objArray1));
                }
                if (flag)
                {
                    HashSet<string> set;
                    HashSet<string> set2;
                    CodeStrippingUtils.GenerateDependencies(outputFolder, this.m_RuntimeClassRegistry, out set, out set2);
                    foreach (string str5 in set2)
                    {
                        string path = Path.Combine(Path.GetDirectoryName(AssemblyStripper.MonoLinkerPath), str5 + ".xml");
                        if (File.Exists(path) && !first.Contains<string>(path))
                        {
                            string[] textArray3 = new string[] { path };
                            first = first.Concat<string>(textArray3);
                            flag2 = true;
                        }
                    }
                }
            }
            while (flag2);
            foreach (string str7 in Directory.GetFiles(outputFolder))
            {
                File.Copy(str7, Path.Combine(managedAssemblyFolderPath, Path.GetFileName(str7)), true);
            }
        }

        private void StripAssemblies(IEnumerable<string> assemblies, string managedAssemblyFolderPath)
        {
            List<string> list = new List<string>();
            list.AddRange(assemblies);
            string[] assembliesToStrip = list.ToArray();
            string[] searchDirs = new string[] { managedAssemblyFolderPath };
            this.RunAssemblyStripper(assemblies, managedAssemblyFolderPath, assembliesToStrip, searchDirs, AssemblyStripper.MonoLinker2Path);
        }

        private string WriteMethodsToPreserveBlackList()
        {
            string path = !Path.IsPathRooted(this.m_StagingAreaData) ? (Directory.GetCurrentDirectory() + "/") : string.Empty;
            path = path + this.m_StagingAreaData + "/methods_pointedto_by_uievents.xml";
            File.WriteAllText(path, this.GetMethodPreserveBlacklistContents());
            return path;
        }

        private string[] Il2CppBlacklistPaths
        {
            get
            {
                return new string[] { Path.Combine("..", "platform_native_link.xml") };
            }
        }

        [CompilerGenerated]
        private sealed class <GetUserAssemblies>c__AnonStorey68
        {
            internal IL2CPPBuilder <>f__this;
            internal string managedDir;

            internal bool <>m__E1(string s)
            {
                return this.<>f__this.m_RuntimeClassRegistry.IsDLLUsed(s);
            }

            internal string <>m__E2(string s)
            {
                return Path.Combine(this.managedDir, s);
            }
        }
    }
}

