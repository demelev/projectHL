// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.InternalAddPlayer
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.SpawnSceneObject
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.RegisterPrefab
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.RegisterPrefab
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.UnregisterPrefab
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.SetLocalObject
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.FindLocalObject
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.ApplySpawnPayload
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading parameter list for ClientScene.CheckForOwner
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading indexer parameters for ClientScene.objects
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading indexer parameters for ClientScene.prefabs
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading indexer parameters for ClientScene.spawnableObjects
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// WARNING:Error reading type name: substituted with "_UNRESOLVED_TYPE_"
// ERROR:Could not load file or assembly 'UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.

// INFO:MMCSReflector::ImportedAssembly: UnityEngine.Networking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

namespace UnityEngine.Networking {
	public class	ClientScene: Object
	{
		internal static void SetNotReady(){}
		internal static void Shutdown(){}
		internal static bool GetPlayerController(short playerControllerId, out PlayerController player){}
		internal static _UNRESOLVED_TYPE_ { TODO: Check type }  InternalAddPlayer( /* TODO: Check Missing Parameters */ ){}
		public static bool AddPlayer(short playerControllerId){}
		public static bool AddPlayer(NetworkConnection readyConn, short playerControllerId){}
		public static bool AddPlayer(NetworkConnection readyConn, short playerControllerId, MessageBase extraMessage){}
		public static bool RemovePlayer(short playerControllerId){}
		public static bool Ready(NetworkConnection conn){}
		public static NetworkClient ConnectLocalServer(){}
		internal static void HandleClientDisconnect(NetworkConnection conn){}
		internal static void PrepareToSpawnSceneObjects(){}
		internal static _UNRESOLVED_TYPE_ { TODO: Check type }  SpawnSceneObject( /* TODO: Check Missing Parameters */ ){}
		internal static void RegisterSystemHandlers(NetworkClient client, bool localClient){}
		internal static string GetStringForAssetId(NetworkHash128 assetId){}
		public static _UNRESOLVED_TYPE_ { TODO: Check type }  RegisterPrefab( /* TODO: Check Missing Parameters */ ){}
		public static _UNRESOLVED_TYPE_ { TODO: Check type }  RegisterPrefab( /* TODO: Check Missing Parameters */ ){}
		public static _UNRESOLVED_TYPE_ { TODO: Check type }  UnregisterPrefab( /* TODO: Check Missing Parameters */ ){}
		public static void RegisterSpawnHandler(NetworkHash128 assetId, SpawnDelegate spawnHandler, UnSpawnDelegate unspawnHandler){}
		public static void UnregisterSpawnHandler(NetworkHash128 assetId){}
		public static void ClearSpawners(){}
		public static void DestroyAllClientObjects(){}
		public static _UNRESOLVED_TYPE_ { TODO: Check type }  SetLocalObject( /* TODO: Check Missing Parameters */ ){}
		public static _UNRESOLVED_TYPE_ { TODO: Check type }  FindLocalObject( /* TODO: Check Missing Parameters */ ){}
		private static _UNRESOLVED_TYPE_ { TODO: Check type }  ApplySpawnPayload( /* TODO: Check Missing Parameters */ ){}
		private static void OnObjectSpawn(NetworkMessage netMsg){}
		private static void OnObjectSpawnScene(NetworkMessage netMsg){}
		private static void OnObjectSpawnFinished(NetworkMessage netMsg){}
		private static void OnObjectDestroy(NetworkMessage netMsg){}
		private static void OnLocalClientObjectDestroy(NetworkMessage netMsg){}
		private static void OnLocalClientObjectHide(NetworkMessage netMsg){}
		private static void OnLocalClientObjectSpawn(NetworkMessage netMsg){}
		private static void OnLocalClientObjectSpawnScene(NetworkMessage netMsg){}
		private static void OnUpdateVarsMessage(NetworkMessage netMsg){}
		private static void OnRPCMessage(NetworkMessage netMsg){}
		private static void OnSyncEventMessage(NetworkMessage netMsg){}
		private static void OnSyncListMessage(NetworkMessage netMsg){}
		private static void OnClientAuthority(NetworkMessage netMsg){}
		private static void OnOwnerMessage(NetworkMessage netMsg){}
		private static _UNRESOLVED_TYPE_ { TODO: Check type }  CheckForOwner( /* TODO: Check Missing Parameters */ ){}
		public ClientScene(){}
		private static ClientScene(){}
		public static List<PlayerController> localPlayers{ get	{} }
		public static bool ready{ get	{} }
		public static NetworkConnection readyConnection{ get	{} }
		public static _UNRESOLVED_TYPE_ { TODO: Check type }   /* TODO: Check indexer parameters */ objects{ get	{} }
		public static _UNRESOLVED_TYPE_ { TODO: Check type }   /* TODO: Check indexer parameters */ prefabs{ get	{} }
		public static _UNRESOLVED_TYPE_ { TODO: Check type }   /* TODO: Check indexer parameters */ spawnableObjects{ get	{} }
		private static List<PlayerController> s_LocalPlayers;
		private static NetworkConnection s_ReadyConnection;
		private static _UNRESOLVED_TYPE_ { TODO: Check type }  s_SpawnableObjects;
		private static bool s_IsReady;
		private static bool s_IsSpawnFinished;
		private static NetworkScene s_NetworkScene;
		private static _UNRESOLVED_TYPE_ { TODO: Check type }  s_ObjectSpawnSceneMessage;
		private static ObjectSpawnFinishedMessage s_ObjectSpawnFinishedMessage;
		private static ObjectDestroyMessage s_ObjectDestroyMessage;
		private static _UNRESOLVED_TYPE_ { TODO: Check type }  s_ObjectSpawnMessage;
		private static OwnerMessage s_OwnerMessage;
		private static ClientAuthorityMessage s_ClientAuthorityMessage;
		private static List<PendingOwner> s_PendingOwnerIds;
	}

	public class	NetworkSettingsAttribute: Attribute, _Attribute
	{
		public NetworkSettingsAttribute(){}
		public int channel;
		public float sendInterval;
	}

	public class	SyncVarAttribute: Attribute, _Attribute
	{
		public SyncVarAttribute(){}
		public string hook;
	}

	public class	CommandAttribute: Attribute, _Attribute
	{
		public CommandAttribute(){}
		public int channel;
	}

	public class	ClientRpcAttribute: Attribute, _Attribute
	{
		public ClientRpcAttribute(){}
		public int channel;
	}

	public class	SyncEventAttribute: Attribute, _Attribute
	{
		public SyncEventAttribute(){}
		public int channel;
	}

	public class	ServerAttribute: Attribute, _Attribute
	{
		public ServerAttribute(){}
	}

	public class	ServerCallbackAttribute: Attribute, _Attribute
	{
		public ServerCallbackAttribute(){}
	}

	public class	ClientAttribute: Attribute, _Attribute
	{
		public ClientAttribute(){}
	}

	public class	ClientCallbackAttribute: Attribute, _Attribute
	{
		public ClientCallbackAttribute(){}
	}

	public class	LogFilter: Object
	{
		public LogFilter(){}
		private static LogFilter(){}
		public static int currentLogLevel{ get	{} set	{} }
		bool logDev{ get	{} }
		public static bool logDebug{ get	{} }
		public static bool logInfo{ get	{} }
		public static bool logWarn{ get	{} }
		public static bool logError{ get	{} }
		public static bool logFatal{ get	{} }
		public static FilterLevel current;
		private static int s_CurrentLogLevel;
		internal const int Developer = null;
		public const int Debug = null;
		public const int Info = null;
		public const int Warn = null;
		public const int Error = null;
		public const int Fatal = null;
	}

	public abstract	class	MessageBase: Object
	{
		public virtual void Deserialize(NetworkReader reader){}
		public virtual void Serialize(NetworkWriter writer){}
		protected MessageBase(){}
	}

