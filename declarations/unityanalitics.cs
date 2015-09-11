// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.

// INFO:MMCSReflector::ImportedAssembly: UnityEngine.Analytics, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null

namespace UnityEngine.Analytics {
	public sealed abstract	class	Analytics: Object
	{
		internal static void AutoStartUnityAnalytics(){}
		internal static AnalyticsResult InternalStartSession(string appId){}
		internal static AnalyticsResult InternalStartSession(string appId, ICloudService cloudService, string configUrl, string eventUrl){}
		internal static string GetPathName(){}
		public static AnalyticsResult SetUserId(string userId){}
		public static AnalyticsResult SetUserGender(Gender gender){}
		public static AnalyticsResult SetUserBirthYear(int birthYear){}
		public static AnalyticsResult Transaction(string productId, decimal amount, string currency){}
		public static AnalyticsResult Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature){}
		public static AnalyticsResult CustomEvent(string customEventName, IDictionary<String, Object> eventData){}
		private static IUnityAnalyticsSession GetSingleton(){}
		private static IUnityAnalyticsSession s_SessionImpl;
	}

}

