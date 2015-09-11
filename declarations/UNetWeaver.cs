// WARNING:Skipped nested type: Unity.UNetWeaver.Helpers+AddSearchDirectoryHelper
// WARNING:Skipped nested type: Unity.UNetWeaver.Weaver+<ImportCorLibType>c__AnonStorey0

// INFO:MMCSReflector::ImportedAssembly: Unity.UNetWeaver, Version=1.0.5718.37211, Culture=neutral, PublicKeyToken=null

namespace Unity.UNetWeaver {
	public sealed abstract	class	Log: Object
	{
		public static void Warning(string msg){}
		public static void Error(string msg){}
		public static Action<String> WarningMethod;
		public static Action<String> ErrorMethod;
	}

	public class	Program: Object
	{
		public static bool Process(string unityEngine, string unetDLL, string outputDirectory, String[] assemblies, String[] extraAssemblyPaths, IAssemblyResolver assemblyResolver, Action<String> printWarning, Action<String> printError){}
		private static void CheckDLLPath(string path){}
		private static void CheckAssemblies(IEnumerable<String> assemblyPaths){}
		private static void CheckAssemblyPath(string assemblyPath){}
		private static void CheckOutputDirectory(string outputDir){}
		public Program(){}
	}

	delegate void AddSearchDirectoryDelegate(string directory);

}

