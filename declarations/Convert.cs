// WARNING:Skipped nested type: UnityEngine.GUI+ScrollViewState
// WARNING:Skipped nested type: UnityEngine.GUI+Scope
// WARNING:Skipped nested type: UnityEngine.GUI+GroupScope
// WARNING:Skipped nested type: UnityEngine.GUI+ScrollViewScope
// WARNING:Skipped nested type: UnityEngine.GUI+ClipScope
// WARNING:Skipped nested type: UnityEngine.GUILayout+LayoutedWindow
// WARNING:Skipped nested type: UnityEngine.GUILayout+HorizontalScope
// WARNING:Skipped nested type: UnityEngine.GUILayout+VerticalScope
// WARNING:Skipped nested type: UnityEngine.GUILayout+AreaScope
// WARNING:Skipped nested type: UnityEngine.GUILayout+ScrollViewScope
// WARNING:Skipped nested type: UnityEngine.GUILayoutUtility+LayoutCache
// WARNING:Skipped nested type: UnityEngine.Transform+Enumerator
// WARNING:Skipped nested type: UnityEngine.SamsungTV+OpenAPI
// WARNING:Skipped nested type: UnityEngine.Animation+Enumerator
// WARNING:Skipped nested type: UnityEngine.InternalStaticBatchingUtility+SortGO
// WARNING:Skipped nested type: UnityEngineInternal.APIUpdaterRuntimeServices+<ResolveType>c__AnonStorey0

// INFO:MMCSReflector::ImportedAssembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null

namespace UnityEngine {
	public sealed class	AssetBundleCreateRequest: AsyncOperation
	{
		internal void DisableCompatibilityChecks(){}
		public AssetBundleCreateRequest(){}
		public AssetBundle assetBundle{ get	{} }
	}

	public sealed class	AssetBundleRequest: AsyncOperation
	{
		public AssetBundleRequest(){}
		public System.Object asset{ get	{} }
		public Object[] allAssets{ get	{} }
		internal AssetBundle m_AssetBundle;
		internal string m_Path;
		internal Type m_Type;
	}

	public sealed class	AssetBundle: Object
	{
		public static AssetBundleCreateRequest CreateFromMemory(Byte[] binary){}
		public static AssetBundle CreateFromMemoryImmediate(Byte[] binary){}
		public static AssetBundle CreateFromFile(string path){}
		public bool Contains(string name){}
		public System.Object Load(string name){}
		public T Load(string name){}
		public System.Object Load(string name, Type type){}
		public AssetBundleRequest LoadAsync(string name, Type type){}
		public Object[] LoadAll(Type type){}
		public Object[] LoadAll(){}
		public T[] LoadAll(){}
		public System.Object LoadAsset(string name){}
		public T LoadAsset(string name){}
		public System.Object LoadAsset(string name, Type type){}
		private System.Object LoadAsset_Internal(string name, Type type){}
		public AssetBundleRequest LoadAssetAsync(string name){}
		public AssetBundleRequest LoadAssetAsync(string name){}
		public AssetBundleRequest LoadAssetAsync(string name, Type type){}
		private AssetBundleRequest LoadAssetAsync_Internal(string name, Type type){}
		public Object[] LoadAssetWithSubAssets(string name){}
		public T[] LoadAssetWithSubAssets(string name){}
		public Object[] LoadAssetWithSubAssets(string name, Type type){}
		internal Object[] LoadAssetWithSubAssets_Internal(string name, Type type){}
		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name){}
		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name){}
		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type){}
		private AssetBundleRequest LoadAssetWithSubAssetsAsync_Internal(string name, Type type){}
		public Object[] LoadAllAssets(){}
		public T[] LoadAllAssets(){}
		public Object[] LoadAllAssets(Type type){}
		public AssetBundleRequest LoadAllAssetsAsync(){}
		public AssetBundleRequest LoadAllAssetsAsync(){}
		public AssetBundleRequest LoadAllAssetsAsync(Type type){}
		public void Unload(bool unloadAllLoadedObjects){}
		public String[] AllAssetNames(){}
		public String[] GetAllAssetNames(){}
		public String[] GetAllScenePaths(){}
		public AssetBundle(){}
		public System.Object mainAsset{ get	{} }
	}

	public sealed class	AssetBundleManifest: Object
	{
		public String[] GetAllAssetBundles(){}
		public String[] GetAllAssetBundlesWithVariant(){}
		public Hash128 GetAssetBundleHash(string assetBundleName){}
		public String[] GetDirectDependencies(string assetBundleName){}
		public String[] GetAllDependencies(string assetBundleName){}
		public AssetBundleManifest(){}
	}

	public sealed class	SystemInfo: Object
	{
		public static bool SupportsRenderTextureFormat(RenderTextureFormat format){}
		public static bool SupportsTextureFormat(TextureFormat format){}
		public SystemInfo(){}
		public static string operatingSystem{ get	{} }
		public static string processorType{ get	{} }
		public static int processorCount{ get	{} }
		public static int systemMemorySize{ get	{} }
		public static int graphicsMemorySize{ get	{} }
		public static string graphicsDeviceName{ get	{} }
		public static string graphicsDeviceVendor{ get	{} }
		public static int graphicsDeviceID{ get	{} }
		public static int graphicsDeviceVendorID{ get	{} }
		public static string graphicsDeviceVersion{ get	{} }
		public static int graphicsShaderLevel{ get	{} }
		public static int graphicsPixelFillrate{ get	{} }
		public static bool supportsVertexPrograms{ get	{} }
		public static bool graphicsMultiThreaded{ get	{} }
		public static bool supportsShadows{ get	{} }
		public static bool supportsRenderTextures{ get	{} }
		public static bool supportsRenderToCubemap{ get	{} }
		public static bool supportsImageEffects{ get	{} }
		public static bool supports3DTextures{ get	{} }
		public static bool supportsComputeShaders{ get	{} }
		public static bool supportsInstancing{ get	{} }
		public static bool supportsSparseTextures{ get	{} }
		public static int supportedRenderTargetCount{ get	{} }
		public static int supportsStencil{ get	{} }
		public static NPOTSupport npotSupport{ get	{} }
		public static string deviceUniqueIdentifier{ get	{} }
		public static string deviceName{ get	{} }
		public static string deviceModel{ get	{} }
		public static bool supportsAccelerometer{ get	{} }
		public static bool supportsGyroscope{ get	{} }
		public static bool supportsLocationService{ get	{} }
		public static bool supportsVibration{ get	{} }
		public static DeviceType deviceType{ get	{} }
		public static int maxTextureSize{ get	{} }
	}

	public sealed class	WaitForSeconds: YieldInstruction
	{
		public WaitForSeconds(float seconds){}
		internal float m_Seconds;
	}

	public sealed class	WaitForFixedUpdate: YieldInstruction
	{
		public WaitForFixedUpdate(){}
	}

	public sealed class	WaitForEndOfFrame: YieldInstruction
	{
		public WaitForEndOfFrame(){}
	}

	public sealed class	Coroutine: YieldInstruction
	{
		private void ReleaseCoroutine(){}
		protected virtual void Finalize(){}
		private Coroutine(){}
		internal IntPtr m_Ptr;
	}

	public class	ScriptableObject: Object
	{
		private static void Internal_CreateScriptableObject(ScriptableObject self){}
		public void SetDirty(){}
		private static void INTERNAL_CALL_SetDirty(ScriptableObject self){}
		public static ScriptableObject CreateInstance(string className){}
		public static ScriptableObject CreateInstance(Type type){}
		private static ScriptableObject CreateInstanceFromType(Type type){}
		public static T CreateInstance(){}
		public ScriptableObject(){}
	}

	public sealed class	Profiler: Object
	{
		public static void AddFramesFromFile(string file){}
		public static void BeginSample(string name){}
		public static void BeginSample(string name, System.Object targetObject){}
		private static void BeginSampleOnly(string name){}
		public static void EndSample(){}
		public static int GetRuntimeMemorySize(System.Object o){}
		public static uint GetMonoHeapSize(){}
		public static uint GetMonoUsedSize(){}
		public static uint GetTotalAllocatedMemory(){}
		public static uint GetTotalUnusedReservedMemory(){}
		public static uint GetTotalReservedMemory(){}
		public Profiler(){}
		public static bool supported{ get	{} }
		public static string logFile{ get	{} set	{} }
		public static bool enableBinaryLog{ get	{} set	{} }
		public static bool enabled{ get	{} set	{} }
		public static uint usedHeapSize{ get	{} }
	}

	public sealed class	CrashReport: Object
	{
		private static int Compare(CrashReport c1, CrashReport c2){}
		private static void PopulateReports(){}
		public static void RemoveAll(){}
		public void Remove(){}
		private static String[] GetReports(){}
		private static void GetReportData(string id, out double secondsSinceUnixEpoch, out string text){}
		private static bool RemoveReport(string id){}
		private CrashReport(string id, DateTime time, string text){}
		private static CrashReport(){}
		public static CrashReport[] reports{ get	{} }
		public static CrashReport lastReport{ get	{} }
		private readonly string id;
		public readonly DateTime time;
		public readonly string text;
		private static List<CrashReport> internalReports;
		private static System.Object reportsLock;
	}

	public sealed class	Cursor: Object
	{
		private static void SetCursor(Texture2D texture, CursorMode cursorMode){}
		public static void SetCursor(Texture2D texture, Vector2 hotspot, CursorMode cursorMode){}
		private static void INTERNAL_CALL_SetCursor(Texture2D texture, ref Vector2 hotspot, CursorMode cursorMode){}
		public Cursor(){}
		public static bool visible{ get	{} set	{} }
		public static CursorLockMode lockState{ get	{} set	{} }
	}

	public sealed class	OcclusionArea: Component
	{
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		private void INTERNAL_get_size(out Vector3 value){}
		private void INTERNAL_set_size(ref Vector3 value){}
		public OcclusionArea(){}
		public Vector3 center{ get	{} set	{} }
		public Vector3 size{ get	{} set	{} }
	}

	public sealed class	OcclusionPortal: Component
	{
		public OcclusionPortal(){}
		public bool open{ get	{} set	{} }
	}

	public sealed class	RenderSettings: Object
	{
		private static void INTERNAL_get_fogColor(out Color value){}
		private static void INTERNAL_set_fogColor(ref Color value){}
		private static void INTERNAL_get_ambientSkyColor(out Color value){}
		private static void INTERNAL_set_ambientSkyColor(ref Color value){}
		private static void INTERNAL_get_ambientEquatorColor(out Color value){}
		private static void INTERNAL_set_ambientEquatorColor(ref Color value){}
		private static void INTERNAL_get_ambientGroundColor(out Color value){}
		private static void INTERNAL_set_ambientGroundColor(ref Color value){}
		private static void INTERNAL_get_ambientLight(out Color value){}
		private static void INTERNAL_set_ambientLight(ref Color value){}
		private static void INTERNAL_get_ambientProbe(out SphericalHarmonicsL2 value){}
		private static void INTERNAL_set_ambientProbe(ref SphericalHarmonicsL2 value){}
		internal static void Reset(){}
		internal static System.Object GetRenderSettings(){}
		public RenderSettings(){}
		public static bool fog{ get	{} set	{} }
		public static FogMode fogMode{ get	{} set	{} }
		public static Color fogColor{ get	{} set	{} }
		public static float fogDensity{ get	{} set	{} }
		public static float fogStartDistance{ get	{} set	{} }
		public static float fogEndDistance{ get	{} set	{} }
		public static AmbientMode ambientMode{ get	{} set	{} }
		public static Color ambientSkyColor{ get	{} set	{} }
		public static Color ambientEquatorColor{ get	{} set	{} }
		public static Color ambientGroundColor{ get	{} set	{} }
		public static Color ambientLight{ get	{} set	{} }
		public static float ambientSkyboxAmount{ get	{} set	{} }
		public static float ambientIntensity{ get	{} set	{} }
		public static SphericalHarmonicsL2 ambientProbe{ get	{} set	{} }
		public static float reflectionIntensity{ get	{} set	{} }
		public static int reflectionBounces{ get	{} set	{} }
		public static float haloStrength{ get	{} set	{} }
		public static float flareStrength{ get	{} set	{} }
		public static float flareFadeSpeed{ get	{} set	{} }
		public static Material skybox{ get	{} set	{} }
		public static DefaultReflectionMode defaultReflectionMode{ get	{} set	{} }
		public static int defaultReflectionResolution{ get	{} set	{} }
		public static Cubemap customReflection{ get	{} set	{} }
	}

	public sealed class	QualitySettings: Object
	{
		public static int GetQualityLevel(){}
		public static void SetQualityLevel(int index, bool applyExpensiveChanges){}
		public static void SetQualityLevel(int index){}
		public static void IncreaseLevel(bool applyExpensiveChanges){}
		public static void IncreaseLevel(){}
		public static void DecreaseLevel(bool applyExpensiveChanges){}
		public static void DecreaseLevel(){}
		private static void INTERNAL_get_shadowCascade4Split(out Vector3 value){}
		private static void INTERNAL_set_shadowCascade4Split(ref Vector3 value){}
		public QualitySettings(){}
		public static String[] names{ get	{} }
		public static QualityLevel currentLevel{ get	{} set	{} }
		public static int pixelLightCount{ get	{} set	{} }
		public static ShadowProjection shadowProjection{ get	{} set	{} }
		public static int shadowCascades{ get	{} set	{} }
		public static float shadowDistance{ get	{} set	{} }
		public static float shadowCascade2Split{ get	{} set	{} }
		public static Vector3 shadowCascade4Split{ get	{} set	{} }
		public static int masterTextureLimit{ get	{} set	{} }
		public static AnisotropicFiltering anisotropicFiltering{ get	{} set	{} }
		public static float lodBias{ get	{} set	{} }
		public static int maximumLODLevel{ get	{} set	{} }
		public static int particleRaycastBudget{ get	{} set	{} }
		public static bool softVegetation{ get	{} set	{} }
		public static bool realtimeReflectionProbes{ get	{} set	{} }
		public static bool billboardsFaceCameraPosition{ get	{} set	{} }
		public static int maxQueuedFrames{ get	{} set	{} }
		public static int vSyncCount{ get	{} set	{} }
		public static int antiAliasing{ get	{} set	{} }
		public static ColorSpace desiredColorSpace{ get	{} }
		public static ColorSpace activeColorSpace{ get	{} }
		public static BlendWeights blendWeights{ get	{} set	{} }
	}

	public sealed class	MeshFilter: Component
	{
		public MeshFilter(){}
		public Mesh mesh{ get	{} set	{} }
		public Mesh sharedMesh{ get	{} set	{} }
	}

	public sealed class	Mesh: Object
	{
		private static void Internal_Create(Mesh mono){}
		public void Clear(bool keepVertexLayout){}
		public void Clear(){}
		private void INTERNAL_get_bounds(out Bounds value){}
		private void INTERNAL_set_bounds(ref Bounds value){}
		public void RecalculateBounds(){}
		public void RecalculateNormals(){}
		public void Optimize(){}
		public Int32[] GetTriangles(int submesh){}
		public void SetTriangles(Int32[] triangles, int submesh){}
		public Int32[] GetIndices(int submesh){}
		public void SetIndices(Int32[] indices, MeshTopology topology, int submesh){}
		public MeshTopology GetTopology(int submesh){}
		public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices){}
		public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes){}
		public void CombineMeshes(CombineInstance[] combine){}
		public void MarkDynamic(){}
		public void UploadMeshData(bool markNoLogerReadable){}
		public string GetBlendShapeName(int index){}
		public int GetBlendShapeIndex(string blendShapeName){}
		public Mesh(){}
		public bool isReadable{ get	{} }
		bool canAccess{ get	{} }
		public Vector3[] vertices{ get	{} set	{} }
		public Vector3[] normals{ get	{} set	{} }
		public Vector4[] tangents{ get	{} set	{} }
		public Vector2[] uv{ get	{} set	{} }
		public Vector2[] uv1{ get	{} set	{} }
		public Vector2[] uv2{ get	{} set	{} }
		public Vector2[] uv3{ get	{} set	{} }
		public Vector2[] uv4{ get	{} set	{} }
		public Bounds bounds{ get	{} set	{} }
		public Color[] colors{ get	{} set	{} }
		public Color32[] colors32{ get	{} set	{} }
		public Int32[] triangles{ get	{} set	{} }
		public int vertexCount{ get	{} }
		public int subMeshCount{ get	{} set	{} }
		public BoneWeight[] boneWeights{ get	{} set	{} }
		public Matrix4x4[] bindposes{ get	{} set	{} }
		public int blendShapeCount{ get	{} }
	}

	public class	SkinnedMeshRenderer: Renderer
	{
		private void INTERNAL_get_localBounds(out Bounds value){}
		private void INTERNAL_set_localBounds(ref Bounds value){}
		public void BakeMesh(Mesh mesh){}
		public float GetBlendShapeWeight(int index){}
		public void SetBlendShapeWeight(int index, float value){}
		public SkinnedMeshRenderer(){}
		public Transform[] bones{ get	{} set	{} }
		public Transform rootBone{ get	{} set	{} }
		public SkinQuality quality{ get	{} set	{} }
		public Mesh sharedMesh{ get	{} set	{} }
		public bool updateWhenOffscreen{ get	{} set	{} }
		public Bounds localBounds{ get	{} set	{} }
		Transform actualRootBone{ get	{} }
	}

	public sealed class	Flare: Object
	{
		public Flare(){}
	}

	public sealed class	LensFlare: Behaviour
	{
		private void INTERNAL_get_color(out Color value){}
		private void INTERNAL_set_color(ref Color value){}
		public LensFlare(){}
		public Flare flare{ get	{} set	{} }
		public float brightness{ get	{} set	{} }
		public float fadeSpeed{ get	{} set	{} }
		public Color color{ get	{} set	{} }
	}

	public class	Renderer: Component
	{
		internal void SetSubsetIndex(int index, int subSetIndexForMaterial){}
		private void INTERNAL_get_worldToLocalMatrix(out Matrix4x4 value){}
		private void INTERNAL_get_localToWorldMatrix(out Matrix4x4 value){}
		private void INTERNAL_get_lightmapScaleOffset(out Vector4 value){}
		private void INTERNAL_set_lightmapScaleOffset(ref Vector4 value){}
		private void INTERNAL_get_realtimeLightmapScaleOffset(out Vector4 value){}
		private void INTERNAL_set_realtimeLightmapScaleOffset(ref Vector4 value){}
		public void SetPropertyBlock(MaterialPropertyBlock properties){}
		public void GetPropertyBlock(MaterialPropertyBlock dest){}
		internal void RenderNow(int material){}
		private void GetClosestReflectionProbesInternal(System.Object result){}
		public void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result){}
		public Renderer(){}
		Transform staticBatchRootTransform{ get	{} set	{} }
		int staticBatchIndex{ get	{} }
		public bool isPartOfStaticBatch{ get	{} }
		public Matrix4x4 worldToLocalMatrix{ get	{} }
		public Matrix4x4 localToWorldMatrix{ get	{} }
		public bool enabled{ get	{} set	{} }
		public ShadowCastingMode shadowCastingMode{ get	{} set	{} }
		public bool castShadows{ get	{} set	{} }
		public bool receiveShadows{ get	{} set	{} }
		public Material material{ get	{} set	{} }
		public Material sharedMaterial{ get	{} set	{} }
		public Material[] materials{ get	{} set	{} }
		public Material[] sharedMaterials{ get	{} set	{} }
		public Bounds bounds{ get	{} }
		public int lightmapIndex{ get	{} set	{} }
		public int realtimeLightmapIndex{ get	{} }
		public Vector4 lightmapTilingOffset{ get	{} set	{} }
		public Vector4 lightmapScaleOffset{ get	{} set	{} }
		public Vector4 realtimeLightmapScaleOffset{ get	{} set	{} }
		public bool isVisible{ get	{} }
		public bool useLightProbes{ get	{} set	{} }
		public Transform lightProbeAnchor{ get	{} set	{} }
		public Transform probeAnchor{ get	{} set	{} }
		public ReflectionProbeUsage reflectionProbeUsage{ get	{} set	{} }
		public string sortingLayerName{ get	{} set	{} }
		public int sortingLayerID{ get	{} set	{} }
		public int sortingOrder{ get	{} set	{} }
	}

	public sealed class	Projector: Behaviour
	{
		public Projector(){}
		public float nearClipPlane{ get	{} set	{} }
		public float farClipPlane{ get	{} set	{} }
		public float fieldOfView{ get	{} set	{} }
		public float aspectRatio{ get	{} set	{} }
		public bool isOrthoGraphic{ get	{} set	{} }
		public float orthoGraphicSize{ get	{} set	{} }
		public bool orthographic{ get	{} set	{} }
		public float orthographicSize{ get	{} set	{} }
		public int ignoreLayers{ get	{} set	{} }
		public Material material{ get	{} set	{} }
	}

	public sealed class	Skybox: Behaviour
	{
		public Skybox(){}
		public Material material{ get	{} set	{} }
	}

	public sealed class	TrailRenderer: Renderer
	{
		public TrailRenderer(){}
		public float time{ get	{} set	{} }
		public float startWidth{ get	{} set	{} }
		public float endWidth{ get	{} set	{} }
		public bool autodestruct{ get	{} set	{} }
	}

	public sealed class	LineRenderer: Renderer
	{
		public void SetWidth(float start, float end){}
		private static void INTERNAL_CALL_SetWidth(LineRenderer self, float start, float end){}
		public void SetColors(Color start, Color end){}
		private static void INTERNAL_CALL_SetColors(LineRenderer self, ref Color start, ref Color end){}
		public void SetVertexCount(int count){}
		private static void INTERNAL_CALL_SetVertexCount(LineRenderer self, int count){}
		public void SetPosition(int index, Vector3 position){}
		private static void INTERNAL_CALL_SetPosition(LineRenderer self, int index, ref Vector3 position){}
		public LineRenderer(){}
		public bool useWorldSpace{ get	{} set	{} }
	}

	public sealed class	MaterialPropertyBlock: Object
	{
		internal void InitBlock(){}
		internal void DestroyBlock(){}
		protected virtual void Finalize(){}
		public void SetFloat(string name, float value){}
		public void SetFloat(int nameID, float value){}
		public void SetVector(string name, Vector4 value){}
		public void SetVector(int nameID, Vector4 value){}
		private static void INTERNAL_CALL_SetVector(MaterialPropertyBlock self, int nameID, ref Vector4 value){}
		public void SetColor(string name, Color value){}
		public void SetColor(int nameID, Color value){}
		private static void INTERNAL_CALL_SetColor(MaterialPropertyBlock self, int nameID, ref Color value){}
		public void SetMatrix(string name, Matrix4x4 value){}
		public void SetMatrix(int nameID, Matrix4x4 value){}
		private static void INTERNAL_CALL_SetMatrix(MaterialPropertyBlock self, int nameID, ref Matrix4x4 value){}
		public void SetTexture(string name, Texture value){}
		public void SetTexture(int nameID, Texture value){}
		public void AddFloat(string name, float value){}
		public void AddFloat(int nameID, float value){}
		public void AddVector(string name, Vector4 value){}
		public void AddVector(int nameID, Vector4 value){}
		private static void INTERNAL_CALL_AddVector(MaterialPropertyBlock self, int nameID, ref Vector4 value){}
		public void AddColor(string name, Color value){}
		public void AddColor(int nameID, Color value){}
		private static void INTERNAL_CALL_AddColor(MaterialPropertyBlock self, int nameID, ref Color value){}
		public void AddMatrix(string name, Matrix4x4 value){}
		public void AddMatrix(int nameID, Matrix4x4 value){}
		private static void INTERNAL_CALL_AddMatrix(MaterialPropertyBlock self, int nameID, ref Matrix4x4 value){}
		public void AddTexture(string name, Texture value){}
		public void AddTexture(int nameID, Texture value){}
		public float GetFloat(string name){}
		public float GetFloat(int nameID){}
		public Vector4 GetVector(string name){}
		public Vector4 GetVector(int nameID){}
		public Matrix4x4 GetMatrix(string name){}
		public Matrix4x4 GetMatrix(int nameID){}
		public Texture GetTexture(string name){}
		public Texture GetTexture(int nameID){}
		public void Clear(){}
		public MaterialPropertyBlock(){}
		internal IntPtr m_Ptr;
	}

	public sealed class	Graphics: Object
	{
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows, bool receiveShadows){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows, bool receiveShadows){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows){}
		private static void Internal_DrawMeshTR(ref Internal_DrawMeshTRArguments arguments, MaterialPropertyBlock properties, Material material, Mesh mesh, Camera camera){}
		private static void Internal_DrawMeshMatrix(ref Internal_DrawMeshMatrixArguments arguments, MaterialPropertyBlock properties, Material material, Mesh mesh, Camera camera){}
		public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation){}
		public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex){}
		public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix){}
		public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix, int materialIndex){}
		private static void Internal_DrawMeshNow1(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex){}
		private static void INTERNAL_CALL_Internal_DrawMeshNow1(Mesh mesh, ref Vector3 position, ref Quaternion rotation, int materialIndex){}
		private static void Internal_DrawMeshNow2(Mesh mesh, Matrix4x4 matrix, int materialIndex){}
		private static void INTERNAL_CALL_Internal_DrawMeshNow2(Mesh mesh, ref Matrix4x4 matrix, int materialIndex){}
		public static void DrawProcedural(MeshTopology topology, int vertexCount, int instanceCount){}
		public static void DrawProcedural(MeshTopology topology, int vertexCount){}
		public static void DrawProceduralIndirect(MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset){}
		public static void DrawProceduralIndirect(MeshTopology topology, ComputeBuffer bufferWithArgs){}
		internal static void DrawSprite(Sprite sprite, Matrix4x4 matrix, Material material, int layer, Camera camera, Color color, MaterialPropertyBlock properties){}
		private static void INTERNAL_CALL_DrawSprite(Sprite sprite, ref Matrix4x4 matrix, Material material, int layer, Camera camera, ref Color color, MaterialPropertyBlock properties){}
		public static void DrawTexture(Rect screenRect, Texture texture){}
		public static void DrawTexture(Rect screenRect, Texture texture, Material mat){}
		public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder){}
		public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat){}
		public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder){}
		public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat){}
		public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color){}
		public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color, Material mat){}
		internal static void DrawTexture(ref InternalDrawTextureArguments arguments){}
		public static void ExecuteCommandBuffer(CommandBuffer buffer){}
		public static void Blit(Texture source, RenderTexture dest){}
		public static void Blit(Texture source, RenderTexture dest, Material mat){}
		public static void Blit(Texture source, RenderTexture dest, Material mat, int pass){}
		public static void Blit(Texture source, Material mat){}
		public static void Blit(Texture source, Material mat, int pass){}
		private static void Internal_BlitMaterial(Texture source, RenderTexture dest, Material mat, int pass, bool setRT){}
		public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat, Vector2[] offsets){}
		private static void Internal_BlitMultiTap(Texture source, RenderTexture dest, Material mat, Vector2[] offsets){}
		private static void Internal_SetNullRT(){}
		private static void Internal_SetRTFullSetup(out RenderBuffer color, out RenderBuffer depth, int mip, int face, RenderBufferLoadAction colorLoad, RenderBufferStoreAction colorStore, RenderBufferLoadAction depthLoad, RenderBufferStoreAction depthStore){}
		private static void Internal_SetRTSimple(out RenderBuffer color, out RenderBuffer depth, int mip, int face){}
		private static void Internal_SetMRTFullSetup(RenderBuffer[] color, out RenderBuffer depth, int mip, int face, RenderBufferLoadAction[] colorLoad, RenderBufferStoreAction[] colorStore, RenderBufferLoadAction depthLoad, RenderBufferStoreAction depthStore){}
		private static void Internal_SetMRTSimple(RenderBuffer[] color, out RenderBuffer depth, int mip, int face){}
		private static void GetActiveColorBuffer(out RenderBuffer res){}
		private static void GetActiveDepthBuffer(out RenderBuffer res){}
		public static void SetRandomWriteTarget(int index, RenderTexture uav){}
		public static void SetRandomWriteTarget(int index, ComputeBuffer uav){}
		public static void ClearRandomWriteTargets(){}
		private static void Internal_SetRandomWriteTargetRT(int index, RenderTexture uav){}
		private static void Internal_SetRandomWriteTargetBuffer(int index, ComputeBuffer uav){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix){}
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, int materialIndex){}
		internal static void SetupVertexLights(Light[] lights){}
		internal static void SetRenderTargetImpl(RenderTargetSetup setup){}
		internal static void SetRenderTargetImpl(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel, int face){}
		internal static void SetRenderTargetImpl(RenderTexture rt, int mipLevel, int face){}
		internal static void SetRenderTargetImpl(RenderBuffer[] colorBuffers, RenderBuffer depthBuffer, int mipLevel, int face){}
		public static void SetRenderTarget(RenderTexture rt){}
		public static void SetRenderTarget(RenderTexture rt, int mipLevel){}
		public static void SetRenderTarget(RenderTexture rt, int mipLevel, CubemapFace face){}
		public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer){}
		public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel){}
		public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel, CubemapFace face){}
		public static void SetRenderTarget(RenderBuffer[] colorBuffers, RenderBuffer depthBuffer){}
		internal static void SetRenderTarget(RenderTargetSetup setup){}
		public Graphics(){}
		public static RenderBuffer activeColorBuffer{ get	{} }
		public static RenderBuffer activeDepthBuffer{ get	{} }
		public static string deviceName{ get	{} }
		public static string deviceVendor{ get	{} }
		public static string deviceVersion{ get	{} }
	}

	public sealed class	LightmapData: Object
	{
		public LightmapData(){}
		public Texture2D lightmapFar{ get	{} set	{} }
		public Texture2D lightmap{ get	{} set	{} }
		public Texture2D lightmapNear{ get	{} set	{} }
		internal Texture2D m_Light;
		internal Texture2D m_Dir;
	}

	public sealed class	LightProbes: Object
	{
		public static void GetInterpolatedProbe(Vector3 position, Renderer renderer, out SphericalHarmonicsL2 probe){}
		private static void INTERNAL_CALL_GetInterpolatedProbe(ref Vector3 position, Renderer renderer, out SphericalHarmonicsL2 probe){}
		public void GetInterpolatedLightProbe(Vector3 position, Renderer renderer, Single[] coefficients){}
		public LightProbes(){}
		public Vector3[] positions{ get	{} }
		public SphericalHarmonicsL2[] bakedProbes{ get	{} set	{} }
		public int count{ get	{} }
		public int cellCount{ get	{} }
		public Single[] coefficients{ get	{} set	{} }
	}

	public sealed class	LightmapSettings: Object
	{
		internal static void Reset(){}
		public LightmapSettings(){}
		public static LightmapData[] lightmaps{ get	{} set	{} }
		public static LightmapsModeLegacy lightmapsModeLegacy{ get	{} set	{} }
		public static LightmapsMode lightmapsMode{ get	{} set	{} }
		public static ColorSpace bakedColorSpace{ get	{} set	{} }
		public static LightProbes lightProbes{ get	{} set	{} }
	}

	public sealed class	GeometryUtility: Object
	{
		public static Plane[] CalculateFrustumPlanes(Camera camera){}
		public static Plane[] CalculateFrustumPlanes(Matrix4x4 worldToProjectionMatrix){}
		private static void Internal_ExtractPlanes(Plane[] planes, Matrix4x4 worldToProjectionMatrix){}
		private static void INTERNAL_CALL_Internal_ExtractPlanes(Plane[] planes, ref Matrix4x4 worldToProjectionMatrix){}
		public static bool TestPlanesAABB(Plane[] planes, Bounds bounds){}
		private static bool INTERNAL_CALL_TestPlanesAABB(Plane[] planes, ref Bounds bounds){}
		public GeometryUtility(){}
	}

	public sealed class	Screen: Object
	{
		public static void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate){}
		public static void SetResolution(int width, int height, bool fullscreen){}
		public Screen(){}
		public static Resolution[] resolutions{ get	{} }
		public static Resolution[] GetResolution{ get	{} }
		public static bool showCursor{ get	{} set	{} }
		public static bool lockCursor{ get	{} set	{} }
		public static Resolution currentResolution{ get	{} }
		public static int width{ get	{} }
		public static int height{ get	{} }
		public static float dpi{ get	{} }
		public static bool fullScreen{ get	{} set	{} }
		public static bool autorotateToPortrait{ get	{} set	{} }
		public static bool autorotateToPortraitUpsideDown{ get	{} set	{} }
		public static bool autorotateToLandscapeLeft{ get	{} set	{} }
		public static bool autorotateToLandscapeRight{ get	{} set	{} }
		public static ScreenOrientation orientation{ get	{} set	{} }
		public static int sleepTimeout{ get	{} set	{} }
		private static bool <showCursor>k__BackingField;
	}

	public sealed class	SleepTimeout: Object
	{
		public SleepTimeout(){}
		public const int NeverSleep = null;
		public const int SystemSetting = null;
	}

	public sealed class	GL: Object
	{
		public static void Vertex3(float x, float y, float z){}
		public static void Vertex(Vector3 v){}
		private static void INTERNAL_CALL_Vertex(ref Vector3 v){}
		public static void Color(Color c){}
		private static void INTERNAL_CALL_Color(ref Color c){}
		public static void TexCoord(Vector3 v){}
		private static void INTERNAL_CALL_TexCoord(ref Vector3 v){}
		public static void TexCoord2(float x, float y){}
		public static void TexCoord3(float x, float y, float z){}
		public static void MultiTexCoord2(int unit, float x, float y){}
		public static void MultiTexCoord3(int unit, float x, float y, float z){}
		public static void MultiTexCoord(int unit, Vector3 v){}
		private static void INTERNAL_CALL_MultiTexCoord(int unit, ref Vector3 v){}
		public static void Begin(int mode){}
		public static void End(){}
		public static void LoadOrtho(){}
		public static void LoadPixelMatrix(){}
		private static void LoadPixelMatrixArgs(float left, float right, float bottom, float top){}
		public static void LoadPixelMatrix(float left, float right, float bottom, float top){}
		public static void Viewport(Rect pixelRect){}
		private static void INTERNAL_CALL_Viewport(ref Rect pixelRect){}
		public static void LoadProjectionMatrix(Matrix4x4 mat){}
		private static void INTERNAL_CALL_LoadProjectionMatrix(ref Matrix4x4 mat){}
		public static void LoadIdentity(){}
		private static void INTERNAL_get_modelview(out Matrix4x4 value){}
		private static void INTERNAL_set_modelview(ref Matrix4x4 value){}
		public static void MultMatrix(Matrix4x4 mat){}
		private static void INTERNAL_CALL_MultMatrix(ref Matrix4x4 mat){}
		public static void PushMatrix(){}
		public static void PopMatrix(){}
		public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, bool renderIntoTexture){}
		private static Matrix4x4 INTERNAL_CALL_GetGPUProjectionMatrix(ref Matrix4x4 proj, bool renderIntoTexture){}
		public static void SetRevertBackfacing(bool revertBackFaces){}
		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor){}
		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor, float depth){}
		private static void Internal_Clear(bool clearDepth, bool clearColor, Color backgroundColor, float depth){}
		private static void INTERNAL_CALL_Internal_Clear(bool clearDepth, bool clearColor, ref Color backgroundColor, float depth){}
		public static void ClearWithSkybox(bool clearDepth, Camera camera){}
		public static void InvalidateState(){}
		public static void IssuePluginEvent(int eventID){}
		public GL(){}
		public static Matrix4x4 modelview{ get	{} set	{} }
		public static bool wireframe{ get	{} set	{} }
		public static bool sRGBWrite{ get	{} set	{} }
		public static bool invertCulling{ get	{} set	{} }
		public const int TRIANGLES = null;
		public const int TRIANGLE_STRIP = null;
		public const int QUADS = null;
		public const int LINES = null;
	}

	public sealed class	MeshRenderer: Renderer
	{
		public MeshRenderer(){}
		public Mesh additionalVertexStreams{ get	{} set	{} }
	}

	public sealed class	StaticBatchingUtility: Object
	{
		public static void Combine(GameObject staticBatchRoot){}
		public static void Combine(GameObject[] gos, GameObject staticBatchRoot){}
		internal static Mesh InternalCombineVertices(MeshInstance[] meshes, string meshName){}
		internal static void InternalCombineIndices(SubMeshInstance[] submeshes, Mesh combinedMesh){}
		public StaticBatchingUtility(){}
	}

	public sealed class	ImageEffectTransformsToLDR: Attribute, _Attribute
	{
		public ImageEffectTransformsToLDR(){}
	}

	public sealed class	ImageEffectOpaque: Attribute, _Attribute
	{
		public ImageEffectOpaque(){}
	}

	public class	Texture: Object
	{
		public static void SetGlobalAnisotropicFilteringLimits(int forcedMin, int globalMax){}
		private static int Internal_GetWidth(Texture mono){}
		private static int Internal_GetHeight(Texture mono){}
		public IntPtr GetNativeTexturePtr(){}
		public int GetNativeTextureID(){}
		public Texture(){}
		public static int masterTextureLimit{ get	{} set	{} }
		public static AnisotropicFiltering anisotropicFiltering{ get	{} set	{} }
		public virtual int width{ get	{} set	{} }
		public virtual int height{ get	{} set	{} }
		public FilterMode filterMode{ get	{} set	{} }
		public int anisoLevel{ get	{} set	{} }
		public TextureWrapMode wrapMode{ get	{} set	{} }
		public float mipMapBias{ get	{} set	{} }
		public Vector2 texelSize{ get	{} }
	}

	public sealed class	Texture2D: Texture
	{
		private static void Internal_Create(Texture2D mono, int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex){}
		public static Texture2D CreateExternalTexture(int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex){}
		public void UpdateExternalTexture(IntPtr nativeTex){}
		public void SetPixel(int x, int y, Color color){}
		private static void INTERNAL_CALL_SetPixel(Texture2D self, int x, int y, ref Color color){}
		public Color GetPixel(int x, int y){}
		public Color GetPixelBilinear(float u, float v){}
		public void SetPixels(Color[] colors){}
		public void SetPixels(Color[] colors, int miplevel){}
		public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel){}
		public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors){}
		private void SetAllPixels32(Color32[] colors, int miplevel){}
		private void SetBlockOfPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel){}
		public void SetPixels32(Color32[] colors){}
		public void SetPixels32(Color32[] colors, int miplevel){}
		public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors){}
		public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel){}
		public bool LoadImage(Byte[] data){}
		public void LoadRawTextureData(Byte[] data){}
		public Color[] GetPixels(){}
		public Color[] GetPixels(int miplevel){}
		public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, int miplevel){}
		public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight){}
		public Color32[] GetPixels32(int miplevel){}
		public Color32[] GetPixels32(){}
		public void Apply(bool updateMipmaps, bool makeNoLongerReadable){}
		public void Apply(bool updateMipmaps){}
		public void Apply(){}
		public bool Resize(int width, int height, TextureFormat format, bool hasMipMap){}
		public bool Resize(int width, int height){}
		private bool Internal_ResizeWH(int width, int height){}
		public void Compress(bool highQuality){}
		private static void INTERNAL_CALL_Compress(Texture2D self, bool highQuality){}
		public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable){}
		public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize){}
		public Rect[] PackTextures(Texture2D[] textures, int padding){}
		public void ReadPixels(Rect source, int destX, int destY, bool recalculateMipMaps){}
		public void ReadPixels(Rect source, int destX, int destY){}
		private static void INTERNAL_CALL_ReadPixels(Texture2D self, ref Rect source, int destX, int destY, bool recalculateMipMaps){}
		public Byte[] EncodeToPNG(){}
		public Byte[] EncodeToJPG(int quality){}
		public Byte[] EncodeToJPG(){}
		public Texture2D(int width, int height){}
		public Texture2D(int width, int height, TextureFormat format, bool mipmap){}
		public Texture2D(int width, int height, TextureFormat format, bool mipmap, bool linear){}
		internal Texture2D(int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex){}
		public int mipmapCount{ get	{} }
		public TextureFormat format{ get	{} }
		public static Texture2D whiteTexture{ get	{} }
		public static Texture2D blackTexture{ get	{} }
		public bool alphaIsTransparency{ get	{} set	{} }
	}

	public sealed class	Cubemap: Texture
	{
		public void SetPixel(CubemapFace face, int x, int y, Color color){}
		private static void INTERNAL_CALL_SetPixel(Cubemap self, CubemapFace face, int x, int y, ref Color color){}
		public Color GetPixel(CubemapFace face, int x, int y){}
		public Color[] GetPixels(CubemapFace face, int miplevel){}
		public Color[] GetPixels(CubemapFace face){}
		public void SetPixels(Color[] colors, CubemapFace face, int miplevel){}
		public void SetPixels(Color[] colors, CubemapFace face){}
		public void Apply(bool updateMipmaps, bool makeNoLongerReadable){}
		public void Apply(bool updateMipmaps){}
		public void Apply(){}
		private static void Internal_Create(Cubemap mono, int size, TextureFormat format, bool mipmap){}
		public void SmoothEdges(int smoothRegionWidthInPixels){}
		public void SmoothEdges(){}
		public Cubemap(int size, TextureFormat format, bool mipmap){}
		public TextureFormat format{ get	{} }
	}

	public sealed class	Texture3D: Texture
	{
		public Color[] GetPixels(int miplevel){}
		public Color[] GetPixels(){}
		public void SetPixels(Color[] colors, int miplevel){}
		public void SetPixels(Color[] colors){}
		public void Apply(bool updateMipmaps){}
		public void Apply(){}
		private static void Internal_Create(Texture3D mono, int width, int height, int depth, TextureFormat format, bool mipmap){}
		public Texture3D(int width, int height, int depth, TextureFormat format, bool mipmap){}
		public int depth{ get	{} }
		public TextureFormat format{ get	{} }
	}

	public sealed class	SparseTexture: Texture
	{
		private static void Internal_Create(SparseTexture mono, int width, int height, TextureFormat format, int mipCount, bool linear){}
		public void UpdateTile(int tileX, int tileY, int miplevel, Color32[] data){}
		public void UpdateTileRaw(int tileX, int tileY, int miplevel, Byte[] data){}
		public void UnloadTile(int tileX, int tileY, int miplevel){}
		public SparseTexture(int width, int height, TextureFormat format, int mipCount){}
		public SparseTexture(int width, int height, TextureFormat format, int mipCount, bool linear){}
		public int tileWidth{ get	{} }
		public int tileHeight{ get	{} }
		public bool isCreated{ get	{} }
	}

	public sealed class	RenderTexture: Texture
	{
		private static void Internal_CreateRenderTexture(RenderTexture rt){}
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing){}
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite){}
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format){}
		public static RenderTexture GetTemporary(int width, int height, int depthBuffer){}
		public static RenderTexture GetTemporary(int width, int height){}
		public static void ReleaseTemporary(RenderTexture temp){}
		private static int Internal_GetWidth(RenderTexture mono){}
		private static void Internal_SetWidth(RenderTexture mono, int width){}
		private static int Internal_GetHeight(RenderTexture mono){}
		private static void Internal_SetHeight(RenderTexture mono, int width){}
		private static void Internal_SetSRGBReadWrite(RenderTexture mono, bool sRGB){}
		public bool Create(){}
		private static bool INTERNAL_CALL_Create(RenderTexture self){}
		public void Release(){}
		private static void INTERNAL_CALL_Release(RenderTexture self){}
		public bool IsCreated(){}
		private static bool INTERNAL_CALL_IsCreated(RenderTexture self){}
		public void DiscardContents(){}
		private static void INTERNAL_CALL_DiscardContents(RenderTexture self){}
		public void DiscardContents(bool discardColor, bool discardDepth){}
		public void MarkRestoreExpected(){}
		private static void INTERNAL_CALL_MarkRestoreExpected(RenderTexture self){}
		private void GetColorBuffer(out RenderBuffer res){}
		private void GetDepthBuffer(out RenderBuffer res){}
		public void SetGlobalShaderProperty(string propertyName){}
		private static void Internal_GetTexelOffset(RenderTexture tex, out Vector2 output){}
		public Vector2 GetTexelOffset(){}
		public static bool SupportsStencil(RenderTexture rt){}
		public void SetBorderColor(Color color){}
		public RenderTexture(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite readWrite){}
		public RenderTexture(int width, int height, int depth, RenderTextureFormat format){}
		public RenderTexture(int width, int height, int depth){}
		public virtual int width{ get	{} set	{} }
		public virtual int height{ get	{} set	{} }
		public int depth{ get	{} set	{} }
		public bool isPowerOfTwo{ get	{} set	{} }
		public bool sRGB{ get	{} }
		public RenderTextureFormat format{ get	{} set	{} }
		public bool useMipMap{ get	{} set	{} }
		public bool generateMips{ get	{} set	{} }
		public bool isCubemap{ get	{} set	{} }
		public bool isVolume{ get	{} set	{} }
		public int volumeDepth{ get	{} set	{} }
		public int antiAliasing{ get	{} set	{} }
		public bool enableRandomWrite{ get	{} set	{} }
		public RenderBuffer colorBuffer{ get	{} }
		public RenderBuffer depthBuffer{ get	{} }
		public static RenderTexture active{ get	{} set	{} }
		public static bool enabled{ get	{} set	{} }
	}

	public sealed class	ReflectionProbe: Behaviour
	{
		private void INTERNAL_get_size(out Vector3 value){}
		private void INTERNAL_set_size(ref Vector3 value){}
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		private void INTERNAL_get_backgroundColor(out Color value){}
		private void INTERNAL_set_backgroundColor(ref Color value){}
		private void INTERNAL_get_bounds(out Bounds value){}
		public int RenderProbe(RenderTexture targetTexture){}
		public int RenderProbe(){}
		public bool IsFinishedRendering(int renderId){}
		public static bool BlendCubemap(Texture src, Texture dst, float blend, RenderTexture target){}
		public ReflectionProbe(){}
		public ReflectionProbeType type{ get	{} set	{} }
		public bool hdr{ get	{} set	{} }
		public Vector3 size{ get	{} set	{} }
		public Vector3 center{ get	{} set	{} }
		public float nearClipPlane{ get	{} set	{} }
		public float farClipPlane{ get	{} set	{} }
		public float shadowDistance{ get	{} set	{} }
		public int resolution{ get	{} set	{} }
		public int cullingMask{ get	{} set	{} }
		public ReflectionProbeClearFlags clearFlags{ get	{} set	{} }
		public Color backgroundColor{ get	{} set	{} }
		public float intensity{ get	{} set	{} }
		public bool boxProjection{ get	{} set	{} }
		public Bounds bounds{ get	{} }
		public ReflectionProbeMode mode{ get	{} set	{} }
		public int importance{ get	{} set	{} }
		public ReflectionProbeRefreshMode refreshMode{ get	{} set	{} }
		public ReflectionProbeTimeSlicingMode timeSlicingMode{ get	{} set	{} }
		public Texture bakedTexture{ get	{} set	{} }
		public Texture customBakedTexture{ get	{} set	{} }
		public Texture texture{ get	{} }
	}

	public class	GUIElement: Behaviour
	{
		public bool HitTest(Vector3 screenPosition, Camera camera){}
		public bool HitTest(Vector3 screenPosition){}
		private static bool INTERNAL_CALL_HitTest(GUIElement self, ref Vector3 screenPosition, Camera camera){}
		public Rect GetScreenRect(Camera camera){}
		public Rect GetScreenRect(){}
		public GUIElement(){}
	}

	public sealed class	GUITexture: GUIElement
	{
		private void INTERNAL_get_color(out Color value){}
		private void INTERNAL_set_color(ref Color value){}
		private void INTERNAL_get_pixelInset(out Rect value){}
		private void INTERNAL_set_pixelInset(ref Rect value){}
		public GUITexture(){}
		public Color color{ get	{} set	{} }
		public Texture texture{ get	{} set	{} }
		public Rect pixelInset{ get	{} set	{} }
		public RectOffset border{ get	{} set	{} }
	}

	public sealed class	GUILayer: Behaviour
	{
		public GUIElement HitTest(Vector3 screenPosition){}
		private static GUIElement INTERNAL_CALL_HitTest(GUILayer self, ref Vector3 screenPosition){}
		public GUILayer(){}
	}

	public sealed class	LODGroup: Component
	{
		private void INTERNAL_get_localReferencePoint(out Vector3 value){}
		private void INTERNAL_set_localReferencePoint(ref Vector3 value){}
		public void RecalculateBounds(){}
		public void SetLODS(LOD[] scriptingLODs){}
		public void ForceLOD(int index){}
		public LODGroup(){}
		public Vector3 localReferencePoint{ get	{} set	{} }
		public float size{ get	{} set	{} }
		public int lodCount{ get	{} }
		public bool enabled{ get	{} set	{} }
	}

	public sealed class	Gradient: Object
	{
		private void Init(){}
		private void Cleanup(){}
		protected virtual void Finalize(){}
		public Color Evaluate(float time){}
		private void INTERNAL_get_constantColor(out Color value){}
		private void INTERNAL_set_constantColor(ref Color value){}
		public void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys){}
		public Gradient(){}
		public GradientColorKey[] colorKeys{ get	{} set	{} }
		public GradientAlphaKey[] alphaKeys{ get	{} set	{} }
		Color constantColor{ get	{} set	{} }
		internal IntPtr m_Ptr;
	}

	public class	GUI: Object
	{
		private static int DoButtonGrid(Rect position, int selected, GUIContent[] contents, int xCount, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle){}
		private static Rect[] CalcMouseRects(Rect position, int count, int xCount, float elemWidth, float elemHeight, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle, bool addBorders){}
		private static int GetButtonGridMouseSelection(Rect[] buttonRects, Vector2 mousePos, bool findNearest){}
		public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue){}
		public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb){}
		public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue){}
		public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue, GUIStyle slider, GUIStyle thumb){}
		public static float Slider(Rect position, float value, float size, float start, float end, GUIStyle slider, GUIStyle thumb, bool horiz, int id){}
		public static float HorizontalScrollbar(Rect position, float value, float size, float leftValue, float rightValue){}
		public static float HorizontalScrollbar(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle style){}
		internal static void InternalRepaintEditorWindow(){}
		internal static bool ScrollerRepeatButton(int scrollerID, Rect rect, GUIStyle style){}
		public static float VerticalScrollbar(Rect position, float value, float size, float topValue, float bottomValue){}
		public static float VerticalScrollbar(Rect position, float value, float size, float topValue, float bottomValue, GUIStyle style){}
		private static float Scroller(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUIStyle leftButton, GUIStyle rightButton, bool horiz){}
		public static void BeginGroup(Rect position){}
		public static void BeginGroup(Rect position, string text){}
		public static void BeginGroup(Rect position, Texture image){}
		public static void BeginGroup(Rect position, GUIContent content){}
		public static void BeginGroup(Rect position, GUIStyle style){}
		public static void BeginGroup(Rect position, string text, GUIStyle style){}
		public static void BeginGroup(Rect position, Texture image, GUIStyle style){}
		public static void BeginGroup(Rect position, GUIContent content, GUIStyle style){}
		public static void EndGroup(){}
		public static void BeginClip(Rect position){}
		public static void EndClip(){}
		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect){}
		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical){}
		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar){}
		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar){}
		protected static Vector2 DoBeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background){}
		internal static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background){}
		public static void EndScrollView(){}
		public static void EndScrollView(bool handleScrollWheel){}
		internal static ScrollViewState GetTopScrollView(){}
		public static void ScrollTo(Rect position){}
		public static bool ScrollTowards(Rect position, float maxDelta){}
		public static Rect Window(int id, Rect clientRect, WindowFunction func, string text){}
		public static Rect Window(int id, Rect clientRect, WindowFunction func, Texture image){}
		public static Rect Window(int id, Rect clientRect, WindowFunction func, GUIContent content){}
		public static Rect Window(int id, Rect clientRect, WindowFunction func, string text, GUIStyle style){}
		public static Rect Window(int id, Rect clientRect, WindowFunction func, Texture image, GUIStyle style){}
		public static Rect Window(int id, Rect clientRect, WindowFunction func, GUIContent title, GUIStyle style){}
		public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, string text){}
		public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, Texture image){}
		public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, GUIContent content){}
		public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, string text, GUIStyle style){}
		public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, Texture image, GUIStyle style){}
		public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style){}
		private static Rect DoModalWindow(int id, Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style, GUISkin skin){}
		private static Rect INTERNAL_CALL_DoModalWindow(int id, ref Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style, GUISkin skin){}
		internal static void CallWindowDelegate(WindowFunction func, int id, GUISkin _skin, int forceRect, float width, float height, GUIStyle style){}
		private static Rect DoWindow(int id, Rect clientRect, WindowFunction func, GUIContent title, GUIStyle style, GUISkin skin, bool forceRectOnLayout){}
		private static Rect INTERNAL_CALL_DoWindow(int id, ref Rect clientRect, WindowFunction func, GUIContent title, GUIStyle style, GUISkin skin, bool forceRectOnLayout){}
		public static void DragWindow(Rect position){}
		private static void INTERNAL_CALL_DragWindow(ref Rect position){}
		public static void DragWindow(){}
		public static void BringWindowToFront(int windowID){}
		public static void BringWindowToBack(int windowID){}
		public static void FocusWindow(int windowID){}
		public static void UnfocusWindow(){}
		internal static void BeginWindows(int skinMode, int editorWindowInstanceID){}
		private static void Internal_BeginWindows(){}
		internal static void EndWindows(){}
		private static void Internal_EndWindows(){}
		private static void INTERNAL_get_color(out Color value){}
		private static void INTERNAL_set_color(ref Color value){}
		private static void INTERNAL_get_backgroundColor(out Color value){}
		private static void INTERNAL_set_backgroundColor(ref Color value){}
		private static void INTERNAL_get_contentColor(out Color value){}
		private static void INTERNAL_set_contentColor(ref Color value){}
		private static string Internal_GetTooltip(){}
		private static void Internal_SetTooltip(string value){}
		private static string Internal_GetMouseTooltip(){}
		public static void Label(Rect position, string text){}
		public static void Label(Rect position, Texture image){}
		public static void Label(Rect position, GUIContent content){}
		public static void Label(Rect position, string text, GUIStyle style){}
		public static void Label(Rect position, Texture image, GUIStyle style){}
		public static void Label(Rect position, GUIContent content, GUIStyle style){}
		private static void DoLabel(Rect position, GUIContent content, IntPtr style){}
		private static void INTERNAL_CALL_DoLabel(ref Rect position, GUIContent content, IntPtr style){}
		private static void InitializeGUIClipTexture(){}
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend){}
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode){}
		public static void DrawTexture(Rect position, Texture image){}
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect){}
		internal static bool CalculateScaledTextureRects(Rect position, ScaleMode scaleMode, float imageAspect, ref Rect outScreenRect, ref Rect outSourceRect){}
		public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords){}
		public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords, bool alphaBlend){}
		public static void Box(Rect position, string text){}
		public static void Box(Rect position, Texture image){}
		public static void Box(Rect position, GUIContent content){}
		public static void Box(Rect position, string text, GUIStyle style){}
		public static void Box(Rect position, Texture image, GUIStyle style){}
		public static void Box(Rect position, GUIContent content, GUIStyle style){}
		public static bool Button(Rect position, string text){}
		public static bool Button(Rect position, Texture image){}
		public static bool Button(Rect position, GUIContent content){}
		public static bool Button(Rect position, string text, GUIStyle style){}
		public static bool Button(Rect position, Texture image, GUIStyle style){}
		public static bool Button(Rect position, GUIContent content, GUIStyle style){}
		private static bool DoButton(Rect position, GUIContent content, IntPtr style){}
		private static bool INTERNAL_CALL_DoButton(ref Rect position, GUIContent content, IntPtr style){}
		public static bool RepeatButton(Rect position, string text){}
		public static bool RepeatButton(Rect position, Texture image){}
		public static bool RepeatButton(Rect position, GUIContent content){}
		public static bool RepeatButton(Rect position, string text, GUIStyle style){}
		public static bool RepeatButton(Rect position, Texture image, GUIStyle style){}
		public static bool RepeatButton(Rect position, GUIContent content, GUIStyle style){}
		private static bool DoRepeatButton(Rect position, GUIContent content, GUIStyle style, FocusType focusType){}
		public static string TextField(Rect position, string text){}
		public static string TextField(Rect position, string text, int maxLength){}
		public static string TextField(Rect position, string text, GUIStyle style){}
		public static string TextField(Rect position, string text, int maxLength, GUIStyle style){}
		public static string PasswordField(Rect position, string password, char maskChar){}
		public static string PasswordField(Rect position, string password, char maskChar, int maxLength){}
		public static string PasswordField(Rect position, string password, char maskChar, GUIStyle style){}
		public static string PasswordField(Rect position, string password, char maskChar, int maxLength, GUIStyle style){}
		internal static string PasswordFieldGetStrToShow(string password, char maskChar){}
		public static string TextArea(Rect position, string text){}
		public static string TextArea(Rect position, string text, int maxLength){}
		public static string TextArea(Rect position, string text, GUIStyle style){}
		public static string TextArea(Rect position, string text, int maxLength, GUIStyle style){}
		private static string TextArea(Rect position, GUIContent content, int maxLength, GUIStyle style){}
		internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style){}
		private static void HandleTextFieldEventForDesktop(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, TextEditor editor){}
		public static void SetNextControlName(string name){}
		public static string GetNameOfFocusedControl(){}
		public static void FocusControl(string name){}
		public static bool Toggle(Rect position, bool value, string text){}
		public static bool Toggle(Rect position, bool value, Texture image){}
		public static bool Toggle(Rect position, bool value, GUIContent content){}
		public static bool Toggle(Rect position, bool value, string text, GUIStyle style){}
		public static bool Toggle(Rect position, bool value, Texture image, GUIStyle style){}
		public static bool Toggle(Rect position, bool value, GUIContent content, GUIStyle style){}
		public static bool Toggle(Rect position, int id, bool value, GUIContent content, GUIStyle style){}
		internal static bool DoToggle(Rect position, int id, bool value, GUIContent content, IntPtr style){}
		private static bool INTERNAL_CALL_DoToggle(ref Rect position, int id, bool value, GUIContent content, IntPtr style){}
		public static int Toolbar(Rect position, int selected, String[] texts){}
		public static int Toolbar(Rect position, int selected, Texture[] images){}
		public static int Toolbar(Rect position, int selected, GUIContent[] content){}
		public static int Toolbar(Rect position, int selected, String[] texts, GUIStyle style){}
		public static int Toolbar(Rect position, int selected, Texture[] images, GUIStyle style){}
		public static int Toolbar(Rect position, int selected, GUIContent[] contents, GUIStyle style){}
		public static int SelectionGrid(Rect position, int selected, String[] texts, int xCount){}
		public static int SelectionGrid(Rect position, int selected, Texture[] images, int xCount){}
		public static int SelectionGrid(Rect position, int selected, GUIContent[] content, int xCount){}
		public static int SelectionGrid(Rect position, int selected, String[] texts, int xCount, GUIStyle style){}
		public static int SelectionGrid(Rect position, int selected, Texture[] images, int xCount, GUIStyle style){}
		public static int SelectionGrid(Rect position, int selected, GUIContent[] contents, int xCount, GUIStyle style){}
		internal static void FindStyles(ref GUIStyle style, out GUIStyle firstStyle, out GUIStyle midStyle, out GUIStyle lastStyle, string first, string mid, string last){}
		internal static int CalcTotalHorizSpacing(int xCount, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle){}
		public GUI(){}
		private static GUI(){}
		DateTime nextScrollStepTime{ get	{} set	{} }
		int scrollTroughSide{ get	{} set	{} }
		public static GUISkin skin{ get	{} set	{} }
		public static Color color{ get	{} set	{} }
		public static Color backgroundColor{ get	{} set	{} }
		public static Color contentColor{ get	{} set	{} }
		public static bool changed{ get	{} set	{} }
		public static bool enabled{ get	{} set	{} }
		public static Matrix4x4 matrix{ get	{} set	{} }
		public static string tooltip{ get	{} set	{} }
		string mouseTooltip{ get	{} }
		Rect tooltipRect{ get	{} set	{} }
		public static int depth{ get	{} set	{} }
		Material blendMaterial{ get	{} }
		Material blitMaterial{ get	{} }
		bool usePageScrollbars{ get	{} }
		private static float scrollStepSize;
		private static int scrollControlID;
		private static GUISkin s_Skin;
		internal static Rect s_ToolTipRect;
		private static int boxHash;
		private static int repeatButtonHash;
		private static int toggleHash;
		private static int buttonGridHash;
		private static int sliderHash;
		private static int beginGroupHash;
		private static int scrollviewHash;
		private static GenericStack s_ScrollViewStates;
		private static DateTime <nextScrollStepTime>k__BackingField;
		private static int <scrollTroughSide>k__BackingField;
	}

	public sealed class	GUILayout: Object
	{
		public static void Label(Texture image, GUILayoutOption[] options){}
		public static void Label(string text, GUILayoutOption[] options){}
		public static void Label(GUIContent content, GUILayoutOption[] options){}
		public static void Label(Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static void Label(string text, GUIStyle style, GUILayoutOption[] options){}
		public static void Label(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		private static void DoLabel(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static void Box(Texture image, GUILayoutOption[] options){}
		public static void Box(string text, GUILayoutOption[] options){}
		public static void Box(GUIContent content, GUILayoutOption[] options){}
		public static void Box(Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static void Box(string text, GUIStyle style, GUILayoutOption[] options){}
		public static void Box(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		private static void DoBox(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static bool Button(Texture image, GUILayoutOption[] options){}
		public static bool Button(string text, GUILayoutOption[] options){}
		public static bool Button(GUIContent content, GUILayoutOption[] options){}
		public static bool Button(Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static bool Button(string text, GUIStyle style, GUILayoutOption[] options){}
		public static bool Button(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		private static bool DoButton(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static bool RepeatButton(Texture image, GUILayoutOption[] options){}
		public static bool RepeatButton(string text, GUILayoutOption[] options){}
		public static bool RepeatButton(GUIContent content, GUILayoutOption[] options){}
		public static bool RepeatButton(Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static bool RepeatButton(string text, GUIStyle style, GUILayoutOption[] options){}
		public static bool RepeatButton(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		private static bool DoRepeatButton(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static string TextField(string text, GUILayoutOption[] options){}
		public static string TextField(string text, int maxLength, GUILayoutOption[] options){}
		public static string TextField(string text, GUIStyle style, GUILayoutOption[] options){}
		public static string TextField(string text, int maxLength, GUIStyle style, GUILayoutOption[] options){}
		public static string PasswordField(string password, char maskChar, GUILayoutOption[] options){}
		public static string PasswordField(string password, char maskChar, int maxLength, GUILayoutOption[] options){}
		public static string PasswordField(string password, char maskChar, GUIStyle style, GUILayoutOption[] options){}
		public static string PasswordField(string password, char maskChar, int maxLength, GUIStyle style, GUILayoutOption[] options){}
		public static string TextArea(string text, GUILayoutOption[] options){}
		public static string TextArea(string text, int maxLength, GUILayoutOption[] options){}
		public static string TextArea(string text, GUIStyle style, GUILayoutOption[] options){}
		public static string TextArea(string text, int maxLength, GUIStyle style, GUILayoutOption[] options){}
		private static string DoTextField(string text, int maxLength, bool multiline, GUIStyle style, GUILayoutOption[] options){}
		public static bool Toggle(bool value, Texture image, GUILayoutOption[] options){}
		public static bool Toggle(bool value, string text, GUILayoutOption[] options){}
		public static bool Toggle(bool value, GUIContent content, GUILayoutOption[] options){}
		public static bool Toggle(bool value, Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static bool Toggle(bool value, string text, GUIStyle style, GUILayoutOption[] options){}
		public static bool Toggle(bool value, GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		private static bool DoToggle(bool value, GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static int Toolbar(int selected, String[] texts, GUILayoutOption[] options){}
		public static int Toolbar(int selected, Texture[] images, GUILayoutOption[] options){}
		public static int Toolbar(int selected, GUIContent[] content, GUILayoutOption[] options){}
		public static int Toolbar(int selected, String[] texts, GUIStyle style, GUILayoutOption[] options){}
		public static int Toolbar(int selected, Texture[] images, GUIStyle style, GUILayoutOption[] options){}
		public static int Toolbar(int selected, GUIContent[] contents, GUIStyle style, GUILayoutOption[] options){}
		public static int SelectionGrid(int selected, String[] texts, int xCount, GUILayoutOption[] options){}
		public static int SelectionGrid(int selected, Texture[] images, int xCount, GUILayoutOption[] options){}
		public static int SelectionGrid(int selected, GUIContent[] content, int xCount, GUILayoutOption[] options){}
		public static int SelectionGrid(int selected, String[] texts, int xCount, GUIStyle style, GUILayoutOption[] options){}
		public static int SelectionGrid(int selected, Texture[] images, int xCount, GUIStyle style, GUILayoutOption[] options){}
		public static int SelectionGrid(int selected, GUIContent[] contents, int xCount, GUIStyle style, GUILayoutOption[] options){}
		public static float HorizontalSlider(float value, float leftValue, float rightValue, GUILayoutOption[] options){}
		public static float HorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUILayoutOption[] options){}
		private static float DoHorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUILayoutOption[] options){}
		public static float VerticalSlider(float value, float leftValue, float rightValue, GUILayoutOption[] options){}
		public static float VerticalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUILayoutOption[] options){}
		private static float DoVerticalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUILayoutOption[] options){}
		public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, GUILayoutOption[] options){}
		public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, GUIStyle style, GUILayoutOption[] options){}
		public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, GUILayoutOption[] options){}
		public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, GUIStyle style, GUILayoutOption[] options){}
		public static void Space(float pixels){}
		public static void FlexibleSpace(){}
		public static void BeginHorizontal(GUILayoutOption[] options){}
		public static void BeginHorizontal(GUIStyle style, GUILayoutOption[] options){}
		public static void BeginHorizontal(string text, GUIStyle style, GUILayoutOption[] options){}
		public static void BeginHorizontal(Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static void BeginHorizontal(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static void EndHorizontal(){}
		public static void BeginVertical(GUILayoutOption[] options){}
		public static void BeginVertical(GUIStyle style, GUILayoutOption[] options){}
		public static void BeginVertical(string text, GUIStyle style, GUILayoutOption[] options){}
		public static void BeginVertical(Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static void BeginVertical(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static void EndVertical(){}
		public static void BeginArea(Rect screenRect){}
		public static void BeginArea(Rect screenRect, string text){}
		public static void BeginArea(Rect screenRect, Texture image){}
		public static void BeginArea(Rect screenRect, GUIContent content){}
		public static void BeginArea(Rect screenRect, GUIStyle style){}
		public static void BeginArea(Rect screenRect, string text, GUIStyle style){}
		public static void BeginArea(Rect screenRect, Texture image, GUIStyle style){}
		public static void BeginArea(Rect screenRect, GUIContent content, GUIStyle style){}
		public static void EndArea(){}
		public static Vector2 BeginScrollView(Vector2 scrollPosition, GUILayoutOption[] options){}
		public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUILayoutOption[] options){}
		public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUILayoutOption[] options){}
		public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style){}
		public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, GUILayoutOption[] options){}
		public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUILayoutOption[] options){}
		public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, GUILayoutOption[] options){}
		public static void EndScrollView(){}
		internal static void EndScrollView(bool handleScrollWheel){}
		public static Rect Window(int id, Rect screenRect, WindowFunction func, string text, GUILayoutOption[] options){}
		public static Rect Window(int id, Rect screenRect, WindowFunction func, Texture image, GUILayoutOption[] options){}
		public static Rect Window(int id, Rect screenRect, WindowFunction func, GUIContent content, GUILayoutOption[] options){}
		public static Rect Window(int id, Rect screenRect, WindowFunction func, string text, GUIStyle style, GUILayoutOption[] options){}
		public static Rect Window(int id, Rect screenRect, WindowFunction func, Texture image, GUIStyle style, GUILayoutOption[] options){}
		public static Rect Window(int id, Rect screenRect, WindowFunction func, GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		private static Rect DoWindow(int id, Rect screenRect, WindowFunction func, GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static GUILayoutOption Width(float width){}
		public static GUILayoutOption MinWidth(float minWidth){}
		public static GUILayoutOption MaxWidth(float maxWidth){}
		public static GUILayoutOption Height(float height){}
		public static GUILayoutOption MinHeight(float minHeight){}
		public static GUILayoutOption MaxHeight(float maxHeight){}
		public static GUILayoutOption ExpandWidth(bool expand){}
		public static GUILayoutOption ExpandHeight(bool expand){}
		public GUILayout(){}
	}

	public class	GUILayoutUtility: Object
	{
		internal static LayoutCache SelectIDList(int instanceID, bool isWindow){}
		internal static void Begin(int instanceID){}
		internal static void BeginWindow(int windowID, GUIStyle style, GUILayoutOption[] options){}
		public static void BeginGroup(string GroupName){}
		public static void EndGroup(string groupName){}
		internal static void Layout(){}
		internal static void LayoutFromEditorWindow(){}
		internal static float LayoutFromInspector(float width){}
		internal static void LayoutFreeGroup(GUILayoutGroup toplevel){}
		private static void LayoutSingleGroup(GUILayoutGroup i){}
		private static Rect Internal_GetWindowRect(int windowID){}
		private static void Internal_MoveWindow(int windowID, Rect r){}
		private static void INTERNAL_CALL_Internal_MoveWindow(int windowID, ref Rect r){}
		internal static Rect GetWindowsBounds(){}
		private static GUILayoutGroup CreateGUILayoutGroupInstanceOfType(Type LayoutType){}
		internal static GUILayoutGroup BeginLayoutGroup(GUIStyle style, GUILayoutOption[] options, Type LayoutType){}
		internal static void EndLayoutGroup(){}
		internal static GUILayoutGroup BeginLayoutArea(GUIStyle style, Type LayoutType){}
		internal static GUILayoutGroup DoBeginLayoutArea(GUIStyle style, Type LayoutType){}
		public static Rect GetRect(GUIContent content, GUIStyle style){}
		public static Rect GetRect(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		private static Rect DoGetRect(GUIContent content, GUIStyle style, GUILayoutOption[] options){}
		public static Rect GetRect(float width, float height){}
		public static Rect GetRect(float width, float height, GUIStyle style){}
		public static Rect GetRect(float width, float height, GUILayoutOption[] options){}
		public static Rect GetRect(float width, float height, GUIStyle style, GUILayoutOption[] options){}
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight){}
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style){}
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUILayoutOption[] options){}
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style, GUILayoutOption[] options){}
		private static Rect DoGetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style, GUILayoutOption[] options){}
		public static Rect GetLastRect(){}
		public static Rect GetAspectRect(float aspect){}
		public static Rect GetAspectRect(float aspect, GUIStyle style){}
		public static Rect GetAspectRect(float aspect, GUILayoutOption[] options){}
		public static Rect GetAspectRect(float aspect, GUIStyle style, GUILayoutOption[] options){}
		private static Rect DoGetAspectRect(float aspect, GUIStyle style, GUILayoutOption[] options){}
		public GUILayoutUtility(){}
		private static GUILayoutUtility(){}
		GUILayoutGroup topLevel{ get	{} }
		GUIStyle spaceStyle{ get	{} }
		private static Dictionary<Int32, LayoutCache> storedLayouts;
		private static Dictionary<Int32, LayoutCache> storedWindows;
		internal static LayoutCache current;
		private static Rect kDummyRect;
		private static GUIStyle s_SpaceStyle;
	}

	public sealed class	GUILayoutOption: Object
	{
		internal GUILayoutOption(Type type, System.Object value){}
		internal Type type;
		internal System.Object value;
	}

	public sealed class	ExitGUIException: Exception, ISerializable, _Exception
	{
		public ExitGUIException(){}
	}

	public class	GUIUtility: Object
	{
		public static int GetControlID(FocusType focus){}
		public static int GetControlID(int hint, FocusType focus){}
		public static int GetControlID(GUIContent contents, FocusType focus){}
		public static int GetControlID(FocusType focus, Rect position){}
		public static int GetControlID(int hint, FocusType focus, Rect position){}
		public static int GetControlID(GUIContent contents, FocusType focus, Rect position){}
		private static int Internal_GetNextControlID2(int hint, FocusType focusType, Rect rect){}
		private static int INTERNAL_CALL_Internal_GetNextControlID2(int hint, FocusType focusType, ref Rect rect){}
		public static System.Object GetStateObject(Type t, int controlID){}
		public static System.Object QueryStateObject(Type t, int controlID){}
		internal static int GetPermanentControlID(){}
		private static int Internal_GetHotControl(){}
		private static void Internal_SetHotControl(int value){}
		internal static void UpdateUndoName(){}
		public static void ExitGUI(){}
		internal static void SetDidGUIWindowsEatLastEvent(bool value){}
		internal static GUISkin GetDefaultSkin(){}
		private static GUISkin Internal_GetDefaultSkin(int skinMode){}
		private static System.Object Internal_GetBuiltinSkin(int skin){}
		internal static GUISkin GetBuiltinSkin(int skin){}
		internal static void BeginGUI(int skinMode, int instanceID, int useGUILayout){}
		private static void Internal_ExitGUI(){}
		internal static void EndGUI(int layoutType){}
		internal static bool EndGUIFromException(Exception exception){}
		internal static void CheckOnGUI(){}
		internal static int Internal_GetGUIDepth(){}
		public static Vector2 GUIToScreenPoint(Vector2 guiPoint){}
		internal static Rect GUIToScreenRect(Rect guiRect){}
		public static Vector2 ScreenToGUIPoint(Vector2 screenPoint){}
		public static Rect ScreenToGUIRect(Rect screenRect){}
		public static void RotateAroundPivot(float angle, Vector2 pivotPoint){}
		public static void ScaleAroundPivot(Vector2 scale, Vector2 pivotPoint){}
		public GUIUtility(){}
		private static GUIUtility(){}
		public static int hotControl{ get	{} set	{} }
		public static int keyboardControl{ get	{} set	{} }
		string systemCopyBuffer{ get	{} set	{} }
		bool mouseUsed{ get	{} set	{} }
		public static bool hasModalWindow{ get	{} }
		bool textFieldInput{ get	{} set	{} }
		internal static int s_SkinMode;
		internal static int s_OriginalID;
		internal static Vector2 s_EditorScreenPointOffset;
		internal static bool s_HasKeyboardFocus;
	}

	public sealed class	GUISettings: Object
	{
		private static float Internal_GetCursorFlashSpeed(){}
		public GUISettings(){}
		public bool doubleClickSelectsWord{ get	{} set	{} }
		public bool tripleClickSelectsLine{ get	{} set	{} }
		public Color cursorColor{ get	{} set	{} }
		public float cursorFlashSpeed{ get	{} set	{} }
		public Color selectionColor{ get	{} set	{} }
		private bool m_DoubleClickSelectsWord;
		private bool m_TripleClickSelectsLine;
		private Color m_CursorColor;
		private float m_CursorFlashSpeed;
		private Color m_SelectionColor;
	}

	public sealed class	GUISkin: ScriptableObject
	{
		internal void OnEnable(){}
		internal void Apply(){}
		private void BuildStyleCache(){}
		public GUIStyle GetStyle(string styleName){}
		public GUIStyle FindStyle(string styleName){}
		internal void MakeCurrent(){}
		public IEnumerator GetEnumerator(){}
		public GUISkin(){}
		public Font font{ get	{} set	{} }
		public GUIStyle box{ get	{} set	{} }
		public GUIStyle label{ get	{} set	{} }
		public GUIStyle textField{ get	{} set	{} }
		public GUIStyle textArea{ get	{} set	{} }
		public GUIStyle button{ get	{} set	{} }
		public GUIStyle toggle{ get	{} set	{} }
		public GUIStyle window{ get	{} set	{} }
		public GUIStyle horizontalSlider{ get	{} set	{} }
		public GUIStyle horizontalSliderThumb{ get	{} set	{} }
		public GUIStyle verticalSlider{ get	{} set	{} }
		public GUIStyle verticalSliderThumb{ get	{} set	{} }
		public GUIStyle horizontalScrollbar{ get	{} set	{} }
		public GUIStyle horizontalScrollbarThumb{ get	{} set	{} }
		public GUIStyle horizontalScrollbarLeftButton{ get	{} set	{} }
		public GUIStyle horizontalScrollbarRightButton{ get	{} set	{} }
		public GUIStyle verticalScrollbar{ get	{} set	{} }
		public GUIStyle verticalScrollbarThumb{ get	{} set	{} }
		public GUIStyle verticalScrollbarUpButton{ get	{} set	{} }
		public GUIStyle verticalScrollbarDownButton{ get	{} set	{} }
		public GUIStyle scrollView{ get	{} set	{} }
		public GUIStyle[] customStyles{ get	{} set	{} }
		public GUISettings settings{ get	{} }
		GUIStyle error{ get	{} }
		private Font m_Font;
		private GUIStyle m_box;
		private GUIStyle m_button;
		private GUIStyle m_toggle;
		private GUIStyle m_label;
		private GUIStyle m_textField;
		private GUIStyle m_textArea;
		private GUIStyle m_window;
		private GUIStyle m_horizontalSlider;
		private GUIStyle m_horizontalSliderThumb;
		private GUIStyle m_verticalSlider;
		private GUIStyle m_verticalSliderThumb;
		private GUIStyle m_horizontalScrollbar;
		private GUIStyle m_horizontalScrollbarThumb;
		private GUIStyle m_horizontalScrollbarLeftButton;
		private GUIStyle m_horizontalScrollbarRightButton;
		private GUIStyle m_verticalScrollbar;
		private GUIStyle m_verticalScrollbarThumb;
		private GUIStyle m_verticalScrollbarUpButton;
		private GUIStyle m_verticalScrollbarDownButton;
		private GUIStyle m_ScrollView;
		internal GUIStyle[] m_CustomStyles;
		private GUISettings m_Settings;
		private Dictionary<String, GUIStyle> styles;
		internal static GUIStyle ms_Error;
		internal static SkinChangedDelegate m_SkinChanged;
		internal static GUISkin current;
	}

	public sealed class	GUIContent: Object
	{
		internal static GUIContent Temp(string t){}
		internal static GUIContent Temp(string t, string tooltip){}
		internal static GUIContent Temp(Texture i){}
		internal static GUIContent Temp(string t, Texture i){}
		internal static void ClearStaticCache(){}
		internal static GUIContent[] Temp(String[] texts){}
		internal static GUIContent[] Temp(Texture[] images){}
		public GUIContent(){}
		public GUIContent(string text){}
		public GUIContent(Texture image){}
		public GUIContent(string text, Texture image){}
		public GUIContent(string text, string tooltip){}
		public GUIContent(Texture image, string tooltip){}
		public GUIContent(string text, Texture image, string tooltip){}
		public GUIContent(GUIContent src){}
		private static GUIContent(){}
		public string text{ get	{} set	{} }
		public Texture image{ get	{} set	{} }
		public string tooltip{ get	{} set	{} }
		int hash{ get	{} }
		private string m_Text;
		private Texture m_Image;
		private string m_Tooltip;
		public static GUIContent none;
		private static GUIContent s_Text;
		private static GUIContent s_Image;
		private static GUIContent s_TextImage;
	}

	public sealed class	GUIStyleState: Object
	{
		protected virtual void Finalize(){}
		private void Init(){}
		private void Cleanup(){}
		private void SetBackgroundInternal(Texture2D value){}
		private Texture2D GetBackgroundInternal(){}
		private void INTERNAL_get_textColor(out Color value){}
		private void INTERNAL_set_textColor(ref Color value){}
		public GUIStyleState(){}
		internal GUIStyleState(GUIStyle sourceStyle, IntPtr source){}
		public Texture2D background{ get	{} set	{} }
		public Color textColor{ get	{} set	{} }
		internal IntPtr m_Ptr;
		private GUIStyle m_SourceStyle;
		private Texture2D m_Background;
	}

	public sealed class	RectOffset: Object
	{
		protected virtual void Finalize(){}
		private void Init(){}
		private void Cleanup(){}
		public Rect Add(Rect rect){}
		private static Rect INTERNAL_CALL_Add(RectOffset self, ref Rect rect){}
		public Rect Remove(Rect rect){}
		private static Rect INTERNAL_CALL_Remove(RectOffset self, ref Rect rect){}
		public virtual string ToString(){}
		public RectOffset(){}
		internal RectOffset(GUIStyle sourceStyle, IntPtr source){}
		public RectOffset(int left, int right, int top, int bottom){}
		public int left{ get	{} set	{} }
		public int right{ get	{} set	{} }
		public int top{ get	{} set	{} }
		public int bottom{ get	{} set	{} }
		public int horizontal{ get	{} }
		public int vertical{ get	{} }
		internal IntPtr m_Ptr;
		private GUIStyle m_SourceStyle;
	}

	public sealed class	GUIStyle: Object
	{
		internal static int Internal_GetNumCharactersThatFitWithinWidth(IntPtr target, string text, float width){}
		public Vector2 CalcSize(GUIContent content){}
		internal static void Internal_CalcSize(IntPtr target, GUIContent content, out Vector2 ret){}
		public Vector2 CalcScreenSize(Vector2 contentSize){}
		public float CalcHeight(GUIContent content, float width){}
		private static float Internal_CalcHeight(IntPtr target, GUIContent content, float width){}
		public void CalcMinMaxWidth(GUIContent content, out float minWidth, out float maxWidth){}
		private static void Internal_CalcMinMaxWidth(IntPtr target, GUIContent content, out float minWidth, out float maxWidth){}
		public virtual string ToString(){}
		protected virtual void Finalize(){}
		internal void InternalOnAfterDeserialize(){}
		private void Init(){}
		private void InitCopy(GUIStyle other){}
		private void Cleanup(){}
		private IntPtr GetStyleStatePtr(int idx){}
		private void AssignStyleState(int idx, IntPtr srcStyleState){}
		private IntPtr GetRectOffsetPtr(int idx){}
		private void AssignRectOffset(int idx, IntPtr srcRectOffset){}
		private void INTERNAL_get_contentOffset(out Vector2 value){}
		private void INTERNAL_set_contentOffset(ref Vector2 value){}
		private void INTERNAL_get_Internal_clipOffset(out Vector2 value){}
		private void INTERNAL_set_Internal_clipOffset(ref Vector2 value){}
		private static float Internal_GetLineHeight(IntPtr target){}
		private void SetFontInternal(Font value){}
		private Font GetFontInternal(){}
		private static void Internal_Draw(IntPtr target, Rect position, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus){}
		private static void Internal_Draw(GUIContent content, ref Internal_DrawArguments arguments){}
		public void Draw(Rect position, bool isHover, bool isActive, bool on, bool hasKeyboardFocus){}
		public void Draw(Rect position, string text, bool isHover, bool isActive, bool on, bool hasKeyboardFocus){}
		public void Draw(Rect position, Texture image, bool isHover, bool isActive, bool on, bool hasKeyboardFocus){}
		public void Draw(Rect position, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus){}
		public void Draw(Rect position, GUIContent content, int controlID){}
		public void Draw(Rect position, GUIContent content, int controlID, bool on){}
		private static void Internal_Draw2(IntPtr style, Rect position, GUIContent content, int controlID, bool on){}
		private static void INTERNAL_CALL_Internal_Draw2(IntPtr style, ref Rect position, GUIContent content, int controlID, bool on){}
		internal void DrawPrefixLabel(Rect position, GUIContent content, int controlID){}
		private static void Internal_DrawPrefixLabel(IntPtr style, Rect position, GUIContent content, int controlID, bool on){}
		private static void INTERNAL_CALL_Internal_DrawPrefixLabel(IntPtr style, ref Rect position, GUIContent content, int controlID, bool on){}
		private static float Internal_GetCursorFlashOffset(){}
		private static void Internal_DrawCursor(IntPtr target, Rect position, GUIContent content, int pos, Color cursorColor){}
		private static void INTERNAL_CALL_Internal_DrawCursor(IntPtr target, ref Rect position, GUIContent content, int pos, ref Color cursorColor){}
		public void DrawCursor(Rect position, GUIContent content, int controlID, int Character){}
		private static void Internal_DrawWithTextSelection(GUIContent content, ref Internal_DrawWithTextSelectionArguments arguments){}
		internal void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter, bool drawSelectionAsComposition){}
		public void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter){}
		internal static void SetDefaultFont(Font font){}
		public Vector2 GetCursorPixelPosition(Rect position, GUIContent content, int cursorStringIndex){}
		internal static void Internal_GetCursorPixelPosition(IntPtr target, Rect position, GUIContent content, int cursorStringIndex, out Vector2 ret){}
		private static void INTERNAL_CALL_Internal_GetCursorPixelPosition(IntPtr target, ref Rect position, GUIContent content, int cursorStringIndex, out Vector2 ret){}
		public int GetCursorStringIndex(Rect position, GUIContent content, Vector2 cursorPixelPosition){}
		internal static int Internal_GetCursorStringIndex(IntPtr target, Rect position, GUIContent content, Vector2 cursorPixelPosition){}
		private static int INTERNAL_CALL_Internal_GetCursorStringIndex(IntPtr target, ref Rect position, GUIContent content, ref Vector2 cursorPixelPosition){}
		internal int GetNumCharactersThatFitWithinWidth(string text, float width){}
		public GUIStyle(){}
		public GUIStyle(GUIStyle other){}
		private static GUIStyle(){}
		public string name{ get	{} set	{} }
		public GUIStyleState normal{ get	{} set	{} }
		public GUIStyleState hover{ get	{} set	{} }
		public GUIStyleState active{ get	{} set	{} }
		public GUIStyleState onNormal{ get	{} set	{} }
		public GUIStyleState onHover{ get	{} set	{} }
		public GUIStyleState onActive{ get	{} set	{} }
		public GUIStyleState focused{ get	{} set	{} }
		public GUIStyleState onFocused{ get	{} set	{} }
		public RectOffset border{ get	{} set	{} }
		public RectOffset margin{ get	{} set	{} }
		public RectOffset padding{ get	{} set	{} }
		public RectOffset overflow{ get	{} set	{} }
		public ImagePosition imagePosition{ get	{} set	{} }
		public TextAnchor alignment{ get	{} set	{} }
		public bool wordWrap{ get	{} set	{} }
		public TextClipping clipping{ get	{} set	{} }
		public Vector2 contentOffset{ get	{} set	{} }
		public Vector2 clipOffset{ get	{} set	{} }
		Vector2 Internal_clipOffset{ get	{} set	{} }
		public float fixedWidth{ get	{} set	{} }
		public float fixedHeight{ get	{} set	{} }
		public bool stretchWidth{ get	{} set	{} }
		public bool stretchHeight{ get	{} set	{} }
		public Font font{ get	{} set	{} }
		public int fontSize{ get	{} set	{} }
		public FontStyle fontStyle{ get	{} set	{} }
		public bool richText{ get	{} set	{} }
		public float lineHeight{ get	{} }
		public static GUIStyle none{ get	{} }
		public bool isHeightDependantOnWidth{ get	{} }
		internal IntPtr m_Ptr;
		private GUIStyleState m_Normal;
		private GUIStyleState m_Hover;
		private GUIStyleState m_Active;
		private GUIStyleState m_Focused;
		private GUIStyleState m_OnNormal;
		private GUIStyleState m_OnHover;
		private GUIStyleState m_OnActive;
		private GUIStyleState m_OnFocused;
		private RectOffset m_Border;
		private RectOffset m_Padding;
		private RectOffset m_Margin;
		private RectOffset m_Overflow;
		private Font m_FontInternal;
		internal static bool showKeyboardFocus;
		private static GUIStyle s_None;
	}

	public sealed class	Handheld: Object
	{
		public static bool PlayFullScreenMovie(string path, Color bgColor, FullScreenMovieControlMode controlMode, FullScreenMovieScalingMode scalingMode){}
		public static bool PlayFullScreenMovie(string path, Color bgColor, FullScreenMovieControlMode controlMode){}
		public static bool PlayFullScreenMovie(string path, Color bgColor){}
		public static bool PlayFullScreenMovie(string path){}
		private static bool INTERNAL_CALL_PlayFullScreenMovie(string path, ref Color bgColor, FullScreenMovieControlMode controlMode, FullScreenMovieScalingMode scalingMode){}
		public static void Vibrate(){}
		internal static void SetActivityIndicatorStyleImpl(int style){}
		public static void SetActivityIndicatorStyle(ActivityIndicatorStyle style){}
		public static void SetActivityIndicatorStyle(AndroidActivityIndicatorStyle style){}
		public static int GetActivityIndicatorStyle(){}
		public static void StartActivityIndicator(){}
		public static void StopActivityIndicator(){}
		public static void ClearShaderCache(){}
		public Handheld(){}
		public static bool use32BitDisplayBuffer{ get	{} set	{} }
	}

	public sealed class	TouchScreenKeyboard: Object
	{
		private void Destroy(){}
		protected virtual void Finalize(){}
		private void TouchScreenKeyboard_InternalConstructorHelper(ref TouchScreenKeyboard_InternalConstructorHelperArguments arguments, string text, string textPlaceholder){}
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert){}
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure){}
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline){}
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection){}
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType){}
		public static TouchScreenKeyboard Open(string text){}
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder){}
		public TouchScreenKeyboard(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder){}
		public static bool isSupported{ get	{} }
		public string text{ get	{} set	{} }
		public static bool hideInput{ get	{} set	{} }
		public bool active{ get	{} set	{} }
		public bool done{ get	{} }
		public bool wasCanceled{ get	{} }
		public static Rect area{ get	{} }
		public static bool visible{ get	{} }
		internal IntPtr m_Ptr;
	}

	public sealed class	Event: Object
	{
		private void Init(){}
		protected virtual void Finalize(){}
		private void Cleanup(){}
		private void InitCopy(Event other){}
		private void InitPtr(IntPtr ptr){}
		public EventType GetTypeForControl(int controlID){}
		private void Internal_SetMousePosition(Vector2 value){}
		private static void INTERNAL_CALL_Internal_SetMousePosition(Event self, ref Vector2 value){}
		private void Internal_GetMousePosition(out Vector2 value){}
		private void Internal_SetMouseDelta(Vector2 value){}
		private static void INTERNAL_CALL_Internal_SetMouseDelta(Event self, ref Vector2 value){}
		private void Internal_GetMouseDelta(out Vector2 value){}
		private static void Internal_SetNativeEvent(IntPtr ptr){}
		private static void Internal_MakeMasterEventCurrent(){}
		public void Use(){}
		public static bool PopEvent(Event outEvent){}
		public static int GetEventCount(){}
		public static Event KeyboardEvent(string key){}
		public virtual int GetHashCode(){}
		public virtual bool Equals(System.Object obj){}
		public virtual string ToString(){}
		public Event(){}
		public Event(Event other){}
		private Event(IntPtr ptr){}
		public EventType rawType{ get	{} }
		public EventType type{ get	{} set	{} }
		public Vector2 mousePosition{ get	{} set	{} }
		public Vector2 delta{ get	{} set	{} }
		public Ray mouseRay{ get	{} set	{} }
		public int button{ get	{} set	{} }
		public EventModifiers modifiers{ get	{} set	{} }
		public float pressure{ get	{} set	{} }
		public int clickCount{ get	{} set	{} }
		public char character{ get	{} set	{} }
		public string commandName{ get	{} set	{} }
		public KeyCode keyCode{ get	{} set	{} }
		public bool shift{ get	{} set	{} }
		public bool control{ get	{} set	{} }
		public bool alt{ get	{} set	{} }
		public bool command{ get	{} set	{} }
		public bool capsLock{ get	{} set	{} }
		public bool numeric{ get	{} set	{} }
		public bool functionKey{ get	{} }
		public static Event current{ get	{} set	{} }
		public bool isKey{ get	{} }
		public bool isMouse{ get	{} }
		internal IntPtr m_Ptr;
		private static Event s_Current;
		private static Event s_MasterEvent;
		private static Dictionary<String, Int32> <>f__switch$map0;
	}

	public sealed class	Gizmos: Object
	{
		public static void DrawRay(Ray r){}
		public static void DrawRay(Vector3 from, Vector3 direction){}
		public static void DrawLine(Vector3 from, Vector3 to){}
		private static void INTERNAL_CALL_DrawLine(ref Vector3 from, ref Vector3 to){}
		public static void DrawWireSphere(Vector3 center, float radius){}
		private static void INTERNAL_CALL_DrawWireSphere(ref Vector3 center, float radius){}
		public static void DrawSphere(Vector3 center, float radius){}
		private static void INTERNAL_CALL_DrawSphere(ref Vector3 center, float radius){}
		public static void DrawWireCube(Vector3 center, Vector3 size){}
		private static void INTERNAL_CALL_DrawWireCube(ref Vector3 center, ref Vector3 size){}
		public static void DrawCube(Vector3 center, Vector3 size){}
		private static void INTERNAL_CALL_DrawCube(ref Vector3 center, ref Vector3 size){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation){}
		public static void DrawMesh(Mesh mesh, Vector3 position){}
		public static void DrawMesh(Mesh mesh){}
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale){}
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale){}
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation){}
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position){}
		public static void DrawMesh(Mesh mesh, int submeshIndex){}
		private static void INTERNAL_CALL_DrawMesh(Mesh mesh, int submeshIndex, ref Vector3 position, ref Quaternion rotation, ref Vector3 scale){}
		public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion rotation){}
		public static void DrawWireMesh(Mesh mesh, Vector3 position){}
		public static void DrawWireMesh(Mesh mesh){}
		public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale){}
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale){}
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation){}
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position){}
		public static void DrawWireMesh(Mesh mesh, int submeshIndex){}
		private static void INTERNAL_CALL_DrawWireMesh(Mesh mesh, int submeshIndex, ref Vector3 position, ref Quaternion rotation, ref Vector3 scale){}
		public static void DrawIcon(Vector3 center, string name, bool allowScaling){}
		public static void DrawIcon(Vector3 center, string name){}
		private static void INTERNAL_CALL_DrawIcon(ref Vector3 center, string name, bool allowScaling){}
		public static void DrawGUITexture(Rect screenRect, Texture texture){}
		public static void DrawGUITexture(Rect screenRect, Texture texture, Material mat){}
		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat){}
		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder){}
		private static void INTERNAL_CALL_DrawGUITexture(ref Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat){}
		private static void INTERNAL_get_color(out Color value){}
		private static void INTERNAL_set_color(ref Color value){}
		private static void INTERNAL_get_matrix(out Matrix4x4 value){}
		private static void INTERNAL_set_matrix(ref Matrix4x4 value){}
		public static void DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect){}
		private static void INTERNAL_CALL_DrawFrustum(ref Vector3 center, float fov, float maxRange, float minRange, float aspect){}
		public Gizmos(){}
		public static Color color{ get	{} set	{} }
		public static Matrix4x4 matrix{ get	{} set	{} }
	}

	public sealed class	FlareLayer: Behaviour
	{
		internal FlareLayer(){}
	}

	public sealed class	LightProbeGroup: Component
	{
		public LightProbeGroup(){}
		public Vector3[] probePositions{ get	{} set	{} }
	}

	public sealed class	Ping: Object
	{
		public void DestroyPing(){}
		protected virtual void Finalize(){}
		public Ping(string address){}
		public bool isDone{ get	{} }
		public int time{ get	{} }
		public string ip{ get	{} }
		private IntPtr pingWrapper;
	}

	public sealed class	NetworkView: Behaviour
	{
		private static void Internal_RPC(NetworkView view, string name, RPCMode mode, Object[] args){}
		private static void Internal_RPC_Target(NetworkView view, string name, NetworkPlayer target, Object[] args){}
		public void RPC(string name, RPCMode mode, Object[] args){}
		public void RPC(string name, NetworkPlayer target, Object[] args){}
		private void Internal_GetViewID(out NetworkViewID viewID){}
		private void Internal_SetViewID(NetworkViewID viewID){}
		private static void INTERNAL_CALL_Internal_SetViewID(NetworkView self, ref NetworkViewID viewID){}
		public bool SetScope(NetworkPlayer player, bool relevancy){}
		public static NetworkView Find(NetworkViewID viewID){}
		private static NetworkView INTERNAL_CALL_Find(ref NetworkViewID viewID){}
		public NetworkView(){}
		public Component observed{ get	{} set	{} }
		public NetworkStateSynchronization stateSynchronization{ get	{} set	{} }
		public NetworkViewID viewID{ get	{} set	{} }
		public int group{ get	{} set	{} }
		public bool isMine{ get	{} }
		public NetworkPlayer owner{ get	{} }
	}

	public sealed class	Network: Object
	{
		public static NetworkConnectionError InitializeServer(int connections, int listenPort, bool useNat){}
		private static NetworkConnectionError Internal_InitializeServerDeprecated(int connections, int listenPort){}
		public static NetworkConnectionError InitializeServer(int connections, int listenPort){}
		public static void InitializeSecurity(){}
		private static NetworkConnectionError Internal_ConnectToSingleIP(string IP, int remotePort, int localPort, string password){}
		private static NetworkConnectionError Internal_ConnectToSingleIP(string IP, int remotePort, int localPort){}
		private static NetworkConnectionError Internal_ConnectToGuid(string guid, string password){}
		private static NetworkConnectionError Internal_ConnectToIPs(String[] IP, int remotePort, int localPort, string password){}
		private static NetworkConnectionError Internal_ConnectToIPs(String[] IP, int remotePort, int localPort){}
		public static NetworkConnectionError Connect(string IP, int remotePort){}
		public static NetworkConnectionError Connect(string IP, int remotePort, string password){}
		public static NetworkConnectionError Connect(String[] IPs, int remotePort){}
		public static NetworkConnectionError Connect(String[] IPs, int remotePort, string password){}
		public static NetworkConnectionError Connect(string GUID){}
		public static NetworkConnectionError Connect(string GUID, string password){}
		public static NetworkConnectionError Connect(HostData hostData){}
		public static NetworkConnectionError Connect(HostData hostData, string password){}
		public static void Disconnect(int timeout){}
		public static void Disconnect(){}
		public static void CloseConnection(NetworkPlayer target, bool sendDisconnectionNotification){}
		private static int Internal_GetPlayer(){}
		private static void Internal_AllocateViewID(out NetworkViewID viewID){}
		public static NetworkViewID AllocateViewID(){}
		public static System.Object Instantiate(System.Object prefab, Vector3 position, Quaternion rotation, int group){}
		private static System.Object INTERNAL_CALL_Instantiate(System.Object prefab, ref Vector3 position, ref Quaternion rotation, int group){}
		public static void Destroy(NetworkViewID viewID){}
		private static void INTERNAL_CALL_Destroy(ref NetworkViewID viewID){}
		public static void Destroy(GameObject gameObject){}
		public static void DestroyPlayerObjects(NetworkPlayer playerID){}
		private static void Internal_RemoveRPCs(NetworkPlayer playerID, NetworkViewID viewID, uint channelMask){}
		private static void INTERNAL_CALL_Internal_RemoveRPCs(NetworkPlayer playerID, ref NetworkViewID viewID, uint channelMask){}
		public static void RemoveRPCs(NetworkPlayer playerID){}
		public static void RemoveRPCs(NetworkPlayer playerID, int group){}
		public static void RemoveRPCs(NetworkViewID viewID){}
		public static void RemoveRPCsInGroup(int group){}
		public static void SetLevelPrefix(int prefix){}
		public static int GetLastPing(NetworkPlayer player){}
		public static int GetAveragePing(NetworkPlayer player){}
		public static void SetReceivingEnabled(NetworkPlayer player, int group, bool enabled){}
		private static void Internal_SetSendingGlobal(int group, bool enabled){}
		private static void Internal_SetSendingSpecific(NetworkPlayer player, int group, bool enabled){}
		public static void SetSendingEnabled(int group, bool enabled){}
		public static void SetSendingEnabled(NetworkPlayer player, int group, bool enabled){}
		private static void Internal_GetTime(out double t){}
		public static ConnectionTesterStatus TestConnection(bool forceTest){}
		public static ConnectionTesterStatus TestConnection(){}
		public static ConnectionTesterStatus TestConnectionNAT(bool forceTest){}
		public static ConnectionTesterStatus TestConnectionNAT(){}
		public static bool HavePublicAddress(){}
		public Network(){}
		public static string incomingPassword{ get	{} set	{} }
		public static NetworkLogLevel logLevel{ get	{} set	{} }
		public static NetworkPlayer[] connections{ get	{} }
		public static NetworkPlayer player{ get	{} }
		public static bool isClient{ get	{} }
		public static bool isServer{ get	{} }
		public static NetworkPeerType peerType{ get	{} }
		public static float sendRate{ get	{} set	{} }
		public static bool isMessageQueueRunning{ get	{} set	{} }
		public static double time{ get	{} }
		public static int minimumAllocatableViewIDs{ get	{} set	{} }
		public static bool useNat{ get	{} set	{} }
		public static string natFacilitatorIP{ get	{} set	{} }
		public static int natFacilitatorPort{ get	{} set	{} }
		public static string connectionTesterIP{ get	{} set	{} }
		public static int connectionTesterPort{ get	{} set	{} }
		public static int maxConnections{ get	{} set	{} }
		public static string proxyIP{ get	{} set	{} }
		public static int proxyPort{ get	{} set	{} }
		public static bool useProxy{ get	{} set	{} }
		public static string proxyPassword{ get	{} set	{} }
	}

	public sealed class	BitStream: Object
	{
		private void Serializeb(ref int value){}
		private void Serializec(ref char value){}
		private void Serializes(ref short value){}
		private void Serializei(ref int value){}
		private void Serializef(ref float value, float maximumDelta){}
		private void Serializeq(ref Quaternion value, float maximumDelta){}
		private static void INTERNAL_CALL_Serializeq(BitStream self, ref Quaternion value, float maximumDelta){}
		private void Serializev(ref Vector3 value, float maximumDelta){}
		private static void INTERNAL_CALL_Serializev(BitStream self, ref Vector3 value, float maximumDelta){}
		private void Serializen(ref NetworkViewID viewID){}
		private static void INTERNAL_CALL_Serializen(BitStream self, ref NetworkViewID viewID){}
		public void Serialize(ref bool value){}
		public void Serialize(ref char value){}
		public void Serialize(ref short value){}
		public void Serialize(ref int value){}
		public void Serialize(ref float value){}
		public void Serialize(ref float value, float maxDelta){}
		public void Serialize(ref Quaternion value){}
		public void Serialize(ref Quaternion value, float maxDelta){}
		public void Serialize(ref Vector3 value){}
		public void Serialize(ref Vector3 value, float maxDelta){}
		public void Serialize(ref NetworkPlayer value){}
		public void Serialize(ref NetworkViewID viewID){}
		private void Serialize(ref string value){}
		public BitStream(){}
		public bool isReading{ get	{} }
		public bool isWriting{ get	{} }
		internal IntPtr m_Ptr;
	}

	public sealed class	RPC: Attribute, _Attribute
	{
		public RPC(){}
	}

	public sealed class	HostData: Object
	{
		public HostData(){}
		public bool useNat{ get	{} set	{} }
		public string gameType{ get	{} set	{} }
		public string gameName{ get	{} set	{} }
		public int connectedPlayers{ get	{} set	{} }
		public int playerLimit{ get	{} set	{} }
		public String[] ip{ get	{} set	{} }
		public int port{ get	{} set	{} }
		public bool passwordProtected{ get	{} set	{} }
		public string comment{ get	{} set	{} }
		public string guid{ get	{} set	{} }
		private int m_Nat;
		private string m_GameType;
		private string m_GameName;
		private int m_ConnectedPlayers;
		private int m_PlayerLimit;
		private String[] m_IP;
		private int m_Port;
		private int m_PasswordProtected;
		private string m_Comment;
		private string m_GUID;
	}

	public sealed class	MasterServer: Object
	{
		public static void RequestHostList(string gameTypeName){}
		public static HostData[] PollHostList(){}
		public static void RegisterHost(string gameTypeName, string gameName, string comment){}
		public static void RegisterHost(string gameTypeName, string gameName){}
		public static void UnregisterHost(){}
		public static void ClearHostList(){}
		public MasterServer(){}
		public static string ipAddress{ get	{} set	{} }
		public static int port{ get	{} set	{} }
		public static int updateRate{ get	{} set	{} }
		public static bool dedicatedServer{ get	{} set	{} }
	}

	public sealed class	RectTransform: Transform, IEnumerable
	{
		private void INTERNAL_get_rect(out Rect value){}
		private void INTERNAL_get_anchorMin(out Vector2 value){}
		private void INTERNAL_set_anchorMin(ref Vector2 value){}
		private void INTERNAL_get_anchorMax(out Vector2 value){}
		private void INTERNAL_set_anchorMax(ref Vector2 value){}
		private void INTERNAL_get_anchoredPosition(out Vector2 value){}
		private void INTERNAL_set_anchoredPosition(ref Vector2 value){}
		private void INTERNAL_get_sizeDelta(out Vector2 value){}
		private void INTERNAL_set_sizeDelta(ref Vector2 value){}
		private void INTERNAL_get_pivot(out Vector2 value){}
		private void INTERNAL_set_pivot(ref Vector2 value){}
		internal static void SendReapplyDrivenProperties(RectTransform driven){}
		public void GetLocalCorners(Vector3[] fourCornersArray){}
		public void GetWorldCorners(Vector3[] fourCornersArray){}
		internal Rect GetRectInParentSpace(){}
		public void SetInsetAndSizeFromParentEdge(Edge edge, float inset, float size){}
		public void SetSizeWithCurrentAnchors(Axis axis, float size){}
		private Vector2 GetParentSize(){}
		public RectTransform(){}
		public Rect rect{ get	{} }
		public Vector2 anchorMin{ get	{} set	{} }
		public Vector2 anchorMax{ get	{} set	{} }
		public Vector3 anchoredPosition3D{ get	{} set	{} }
		public Vector2 anchoredPosition{ get	{} set	{} }
		public Vector2 sizeDelta{ get	{} set	{} }
		public Vector2 pivot{ get	{} set	{} }
		System.Object drivenByObject{ get	{} set	{} }
		DrivenTransformProperties drivenProperties{ get	{} set	{} }
		public Vector2 offsetMin{ get	{} set	{} }
		public Vector2 offsetMax{ get	{} set	{} }
		public static event	ReapplyDrivenProperties reapplyDrivenProperties;
	}

	public sealed class	ResourceRequest: AsyncOperation
	{
		public ResourceRequest(){}
		public System.Object asset{ get	{} }
		internal string m_Path;
		internal Type m_Type;
	}

	public sealed class	Resources: Object
	{
		internal static T[] ConvertObjects(Object[] rawObjects){}
		public static Object[] FindObjectsOfTypeAll(Type type){}
		public static T[] FindObjectsOfTypeAll(){}
		public static System.Object Load(string path){}
		public static T Load(string path){}
		public static System.Object Load(string path, Type systemTypeInstance){}
		public static ResourceRequest LoadAsync(string path){}
		public static ResourceRequest LoadAsync(string path){}
		public static ResourceRequest LoadAsync(string path, Type type){}
		public static Object[] LoadAll(string path, Type systemTypeInstance){}
		public static Object[] LoadAll(string path){}
		public static T[] LoadAll(string path){}
		public static System.Object GetBuiltinResource(Type type, string path){}
		public static T GetBuiltinResource(string path){}
		public static System.Object LoadAssetAtPath(string assetPath, Type type){}
		public static T LoadAssetAtPath(string assetPath){}
		public static void UnloadAsset(System.Object assetToUnload){}
		public static AsyncOperation UnloadUnusedAssets(){}
		public Resources(){}
	}

	public class	TextAsset: Object
	{
		public virtual string ToString(){}
		public TextAsset(){}
		public string text{ get	{} }
		public Byte[] bytes{ get	{} }
	}

	public sealed class	SerializePrivateVariables: Attribute, _Attribute
	{
		public SerializePrivateVariables(){}
	}

	public sealed class	SerializeField: Attribute, _Attribute
	{
		public SerializeField(){}
	}

	public interface ISerializationCallbackReceiver	{
		void OnBeforeSerialize();
		void OnAfterDeserialize();
	}

	public sealed class	Security: Object
	{
		public static bool PrefetchSocketPolicy(string ip, int atPort){}
		public static bool PrefetchSocketPolicy(string ip, int atPort, int timeout){}
		public static string GetChainOfTrustValue(string name){}
		private static string GetChainOfTrustValueInternal(string name, string publicKeyToken){}
		private static MethodInfo GetUnityCrossDomainHelperMethod(string methodname){}
		internal static string TokenToHex(Byte[] token){}
		internal static void ClearVerifiedAssemblies(){}
		public static Assembly LoadAndVerifyAssembly(Byte[] assemblyData, string authorizationKey){}
		public static Assembly LoadAndVerifyAssembly(Byte[] assemblyData){}
		private static Assembly LoadAndVerifyAssemblyInternal(Byte[] assemblyData){}
		internal static bool VerifySignature(string file, Byte[] publicKey){}
		public Security(){}
		private static Security(){}
		private static List<Assembly> _verifiedAssemblies;
		private readonly static string kSignatureExtension;
		private const string publicVerificationKey = null;
	}

	public sealed class	Shader: Object
	{
		public static Shader Find(string name){}
		internal static Shader FindBuiltin(string name){}
		public static void EnableKeyword(string keyword){}
		public static void DisableKeyword(string keyword){}
		public static bool IsKeywordEnabled(string keyword){}
		public static void SetGlobalColor(string propertyName, Color color){}
		public static void SetGlobalColor(int nameID, Color color){}
		private static void INTERNAL_CALL_SetGlobalColor(int nameID, ref Color color){}
		public static void SetGlobalVector(string propertyName, Vector4 vec){}
		public static void SetGlobalVector(int nameID, Vector4 vec){}
		public static void SetGlobalFloat(string propertyName, float value){}
		public static void SetGlobalFloat(int nameID, float value){}
		public static void SetGlobalInt(string propertyName, int value){}
		public static void SetGlobalInt(int nameID, int value){}
		public static void SetGlobalTexture(string propertyName, Texture tex){}
		public static void SetGlobalTexture(int nameID, Texture tex){}
		public static void SetGlobalMatrix(string propertyName, Matrix4x4 mat){}
		public static void SetGlobalMatrix(int nameID, Matrix4x4 mat){}
		private static void INTERNAL_CALL_SetGlobalMatrix(int nameID, ref Matrix4x4 mat){}
		public static void SetGlobalTexGenMode(string propertyName, TexGenMode mode){}
		public static void SetGlobalTextureMatrixName(string propertyName, string matrixName){}
		public static void SetGlobalBuffer(string propertyName, ComputeBuffer buffer){}
		public static int PropertyToID(string name){}
		public static void WarmupAllShaders(){}
		public Shader(){}
		public bool isSupported{ get	{} }
		string customEditor{ get	{} }
		public int maximumLOD{ get	{} set	{} }
		public static int globalMaximumLOD{ get	{} set	{} }
		public int renderQueue{ get	{} }
		DisableBatchingType disableBatching{ get	{} }
	}

	public class	Material: Object
	{
		public void SetColor(string propertyName, Color color){}
		public void SetColor(int nameID, Color color){}
		private static void INTERNAL_CALL_SetColor(Material self, int nameID, ref Color color){}
		public Color GetColor(string propertyName){}
		public Color GetColor(int nameID){}
		public void SetVector(string propertyName, Vector4 vector){}
		public void SetVector(int nameID, Vector4 vector){}
		public Vector4 GetVector(string propertyName){}
		public Vector4 GetVector(int nameID){}
		public void SetTexture(string propertyName, Texture texture){}
		public void SetTexture(int nameID, Texture texture){}
		public Texture GetTexture(string propertyName){}
		public Texture GetTexture(int nameID){}
		private static void Internal_GetTextureOffset(Material mat, string name, out Vector2 output){}
		private static void Internal_GetTextureScale(Material mat, string name, out Vector2 output){}
		public void SetTextureOffset(string propertyName, Vector2 offset){}
		private static void INTERNAL_CALL_SetTextureOffset(Material self, string propertyName, ref Vector2 offset){}
		public Vector2 GetTextureOffset(string propertyName){}
		public void SetTextureScale(string propertyName, Vector2 scale){}
		private static void INTERNAL_CALL_SetTextureScale(Material self, string propertyName, ref Vector2 scale){}
		public Vector2 GetTextureScale(string propertyName){}
		public void SetMatrix(string propertyName, Matrix4x4 matrix){}
		public void SetMatrix(int nameID, Matrix4x4 matrix){}
		private static void INTERNAL_CALL_SetMatrix(Material self, int nameID, ref Matrix4x4 matrix){}
		public Matrix4x4 GetMatrix(string propertyName){}
		public Matrix4x4 GetMatrix(int nameID){}
		public void SetFloat(string propertyName, float value){}
		public void SetFloat(int nameID, float value){}
		public float GetFloat(string propertyName){}
		public float GetFloat(int nameID){}
		public void SetInt(string propertyName, int value){}
		public void SetInt(int nameID, int value){}
		public int GetInt(string propertyName){}
		public int GetInt(int nameID){}
		public void SetBuffer(string propertyName, ComputeBuffer buffer){}
		public bool HasProperty(string propertyName){}
		public bool HasProperty(int nameID){}
		public string GetTag(string tag, bool searchFallbacks, string defaultValue){}
		public string GetTag(string tag, bool searchFallbacks){}
		public void Lerp(Material start, Material end, float t){}
		public bool SetPass(int pass){}
		public static Material Create(string scriptContents){}
		private static void Internal_CreateWithString(Material mono, string contents){}
		private static void Internal_CreateWithShader(Material mono, Shader shader){}
		private static void Internal_CreateWithMaterial(Material mono, Material source){}
		public void CopyPropertiesFromMaterial(Material mat){}
		public void EnableKeyword(string keyword){}
		public void DisableKeyword(string keyword){}
		public bool IsKeywordEnabled(string keyword){}
		public Material(string contents){}
		public Material(Shader shader){}
		public Material(Material source){}
		public Shader shader{ get	{} set	{} }
		public Color color{ get	{} set	{} }
		public Texture mainTexture{ get	{} set	{} }
		public Vector2 mainTextureOffset{ get	{} set	{} }
		public Vector2 mainTextureScale{ get	{} set	{} }
		public int passCount{ get	{} }
		public int renderQueue{ get	{} set	{} }
		public String[] shaderKeywords{ get	{} set	{} }
		public MaterialGlobalIlluminationFlags globalIlluminationFlags{ get	{} set	{} }
	}

	public sealed class	ShaderVariantCollection: Object
	{
		private static void Internal_Create(ShaderVariantCollection mono){}
		public bool Add(ShaderVariant variant){}
		private bool AddInternal(Shader shader, PassType passType, String[] keywords){}
		public bool Remove(ShaderVariant variant){}
		private bool RemoveInternal(Shader shader, PassType passType, String[] keywords){}
		public bool Contains(ShaderVariant variant){}
		private bool ContainsInternal(Shader shader, PassType passType, String[] keywords){}
		public void Clear(){}
		public void WarmUp(){}
		public ShaderVariantCollection(){}
		public int shaderCount{ get	{} }
		public int variantCount{ get	{} }
		public bool isWarmedUp{ get	{} }
	}

	public sealed class	ProceduralPropertyDescription: Object
	{
		public ProceduralPropertyDescription(){}
		public string name;
		public string label;
		public string group;
		public ProceduralPropertyType type;
		public bool hasRange;
		public float minimum;
		public float maximum;
		public float step;
		public String[] enumOptions;
		public String[] componentLabels;
	}

	public sealed class	ProceduralMaterial: Material
	{
		public ProceduralPropertyDescription[] GetProceduralPropertyDescriptions(){}
		public bool HasProceduralProperty(string inputName){}
		public bool GetProceduralBoolean(string inputName){}
		public void SetProceduralBoolean(string inputName, bool value){}
		public float GetProceduralFloat(string inputName){}
		public void SetProceduralFloat(string inputName, float value){}
		public Vector4 GetProceduralVector(string inputName){}
		public void SetProceduralVector(string inputName, Vector4 value){}
		private static void INTERNAL_CALL_SetProceduralVector(ProceduralMaterial self, string inputName, ref Vector4 value){}
		public Color GetProceduralColor(string inputName){}
		public void SetProceduralColor(string inputName, Color value){}
		private static void INTERNAL_CALL_SetProceduralColor(ProceduralMaterial self, string inputName, ref Color value){}
		public int GetProceduralEnum(string inputName){}
		public void SetProceduralEnum(string inputName, int value){}
		public Texture2D GetProceduralTexture(string inputName){}
		public void SetProceduralTexture(string inputName, Texture2D value){}
		public bool IsProceduralPropertyCached(string inputName){}
		public void CacheProceduralProperty(string inputName, bool value){}
		public void ClearCache(){}
		public void RebuildTextures(){}
		public void RebuildTexturesImmediately(){}
		public static void StopRebuilds(){}
		public Texture[] GetGeneratedTextures(){}
		public ProceduralTexture GetGeneratedTexture(string textureName){}
		public ProceduralMaterial(){}
		public ProceduralCacheSize cacheSize{ get	{} set	{} }
		public int animationUpdateRate{ get	{} set	{} }
		public bool isProcessing{ get	{} }
		public bool isCachedDataAvailable{ get	{} }
		public bool isLoadTimeGenerated{ get	{} set	{} }
		public ProceduralLoadingBehavior loadingBehavior{ get	{} }
		public static bool isSupported{ get	{} }
		public static ProceduralProcessorUsage substanceProcessorUsage{ get	{} set	{} }
		public string preset{ get	{} set	{} }
		public bool isReadable{ get	{} set	{} }
	}

	public sealed class	ProceduralTexture: Texture
	{
		public ProceduralOutputType GetProceduralOutputType(){}
		internal ProceduralMaterial GetProceduralMaterial(){}
		internal bool HasBeenGenerated(){}
		public Color32[] GetPixels32(int x, int y, int blockWidth, int blockHeight){}
		public ProceduralTexture(){}
		public bool hasAlpha{ get	{} }
		public TextureFormat format{ get	{} }
	}

	public sealed class	Sprite: Object
	{
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border){}
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType){}
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude){}
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit){}
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot){}
		private static Sprite INTERNAL_CALL_Create(Texture2D texture, ref Rect rect, ref Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, ref Vector4 border){}
		private static void Internal_GetTextureRectOffset(Sprite sprite, out Vector2 output){}
		private static void Internal_GetPivot(Sprite sprite, out Vector2 output){}
		public void OverrideGeometry(Vector2[] vertices, UInt16[] triangles){}
		public Sprite(){}
		public Bounds bounds{ get	{} }
		public Rect rect{ get	{} }
		public float pixelsPerUnit{ get	{} }
		public Texture2D texture{ get	{} }
		public Rect textureRect{ get	{} }
		public Vector2 textureRectOffset{ get	{} }
		public bool packed{ get	{} }
		public SpritePackingMode packingMode{ get	{} }
		public SpritePackingRotation packingRotation{ get	{} }
		public Vector2 pivot{ get	{} }
		public Vector4 border{ get	{} }
		public Vector2[] vertices{ get	{} }
		public UInt16[] triangles{ get	{} }
		public Vector2[] uv{ get	{} }
	}

	public sealed class	SpriteRenderer: Renderer
	{
		private Sprite GetSprite_INTERNAL(){}
		private void SetSprite_INTERNAL(Sprite sprite){}
		private void INTERNAL_get_color(out Color value){}
		private void INTERNAL_set_color(ref Color value){}
		public SpriteRenderer(){}
		public Sprite sprite{ get	{} set	{} }
		public Color color{ get	{} set	{} }
	}

	public sealed class	WWW: Object, IDisposable
	{
		public sealed virtual void Dispose(){}
		protected virtual void Finalize(){}
		private void DestroyWWW(bool cancel){}
		public void InitWWW(string url, Byte[] postData, String[] iHeaders){}
		internal bool enforceWebSecurityRestrictions(){}
		public static string EscapeURL(string s){}
		public static string EscapeURL(string s, Encoding e){}
		public static string UnEscapeURL(string s){}
		public static string UnEscapeURL(string s, Encoding e){}
		private Encoding GetTextEncoder(){}
		private Texture2D GetTexture(bool markNonReadable){}
		public AudioClip GetAudioClip(bool threeD){}
		public AudioClip GetAudioClip(bool threeD, bool stream){}
		public AudioClip GetAudioClip(bool threeD, bool stream, AudioType audioType){}
		public AudioClip GetAudioClipCompressed(){}
		public AudioClip GetAudioClipCompressed(bool threeD){}
		public AudioClip GetAudioClipCompressed(bool threeD, AudioType audioType){}
		private AudioClip GetAudioClipInternal(bool threeD, bool stream, bool compressed, AudioType audioType){}
		public void LoadImageIntoTexture(Texture2D tex){}
		public static string GetURL(string url){}
		public static Texture2D GetTextureFromURL(string url){}
		public void LoadUnityWeb(){}
		private static void INTERNAL_CALL_WWW(WWW self, string url, ref Hash128 hash, uint crc){}
		public static WWW LoadFromCacheOrDownload(string url, int version){}
		public static WWW LoadFromCacheOrDownload(string url, int version, uint crc){}
		public static WWW LoadFromCacheOrDownload(string url, Hash128 hash){}
		public static WWW LoadFromCacheOrDownload(string url, Hash128 hash, uint crc){}
		private static void CheckSecurityOnHeaders(String[] headers){}
		private static String[] FlattenedHeadersFrom(Dictionary<String, String> headers){}
		internal static Dictionary<String, String> ParseHTTPHeaderString(string input){}
		public WWW(string url){}
		public WWW(string url, WWWForm form){}
		public WWW(string url, Byte[] postData){}
		public WWW(string url, Byte[] postData, Hashtable headers){}
		public WWW(string url, Byte[] postData, Dictionary<String, String> headers){}
		internal WWW(string url, Hash128 hash, uint crc){}
		private static WWW(){}
		public Dictionary<String, String> responseHeaders{ get	{} }
		string responseHeadersString{ get	{} }
		public string text{ get	{} }
		Encoding DefaultEncoding{ get	{} }
		public string data{ get	{} }
		public Byte[] bytes{ get	{} }
		public int size{ get	{} }
		public string error{ get	{} }
		public Texture2D texture{ get	{} }
		public Texture2D textureNonReadable{ get	{} }
		public AudioClip audioClip{ get	{} }
		public MovieTexture movie{ get	{} }
		public bool isDone{ get	{} }
		public float progress{ get	{} }
		public float uploadProgress{ get	{} }
		public int bytesDownloaded{ get	{} }
		public AudioClip oggVorbis{ get	{} }
		public string url{ get	{} }
		public AssetBundle assetBundle{ get	{} }
		public ThreadPriority threadPriority{ get	{} set	{} }
		internal IntPtr m_Ptr;
		private readonly static Char[] forbiddenCharacters;
		private readonly static Char[] forbiddenCharactersForNames;
		private readonly static String[] forbiddenHeaderKeys;
	}

	public sealed class	WWWForm: Object
	{
		public void AddField(string fieldName, string value){}
		public void AddField(string fieldName, string value, Encoding e){}
		public void AddField(string fieldName, int i){}
		public void AddBinaryData(string fieldName, Byte[] contents, string fileName){}
		public void AddBinaryData(string fieldName, Byte[] contents){}
		public void AddBinaryData(string fieldName, Byte[] contents, string fileName, string mimeType){}
		public WWWForm(){}
		public Dictionary<String, String> headers{ get	{} }
		public Byte[] data{ get	{} }
		private List<Byte[]> formData;
		private List<String> fieldNames;
		private List<String> fileNames;
		private List<String> types;
		private Byte[] boundary;
		private bool containsFiles;
	}

	public sealed class	Caching: Object
	{
		public static bool Authorize(string name, string domain, long size, string signature){}
		public static bool Authorize(string name, string domain, long size, int expiration, string signature){}
		public static bool Authorize(string name, string domain, int size, int expiration, string signature){}
		public static bool Authorize(string name, string domain, int size, string signature){}
		public static bool CleanCache(){}
		public static bool CleanNamedCache(string name){}
		public static bool DeleteFromCache(string url){}
		public static int GetVersionFromCache(string url){}
		public static bool IsVersionCached(string url, int version){}
		public static bool IsVersionCached(string url, Hash128 hash){}
		private static bool INTERNAL_CALL_IsVersionCached(string url, ref Hash128 hash){}
		public static bool MarkAsUsed(string url, int version){}
		public static bool MarkAsUsed(string url, Hash128 hash){}
		private static bool INTERNAL_CALL_MarkAsUsed(string url, ref Hash128 hash){}
		public static void SetNoBackupFlag(string url, int version){}
		public static void SetNoBackupFlag(string url, Hash128 hash){}
		private static void INTERNAL_CALL_SetNoBackupFlag(string url, ref Hash128 hash){}
		public static void ResetNoBackupFlag(string url, int version){}
		public static void ResetNoBackupFlag(string url, Hash128 hash){}
		private static void INTERNAL_CALL_ResetNoBackupFlag(string url, ref Hash128 hash){}
		public Caching(){}
		public static CacheIndex[] index{ get	{} }
		public static long spaceFree{ get	{} }
		public static long maximumAvailableDiskSpace{ get	{} set	{} }
		public static long spaceOccupied{ get	{} }
		public static int spaceAvailable{ get	{} }
		public static int spaceUsed{ get	{} }
		public static int expirationDelay{ get	{} set	{} }
		public static bool enabled{ get	{} set	{} }
		public static bool ready{ get	{} }
	}

	public sealed class	UnityEventQueueSystem: Object
	{
		public static string GenerateEventIdForPayload(string eventPayloadName){}
		public static IntPtr GetGlobalEventQueue(){}
		public UnityEventQueueSystem(){}
	}

	public class	AsyncOperation: YieldInstruction
	{
		private void InternalDestroy(){}
		protected virtual void Finalize(){}
		public AsyncOperation(){}
		public bool isDone{ get	{} }
		public float progress{ get	{} }
		public int priority{ get	{} set	{} }
		public bool allowSceneActivation{ get	{} set	{} }
		internal IntPtr m_Ptr;
	}

	public sealed class	Application: Object
	{
		public static void Quit(){}
		public static void CancelQuit(){}
		public static void LoadLevel(int index){}
		public static void LoadLevel(string name){}
		public static AsyncOperation LoadLevelAsync(int index){}
		public static AsyncOperation LoadLevelAsync(string levelName){}
		public static AsyncOperation LoadLevelAdditiveAsync(int index){}
		public static AsyncOperation LoadLevelAdditiveAsync(string levelName){}
		private static AsyncOperation LoadLevelAsync(string monoLevelName, int index, bool additive, bool mustCompleteNextFrame){}
		public static void LoadLevelAdditive(int index){}
		public static void LoadLevelAdditive(string name){}
		private static float GetStreamProgressForLevelByName(string levelName){}
		public static float GetStreamProgressForLevel(int levelIndex){}
		public static float GetStreamProgressForLevel(string levelName){}
		private static bool CanStreamedLevelBeLoadedByName(string levelName){}
		public static bool CanStreamedLevelBeLoaded(int levelIndex){}
		public static bool CanStreamedLevelBeLoaded(string levelName){}
		public static void CaptureScreenshot(string filename, int superSize){}
		public static void CaptureScreenshot(string filename){}
		public static bool HasProLicense(){}
		internal static bool HasAdvancedLicense(){}
		public static void DontDestroyOnLoad(System.Object mono){}
		private static string ObjectToJSString(System.Object o){}
		public static void ExternalCall(string functionName, Object[] args){}
		private static string BuildInvocationForArguments(string functionName, Object[] args){}
		public static void ExternalEval(string script){}
		private static void Internal_ExternalCall(string script){}
		internal static int GetBuildUnityVersion(){}
		internal static int GetNumericUnityVersion(string version){}
		public static void OpenURL(string url){}
		public static void CommitSuicide(int mode){}
		private static void CallLogCallback(string logString, string stackTrace, LogType type, bool invokedOnMainThread){}
		private static void SetLogCallbackDefined(bool defined, bool threaded){}
		public static AsyncOperation RequestUserAuthorization(UserAuthorization mode){}
		public static bool HasUserAuthorization(UserAuthorization mode){}
		internal static void ReplyToUserAuthorizationRequest(bool reply, bool remember){}
		internal static void ReplyToUserAuthorizationRequest(bool reply){}
		private static int GetUserAuthorizationRequestMode_Internal(){}
		internal static UserAuthorization GetUserAuthorizationRequestMode(){}
		public static void RegisterLogCallback(LogCallback handler){}
		public static void RegisterLogCallbackThreaded(LogCallback handler){}
		private static void RegisterLogCallback(LogCallback handler, bool threaded){}
		public Application(){}
		public static int loadedLevel{ get	{} }
		public static string loadedLevelName{ get	{} }
		public static bool isLoadingLevel{ get	{} }
		public static int levelCount{ get	{} }
		public static int streamedBytes{ get	{} }
		public static bool isPlaying{ get	{} }
		public static bool isEditor{ get	{} }
		public static bool isWebPlayer{ get	{} }
		public static RuntimePlatform platform{ get	{} }
		public static bool isMobilePlatform{ get	{} }
		public static bool isConsolePlatform{ get	{} }
		public static bool runInBackground{ get	{} set	{} }
		public static bool isPlayer{ get	{} }
		public static string dataPath{ get	{} }
		public static string streamingAssetsPath{ get	{} }
		public static string persistentDataPath{ get	{} }
		public static string temporaryCachePath{ get	{} }
		public static string srcValue{ get	{} }
		public static string absoluteURL{ get	{} }
		public static string absoluteUrl{ get	{} }
		public static string unityVersion{ get	{} }
		public static string version{ get	{} }
		public static string bundleIdentifier{ get	{} }
		public static ApplicationInstallMode installMode{ get	{} }
		public static ApplicationSandboxType sandboxType{ get	{} }
		public static string productName{ get	{} }
		public static string companyName{ get	{} }
		public static string cloudProjectId{ get	{} }
		public static bool webSecurityEnabled{ get	{} }
		public static string webSecurityHostUrl{ get	{} }
		public static int targetFrameRate{ get	{} set	{} }
		public static SystemLanguage systemLanguage{ get	{} }
		public static ThreadPriority backgroundLoadingPriority{ get	{} set	{} }
		public static NetworkReachability internetReachability{ get	{} }
		public static bool genuine{ get	{} }
		public static bool genuineCheckAvailable{ get	{} }
		bool submitAnalytics{ get	{} }
		public static event	LogCallback logMessageReceived;
		public static event	LogCallback logMessageReceivedThreaded;
		private static LogCallback s_LogCallbackHandler;
		private static LogCallback s_LogCallbackHandlerThreaded;
		private static LogCallback s_RegisterLogCallbackDeprecated;
	}

	public class	Behaviour: Component
	{
		public Behaviour(){}
		public bool enabled{ get	{} set	{} }
		public bool isActiveAndEnabled{ get	{} }
	}

	public sealed class	Camera: Behaviour
	{
		private static Ray INTERNAL_CALL_ScreenPointToRay(Camera self, ref Vector3 position){}
		public static int GetAllCameras(Camera[] cameras){}
		public float GetScreenWidth(){}
		public float GetScreenHeight(){}
		public void DoClear(){}
		private static void FireOnPreCull(Camera cam){}
		private static void FireOnPreRender(Camera cam){}
		private static void FireOnPostRender(Camera cam){}
		public void Render(){}
		public void RenderWithShader(Shader shader, string replacementTag){}
		public void SetReplacementShader(Shader shader, string replacementTag){}
		public void ResetReplacementShader(){}
		private static void INTERNAL_CALL_ResetReplacementShader(Camera self){}
		public void RenderDontRestore(){}
		public static void SetupCurrent(Camera cur){}
		public bool RenderToCubemap(Cubemap cubemap){}
		public bool RenderToCubemap(Cubemap cubemap, int faceMask){}
		public bool RenderToCubemap(RenderTexture cubemap){}
		public bool RenderToCubemap(RenderTexture cubemap, int faceMask){}
		private bool Internal_RenderToCubemapRT(RenderTexture cubemap, int faceMask){}
		private bool Internal_RenderToCubemapTexture(Cubemap cubemap, int faceMask){}
		public void CopyFrom(Camera other){}
		internal bool IsFiltered(GameObject go){}
		public void AddCommandBuffer(CameraEvent evt, CommandBuffer buffer){}
		public void RemoveCommandBuffer(CameraEvent evt, CommandBuffer buffer){}
		public void RemoveCommandBuffers(CameraEvent evt){}
		public void RemoveAllCommandBuffers(){}
		public CommandBuffer[] GetCommandBuffers(CameraEvent evt){}
		internal GameObject RaycastTry(Ray ray, float distance, int layerMask){}
		private static GameObject INTERNAL_CALL_RaycastTry(Camera self, ref Ray ray, float distance, int layerMask){}
		internal GameObject RaycastTry2D(Ray ray, float distance, int layerMask){}
		private static GameObject INTERNAL_CALL_RaycastTry2D(Camera self, ref Ray ray, float distance, int layerMask){}
		public Matrix4x4 CalculateObliqueMatrix(Vector4 clipPlane){}
		private static Matrix4x4 INTERNAL_CALL_CalculateObliqueMatrix(Camera self, ref Vector4 clipPlane){}
		internal void OnlyUsedForTesting1(){}
		internal void OnlyUsedForTesting2(){}
		private void INTERNAL_get_backgroundColor(out Color value){}
		private void INTERNAL_set_backgroundColor(ref Color value){}
		private void INTERNAL_get_rect(out Rect value){}
		private void INTERNAL_set_rect(ref Rect value){}
		private void INTERNAL_get_pixelRect(out Rect value){}
		private void INTERNAL_set_pixelRect(ref Rect value){}
		private void SetTargetBuffersImpl(out RenderBuffer color, out RenderBuffer depth){}
		private void SetTargetBuffersMRTImpl(RenderBuffer[] color, out RenderBuffer depth){}
		public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer){}
		public void SetTargetBuffers(RenderBuffer[] colorBuffer, RenderBuffer depthBuffer){}
		private void INTERNAL_get_cameraToWorldMatrix(out Matrix4x4 value){}
		private void INTERNAL_get_worldToCameraMatrix(out Matrix4x4 value){}
		private void INTERNAL_set_worldToCameraMatrix(ref Matrix4x4 value){}
		public void ResetWorldToCameraMatrix(){}
		private static void INTERNAL_CALL_ResetWorldToCameraMatrix(Camera self){}
		private void INTERNAL_get_projectionMatrix(out Matrix4x4 value){}
		private void INTERNAL_set_projectionMatrix(ref Matrix4x4 value){}
		public void ResetProjectionMatrix(){}
		private static void INTERNAL_CALL_ResetProjectionMatrix(Camera self){}
		public void ResetAspect(){}
		private static void INTERNAL_CALL_ResetAspect(Camera self){}
		private void INTERNAL_get_velocity(out Vector3 value){}
		public Vector3 WorldToScreenPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_WorldToScreenPoint(Camera self, ref Vector3 position){}
		public Vector3 WorldToViewportPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_WorldToViewportPoint(Camera self, ref Vector3 position){}
		public Vector3 ViewportToWorldPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_ViewportToWorldPoint(Camera self, ref Vector3 position){}
		public Vector3 ScreenToWorldPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_ScreenToWorldPoint(Camera self, ref Vector3 position){}
		public Vector3 ScreenToViewportPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_ScreenToViewportPoint(Camera self, ref Vector3 position){}
		public Vector3 ViewportToScreenPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_ViewportToScreenPoint(Camera self, ref Vector3 position){}
		public Ray ViewportPointToRay(Vector3 position){}
		private static Ray INTERNAL_CALL_ViewportPointToRay(Camera self, ref Vector3 position){}
		public Ray ScreenPointToRay(Vector3 position){}
		public Camera(){}
		public float fov{ get	{} set	{} }
		public float near{ get	{} set	{} }
		public float far{ get	{} set	{} }
		public float fieldOfView{ get	{} set	{} }
		public float nearClipPlane{ get	{} set	{} }
		public float farClipPlane{ get	{} set	{} }
		public RenderingPath renderingPath{ get	{} set	{} }
		public RenderingPath actualRenderingPath{ get	{} }
		public bool hdr{ get	{} set	{} }
		public float orthographicSize{ get	{} set	{} }
		public bool isOrthoGraphic{ get	{} set	{} }
		public bool orthographic{ get	{} set	{} }
		public TransparencySortMode transparencySortMode{ get	{} set	{} }
		public float depth{ get	{} set	{} }
		public float aspect{ get	{} set	{} }
		public int cullingMask{ get	{} set	{} }
		int PreviewCullingLayer{ get	{} }
		public int eventMask{ get	{} set	{} }
		public Color backgroundColor{ get	{} set	{} }
		public Rect rect{ get	{} set	{} }
		public Rect pixelRect{ get	{} set	{} }
		public RenderTexture targetTexture{ get	{} set	{} }
		public int pixelWidth{ get	{} }
		public int pixelHeight{ get	{} }
		public Matrix4x4 cameraToWorldMatrix{ get	{} }
		public Matrix4x4 worldToCameraMatrix{ get	{} set	{} }
		public Matrix4x4 projectionMatrix{ get	{} set	{} }
		public Vector3 velocity{ get	{} }
		public CameraClearFlags clearFlags{ get	{} set	{} }
		public bool stereoEnabled{ get	{} }
		public float stereoSeparation{ get	{} set	{} }
		public float stereoConvergence{ get	{} set	{} }
		public int targetDisplay{ get	{} set	{} }
		public static Camera main{ get	{} }
		public static Camera current{ get	{} }
		public static Camera[] allCameras{ get	{} }
		public static int allCamerasCount{ get	{} }
		public static Camera mainCamera{ get	{} }
		public bool useOcclusionCulling{ get	{} set	{} }
		public Single[] layerCullDistances{ get	{} set	{} }
		public bool layerCullSpherical{ get	{} set	{} }
		public DepthTextureMode depthTextureMode{ get	{} set	{} }
		public bool clearStencilAfterLightingPass{ get	{} set	{} }
		public int commandBufferCount{ get	{} }
		public static CameraCallback onPreCull;
		public static CameraCallback onPreRender;
		public static CameraCallback onPostRender;
	}

	public sealed class	ComputeShader: Object
	{
		public int FindKernel(string name){}
		public void SetFloat(string name, float val){}
		public void SetInt(string name, int val){}
		public void SetVector(string name, Vector4 val){}
		private static void INTERNAL_CALL_SetVector(ComputeShader self, string name, ref Vector4 val){}
		public void SetFloats(string name, Single[] values){}
		private void Internal_SetFloats(string name, Single[] values){}
		public void SetInts(string name, Int32[] values){}
		private void Internal_SetInts(string name, Int32[] values){}
		public void SetTexture(int kernelIndex, string name, Texture texture){}
		public void SetBuffer(int kernelIndex, string name, ComputeBuffer buffer){}
		public void Dispatch(int kernelIndex, int threadsX, int threadsY, int threadsZ){}
		public ComputeShader(){}
	}

	public sealed class	ComputeBuffer: Object, IDisposable
	{
		protected virtual void Finalize(){}
		public sealed virtual void Dispose(){}
		private void Dispose(bool disposing){}
		private static void InitBuffer(ComputeBuffer buf, int count, int stride, ComputeBufferType type){}
		private static void DestroyBuffer(ComputeBuffer buf){}
		public void Release(){}
		public void SetData(Array data){}
		private void InternalSetData(Array data, int elemSize){}
		public void GetData(Array data){}
		private void InternalGetData(Array data, int elemSize){}
		public static void CopyCount(ComputeBuffer src, ComputeBuffer dst, int dstOffset){}
		public ComputeBuffer(int count, int stride){}
		public ComputeBuffer(int count, int stride, ComputeBufferType type){}
		public int count{ get	{} }
		public int stride{ get	{} }
		internal IntPtr m_Ptr;
	}

	public sealed class	Debug: Object
	{
		public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest){}
		public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration){}
		public static void DrawLine(Vector3 start, Vector3 end, Color color){}
		public static void DrawLine(Vector3 start, Vector3 end){}
		private static void INTERNAL_CALL_DrawLine(ref Vector3 start, ref Vector3 end, ref Color color, float duration, bool depthTest){}
		public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration){}
		public static void DrawRay(Vector3 start, Vector3 dir, Color color){}
		public static void DrawRay(Vector3 start, Vector3 dir){}
		public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest){}
		public static void Break(){}
		public static void DebugBreak(){}
		private static void Internal_Log(int level, string msg, System.Object obj){}
		private static void Internal_LogException(Exception exception, System.Object obj){}
		public static void Log(System.Object message){}
		public static void Log(System.Object message, System.Object context){}
		public static void LogFormat(string format, Object[] args){}
		public static void LogFormat(System.Object context, string format, Object[] args){}
		public static void LogError(System.Object message){}
		public static void LogError(System.Object message, System.Object context){}
		public static void LogErrorFormat(string format, Object[] args){}
		public static void LogErrorFormat(System.Object context, string format, Object[] args){}
		public static void ClearDeveloperConsole(){}
		internal static void WriteLineToLogFile(string message){}
		public static void LogException(Exception exception){}
		public static void LogException(Exception exception, System.Object context){}
		internal static void LogPlayerBuildError(string message, string file, int line, int column){}
		public static void LogWarning(System.Object message){}
		public static void LogWarning(System.Object message, System.Object context){}
		public static void LogWarningFormat(string format, Object[] args){}
		public static void LogWarningFormat(System.Object context, string format, Object[] args){}
		internal static void OpenConsoleFile(){}
		public Debug(){}
		public static bool developerConsoleVisible{ get	{} set	{} }
		public static bool isDebugBuild{ get	{} }
	}

	public sealed class	Display: Object
	{
		public void Activate(){}
		public void Activate(int width, int height, int refreshRate){}
		public void SetParams(int width, int height, int x, int y){}
		public void SetRenderingResolution(int w, int h){}
		public static bool MultiDisplayLicense(){}
		public static Vector3 RelativeMouseAt(Vector3 inputMouseCoordinates){}
		private static void RecreateDisplayList(IntPtr[] nativeDisplay){}
		private static void FireDisplaysUpdated(){}
		private static void GetSystemExtImpl(IntPtr nativeDisplay, out int w, out int h){}
		private static void GetRenderingExtImpl(IntPtr nativeDisplay, out int w, out int h){}
		private static void GetRenderingBuffersImpl(IntPtr nativeDisplay, out RenderBuffer color, out RenderBuffer depth){}
		private static void SetRenderingResolutionImpl(IntPtr nativeDisplay, int w, int h){}
		private static void ActivateDisplayImpl(IntPtr nativeDisplay, int width, int height, int refreshRate){}
		private static void SetParamsImpl(IntPtr nativeDisplay, int width, int height, int x, int y){}
		private static bool MultiDisplayLicenseImpl(){}
		private static int RelativeMouseAtImpl(int x, int y, out int rx, out int ry){}
		internal Display(){}
		internal Display(IntPtr nativeDisplay){}
		private static Display(){}
		public int renderingWidth{ get	{} }
		public int renderingHeight{ get	{} }
		public int systemWidth{ get	{} }
		public int systemHeight{ get	{} }
		public RenderBuffer colorBuffer{ get	{} }
		public RenderBuffer depthBuffer{ get	{} }
		public static Display main{ get	{} }
		public static event	DisplaysUpdatedDelegate onDisplaysUpdated;
		internal IntPtr nativeDisplay;
		public static Display[] displays;
		private static Display _mainDisplay;
	}

	public sealed class	NotConvertedAttribute: Attribute, _Attribute
	{
		public NotConvertedAttribute(){}
	}

	public sealed class	NotFlashValidatedAttribute: Attribute, _Attribute
	{
		public NotFlashValidatedAttribute(){}
	}

	public sealed class	NotRenamedAttribute: Attribute, _Attribute
	{
		public NotRenamedAttribute(){}
	}

	public class	MonoBehaviour: Behaviour
	{
		private void Internal_CancelInvokeAll(){}
		private bool Internal_IsInvokingAll(){}
		public void Invoke(string methodName, float time){}
		public void InvokeRepeating(string methodName, float time, float repeatRate){}
		public void CancelInvoke(){}
		public void CancelInvoke(string methodName){}
		public bool IsInvoking(string methodName){}
		public bool IsInvoking(){}
		public Coroutine StartCoroutine(IEnumerator routine){}
		public Coroutine StartCoroutine_Auto(IEnumerator routine){}
		public Coroutine StartCoroutine(string methodName, System.Object value){}
		public Coroutine StartCoroutine(string methodName){}
		public void StopCoroutine(string methodName){}
		public void StopCoroutine(IEnumerator routine){}
		public void StopCoroutine(Coroutine routine){}
		internal void StopCoroutineViaEnumerator_Auto(IEnumerator routine){}
		internal void StopCoroutine_Auto(Coroutine routine){}
		public void StopAllCoroutines(){}
		public static void print(System.Object message){}
		public MonoBehaviour(){}
		public bool useGUILayout{ get	{} set	{} }
	}

	public sealed class	Gyroscope: Object
	{
		private static Vector3 rotationRate_Internal(int idx){}
		private static Vector3 rotationRateUnbiased_Internal(int idx){}
		private static Vector3 gravity_Internal(int idx){}
		private static Vector3 userAcceleration_Internal(int idx){}
		private static Quaternion attitude_Internal(int idx){}
		private static bool getEnabled_Internal(int idx){}
		private static void setEnabled_Internal(int idx, bool enabled){}
		private static float getUpdateInterval_Internal(int idx){}
		private static void setUpdateInterval_Internal(int idx, float interval){}
		internal Gyroscope(int index){}
		public Vector3 rotationRate{ get	{} }
		public Vector3 rotationRateUnbiased{ get	{} }
		public Vector3 gravity{ get	{} }
		public Vector3 userAcceleration{ get	{} }
		public Quaternion attitude{ get	{} }
		public bool enabled{ get	{} set	{} }
		public float updateInterval{ get	{} set	{} }
		private int m_GyroIndex;
	}

	public sealed class	LocationService: Object
	{
		public void Start(float desiredAccuracyInMeters, float updateDistanceInMeters){}
		public void Start(float desiredAccuracyInMeters){}
		public void Start(){}
		public void Stop(){}
		public LocationService(){}
		public bool isEnabledByUser{ get	{} }
		public LocationServiceStatus status{ get	{} }
		public LocationInfo lastData{ get	{} }
	}

	public sealed class	Compass: Object
	{
		public Compass(){}
		public float magneticHeading{ get	{} }
		public float trueHeading{ get	{} }
		public float headingAccuracy{ get	{} }
		public Vector3 rawVector{ get	{} }
		public double timestamp{ get	{} }
		public bool enabled{ get	{} set	{} }
	}

	public sealed class	Input: Object
	{
		private static int mainGyroIndex_Internal(){}
		private static bool GetKeyInt(int key){}
		private static bool GetKeyString(string name){}
		private static bool GetKeyUpInt(int key){}
		private static bool GetKeyUpString(string name){}
		private static bool GetKeyDownInt(int key){}
		private static bool GetKeyDownString(string name){}
		public static float GetAxis(string axisName){}
		public static float GetAxisRaw(string axisName){}
		public static bool GetButton(string buttonName){}
		public static bool GetButtonDown(string buttonName){}
		public static bool GetButtonUp(string buttonName){}
		public static bool GetKey(string name){}
		public static bool GetKey(KeyCode key){}
		public static bool GetKeyDown(string name){}
		public static bool GetKeyDown(KeyCode key){}
		public static bool GetKeyUp(string name){}
		public static bool GetKeyUp(KeyCode key){}
		public static String[] GetJoystickNames(){}
		public static bool IsJoystickPreconfigured(string joystickName){}
		public static bool GetMouseButton(int button){}
		public static bool GetMouseButtonDown(int button){}
		public static bool GetMouseButtonUp(int button){}
		public static void ResetInputAxes(){}
		public static AccelerationEvent GetAccelerationEvent(int index){}
		public static Touch GetTouch(int index){}
		public static Quaternion GetRotation(int deviceID){}
		public static Vector3 GetPosition(int deviceID){}
		private static void INTERNAL_get_compositionCursorPos(out Vector2 value){}
		private static void INTERNAL_set_compositionCursorPos(ref Vector2 value){}
		public Input(){}
		private static Input(){}
		public static bool compensateSensors{ get	{} set	{} }
		public static bool isGyroAvailable{ get	{} }
		public static Gyroscope gyro{ get	{} }
		public static Vector3 mousePosition{ get	{} }
		public static Vector2 mouseScrollDelta{ get	{} }
		public static bool mousePresent{ get	{} }
		public static bool simulateMouseWithTouches{ get	{} set	{} }
		public static bool anyKey{ get	{} }
		public static bool anyKeyDown{ get	{} }
		public static string inputString{ get	{} }
		public static Vector3 acceleration{ get	{} }
		public static AccelerationEvent[] accelerationEvents{ get	{} }
		public static int accelerationEventCount{ get	{} }
		public static Touch[] touches{ get	{} }
		public static int touchCount{ get	{} }
		public static bool eatKeyPressOnTextFieldFocus{ get	{} set	{} }
		public static bool touchSupported{ get	{} }
		public static bool multiTouchEnabled{ get	{} set	{} }
		public static LocationService location{ get	{} }
		public static Compass compass{ get	{} }
		public static DeviceOrientation deviceOrientation{ get	{} }
		public static IMECompositionMode imeCompositionMode{ get	{} set	{} }
		public static string compositionString{ get	{} }
		public static bool imeIsSelected{ get	{} }
		public static Vector2 compositionCursorPos{ get	{} set	{} }
		private static Gyroscope m_MainGyro;
		private static LocationService locationServiceInstance;
		private static Compass compassInstance;
	}

	public class	Object: Object
	{
		private static System.Object Internal_CloneSingle(System.Object data){}
		private static System.Object Internal_InstantiateSingle(System.Object data, Vector3 pos, Quaternion rot){}
		private static System.Object INTERNAL_CALL_Internal_InstantiateSingle(System.Object data, ref Vector3 pos, ref Quaternion rot){}
		public static void Destroy(System.Object obj, float t){}
		public static void Destroy(System.Object obj){}
		public static void DestroyImmediate(System.Object obj, bool allowDestroyingAssets){}
		public static void DestroyImmediate(System.Object obj){}
		public static Object[] FindObjectsOfType(Type type){}
		public static void DontDestroyOnLoad(System.Object target){}
		public static void DestroyObject(System.Object obj, float t){}
		public static void DestroyObject(System.Object obj){}
		public static Object[] FindSceneObjectsOfType(Type type){}
		public static Object[] FindObjectsOfTypeIncludingAssets(Type type){}
		public static Object[] FindObjectsOfTypeAll(Type type){}
		public virtual string ToString(){}
		internal static bool DoesObjectWithInstanceIDExist(int instanceID){}
		public virtual bool Equals(System.Object o){}
		public virtual int GetHashCode(){}
		private static bool CompareBaseObjects(System.Object lhs, System.Object rhs){}
		private static bool IsNativeObjectAlive(System.Object o){}
		public int GetInstanceID(){}
		private IntPtr GetCachedPtr(){}
		public static System.Object Instantiate(System.Object original, Vector3 position, Quaternion rotation){}
		public static System.Object Instantiate(System.Object original){}
		public static T Instantiate(T original){}
		private static void CheckNullArgument(System.Object arg, string message){}
		public static T[] FindObjectsOfType(){}
		public static System.Object FindObjectOfType(Type type){}
		public static T FindObjectOfType(){}
		public Object(){}
		public string name{ get	{} set	{} }
		public HideFlags hideFlags{ get	{} set	{} }
		private int m_InstanceID;
		private IntPtr m_CachedPtr;
		private string m_UnityRuntimeErrorString;
	}

	public class	Component: Object
	{
		public Component GetComponent(Type type){}
		internal void GetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue){}
		public T GetComponent(){}
		public Component GetComponent(string type){}
		public Component GetComponentInChildren(Type t){}
		public T GetComponentInChildren(){}
		public Component[] GetComponentsInChildren(Type t){}
		public Component[] GetComponentsInChildren(Type t, bool includeInactive){}
		public T[] GetComponentsInChildren(bool includeInactive){}
		public void GetComponentsInChildren(bool includeInactive, List<T> result){}
		public T[] GetComponentsInChildren(){}
		public void GetComponentsInChildren(List<T> results){}
		public Component GetComponentInParent(Type t){}
		public T GetComponentInParent(){}
		public Component[] GetComponentsInParent(Type t){}
		public Component[] GetComponentsInParent(Type t, bool includeInactive){}
		public T[] GetComponentsInParent(bool includeInactive){}
		public void GetComponentsInParent(bool includeInactive, List<T> results){}
		public T[] GetComponentsInParent(){}
		public Component[] GetComponents(Type type){}
		private void GetComponentsForListInternal(Type searchType, System.Object resultList){}
		public void GetComponents(Type type, List<Component> results){}
		public void GetComponents(List<T> results){}
		public T[] GetComponents(){}
		public bool CompareTag(string tag){}
		public void SendMessageUpwards(string methodName, System.Object value, SendMessageOptions options){}
		public void SendMessageUpwards(string methodName, System.Object value){}
		public void SendMessageUpwards(string methodName){}
		public void SendMessageUpwards(string methodName, SendMessageOptions options){}
		public void SendMessage(string methodName, System.Object value, SendMessageOptions options){}
		public void SendMessage(string methodName, System.Object value){}
		public void SendMessage(string methodName){}
		public void SendMessage(string methodName, SendMessageOptions options){}
		public void BroadcastMessage(string methodName, System.Object parameter, SendMessageOptions options){}
		public void BroadcastMessage(string methodName, System.Object parameter){}
		public void BroadcastMessage(string methodName){}
		public void BroadcastMessage(string methodName, SendMessageOptions options){}
		public Component(){}
		public Transform transform{ get	{} }
		public GameObject gameObject{ get	{} }
		public string tag{ get	{} set	{} }
		public Component rigidbody{ get	{} }
		public Component rigidbody2D{ get	{} }
		public Component camera{ get	{} }
		public Component light{ get	{} }
		public Component animation{ get	{} }
		public Component constantForce{ get	{} }
		public Component renderer{ get	{} }
		public Component audio{ get	{} }
		public Component guiText{ get	{} }
		public Component networkView{ get	{} }
		public Component guiElement{ get	{} }
		public Component guiTexture{ get	{} }
		public Component collider{ get	{} }
		public Component collider2D{ get	{} }
		public Component hingeJoint{ get	{} }
		public Component particleEmitter{ get	{} }
		public Component particleSystem{ get	{} }
	}

	public sealed class	Light: Behaviour
	{
		private void INTERNAL_get_color(out Color value){}
		private void INTERNAL_set_color(ref Color value){}
		private void INTERNAL_get_areaSize(out Vector2 value){}
		private void INTERNAL_set_areaSize(ref Vector2 value){}
		public static Light[] GetLights(LightType type, int layer){}
		public Light(){}
		public LightType type{ get	{} set	{} }
		public Color color{ get	{} set	{} }
		public float intensity{ get	{} set	{} }
		public float bounceIntensity{ get	{} set	{} }
		public LightShadows shadows{ get	{} set	{} }
		public float shadowStrength{ get	{} set	{} }
		public float shadowBias{ get	{} set	{} }
		public float shadowNormalBias{ get	{} set	{} }
		public float shadowSoftness{ get	{} set	{} }
		public float shadowSoftnessFade{ get	{} set	{} }
		public float range{ get	{} set	{} }
		public float spotAngle{ get	{} set	{} }
		public float cookieSize{ get	{} set	{} }
		public Texture cookie{ get	{} set	{} }
		public Flare flare{ get	{} set	{} }
		public LightRenderMode renderMode{ get	{} set	{} }
		public bool alreadyLightmapped{ get	{} set	{} }
		public int cullingMask{ get	{} set	{} }
		public Vector2 areaSize{ get	{} set	{} }
		public static int pixelLightCount{ get	{} set	{} }
		public float shadowConstantBias{ get	{} set	{} }
		public float shadowObjectSizeBias{ get	{} set	{} }
		public bool attenuate{ get	{} set	{} }
	}

	public sealed class	GameObject: Object
	{
		public static GameObject CreatePrimitive(PrimitiveType type){}
		public Component GetComponent(Type type){}
		internal void GetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue){}
		public T GetComponent(){}
		internal Component GetComponentByName(string type){}
		public Component GetComponent(string type){}
		public Component GetComponentInChildren(Type type){}
		public T GetComponentInChildren(){}
		public Component GetComponentInParent(Type type){}
		public T GetComponentInParent(){}
		public Component[] GetComponents(Type type){}
		public T[] GetComponents(){}
		public void GetComponents(Type type, List<Component> results){}
		public void GetComponents(List<T> results){}
		public Component[] GetComponentsInChildren(Type type){}
		public Component[] GetComponentsInChildren(Type type, bool includeInactive){}
		public T[] GetComponentsInChildren(bool includeInactive){}
		public void GetComponentsInChildren(bool includeInactive, List<T> results){}
		public T[] GetComponentsInChildren(){}
		public void GetComponentsInChildren(List<T> results){}
		public Component[] GetComponentsInParent(Type type){}
		public Component[] GetComponentsInParent(Type type, bool includeInactive){}
		public void GetComponentsInParent(bool includeInactive, List<T> results){}
		public T[] GetComponentsInParent(bool includeInactive){}
		public T[] GetComponentsInParent(){}
		private Array GetComponentsInternal(Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, System.Object resultList){}
		internal Component AddComponentInternal(string className){}
		public void SetActive(bool value){}
		public void SetActiveRecursively(bool state){}
		public bool CompareTag(string tag){}
		public static GameObject FindGameObjectWithTag(string tag){}
		public static GameObject FindWithTag(string tag){}
		public static GameObject[] FindGameObjectsWithTag(string tag){}
		public void SendMessageUpwards(string methodName, System.Object value, SendMessageOptions options){}
		public void SendMessageUpwards(string methodName, System.Object value){}
		public void SendMessageUpwards(string methodName){}
		public void SendMessageUpwards(string methodName, SendMessageOptions options){}
		public void SendMessage(string methodName, System.Object value, SendMessageOptions options){}
		public void SendMessage(string methodName, System.Object value){}
		public void SendMessage(string methodName){}
		public void SendMessage(string methodName, SendMessageOptions options){}
		public void BroadcastMessage(string methodName, System.Object parameter, SendMessageOptions options){}
		public void BroadcastMessage(string methodName, System.Object parameter){}
		public void BroadcastMessage(string methodName){}
		public void BroadcastMessage(string methodName, SendMessageOptions options){}
		private Component Internal_AddComponentWithType(Type componentType){}
		public Component AddComponent(Type componentType){}
		public T AddComponent(){}
		private static void Internal_CreateGameObject(GameObject mono, string name){}
		public static GameObject Find(string name){}
		public void SampleAnimation(System.Object clip, float time){}
		public Component AddComponent(string className){}
		public void PlayAnimation(System.Object animation){}
		public void StopAnimation(){}
		public GameObject(string name){}
		public GameObject(){}
		public GameObject(string name, Type[] components){}
		public Transform transform{ get	{} }
		public int layer{ get	{} set	{} }
		public bool active{ get	{} set	{} }
		public bool activeSelf{ get	{} }
		public bool activeInHierarchy{ get	{} }
		public bool isStatic{ get	{} set	{} }
		bool isStaticBatchable{ get	{} }
		public string tag{ get	{} set	{} }
		public GameObject gameObject{ get	{} }
		public Component rigidbody{ get	{} }
		public Component rigidbody2D{ get	{} }
		public Component camera{ get	{} }
		public Component light{ get	{} }
		public Component animation{ get	{} }
		public Component constantForce{ get	{} }
		public Component renderer{ get	{} }
		public Component audio{ get	{} }
		public Component guiText{ get	{} }
		public Component networkView{ get	{} }
		public Component guiElement{ get	{} }
		public Component guiTexture{ get	{} }
		public Component collider{ get	{} }
		public Component collider2D{ get	{} }
		public Component hingeJoint{ get	{} }
		public Component particleEmitter{ get	{} }
		public Component particleSystem{ get	{} }
	}

	public class	Transform: Component, IEnumerable
	{
		private void INTERNAL_get_position(out Vector3 value){}
		private void INTERNAL_set_position(ref Vector3 value){}
		private void INTERNAL_get_localPosition(out Vector3 value){}
		private void INTERNAL_set_localPosition(ref Vector3 value){}
		private void INTERNAL_get_localEulerAngles(out Vector3 value){}
		private void INTERNAL_set_localEulerAngles(ref Vector3 value){}
		private void INTERNAL_get_rotation(out Quaternion value){}
		private void INTERNAL_set_rotation(ref Quaternion value){}
		private void INTERNAL_get_localRotation(out Quaternion value){}
		private void INTERNAL_set_localRotation(ref Quaternion value){}
		private void INTERNAL_get_localScale(out Vector3 value){}
		private void INTERNAL_set_localScale(ref Vector3 value){}
		public void SetParent(Transform parent){}
		public void SetParent(Transform parent, bool worldPositionStays){}
		private void INTERNAL_get_worldToLocalMatrix(out Matrix4x4 value){}
		private void INTERNAL_get_localToWorldMatrix(out Matrix4x4 value){}
		public void Translate(Vector3 translation){}
		public void Translate(Vector3 translation, Space relativeTo){}
		public void Translate(float x, float y, float z){}
		public void Translate(float x, float y, float z, Space relativeTo){}
		public void Translate(Vector3 translation, Transform relativeTo){}
		public void Translate(float x, float y, float z, Transform relativeTo){}
		public void Rotate(Vector3 eulerAngles){}
		public void Rotate(Vector3 eulerAngles, Space relativeTo){}
		public void Rotate(float xAngle, float yAngle, float zAngle){}
		public void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo){}
		internal void RotateAroundInternal(Vector3 axis, float angle){}
		private static void INTERNAL_CALL_RotateAroundInternal(Transform self, ref Vector3 axis, float angle){}
		public void Rotate(Vector3 axis, float angle){}
		public void Rotate(Vector3 axis, float angle, Space relativeTo){}
		public void RotateAround(Vector3 point, Vector3 axis, float angle){}
		public void LookAt(Transform target){}
		public void LookAt(Transform target, Vector3 worldUp){}
		public void LookAt(Vector3 worldPosition, Vector3 worldUp){}
		public void LookAt(Vector3 worldPosition){}
		private static void INTERNAL_CALL_LookAt(Transform self, ref Vector3 worldPosition, ref Vector3 worldUp){}
		public Vector3 TransformDirection(Vector3 direction){}
		private static Vector3 INTERNAL_CALL_TransformDirection(Transform self, ref Vector3 direction){}
		public Vector3 TransformDirection(float x, float y, float z){}
		public Vector3 InverseTransformDirection(Vector3 direction){}
		private static Vector3 INTERNAL_CALL_InverseTransformDirection(Transform self, ref Vector3 direction){}
		public Vector3 InverseTransformDirection(float x, float y, float z){}
		public Vector3 TransformVector(Vector3 vector){}
		private static Vector3 INTERNAL_CALL_TransformVector(Transform self, ref Vector3 vector){}
		public Vector3 TransformVector(float x, float y, float z){}
		public Vector3 InverseTransformVector(Vector3 vector){}
		private static Vector3 INTERNAL_CALL_InverseTransformVector(Transform self, ref Vector3 vector){}
		public Vector3 InverseTransformVector(float x, float y, float z){}
		public Vector3 TransformPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_TransformPoint(Transform self, ref Vector3 position){}
		public Vector3 TransformPoint(float x, float y, float z){}
		public Vector3 InverseTransformPoint(Vector3 position){}
		private static Vector3 INTERNAL_CALL_InverseTransformPoint(Transform self, ref Vector3 position){}
		public Vector3 InverseTransformPoint(float x, float y, float z){}
		public void DetachChildren(){}
		public void SetAsFirstSibling(){}
		public void SetAsLastSibling(){}
		public void SetSiblingIndex(int index){}
		public int GetSiblingIndex(){}
		public Transform Find(string name){}
		internal void SendTransformChangedScale(){}
		private void INTERNAL_get_lossyScale(out Vector3 value){}
		public bool IsChildOf(Transform parent){}
		public Transform FindChild(string name){}
		public sealed virtual IEnumerator GetEnumerator(){}
		public void RotateAround(Vector3 axis, float angle){}
		private static void INTERNAL_CALL_RotateAround(Transform self, ref Vector3 axis, float angle){}
		public void RotateAroundLocal(Vector3 axis, float angle){}
		private static void INTERNAL_CALL_RotateAroundLocal(Transform self, ref Vector3 axis, float angle){}
		public Transform GetChild(int index){}
		public int GetChildCount(){}
		internal bool IsNonUniformScaleTransform(){}
		protected Transform(){}
		public Vector3 position{ get	{} set	{} }
		public Vector3 localPosition{ get	{} set	{} }
		public Vector3 eulerAngles{ get	{} set	{} }
		public Vector3 localEulerAngles{ get	{} set	{} }
		public Vector3 right{ get	{} set	{} }
		public Vector3 up{ get	{} set	{} }
		public Vector3 forward{ get	{} set	{} }
		public Quaternion rotation{ get	{} set	{} }
		public Quaternion localRotation{ get	{} set	{} }
		public Vector3 localScale{ get	{} set	{} }
		public Transform parent{ get	{} set	{} }
		Transform parentInternal{ get	{} set	{} }
		public Matrix4x4 worldToLocalMatrix{ get	{} }
		public Matrix4x4 localToWorldMatrix{ get	{} }
		public Transform root{ get	{} }
		public int childCount{ get	{} }
		public Vector3 lossyScale{ get	{} }
		public bool hasChanged{ get	{} set	{} }
	}

	public sealed class	Time: Object
	{
		public Time(){}
		public static float time{ get	{} }
		public static float timeSinceLevelLoad{ get	{} }
		public static float deltaTime{ get	{} }
		public static float fixedTime{ get	{} }
		public static float unscaledTime{ get	{} }
		public static float unscaledDeltaTime{ get	{} }
		public static float fixedDeltaTime{ get	{} set	{} }
		public static float maximumDeltaTime{ get	{} set	{} }
		public static float smoothDeltaTime{ get	{} }
		public static float timeScale{ get	{} set	{} }
		public static int frameCount{ get	{} }
		public static int renderedFrameCount{ get	{} }
		public static float realtimeSinceStartup{ get	{} }
		public static int captureFramerate{ get	{} set	{} }
	}

	public sealed class	Random: Object
	{
		public static float Range(float min, float max){}
		public static int Range(int min, int max){}
		private static int RandomRangeInt(int min, int max){}
		private static void GetRandomUnitCircle(out Vector2 output){}
		public static float RandomRange(float min, float max){}
		public static int RandomRange(int min, int max){}
		public Random(){}
		public static int seed{ get	{} set	{} }
		public static float value{ get	{} }
		public static Vector3 insideUnitSphere{ get	{} }
		public static Vector2 insideUnitCircle{ get	{} }
		public static Vector3 onUnitSphere{ get	{} }
		public static Quaternion rotation{ get	{} }
		public static Quaternion rotationUniform{ get	{} }
	}

	public class	YieldInstruction: Object
	{
		public YieldInstruction(){}
	}

	public sealed class	PlayerPrefsException: Exception, ISerializable, _Exception
	{
		public PlayerPrefsException(string error){}
	}

	public sealed class	PlayerPrefs: Object
	{
		private static bool TrySetInt(string key, int value){}
		private static bool TrySetFloat(string key, float value){}
		private static bool TrySetSetString(string key, string value){}
		public static void SetInt(string key, int value){}
		public static int GetInt(string key, int defaultValue){}
		public static int GetInt(string key){}
		public static void SetFloat(string key, float value){}
		public static float GetFloat(string key, float defaultValue){}
		public static float GetFloat(string key){}
		public static void SetString(string key, string value){}
		public static string GetString(string key, string defaultValue){}
		public static string GetString(string key){}
		public static bool HasKey(string key){}
		public static void DeleteKey(string key){}
		public static void DeleteAll(){}
		public static void Save(){}
		public PlayerPrefs(){}
	}

	public class	AndroidJavaObject: Object, IDisposable
	{
		public sealed virtual void Dispose(){}
		public void Call(string methodName, Object[] args){}
		public void CallStatic(string methodName, Object[] args){}
		public FieldType Get(string fieldName){}
		public void Set(string fieldName, FieldType val){}
		public FieldType GetStatic(string fieldName){}
		public void SetStatic(string fieldName, FieldType val){}
		public IntPtr GetRawObject(){}
		public IntPtr GetRawClass(){}
		public ReturnType Call(string methodName, Object[] args){}
		public ReturnType CallStatic(string methodName, Object[] args){}
		protected void DebugPrint(string msg){}
		protected void DebugPrint(string call, string methodName, string signature, Object[] args){}
		private void _AndroidJavaObject(string className, Object[] args){}
		protected virtual void Finalize(){}
		protected virtual void Dispose(bool disposing){}
		protected void _Dispose(){}
		protected void _Call(string methodName, Object[] args){}
		protected ReturnType _Call(string methodName, Object[] args){}
		protected FieldType _Get(string fieldName){}
		protected void _Set(string fieldName, FieldType val){}
		protected void _CallStatic(string methodName, Object[] args){}
		protected ReturnType _CallStatic(string methodName, Object[] args){}
		protected FieldType _GetStatic(string fieldName){}
		protected void _SetStatic(string fieldName, FieldType val){}
		internal static AndroidJavaObject AndroidJavaObjectDeleteLocalRef(IntPtr jobject){}
		internal static AndroidJavaClass AndroidJavaClassDeleteLocalRef(IntPtr jclass){}
		protected IntPtr _GetRawObject(){}
		protected IntPtr _GetRawClass(){}
		protected static AndroidJavaObject FindClass(string name){}
		public AndroidJavaObject(string className, Object[] args){}
		internal AndroidJavaObject(IntPtr jobject){}
		internal AndroidJavaObject(){}
		private static AndroidJavaObject(){}
		AndroidJavaClass JavaLangClass{ get	{} }
		private bool m_disposed;
		protected IntPtr m_jobject;
		protected IntPtr m_jclass;
		private static bool enableDebugPrints;
		private static AndroidJavaClass s_JavaLangClass;
	}

	public class	AndroidJavaClass: AndroidJavaObject, IDisposable
	{
		private void _AndroidJavaClass(string className){}
		public AndroidJavaClass(string className){}
		internal AndroidJavaClass(IntPtr jclass){}
	}

	public sealed class	AndroidJNIHelper: Object
	{
		public static IntPtr GetConstructorID(IntPtr javaClass){}
		public static IntPtr GetConstructorID(IntPtr javaClass, string signature){}
		public static IntPtr GetMethodID(IntPtr javaClass, string methodName, string signature){}
		public static IntPtr GetMethodID(IntPtr javaClass, string methodName){}
		public static IntPtr GetMethodID(IntPtr javaClass, string methodName, string signature, bool isStatic){}
		public static IntPtr GetFieldID(IntPtr javaClass, string fieldName, string signature){}
		public static IntPtr GetFieldID(IntPtr javaClass, string fieldName){}
		public static IntPtr GetFieldID(IntPtr javaClass, string fieldName, string signature, bool isStatic){}
		public static IntPtr CreateJavaRunnable(AndroidJavaRunnable jrunnable){}
		public static IntPtr CreateJavaProxy(AndroidJavaProxy proxy){}
		public static IntPtr ConvertToJNIArray(Array array){}
		public static jvalue[] CreateJNIArgArray(Object[] args){}
		public static void DeleteJNIArgArray(Object[] args, jvalue[] jniArgs){}
		public static IntPtr GetConstructorID(IntPtr jclass, Object[] args){}
		public static IntPtr GetMethodID(IntPtr jclass, string methodName, Object[] args, bool isStatic){}
		public static string GetSignature(System.Object obj){}
		public static string GetSignature(Object[] args){}
		public static ArrayType ConvertFromJNIArray(IntPtr array){}
		public static IntPtr GetMethodID(IntPtr jclass, string methodName, Object[] args, bool isStatic){}
		public static IntPtr GetFieldID(IntPtr jclass, string fieldName, bool isStatic){}
		public static string GetSignature(Object[] args){}
		private AndroidJNIHelper(){}
		public static bool debug{ get	{} set	{} }
	}

	public sealed class	AndroidJNI: Object
	{
		public static float GetStaticFloatField(IntPtr clazz, IntPtr fieldID){}
		public static double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID){}
		public static void SetStaticStringField(IntPtr clazz, IntPtr fieldID, string val){}
		public static void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val){}
		public static void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool val){}
		public static void SetStaticByteField(IntPtr clazz, IntPtr fieldID, byte val){}
		public static void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char val){}
		public static void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short val){}
		public static void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int val){}
		public static void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long val){}
		public static void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float val){}
		public static void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double val){}
		public static IntPtr ToBooleanArray(Boolean[] array){}
		public static IntPtr ToByteArray(Byte[] array){}
		public static IntPtr ToCharArray(Char[] array){}
		public static IntPtr ToShortArray(Int16[] array){}
		public static IntPtr ToIntArray(Int32[] array){}
		public static IntPtr ToLongArray(Int64[] array){}
		public static IntPtr ToFloatArray(Single[] array){}
		public static IntPtr ToDoubleArray(Double[] array){}
		public static IntPtr ToObjectArray(IntPtr[] array, IntPtr arrayClass){}
		public static IntPtr ToObjectArray(IntPtr[] array){}
		public static Boolean[] FromBooleanArray(IntPtr array){}
		public static Byte[] FromByteArray(IntPtr array){}
		public static Char[] FromCharArray(IntPtr array){}
		public static Int16[] FromShortArray(IntPtr array){}
		public static Int32[] FromIntArray(IntPtr array){}
		public static Int64[] FromLongArray(IntPtr array){}
		public static Single[] FromFloatArray(IntPtr array){}
		public static Double[] FromDoubleArray(IntPtr array){}
		public static IntPtr[] FromObjectArray(IntPtr array){}
		public static int GetArrayLength(IntPtr array){}
		public static IntPtr NewBooleanArray(int size){}
		public static IntPtr NewByteArray(int size){}
		public static IntPtr NewCharArray(int size){}
		public static IntPtr NewShortArray(int size){}
		public static IntPtr NewIntArray(int size){}
		public static IntPtr NewLongArray(int size){}
		public static IntPtr NewFloatArray(int size){}
		public static IntPtr NewDoubleArray(int size){}
		public static IntPtr NewObjectArray(int size, IntPtr clazz, IntPtr obj){}
		public static bool GetBooleanArrayElement(IntPtr array, int index){}
		public static byte GetByteArrayElement(IntPtr array, int index){}
		public static char GetCharArrayElement(IntPtr array, int index){}
		public static short GetShortArrayElement(IntPtr array, int index){}
		public static int GetIntArrayElement(IntPtr array, int index){}
		public static long GetLongArrayElement(IntPtr array, int index){}
		public static float GetFloatArrayElement(IntPtr array, int index){}
		public static double GetDoubleArrayElement(IntPtr array, int index){}
		public static IntPtr GetObjectArrayElement(IntPtr array, int index){}
		public static void SetBooleanArrayElement(IntPtr array, int index, byte val){}
		public static void SetByteArrayElement(IntPtr array, int index, sbyte val){}
		public static void SetCharArrayElement(IntPtr array, int index, char val){}
		public static void SetShortArrayElement(IntPtr array, int index, short val){}
		public static void SetIntArrayElement(IntPtr array, int index, int val){}
		public static void SetLongArrayElement(IntPtr array, int index, long val){}
		public static void SetFloatArrayElement(IntPtr array, int index, float val){}
		public static void SetDoubleArrayElement(IntPtr array, int index, double val){}
		public static void SetObjectArrayElement(IntPtr array, int index, IntPtr obj){}
		public static int AttachCurrentThread(){}
		public static int DetachCurrentThread(){}
		public static int GetVersion(){}
		public static IntPtr FindClass(string name){}
		public static IntPtr FromReflectedMethod(IntPtr refMethod){}
		public static IntPtr FromReflectedField(IntPtr refField){}
		public static IntPtr ToReflectedMethod(IntPtr clazz, IntPtr methodID, bool isStatic){}
		public static IntPtr ToReflectedField(IntPtr clazz, IntPtr fieldID, bool isStatic){}
		public static IntPtr GetSuperclass(IntPtr clazz){}
		public static bool IsAssignableFrom(IntPtr clazz1, IntPtr clazz2){}
		public static int Throw(IntPtr obj){}
		public static int ThrowNew(IntPtr clazz, string message){}
		public static IntPtr ExceptionOccurred(){}
		public static void ExceptionDescribe(){}
		public static void ExceptionClear(){}
		public static void FatalError(string message){}
		public static int PushLocalFrame(int capacity){}
		public static IntPtr PopLocalFrame(IntPtr result){}
		public static IntPtr NewGlobalRef(IntPtr obj){}
		public static void DeleteGlobalRef(IntPtr obj){}
		public static IntPtr NewLocalRef(IntPtr obj){}
		public static void DeleteLocalRef(IntPtr obj){}
		public static bool IsSameObject(IntPtr obj1, IntPtr obj2){}
		public static int EnsureLocalCapacity(int capacity){}
		public static IntPtr AllocObject(IntPtr clazz){}
		public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static IntPtr GetObjectClass(IntPtr obj){}
		public static bool IsInstanceOf(IntPtr obj, IntPtr clazz){}
		public static IntPtr GetMethodID(IntPtr clazz, string name, string sig){}
		public static IntPtr GetFieldID(IntPtr clazz, string name, string sig){}
		public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig){}
		public static IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig){}
		public static IntPtr NewStringUTF(string bytes){}
		public static int GetStringUTFLength(IntPtr str){}
		public static string GetStringUTFChars(IntPtr str){}
		public static string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static int CallIntMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static short CallShortMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static byte CallByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static char CallCharMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static float CallFloatMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static long CallLongMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static void CallVoidMethod(IntPtr obj, IntPtr methodID, jvalue[] args){}
		public static string GetStringField(IntPtr obj, IntPtr fieldID){}
		public static IntPtr GetObjectField(IntPtr obj, IntPtr fieldID){}
		public static bool GetBooleanField(IntPtr obj, IntPtr fieldID){}
		public static byte GetByteField(IntPtr obj, IntPtr fieldID){}
		public static char GetCharField(IntPtr obj, IntPtr fieldID){}
		public static short GetShortField(IntPtr obj, IntPtr fieldID){}
		public static int GetIntField(IntPtr obj, IntPtr fieldID){}
		public static long GetLongField(IntPtr obj, IntPtr fieldID){}
		public static float GetFloatField(IntPtr obj, IntPtr fieldID){}
		public static double GetDoubleField(IntPtr obj, IntPtr fieldID){}
		public static void SetStringField(IntPtr obj, IntPtr fieldID, string val){}
		public static void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val){}
		public static void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val){}
		public static void SetByteField(IntPtr obj, IntPtr fieldID, byte val){}
		public static void SetCharField(IntPtr obj, IntPtr fieldID, char val){}
		public static void SetShortField(IntPtr obj, IntPtr fieldID, short val){}
		public static void SetIntField(IntPtr obj, IntPtr fieldID, int val){}
		public static void SetLongField(IntPtr obj, IntPtr fieldID, long val){}
		public static void SetFloatField(IntPtr obj, IntPtr fieldID, float val){}
		public static void SetDoubleField(IntPtr obj, IntPtr fieldID, double val){}
		public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static byte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){}
		public static string GetStaticStringField(IntPtr clazz, IntPtr fieldID){}
		public static IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID){}
		public static bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID){}
		public static byte GetStaticByteField(IntPtr clazz, IntPtr fieldID){}
		public static char GetStaticCharField(IntPtr clazz, IntPtr fieldID){}
		public static short GetStaticShortField(IntPtr clazz, IntPtr fieldID){}
		public static int GetStaticIntField(IntPtr clazz, IntPtr fieldID){}
		public static long GetStaticLongField(IntPtr clazz, IntPtr fieldID){}
		private AndroidJNI(){}
	}

	public sealed class	AndroidInput: Object
	{
		public static Touch GetSecondaryTouch(int index){}
		private AndroidInput(){}
		public static int touchCountSecondary{ get	{} }
		public static bool secondaryTouchEnabled{ get	{} }
		public static int secondaryTouchWidth{ get	{} }
		public static int secondaryTouchHeight{ get	{} }
	}

	public class	Motion: Object
	{
		public bool ValidateIfRetargetable(bool val){}
		public Motion(){}
		public float averageDuration{ get	{} }
		public float averageAngularSpeed{ get	{} }
		public Vector3 averageSpeed{ get	{} }
		public float apparentSpeed{ get	{} }
		public bool isLooping{ get	{} }
		public bool legacy{ get	{} }
		public bool isHumanMotion{ get	{} }
		public bool isAnimatorMotion{ get	{} }
	}

	public sealed class	ADBannerView: Object
	{
		public ADBannerView(){}
	}

	public sealed class	ADInterstitialAd: Object
	{
		public ADInterstitialAd(){}
	}

	public sealed class	iPhone: Object
	{
		public iPhone(){}
	}

	public sealed class	iPhoneInput: Object
	{
		public iPhoneInput(){}
		public static iPhoneOrientation orientation{ get	{} }
		LocationInfo lastLocation{ get	{} }
	}

	public sealed class	iPhoneSettings: Object
	{
		public static void StartLocationServiceUpdates(float desiredAccuracyInMeters, float updateDistanceInMeters){}
		public static void StartLocationServiceUpdates(float desiredAccuracyInMeters){}
		public static void StartLocationServiceUpdates(){}
		public static void StopLocationServiceUpdates(){}
		public iPhoneSettings(){}
		public static iPhoneScreenOrientation screenOrientation{ get	{} }
		public static bool verticalOrientation{ get	{} }
		public static bool screenCanDarken{ get	{} }
		public static string uniqueIdentifier{ get	{} }
		public static string name{ get	{} }
		public static string model{ get	{} }
		public static string systemName{ get	{} }
		public static string systemVersion{ get	{} }
		public static iPhoneNetworkReachability internetReachability{ get	{} }
		public static iPhoneGeneration generation{ get	{} }
		public static LocationServiceStatus locationServiceStatus{ get	{} }
		public static bool locationServiceEnabledByUser{ get	{} }
	}

	public sealed class	iPhoneKeyboard: Object
	{
		public iPhoneKeyboard(){}
	}

	public sealed class	iPhoneUtils: Object
	{
		public static void PlayMovie(string path, Color bgColor, iPhoneMovieControlMode controlMode, iPhoneMovieScalingMode scalingMode){}
		public static void PlayMovie(string path, Color bgColor, iPhoneMovieControlMode controlMode){}
		public static void PlayMovie(string path, Color bgColor){}
		public static void PlayMovieURL(string url, Color bgColor, iPhoneMovieControlMode controlMode, iPhoneMovieScalingMode scalingMode){}
		public static void PlayMovieURL(string url, Color bgColor, iPhoneMovieControlMode controlMode){}
		public static void PlayMovieURL(string url, Color bgColor){}
		public static void Vibrate(){}
		public iPhoneUtils(){}
		public static bool isApplicationGenuine{ get	{} }
		public static bool isApplicationGenuineAvailable{ get	{} }
	}

	public sealed class	LocalNotification: Object
	{
		public LocalNotification(){}
	}

	public sealed class	RemoteNotification: Object
	{
		public RemoteNotification(){}
	}

	public sealed class	NotificationServices: Object
	{
		public static void RegisterForRemoteNotificationTypes(RemoteNotificationType notificationTypes){}
		public NotificationServices(){}
	}

	public sealed class	SamsungTV: Object
	{
		public SamsungTV(){}
		public static TouchPadMode touchPadMode{ get	{} set	{} }
		public static GestureMode gestureMode{ get	{} set	{} }
		public static bool airMouseConnected{ get	{} }
		public static bool gestureWorking{ get	{} }
		public static GamePadMode gamePadMode{ get	{} set	{} }
	}

	public sealed class	BillboardAsset: Object
	{
		internal void MakeRenderMesh(Mesh mesh){}
		internal void MakeMaterialProperties(MaterialPropertyBlock properties, Camera camera, float widthScale, float heightScale, float rotation){}
		internal void MakePreviewMesh(Mesh mesh){}
		public BillboardAsset(){}
		public float width{ get	{} set	{} }
		public float height{ get	{} set	{} }
		public float bottom{ get	{} set	{} }
		public int imageCount{ get	{} }
		public int vertexCount{ get	{} }
		public int indexCount{ get	{} }
		public Material material{ get	{} set	{} }
	}

	public sealed class	BillboardRenderer: Renderer
	{
		public BillboardRenderer(){}
		public BillboardAsset billboard{ get	{} set	{} }
	}

	public sealed class	WindZone: Component
	{
		public WindZone(){}
		public WindZoneMode mode{ get	{} set	{} }
		public float radius{ get	{} set	{} }
		public float windMain{ get	{} set	{} }
		public float windTurbulence{ get	{} set	{} }
		public float windPulseMagnitude{ get	{} set	{} }
		public float windPulseFrequency{ get	{} set	{} }
	}

	public sealed class	DynamicGI: Object
	{
		public static void SetEmissive(Renderer renderer, Color color){}
		private static void INTERNAL_CALL_SetEmissive(Renderer renderer, ref Color color){}
		public static void UpdateMaterials(Renderer renderer){}
		internal static void UpdateMaterialsForRenderer(Renderer renderer){}
		public static void UpdateMaterials(Terrain terrain){}
		public static void UpdateMaterials(Terrain terrain, int x, int y, int width, int height){}
		internal static void UpdateMaterialsForTerrain(Terrain terrain, Rect uvBounds){}
		private static void INTERNAL_CALL_UpdateMaterialsForTerrain(Terrain terrain, ref Rect uvBounds){}
		public static void UpdateEnvironment(){}
		public DynamicGI(){}
		public static float indirectScale{ get	{} set	{} }
		public static float updateThreshold{ get	{} set	{} }
		public static bool synchronousMode{ get	{} set	{} }
	}

	public sealed class	ParticleSystem: Component
	{
		private void INTERNAL_get_startColor(out Color value){}
		private void INTERNAL_set_startColor(ref Color value){}
		public void SetParticles(Particle[] particles, int size){}
		public int GetParticles(Particle[] particles){}
		private void Internal_Simulate(float t, bool restart){}
		private void Internal_Play(){}
		private void Internal_Stop(){}
		private void Internal_Pause(){}
		private void Internal_Clear(){}
		private bool Internal_IsAlive(){}
		public void Simulate(float t, bool withChildren){}
		public void Simulate(float t){}
		public void Simulate(float t, bool withChildren, bool restart){}
		public void Play(){}
		public void Play(bool withChildren){}
		public void Stop(){}
		public void Stop(bool withChildren){}
		public void Pause(){}
		public void Pause(bool withChildren){}
		public void Clear(){}
		public void Clear(bool withChildren){}
		public bool IsAlive(){}
		public bool IsAlive(bool withChildren){}
		public void Emit(int count){}
		private static void INTERNAL_CALL_Emit(ParticleSystem self, int count){}
		public void Emit(Vector3 position, Vector3 velocity, float size, float lifetime, Color32 color){}
		public void Emit(Particle particle){}
		private void Internal_Emit(ref Particle particle){}
		internal static ParticleSystem[] GetParticleSystems(ParticleSystem root){}
		private static void GetDirectParticleSystemChildrenRecursive(Transform transform, List<ParticleSystem> particleSystems){}
		internal void SetupDefaultType(int type){}
		public ParticleSystem(){}
		public float startDelay{ get	{} set	{} }
		public bool isPlaying{ get	{} }
		public bool isStopped{ get	{} }
		public bool isPaused{ get	{} }
		public bool loop{ get	{} set	{} }
		public bool playOnAwake{ get	{} set	{} }
		public float time{ get	{} set	{} }
		public float duration{ get	{} }
		public float playbackSpeed{ get	{} set	{} }
		public int particleCount{ get	{} }
		public int safeCollisionEventSize{ get	{} }
		public bool enableEmission{ get	{} set	{} }
		public float emissionRate{ get	{} set	{} }
		public float startSpeed{ get	{} set	{} }
		public float startSize{ get	{} set	{} }
		public Color startColor{ get	{} set	{} }
		public float startRotation{ get	{} set	{} }
		public float startLifetime{ get	{} set	{} }
		public float gravityModifier{ get	{} set	{} }
		public int maxParticles{ get	{} set	{} }
		public ParticleSystemSimulationSpace simulationSpace{ get	{} set	{} }
		public uint randomSeed{ get	{} set	{} }
	}

	public sealed class	ParticleSystemRenderer: Renderer
	{
		public ParticleSystemRenderer(){}
		public ParticleSystemRenderMode renderMode{ get	{} set	{} }
		public float lengthScale{ get	{} set	{} }
		public float velocityScale{ get	{} set	{} }
		public float cameraVelocityScale{ get	{} set	{} }
		public float maxParticleSize{ get	{} set	{} }
		public Mesh mesh{ get	{} set	{} }
		bool editorEnabled{ get	{} set	{} }
	}

	public sealed abstract	class	ParticlePhysicsExtensions: Object
	{
		public static int GetSafeCollisionEventSize(ParticleSystem ps){}
		public static int GetCollisionEvents(ParticleSystem ps, GameObject go, ParticleCollisionEvent[] collisionEvents){}
	}

	public class	ParticleEmitter: Component
	{
		private void INTERNAL_get_worldVelocity(out Vector3 value){}
		private void INTERNAL_set_worldVelocity(ref Vector3 value){}
		private void INTERNAL_get_localVelocity(out Vector3 value){}
		private void INTERNAL_set_localVelocity(ref Vector3 value){}
		private void INTERNAL_get_rndVelocity(out Vector3 value){}
		private void INTERNAL_set_rndVelocity(ref Vector3 value){}
		public void ClearParticles(){}
		private static void INTERNAL_CALL_ClearParticles(ParticleEmitter self){}
		public void Emit(){}
		public void Emit(int count){}
		public void Emit(Vector3 pos, Vector3 velocity, float size, float energy, Color color){}
		public void Emit(Vector3 pos, Vector3 velocity, float size, float energy, Color color, float rotation, float angularVelocity){}
		private void Emit2(int count){}
		private void Emit3(ref InternalEmitParticleArguments args){}
		public void Simulate(float deltaTime){}
		internal ParticleEmitter(){}
		public bool emit{ get	{} set	{} }
		public float minSize{ get	{} set	{} }
		public float maxSize{ get	{} set	{} }
		public float minEnergy{ get	{} set	{} }
		public float maxEnergy{ get	{} set	{} }
		public float minEmission{ get	{} set	{} }
		public float maxEmission{ get	{} set	{} }
		public float emitterVelocityScale{ get	{} set	{} }
		public Vector3 worldVelocity{ get	{} set	{} }
		public Vector3 localVelocity{ get	{} set	{} }
		public Vector3 rndVelocity{ get	{} set	{} }
		public bool useWorldSpace{ get	{} set	{} }
		public bool rndRotation{ get	{} set	{} }
		public float angularVelocity{ get	{} set	{} }
		public float rndAngularVelocity{ get	{} set	{} }
		public Particle[] particles{ get	{} set	{} }
		public int particleCount{ get	{} }
		public bool enabled{ get	{} set	{} }
	}

	public sealed class	EllipsoidParticleEmitter: ParticleEmitter
	{
		internal EllipsoidParticleEmitter(){}
	}

	public sealed class	MeshParticleEmitter: ParticleEmitter
	{
		internal MeshParticleEmitter(){}
	}

	public sealed class	ParticleAnimator: Component
	{
		private void INTERNAL_get_worldRotationAxis(out Vector3 value){}
		private void INTERNAL_set_worldRotationAxis(ref Vector3 value){}
		private void INTERNAL_get_localRotationAxis(out Vector3 value){}
		private void INTERNAL_set_localRotationAxis(ref Vector3 value){}
		private void INTERNAL_get_rndForce(out Vector3 value){}
		private void INTERNAL_set_rndForce(ref Vector3 value){}
		private void INTERNAL_get_force(out Vector3 value){}
		private void INTERNAL_set_force(ref Vector3 value){}
		public ParticleAnimator(){}
		public bool doesAnimateColor{ get	{} set	{} }
		public Vector3 worldRotationAxis{ get	{} set	{} }
		public Vector3 localRotationAxis{ get	{} set	{} }
		public float sizeGrow{ get	{} set	{} }
		public Vector3 rndForce{ get	{} set	{} }
		public Vector3 force{ get	{} set	{} }
		public float damping{ get	{} set	{} }
		public bool autodestruct{ get	{} set	{} }
		public Color[] colorAnimation{ get	{} set	{} }
	}

	public sealed class	ParticleRenderer: Renderer
	{
		public ParticleRenderer(){}
		public ParticleRenderMode particleRenderMode{ get	{} set	{} }
		public float lengthScale{ get	{} set	{} }
		public float velocityScale{ get	{} set	{} }
		public float cameraVelocityScale{ get	{} set	{} }
		public float maxParticleSize{ get	{} set	{} }
		public int uvAnimationXTile{ get	{} set	{} }
		public int uvAnimationYTile{ get	{} set	{} }
		public float uvAnimationCycles{ get	{} set	{} }
		public int animatedTextureCount{ get	{} set	{} }
		public float maxPartileSize{ get	{} set	{} }
		public Rect[] uvTiles{ get	{} set	{} }
		public AnimationCurve widthCurve{ get	{} set	{} }
		public AnimationCurve heightCurve{ get	{} set	{} }
		public AnimationCurve rotationCurve{ get	{} set	{} }
	}

	public class	Physics: Object
	{
		private static void INTERNAL_get_gravity(out Vector3 value){}
		private static void INTERNAL_set_gravity(ref Vector3 value){}
		private static bool Internal_Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layermask){}
		private static bool INTERNAL_CALL_Internal_Raycast(ref Vector3 origin, ref Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layermask){}
		private static bool Internal_CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layermask){}
		private static bool INTERNAL_CALL_Internal_CapsuleCast(ref Vector3 point1, ref Vector3 point2, float radius, ref Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layermask){}
		private static bool Internal_RaycastTest(Vector3 origin, Vector3 direction, float maxDistance, int layermask){}
		private static bool INTERNAL_CALL_Internal_RaycastTest(ref Vector3 origin, ref Vector3 direction, float maxDistance, int layermask){}
		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance){}
		public static bool Raycast(Vector3 origin, Vector3 direction){}
		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask){}
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance){}
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo){}
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask){}
		public static bool Raycast(Ray ray, float maxDistance){}
		public static bool Raycast(Ray ray){}
		public static bool Raycast(Ray ray, float maxDistance, int layerMask){}
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance){}
		public static bool Raycast(Ray ray, out RaycastHit hitInfo){}
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask){}
		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance){}
		public static RaycastHit[] RaycastAll(Ray ray){}
		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, int layerMask){}
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layermask){}
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance){}
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction){}
		private static RaycastHit[] INTERNAL_CALL_RaycastAll(ref Vector3 origin, ref Vector3 direction, float maxDistance, int layermask){}
		public static bool Linecast(Vector3 start, Vector3 end){}
		public static bool Linecast(Vector3 start, Vector3 end, int layerMask){}
		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo){}
		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask){}
		public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask){}
		public static Collider[] OverlapSphere(Vector3 position, float radius){}
		private static Collider[] INTERNAL_CALL_OverlapSphere(ref Vector3 position, float radius, int layerMask){}
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance){}
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction){}
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask){}
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance){}
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo){}
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask){}
		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance){}
		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo){}
		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask){}
		public static bool SphereCast(Ray ray, float radius, float maxDistance){}
		public static bool SphereCast(Ray ray, float radius){}
		public static bool SphereCast(Ray ray, float radius, float maxDistance, int layerMask){}
		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance){}
		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo){}
		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask){}
		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layermask){}
		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance){}
		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction){}
		private static RaycastHit[] INTERNAL_CALL_CapsuleCastAll(ref Vector3 point1, ref Vector3 point2, float radius, ref Vector3 direction, float maxDistance, int layermask){}
		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance){}
		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction){}
		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask){}
		public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance){}
		public static RaycastHit[] SphereCastAll(Ray ray, float radius){}
		public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask){}
		public static bool CheckSphere(Vector3 position, float radius, int layerMask){}
		public static bool CheckSphere(Vector3 position, float radius){}
		private static bool INTERNAL_CALL_CheckSphere(ref Vector3 position, float radius, int layerMask){}
		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layermask){}
		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius){}
		private static bool INTERNAL_CALL_CheckCapsule(ref Vector3 start, ref Vector3 end, float radius, int layermask){}
		public static void IgnoreCollision(Collider collider1, Collider collider2, bool ignore){}
		public static void IgnoreCollision(Collider collider1, Collider collider2){}
		public static void IgnoreLayerCollision(int layer1, int layer2, bool ignore){}
		public static void IgnoreLayerCollision(int layer1, int layer2){}
		public static bool GetIgnoreLayerCollision(int layer1, int layer2){}
		public Physics(){}
		public static Vector3 gravity{ get	{} set	{} }
		public static float minPenetrationForPenalty{ get	{} set	{} }
		public static float defaultContactOffset{ get	{} set	{} }
		public static float bounceThreshold{ get	{} set	{} }
		public static float bounceTreshold{ get	{} set	{} }
		public static float sleepVelocity{ get	{} set	{} }
		public static float sleepAngularVelocity{ get	{} set	{} }
		public static float maxAngularVelocity{ get	{} set	{} }
		public static int solverIterationCount{ get	{} set	{} }
		public static float sleepThreshold{ get	{} set	{} }
		public static float penetrationPenaltyForce{ get	{} set	{} }
		public const int kIgnoreRaycastLayer = null;
		public const int kDefaultRaycastLayers = null;
		public const int kAllLayers = null;
		public const int IgnoreRaycastLayer = null;
		public const int DefaultRaycastLayers = null;
		public const int AllLayers = null;
	}

	public sealed class	Rigidbody: Component
	{
		public bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float maxDistance){}
		public bool SweepTest(Vector3 direction, out RaycastHit hitInfo){}
		private static bool INTERNAL_CALL_SweepTest(Rigidbody self, ref Vector3 direction, out RaycastHit hitInfo, float maxDistance){}
		public RaycastHit[] SweepTestAll(Vector3 direction, float maxDistance){}
		public RaycastHit[] SweepTestAll(Vector3 direction){}
		private static RaycastHit[] INTERNAL_CALL_SweepTestAll(Rigidbody self, ref Vector3 direction, float maxDistance){}
		public void SetMaxAngularVelocity(float a){}
		private void INTERNAL_get_velocity(out Vector3 value){}
		private void INTERNAL_set_velocity(ref Vector3 value){}
		private void INTERNAL_get_angularVelocity(out Vector3 value){}
		private void INTERNAL_set_angularVelocity(ref Vector3 value){}
		public void SetDensity(float density){}
		private static void INTERNAL_CALL_SetDensity(Rigidbody self, float density){}
		public void AddForce(Vector3 force, ForceMode mode){}
		public void AddForce(Vector3 force){}
		private static void INTERNAL_CALL_AddForce(Rigidbody self, ref Vector3 force, ForceMode mode){}
		public void AddForce(float x, float y, float z){}
		public void AddForce(float x, float y, float z, ForceMode mode){}
		public void AddRelativeForce(Vector3 force, ForceMode mode){}
		public void AddRelativeForce(Vector3 force){}
		private static void INTERNAL_CALL_AddRelativeForce(Rigidbody self, ref Vector3 force, ForceMode mode){}
		public void AddRelativeForce(float x, float y, float z){}
		public void AddRelativeForce(float x, float y, float z, ForceMode mode){}
		public void AddTorque(Vector3 torque, ForceMode mode){}
		public void AddTorque(Vector3 torque){}
		private static void INTERNAL_CALL_AddTorque(Rigidbody self, ref Vector3 torque, ForceMode mode){}
		public void AddTorque(float x, float y, float z){}
		public void AddTorque(float x, float y, float z, ForceMode mode){}
		public void AddRelativeTorque(Vector3 torque, ForceMode mode){}
		public void AddRelativeTorque(Vector3 torque){}
		private static void INTERNAL_CALL_AddRelativeTorque(Rigidbody self, ref Vector3 torque, ForceMode mode){}
		public void AddRelativeTorque(float x, float y, float z){}
		public void AddRelativeTorque(float x, float y, float z, ForceMode mode){}
		public void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode mode){}
		public void AddForceAtPosition(Vector3 force, Vector3 position){}
		private static void INTERNAL_CALL_AddForceAtPosition(Rigidbody self, ref Vector3 force, ref Vector3 position, ForceMode mode){}
		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier, ForceMode mode){}
		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier){}
		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius){}
		private static void INTERNAL_CALL_AddExplosionForce(Rigidbody self, float explosionForce, ref Vector3 explosionPosition, float explosionRadius, float upwardsModifier, ForceMode mode){}
		public Vector3 ClosestPointOnBounds(Vector3 position){}
		private static Vector3 INTERNAL_CALL_ClosestPointOnBounds(Rigidbody self, ref Vector3 position){}
		public Vector3 GetRelativePointVelocity(Vector3 relativePoint){}
		private static Vector3 INTERNAL_CALL_GetRelativePointVelocity(Rigidbody self, ref Vector3 relativePoint){}
		public Vector3 GetPointVelocity(Vector3 worldPoint){}
		private static Vector3 INTERNAL_CALL_GetPointVelocity(Rigidbody self, ref Vector3 worldPoint){}
		private void INTERNAL_get_centerOfMass(out Vector3 value){}
		private void INTERNAL_set_centerOfMass(ref Vector3 value){}
		private void INTERNAL_get_worldCenterOfMass(out Vector3 value){}
		private void INTERNAL_get_inertiaTensorRotation(out Quaternion value){}
		private void INTERNAL_set_inertiaTensorRotation(ref Quaternion value){}
		private void INTERNAL_get_inertiaTensor(out Vector3 value){}
		private void INTERNAL_set_inertiaTensor(ref Vector3 value){}
		private void INTERNAL_get_position(out Vector3 value){}
		private void INTERNAL_set_position(ref Vector3 value){}
		private void INTERNAL_get_rotation(out Quaternion value){}
		private void INTERNAL_set_rotation(ref Quaternion value){}
		public void MovePosition(Vector3 position){}
		private static void INTERNAL_CALL_MovePosition(Rigidbody self, ref Vector3 position){}
		public void MoveRotation(Quaternion rot){}
		private static void INTERNAL_CALL_MoveRotation(Rigidbody self, ref Quaternion rot){}
		public void Sleep(){}
		private static void INTERNAL_CALL_Sleep(Rigidbody self){}
		public bool IsSleeping(){}
		private static bool INTERNAL_CALL_IsSleeping(Rigidbody self){}
		public void WakeUp(){}
		private static void INTERNAL_CALL_WakeUp(Rigidbody self){}
		public Rigidbody(){}
		public Vector3 velocity{ get	{} set	{} }
		public Vector3 angularVelocity{ get	{} set	{} }
		public float drag{ get	{} set	{} }
		public float angularDrag{ get	{} set	{} }
		public float mass{ get	{} set	{} }
		public bool useGravity{ get	{} set	{} }
		public float maxDepenetrationVelocity{ get	{} set	{} }
		public bool isKinematic{ get	{} set	{} }
		public bool freezeRotation{ get	{} set	{} }
		public RigidbodyConstraints constraints{ get	{} set	{} }
		public CollisionDetectionMode collisionDetectionMode{ get	{} set	{} }
		public Vector3 centerOfMass{ get	{} set	{} }
		public Vector3 worldCenterOfMass{ get	{} }
		public Quaternion inertiaTensorRotation{ get	{} set	{} }
		public Vector3 inertiaTensor{ get	{} set	{} }
		public bool detectCollisions{ get	{} set	{} }
		public bool useConeFriction{ get	{} set	{} }
		public Vector3 position{ get	{} set	{} }
		public Quaternion rotation{ get	{} set	{} }
		public RigidbodyInterpolation interpolation{ get	{} set	{} }
		public int solverIterationCount{ get	{} set	{} }
		public float sleepVelocity{ get	{} set	{} }
		public float sleepAngularVelocity{ get	{} set	{} }
		public float sleepThreshold{ get	{} set	{} }
		public float maxAngularVelocity{ get	{} set	{} }
	}

	public class	Joint: Component
	{
		private void INTERNAL_get_axis(out Vector3 value){}
		private void INTERNAL_set_axis(ref Vector3 value){}
		private void INTERNAL_get_anchor(out Vector3 value){}
		private void INTERNAL_set_anchor(ref Vector3 value){}
		private void INTERNAL_get_connectedAnchor(out Vector3 value){}
		private void INTERNAL_set_connectedAnchor(ref Vector3 value){}
		public Joint(){}
		public Rigidbody connectedBody{ get	{} set	{} }
		public Vector3 axis{ get	{} set	{} }
		public Vector3 anchor{ get	{} set	{} }
		public Vector3 connectedAnchor{ get	{} set	{} }
		public bool autoConfigureConnectedAnchor{ get	{} set	{} }
		public float breakForce{ get	{} set	{} }
		public float breakTorque{ get	{} set	{} }
		public bool enableCollision{ get	{} set	{} }
		public bool enablePreprocessing{ get	{} set	{} }
	}

	public sealed class	HingeJoint: Joint
	{
		private void INTERNAL_get_motor(out JointMotor value){}
		private void INTERNAL_set_motor(ref JointMotor value){}
		private void INTERNAL_get_limits(out JointLimits value){}
		private void INTERNAL_set_limits(ref JointLimits value){}
		private void INTERNAL_get_spring(out JointSpring value){}
		private void INTERNAL_set_spring(ref JointSpring value){}
		public HingeJoint(){}
		public JointMotor motor{ get	{} set	{} }
		public JointLimits limits{ get	{} set	{} }
		public JointSpring spring{ get	{} set	{} }
		public bool useMotor{ get	{} set	{} }
		public bool useLimits{ get	{} set	{} }
		public bool useSpring{ get	{} set	{} }
		public float velocity{ get	{} }
		public float angle{ get	{} }
	}

	public sealed class	SpringJoint: Joint
	{
		public SpringJoint(){}
		public float spring{ get	{} set	{} }
		public float damper{ get	{} set	{} }
		public float minDistance{ get	{} set	{} }
		public float maxDistance{ get	{} set	{} }
	}

	public sealed class	FixedJoint: Joint
	{
		public FixedJoint(){}
	}

	public sealed class	CharacterJoint: Joint
	{
		private void INTERNAL_get_swingAxis(out Vector3 value){}
		private void INTERNAL_set_swingAxis(ref Vector3 value){}
		private void INTERNAL_get_twistLimitSpring(out SoftJointLimitSpring value){}
		private void INTERNAL_set_twistLimitSpring(ref SoftJointLimitSpring value){}
		private void INTERNAL_get_swingLimitSpring(out SoftJointLimitSpring value){}
		private void INTERNAL_set_swingLimitSpring(ref SoftJointLimitSpring value){}
		private void INTERNAL_get_lowTwistLimit(out SoftJointLimit value){}
		private void INTERNAL_set_lowTwistLimit(ref SoftJointLimit value){}
		private void INTERNAL_get_highTwistLimit(out SoftJointLimit value){}
		private void INTERNAL_set_highTwistLimit(ref SoftJointLimit value){}
		private void INTERNAL_get_swing1Limit(out SoftJointLimit value){}
		private void INTERNAL_set_swing1Limit(ref SoftJointLimit value){}
		private void INTERNAL_get_swing2Limit(out SoftJointLimit value){}
		private void INTERNAL_set_swing2Limit(ref SoftJointLimit value){}
		public CharacterJoint(){}
		public Vector3 swingAxis{ get	{} set	{} }
		public SoftJointLimitSpring twistLimitSpring{ get	{} set	{} }
		public SoftJointLimitSpring swingLimitSpring{ get	{} set	{} }
		public SoftJointLimit lowTwistLimit{ get	{} set	{} }
		public SoftJointLimit highTwistLimit{ get	{} set	{} }
		public SoftJointLimit swing1Limit{ get	{} set	{} }
		public SoftJointLimit swing2Limit{ get	{} set	{} }
		public bool enableProjection{ get	{} set	{} }
		public float projectionDistance{ get	{} set	{} }
		public float projectionAngle{ get	{} set	{} }
		public Quaternion targetRotation;
		public Vector3 targetAngularVelocity;
		public JointDrive rotationDrive;
	}

	public sealed class	ConfigurableJoint: Joint
	{
		private void INTERNAL_get_secondaryAxis(out Vector3 value){}
		private void INTERNAL_set_secondaryAxis(ref Vector3 value){}
		private void INTERNAL_get_linearLimitSpring(out SoftJointLimitSpring value){}
		private void INTERNAL_set_linearLimitSpring(ref SoftJointLimitSpring value){}
		private void INTERNAL_get_angularXLimitSpring(out SoftJointLimitSpring value){}
		private void INTERNAL_set_angularXLimitSpring(ref SoftJointLimitSpring value){}
		private void INTERNAL_get_angularYZLimitSpring(out SoftJointLimitSpring value){}
		private void INTERNAL_set_angularYZLimitSpring(ref SoftJointLimitSpring value){}
		private void INTERNAL_get_linearLimit(out SoftJointLimit value){}
		private void INTERNAL_set_linearLimit(ref SoftJointLimit value){}
		private void INTERNAL_get_lowAngularXLimit(out SoftJointLimit value){}
		private void INTERNAL_set_lowAngularXLimit(ref SoftJointLimit value){}
		private void INTERNAL_get_highAngularXLimit(out SoftJointLimit value){}
		private void INTERNAL_set_highAngularXLimit(ref SoftJointLimit value){}
		private void INTERNAL_get_angularYLimit(out SoftJointLimit value){}
		private void INTERNAL_set_angularYLimit(ref SoftJointLimit value){}
		private void INTERNAL_get_angularZLimit(out SoftJointLimit value){}
		private void INTERNAL_set_angularZLimit(ref SoftJointLimit value){}
		private void INTERNAL_get_targetPosition(out Vector3 value){}
		private void INTERNAL_set_targetPosition(ref Vector3 value){}
		private void INTERNAL_get_targetVelocity(out Vector3 value){}
		private void INTERNAL_set_targetVelocity(ref Vector3 value){}
		private void INTERNAL_get_xDrive(out JointDrive value){}
		private void INTERNAL_set_xDrive(ref JointDrive value){}
		private void INTERNAL_get_yDrive(out JointDrive value){}
		private void INTERNAL_set_yDrive(ref JointDrive value){}
		private void INTERNAL_get_zDrive(out JointDrive value){}
		private void INTERNAL_set_zDrive(ref JointDrive value){}
		private void INTERNAL_get_targetRotation(out Quaternion value){}
		private void INTERNAL_set_targetRotation(ref Quaternion value){}
		private void INTERNAL_get_targetAngularVelocity(out Vector3 value){}
		private void INTERNAL_set_targetAngularVelocity(ref Vector3 value){}
		private void INTERNAL_get_angularXDrive(out JointDrive value){}
		private void INTERNAL_set_angularXDrive(ref JointDrive value){}
		private void INTERNAL_get_angularYZDrive(out JointDrive value){}
		private void INTERNAL_set_angularYZDrive(ref JointDrive value){}
		private void INTERNAL_get_slerpDrive(out JointDrive value){}
		private void INTERNAL_set_slerpDrive(ref JointDrive value){}
		public ConfigurableJoint(){}
		public Vector3 secondaryAxis{ get	{} set	{} }
		public ConfigurableJointMotion xMotion{ get	{} set	{} }
		public ConfigurableJointMotion yMotion{ get	{} set	{} }
		public ConfigurableJointMotion zMotion{ get	{} set	{} }
		public ConfigurableJointMotion angularXMotion{ get	{} set	{} }
		public ConfigurableJointMotion angularYMotion{ get	{} set	{} }
		public ConfigurableJointMotion angularZMotion{ get	{} set	{} }
		public SoftJointLimitSpring linearLimitSpring{ get	{} set	{} }
		public SoftJointLimitSpring angularXLimitSpring{ get	{} set	{} }
		public SoftJointLimitSpring angularYZLimitSpring{ get	{} set	{} }
		public SoftJointLimit linearLimit{ get	{} set	{} }
		public SoftJointLimit lowAngularXLimit{ get	{} set	{} }
		public SoftJointLimit highAngularXLimit{ get	{} set	{} }
		public SoftJointLimit angularYLimit{ get	{} set	{} }
		public SoftJointLimit angularZLimit{ get	{} set	{} }
		public Vector3 targetPosition{ get	{} set	{} }
		public Vector3 targetVelocity{ get	{} set	{} }
		public JointDrive xDrive{ get	{} set	{} }
		public JointDrive yDrive{ get	{} set	{} }
		public JointDrive zDrive{ get	{} set	{} }
		public Quaternion targetRotation{ get	{} set	{} }
		public Vector3 targetAngularVelocity{ get	{} set	{} }
		public RotationDriveMode rotationDriveMode{ get	{} set	{} }
		public JointDrive angularXDrive{ get	{} set	{} }
		public JointDrive angularYZDrive{ get	{} set	{} }
		public JointDrive slerpDrive{ get	{} set	{} }
		public JointProjectionMode projectionMode{ get	{} set	{} }
		public float projectionDistance{ get	{} set	{} }
		public float projectionAngle{ get	{} set	{} }
		public bool configuredInWorldSpace{ get	{} set	{} }
		public bool swapBodies{ get	{} set	{} }
	}

	public sealed class	ConstantForce: Behaviour
	{
		private void INTERNAL_get_force(out Vector3 value){}
		private void INTERNAL_set_force(ref Vector3 value){}
		private void INTERNAL_get_relativeForce(out Vector3 value){}
		private void INTERNAL_set_relativeForce(ref Vector3 value){}
		private void INTERNAL_get_torque(out Vector3 value){}
		private void INTERNAL_set_torque(ref Vector3 value){}
		private void INTERNAL_get_relativeTorque(out Vector3 value){}
		private void INTERNAL_set_relativeTorque(ref Vector3 value){}
		public ConstantForce(){}
		public Vector3 force{ get	{} set	{} }
		public Vector3 relativeForce{ get	{} set	{} }
		public Vector3 torque{ get	{} set	{} }
		public Vector3 relativeTorque{ get	{} set	{} }
	}

	public class	Collider: Component
	{
		public Vector3 ClosestPointOnBounds(Vector3 position){}
		private static Vector3 INTERNAL_CALL_ClosestPointOnBounds(Collider self, ref Vector3 position){}
		private void INTERNAL_get_bounds(out Bounds value){}
		private static bool Internal_Raycast(Collider col, Ray ray, out RaycastHit hitInfo, float maxDistance){}
		private static bool INTERNAL_CALL_Internal_Raycast(Collider col, ref Ray ray, out RaycastHit hitInfo, float maxDistance){}
		public bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance){}
		public Collider(){}
		public bool enabled{ get	{} set	{} }
		public Rigidbody attachedRigidbody{ get	{} }
		public bool isTrigger{ get	{} set	{} }
		public float contactOffset{ get	{} set	{} }
		public PhysicMaterial material{ get	{} set	{} }
		public PhysicMaterial sharedMaterial{ get	{} set	{} }
		public Bounds bounds{ get	{} }
	}

	public sealed class	BoxCollider: Collider
	{
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		private void INTERNAL_get_size(out Vector3 value){}
		private void INTERNAL_set_size(ref Vector3 value){}
		public BoxCollider(){}
		public Vector3 center{ get	{} set	{} }
		public Vector3 size{ get	{} set	{} }
		public Vector3 extents{ get	{} set	{} }
	}

	public sealed class	SphereCollider: Collider
	{
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		public SphereCollider(){}
		public Vector3 center{ get	{} set	{} }
		public float radius{ get	{} set	{} }
	}

	public sealed class	MeshCollider: Collider
	{
		public MeshCollider(){}
		public Mesh sharedMesh{ get	{} set	{} }
		public bool convex{ get	{} set	{} }
		public bool smoothSphereCollisions{ get	{} set	{} }
	}

	public sealed class	CapsuleCollider: Collider
	{
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		public CapsuleCollider(){}
		public Vector3 center{ get	{} set	{} }
		public float radius{ get	{} set	{} }
		public float height{ get	{} set	{} }
		public int direction{ get	{} set	{} }
	}

	public sealed class	WheelCollider: Collider
	{
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		private void INTERNAL_get_suspensionSpring(out JointSpring value){}
		private void INTERNAL_set_suspensionSpring(ref JointSpring value){}
		private void INTERNAL_get_forwardFriction(out WheelFrictionCurve value){}
		private void INTERNAL_set_forwardFriction(ref WheelFrictionCurve value){}
		private void INTERNAL_get_sidewaysFriction(out WheelFrictionCurve value){}
		private void INTERNAL_set_sidewaysFriction(ref WheelFrictionCurve value){}
		public void ConfigureVehicleSubsteps(float speedThreshold, int stepsBelowThreshold, int stepsAboveThreshold){}
		public bool GetGroundHit(out WheelHit hit){}
		public void GetWorldPose(out Vector3 pos, out Quaternion quat){}
		public WheelCollider(){}
		public Vector3 center{ get	{} set	{} }
		public float radius{ get	{} set	{} }
		public float suspensionDistance{ get	{} set	{} }
		public JointSpring suspensionSpring{ get	{} set	{} }
		public float forceAppPointDistance{ get	{} set	{} }
		public float mass{ get	{} set	{} }
		public float wheelDampingRate{ get	{} set	{} }
		public WheelFrictionCurve forwardFriction{ get	{} set	{} }
		public WheelFrictionCurve sidewaysFriction{ get	{} set	{} }
		public float motorTorque{ get	{} set	{} }
		public float brakeTorque{ get	{} set	{} }
		public float steerAngle{ get	{} set	{} }
		public bool isGrounded{ get	{} }
		public float sprungMass{ get	{} }
		public float rpm{ get	{} }
	}

	public sealed class	PhysicMaterial: Object
	{
		private static void Internal_CreateDynamicsMaterial(PhysicMaterial mat, string name){}
		private void INTERNAL_get_frictionDirection2(out Vector3 value){}
		private void INTERNAL_set_frictionDirection2(ref Vector3 value){}
		public PhysicMaterial(){}
		public PhysicMaterial(string name){}
		public float dynamicFriction{ get	{} set	{} }
		public float staticFriction{ get	{} set	{} }
		public float bounciness{ get	{} set	{} }
		public float bouncyness{ get	{} set	{} }
		public Vector3 frictionDirection2{ get	{} set	{} }
		public float dynamicFriction2{ get	{} set	{} }
		public float staticFriction2{ get	{} set	{} }
		public PhysicMaterialCombine frictionCombine{ get	{} set	{} }
		public PhysicMaterialCombine bounceCombine{ get	{} set	{} }
		public Vector3 frictionDirection{ get	{} set	{} }
	}

	public class	Collision: Object
	{
		public virtual IEnumerator GetEnumerator(){}
		public Collision(){}
		public Vector3 relativeVelocity{ get	{} }
		public Rigidbody rigidbody{ get	{} }
		public Collider collider{ get	{} }
		public Transform transform{ get	{} }
		public GameObject gameObject{ get	{} }
		public ContactPoint[] contacts{ get	{} }
		public Vector3 impactForceSum{ get	{} }
		public Vector3 frictionForceSum{ get	{} }
		public Component other{ get	{} }
		internal Vector3 m_RelativeVelocity;
		internal Rigidbody m_Rigidbody;
		internal Collider m_Collider;
		internal ContactPoint[] m_Contacts;
	}

	public sealed class	ControllerColliderHit: Object
	{
		public ControllerColliderHit(){}
		public CharacterController controller{ get	{} }
		public Collider collider{ get	{} }
		public Rigidbody rigidbody{ get	{} }
		public GameObject gameObject{ get	{} }
		public Transform transform{ get	{} }
		public Vector3 point{ get	{} }
		public Vector3 normal{ get	{} }
		public Vector3 moveDirection{ get	{} }
		public float moveLength{ get	{} }
		bool push{ get	{} set	{} }
		internal CharacterController m_Controller;
		internal Collider m_Collider;
		internal Vector3 m_Point;
		internal Vector3 m_Normal;
		internal Vector3 m_MoveDirection;
		internal float m_MoveLength;
		internal int m_Push;
	}

	public sealed class	CharacterController: Collider
	{
		public bool SimpleMove(Vector3 speed){}
		private static bool INTERNAL_CALL_SimpleMove(CharacterController self, ref Vector3 speed){}
		public CollisionFlags Move(Vector3 motion){}
		private static CollisionFlags INTERNAL_CALL_Move(CharacterController self, ref Vector3 motion){}
		private void INTERNAL_get_velocity(out Vector3 value){}
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		public CharacterController(){}
		public bool isGrounded{ get	{} }
		public Vector3 velocity{ get	{} }
		public CollisionFlags collisionFlags{ get	{} }
		public float radius{ get	{} set	{} }
		public float height{ get	{} set	{} }
		public Vector3 center{ get	{} set	{} }
		public float slopeLimit{ get	{} set	{} }
		public float stepOffset{ get	{} set	{} }
		public bool detectCollisions{ get	{} set	{} }
	}

	public sealed class	Cloth: Component
	{
		private void INTERNAL_get_externalAcceleration(out Vector3 value){}
		private void INTERNAL_set_externalAcceleration(ref Vector3 value){}
		private void INTERNAL_get_randomAcceleration(out Vector3 value){}
		private void INTERNAL_set_randomAcceleration(ref Vector3 value){}
		public void ClearTransformMotion(){}
		private static void INTERNAL_CALL_ClearTransformMotion(Cloth self){}
		public void SetEnabledFading(bool enabled, float interpolationTime){}
		public void SetEnabledFading(bool enabled){}
		public Cloth(){}
		public float sleepThreshold{ get	{} set	{} }
		public float bendingStiffness{ get	{} set	{} }
		public float stretchingStiffness{ get	{} set	{} }
		public float damping{ get	{} set	{} }
		public Vector3 externalAcceleration{ get	{} set	{} }
		public Vector3 randomAcceleration{ get	{} set	{} }
		public bool useGravity{ get	{} set	{} }
		public bool selfCollision{ get	{} set	{} }
		public bool enabled{ get	{} set	{} }
		public Vector3[] vertices{ get	{} }
		public Vector3[] normals{ get	{} }
		public float friction{ get	{} set	{} }
		public float collisionMassScale{ get	{} set	{} }
		public float useContinuousCollision{ get	{} set	{} }
		public float useVirtualParticles{ get	{} set	{} }
		public ClothSkinningCoefficient[] coefficients{ get	{} set	{} }
		public float worldVelocityScale{ get	{} set	{} }
		public float worldAccelerationScale{ get	{} set	{} }
		public bool solverFrequency{ get	{} set	{} }
		public CapsuleCollider[] capsuleColliders{ get	{} set	{} }
		public ClothSphereColliderPair[] sphereColliders{ get	{} set	{} }
	}

	public class	Physics2D: Object
	{
		private static int INTERNAL_CALL_CircleCastNonAlloc(ref Vector2 origin, float radius, ref Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth){}
		private static void Internal_BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		private static void INTERNAL_CALL_Internal_BoxCast(ref Vector2 origin, ref Vector2 size, float angle, ref Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth){}
		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask){}
		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance){}
		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction){}
		public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth){}
		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask){}
		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance){}
		public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction){}
		private static RaycastHit2D[] INTERNAL_CALL_BoxCastAll(ref Vector2 origin, ref Vector2 size, float angle, ref Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth){}
		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth){}
		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask){}
		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance){}
		public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results){}
		private static int INTERNAL_CALL_BoxCastNonAlloc(ref Vector2 origin, ref Vector2 size, float angle, ref Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth){}
		private static void Internal_GetRayIntersection(Ray ray, float distance, int layerMask, out RaycastHit2D raycastHit){}
		private static void INTERNAL_CALL_Internal_GetRayIntersection(ref Ray ray, float distance, int layerMask, out RaycastHit2D raycastHit){}
		public static RaycastHit2D GetRayIntersection(Ray ray, float distance){}
		public static RaycastHit2D GetRayIntersection(Ray ray){}
		public static RaycastHit2D GetRayIntersection(Ray ray, float distance, int layerMask){}
		public static RaycastHit2D[] GetRayIntersectionAll(Ray ray, float distance, int layerMask){}
		public static RaycastHit2D[] GetRayIntersectionAll(Ray ray, float distance){}
		public static RaycastHit2D[] GetRayIntersectionAll(Ray ray){}
		private static RaycastHit2D[] INTERNAL_CALL_GetRayIntersectionAll(ref Ray ray, float distance, int layerMask){}
		public static int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results, float distance, int layerMask){}
		public static int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results, float distance){}
		public static int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results){}
		private static int INTERNAL_CALL_GetRayIntersectionNonAlloc(ref Ray ray, RaycastHit2D[] results, float distance, int layerMask){}
		public static Collider2D OverlapPoint(Vector2 point, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D OverlapPoint(Vector2 point, int layerMask, float minDepth){}
		public static Collider2D OverlapPoint(Vector2 point, int layerMask){}
		public static Collider2D OverlapPoint(Vector2 point){}
		private static Collider2D INTERNAL_CALL_OverlapPoint(ref Vector2 point, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float minDepth){}
		public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask){}
		public static Collider2D[] OverlapPointAll(Vector2 point){}
		private static Collider2D[] INTERNAL_CALL_OverlapPointAll(ref Vector2 point, int layerMask, float minDepth, float maxDepth){}
		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth, float maxDepth){}
		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth){}
		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask){}
		public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results){}
		private static int INTERNAL_CALL_OverlapPointNonAlloc(ref Vector2 point, Collider2D[] results, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, float minDepth){}
		public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask){}
		public static Collider2D OverlapCircle(Vector2 point, float radius){}
		private static Collider2D INTERNAL_CALL_OverlapCircle(ref Vector2 point, float radius, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, float minDepth){}
		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask){}
		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius){}
		private static Collider2D[] INTERNAL_CALL_OverlapCircleAll(ref Vector2 point, float radius, int layerMask, float minDepth, float maxDepth){}
		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth, float maxDepth){}
		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth){}
		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask){}
		public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results){}
		private static int INTERNAL_CALL_OverlapCircleNonAlloc(ref Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth){}
		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask){}
		public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB){}
		private static Collider2D INTERNAL_CALL_OverlapArea(ref Vector2 pointA, ref Vector2 pointB, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth){}
		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth){}
		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask){}
		public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB){}
		private static Collider2D[] INTERNAL_CALL_OverlapAreaAll(ref Vector2 pointA, ref Vector2 pointB, int layerMask, float minDepth, float maxDepth){}
		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth, float maxDepth){}
		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth){}
		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask){}
		public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results){}
		private static int INTERNAL_CALL_OverlapAreaNonAlloc(ref Vector2 pointA, ref Vector2 pointB, Collider2D[] results, int layerMask, float minDepth, float maxDepth){}
		private static void INTERNAL_get_gravity(out Vector2 value){}
		private static void INTERNAL_set_gravity(ref Vector2 value){}
		public static void IgnoreCollision(Collider2D collider1, Collider2D collider2, bool ignore){}
		public static void IgnoreCollision(Collider2D collider1, Collider2D collider2){}
		public static bool GetIgnoreCollision(Collider2D collider1, Collider2D collider2){}
		public static void IgnoreLayerCollision(int layer1, int layer2, bool ignore){}
		public static void IgnoreLayerCollision(int layer1, int layer2){}
		public static bool GetIgnoreLayerCollision(int layer1, int layer2){}
		public static bool IsTouching(Collider2D collider1, Collider2D collider2){}
		public static bool IsTouchingLayers(Collider2D collider, int layerMask){}
		public static bool IsTouchingLayers(Collider2D collider){}
		internal static void SetEditorDragMovement(bool dragging, GameObject[] objs){}
		private static void Internal_Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		private static void INTERNAL_CALL_Internal_Linecast(ref Vector2 start, ref Vector2 end, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth){}
		public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask){}
		public static RaycastHit2D Linecast(Vector2 start, Vector2 end){}
		public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, float minDepth){}
		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask){}
		public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end){}
		private static RaycastHit2D[] INTERNAL_CALL_LinecastAll(ref Vector2 start, ref Vector2 end, int layerMask, float minDepth, float maxDepth){}
		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth, float maxDepth){}
		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth){}
		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask){}
		public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results){}
		private static int INTERNAL_CALL_LinecastNonAlloc(ref Vector2 start, ref Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth, float maxDepth){}
		private static void Internal_Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		private static void INTERNAL_CALL_Internal_Raycast(ref Vector2 origin, ref Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth){}
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask){}
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance){}
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction){}
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth){}
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask){}
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance){}
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction){}
		private static RaycastHit2D[] INTERNAL_CALL_RaycastAll(ref Vector2 origin, ref Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth){}
		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth){}
		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask){}
		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance){}
		public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results){}
		private static int INTERNAL_CALL_RaycastNonAlloc(ref Vector2 origin, ref Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth){}
		private static void Internal_CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		private static void INTERNAL_CALL_Internal_CircleCast(ref Vector2 origin, float radius, ref Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D raycastHit){}
		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth){}
		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask){}
		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance){}
		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction){}
		public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth){}
		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask){}
		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance){}
		public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction){}
		private static RaycastHit2D[] INTERNAL_CALL_CircleCastAll(ref Vector2 origin, float radius, ref Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth){}
		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth){}
		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth){}
		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask){}
		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance){}
		public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results){}
		public Physics2D(){}
		private static Physics2D(){}
		public static int velocityIterations{ get	{} set	{} }
		public static int positionIterations{ get	{} set	{} }
		public static Vector2 gravity{ get	{} set	{} }
		public static bool raycastsHitTriggers{ get	{} set	{} }
		public static bool raycastsStartInColliders{ get	{} set	{} }
		public static bool deleteStopsCallbacks{ get	{} set	{} }
		public static bool changeStopsCallbacks{ get	{} set	{} }
		public static float velocityThreshold{ get	{} set	{} }
		public static float maxLinearCorrection{ get	{} set	{} }
		public static float maxAngularCorrection{ get	{} set	{} }
		public static float maxTranslationSpeed{ get	{} set	{} }
		public static float maxRotationSpeed{ get	{} set	{} }
		public static float minPenetrationForPenalty{ get	{} set	{} }
		public static float baumgarteScale{ get	{} set	{} }
		public static float baumgarteTOIScale{ get	{} set	{} }
		public static float timeToSleep{ get	{} set	{} }
		public static float linearSleepTolerance{ get	{} set	{} }
		public static float angularSleepTolerance{ get	{} set	{} }
		private static List<Rigidbody2D> m_LastDisabledRigidbody2D;
		public const int IgnoreRaycastLayer = null;
		public const int DefaultRaycastLayers = null;
		public const int AllLayers = null;
	}

	public sealed class	Rigidbody2D: Component
	{
		private void INTERNAL_get_position(out Vector2 value){}
		private void INTERNAL_set_position(ref Vector2 value){}
		public void MovePosition(Vector2 position){}
		private static void INTERNAL_CALL_MovePosition(Rigidbody2D self, ref Vector2 position){}
		public void MoveRotation(float angle){}
		private static void INTERNAL_CALL_MoveRotation(Rigidbody2D self, float angle){}
		private void INTERNAL_get_velocity(out Vector2 value){}
		private void INTERNAL_set_velocity(ref Vector2 value){}
		private void INTERNAL_get_centerOfMass(out Vector2 value){}
		private void INTERNAL_set_centerOfMass(ref Vector2 value){}
		private void INTERNAL_get_worldCenterOfMass(out Vector2 value){}
		public bool IsSleeping(){}
		public bool IsAwake(){}
		public void Sleep(){}
		public void WakeUp(){}
		public void AddForce(Vector2 force, ForceMode2D mode){}
		public void AddForce(Vector2 force){}
		private static void INTERNAL_CALL_AddForce(Rigidbody2D self, ref Vector2 force, ForceMode2D mode){}
		public void AddRelativeForce(Vector2 relativeForce, ForceMode2D mode){}
		public void AddRelativeForce(Vector2 relativeForce){}
		private static void INTERNAL_CALL_AddRelativeForce(Rigidbody2D self, ref Vector2 relativeForce, ForceMode2D mode){}
		public void AddForceAtPosition(Vector2 force, Vector2 position, ForceMode2D mode){}
		public void AddForceAtPosition(Vector2 force, Vector2 position){}
		private static void INTERNAL_CALL_AddForceAtPosition(Rigidbody2D self, ref Vector2 force, ref Vector2 position, ForceMode2D mode){}
		public void AddTorque(float torque, ForceMode2D mode){}
		public void AddTorque(float torque){}
		public Vector2 GetPoint(Vector2 point){}
		private static void Rigidbody2D_CUSTOM_INTERNAL_GetPoint(Rigidbody2D rigidbody, Vector2 point, out Vector2 value){}
		private static void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetPoint(Rigidbody2D rigidbody, ref Vector2 point, out Vector2 value){}
		public Vector2 GetRelativePoint(Vector2 relativePoint){}
		private static void Rigidbody2D_CUSTOM_INTERNAL_GetRelativePoint(Rigidbody2D rigidbody, Vector2 relativePoint, out Vector2 value){}
		private static void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativePoint(Rigidbody2D rigidbody, ref Vector2 relativePoint, out Vector2 value){}
		public Vector2 GetVector(Vector2 vector){}
		private static void Rigidbody2D_CUSTOM_INTERNAL_GetVector(Rigidbody2D rigidbody, Vector2 vector, out Vector2 value){}
		private static void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetVector(Rigidbody2D rigidbody, ref Vector2 vector, out Vector2 value){}
		public Vector2 GetRelativeVector(Vector2 relativeVector){}
		private static void Rigidbody2D_CUSTOM_INTERNAL_GetRelativeVector(Rigidbody2D rigidbody, Vector2 relativeVector, out Vector2 value){}
		private static void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativeVector(Rigidbody2D rigidbody, ref Vector2 relativeVector, out Vector2 value){}
		public Vector2 GetPointVelocity(Vector2 point){}
		private static void Rigidbody2D_CUSTOM_INTERNAL_GetPointVelocity(Rigidbody2D rigidbody, Vector2 point, out Vector2 value){}
		private static void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetPointVelocity(Rigidbody2D rigidbody, ref Vector2 point, out Vector2 value){}
		public Vector2 GetRelativePointVelocity(Vector2 relativePoint){}
		private static void Rigidbody2D_CUSTOM_INTERNAL_GetRelativePointVelocity(Rigidbody2D rigidbody, Vector2 relativePoint, out Vector2 value){}
		private static void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativePointVelocity(Rigidbody2D rigidbody, ref Vector2 relativePoint, out Vector2 value){}
		public Rigidbody2D(){}
		public Vector2 position{ get	{} set	{} }
		public float rotation{ get	{} set	{} }
		public Vector2 velocity{ get	{} set	{} }
		public float angularVelocity{ get	{} set	{} }
		public float mass{ get	{} set	{} }
		public Vector2 centerOfMass{ get	{} set	{} }
		public Vector2 worldCenterOfMass{ get	{} }
		public float inertia{ get	{} set	{} }
		public float drag{ get	{} set	{} }
		public float angularDrag{ get	{} set	{} }
		public float gravityScale{ get	{} set	{} }
		public bool isKinematic{ get	{} set	{} }
		public bool fixedAngle{ get	{} set	{} }
		public bool simulated{ get	{} set	{} }
		public RigidbodyInterpolation2D interpolation{ get	{} set	{} }
		public RigidbodySleepMode2D sleepMode{ get	{} set	{} }
		public CollisionDetectionMode2D collisionDetectionMode{ get	{} set	{} }
	}

	public class	Collider2D: Behaviour
	{
		private void INTERNAL_get_offset(out Vector2 value){}
		private void INTERNAL_set_offset(ref Vector2 value){}
		private void INTERNAL_get_bounds(out Bounds value){}
		public bool OverlapPoint(Vector2 point){}
		private static bool INTERNAL_CALL_OverlapPoint(Collider2D self, ref Vector2 point){}
		public bool IsTouching(Collider2D collider){}
		public bool IsTouchingLayers(int layerMask){}
		public bool IsTouchingLayers(){}
		public Collider2D(){}
		public bool isTrigger{ get	{} set	{} }
		public bool usedByEffector{ get	{} set	{} }
		public Vector2 offset{ get	{} set	{} }
		public Rigidbody2D attachedRigidbody{ get	{} }
		public int shapeCount{ get	{} }
		public Bounds bounds{ get	{} }
		ColliderErrorState2D errorState{ get	{} }
		public PhysicsMaterial2D sharedMaterial{ get	{} set	{} }
	}

	public sealed class	CircleCollider2D: Collider2D
	{
		public CircleCollider2D(){}
		public float radius{ get	{} set	{} }
		public Vector2 center{ get	{} set	{} }
	}

	public sealed class	BoxCollider2D: Collider2D
	{
		private void INTERNAL_get_size(out Vector2 value){}
		private void INTERNAL_set_size(ref Vector2 value){}
		public BoxCollider2D(){}
		public Vector2 size{ get	{} set	{} }
		public Vector2 center{ get	{} set	{} }
	}

	public sealed class	EdgeCollider2D: Collider2D
	{
		public void Reset(){}
		public EdgeCollider2D(){}
		public int edgeCount{ get	{} }
		public int pointCount{ get	{} }
		public Vector2[] points{ get	{} set	{} }
	}

	public sealed class	PolygonCollider2D: Collider2D
	{
		public Vector2[] GetPath(int index){}
		public void SetPath(int index, Vector2[] points){}
		public int GetTotalPointCount(){}
		public void CreatePrimitive(int sides, Vector2 scale, Vector2 offset){}
		public void CreatePrimitive(int sides, Vector2 scale){}
		public void CreatePrimitive(int sides){}
		private static void INTERNAL_CALL_CreatePrimitive(PolygonCollider2D self, int sides, ref Vector2 scale, ref Vector2 offset){}
		public PolygonCollider2D(){}
		public Vector2[] points{ get	{} set	{} }
		public int pathCount{ get	{} set	{} }
	}

	public class	Collision2D: Object
	{
		public Collision2D(){}
		public bool enabled{ get	{} }
		public Rigidbody2D rigidbody{ get	{} }
		public Collider2D collider{ get	{} }
		public Transform transform{ get	{} }
		public GameObject gameObject{ get	{} }
		public ContactPoint2D[] contacts{ get	{} }
		public Vector2 relativeVelocity{ get	{} }
		internal Rigidbody2D m_Rigidbody;
		internal Collider2D m_Collider;
		internal ContactPoint2D[] m_Contacts;
		internal Vector2 m_RelativeVelocity;
		internal bool m_Enabled;
	}

	public class	Joint2D: Behaviour
	{
		public Joint2D(){}
		public Rigidbody2D connectedBody{ get	{} set	{} }
		public bool collideConnected{ get	{} set	{} }
		public bool enableCollision{ get	{} set	{} }
	}

	public class	AnchoredJoint2D: Joint2D
	{
		private void INTERNAL_get_anchor(out Vector2 value){}
		private void INTERNAL_set_anchor(ref Vector2 value){}
		private void INTERNAL_get_connectedAnchor(out Vector2 value){}
		private void INTERNAL_set_connectedAnchor(ref Vector2 value){}
		public AnchoredJoint2D(){}
		public Vector2 anchor{ get	{} set	{} }
		public Vector2 connectedAnchor{ get	{} set	{} }
	}

	public sealed class	SpringJoint2D: AnchoredJoint2D
	{
		public Vector2 GetReactionForce(float timeStep){}
		private static void SpringJoint2D_CUSTOM_INTERNAL_GetReactionForce(SpringJoint2D joint, float timeStep, out Vector2 value){}
		public float GetReactionTorque(float timeStep){}
		private static float INTERNAL_CALL_GetReactionTorque(SpringJoint2D self, float timeStep){}
		public SpringJoint2D(){}
		public float distance{ get	{} set	{} }
		public float dampingRatio{ get	{} set	{} }
		public float frequency{ get	{} set	{} }
	}

	public sealed class	DistanceJoint2D: AnchoredJoint2D
	{
		public Vector2 GetReactionForce(float timeStep){}
		private static void DistanceJoint2D_CUSTOM_INTERNAL_GetReactionForce(DistanceJoint2D joint, float timeStep, out Vector2 value){}
		public float GetReactionTorque(float timeStep){}
		private static float INTERNAL_CALL_GetReactionTorque(DistanceJoint2D self, float timeStep){}
		public DistanceJoint2D(){}
		public float distance{ get	{} set	{} }
		public bool maxDistanceOnly{ get	{} set	{} }
	}

	public sealed class	HingeJoint2D: AnchoredJoint2D
	{
		private void INTERNAL_get_motor(out JointMotor2D value){}
		private void INTERNAL_set_motor(ref JointMotor2D value){}
		private void INTERNAL_get_limits(out JointAngleLimits2D value){}
		private void INTERNAL_set_limits(ref JointAngleLimits2D value){}
		public Vector2 GetReactionForce(float timeStep){}
		private static void HingeJoint2D_CUSTOM_INTERNAL_GetReactionForce(HingeJoint2D joint, float timeStep, out Vector2 value){}
		public float GetReactionTorque(float timeStep){}
		private static float INTERNAL_CALL_GetReactionTorque(HingeJoint2D self, float timeStep){}
		public float GetMotorTorque(float timeStep){}
		private static float INTERNAL_CALL_GetMotorTorque(HingeJoint2D self, float timeStep){}
		public HingeJoint2D(){}
		public bool useMotor{ get	{} set	{} }
		public bool useLimits{ get	{} set	{} }
		public JointMotor2D motor{ get	{} set	{} }
		public JointAngleLimits2D limits{ get	{} set	{} }
		public JointLimitState2D limitState{ get	{} }
		public float referenceAngle{ get	{} }
		public float jointAngle{ get	{} }
		public float jointSpeed{ get	{} }
	}

	public sealed class	SliderJoint2D: AnchoredJoint2D
	{
		private void INTERNAL_get_motor(out JointMotor2D value){}
		private void INTERNAL_set_motor(ref JointMotor2D value){}
		private void INTERNAL_get_limits(out JointTranslationLimits2D value){}
		private void INTERNAL_set_limits(ref JointTranslationLimits2D value){}
		public float GetMotorForce(float timeStep){}
		private static float INTERNAL_CALL_GetMotorForce(SliderJoint2D self, float timeStep){}
		public SliderJoint2D(){}
		public float angle{ get	{} set	{} }
		public bool useMotor{ get	{} set	{} }
		public bool useLimits{ get	{} set	{} }
		public JointMotor2D motor{ get	{} set	{} }
		public JointTranslationLimits2D limits{ get	{} set	{} }
		public JointLimitState2D limitState{ get	{} }
		public float referenceAngle{ get	{} }
		public float jointTranslation{ get	{} }
		public float jointSpeed{ get	{} }
	}

	public sealed class	WheelJoint2D: AnchoredJoint2D
	{
		private void INTERNAL_get_suspension(out JointSuspension2D value){}
		private void INTERNAL_set_suspension(ref JointSuspension2D value){}
		private void INTERNAL_get_motor(out JointMotor2D value){}
		private void INTERNAL_set_motor(ref JointMotor2D value){}
		public float GetMotorTorque(float timeStep){}
		private static float INTERNAL_CALL_GetMotorTorque(WheelJoint2D self, float timeStep){}
		public WheelJoint2D(){}
		public JointSuspension2D suspension{ get	{} set	{} }
		public bool useMotor{ get	{} set	{} }
		public JointMotor2D motor{ get	{} set	{} }
		public float jointTranslation{ get	{} }
		public float jointSpeed{ get	{} }
	}

	public sealed class	PhysicsMaterial2D: Object
	{
		private static void Internal_Create(PhysicsMaterial2D mat, string name){}
		public PhysicsMaterial2D(){}
		public PhysicsMaterial2D(string name){}
		public float bounciness{ get	{} set	{} }
		public float friction{ get	{} set	{} }
	}

	public class	PhysicsUpdateBehaviour2D: Behaviour
	{
		public PhysicsUpdateBehaviour2D(){}
	}

	public sealed class	ConstantForce2D: PhysicsUpdateBehaviour2D
	{
		private void INTERNAL_get_force(out Vector2 value){}
		private void INTERNAL_set_force(ref Vector2 value){}
		private void INTERNAL_get_relativeForce(out Vector2 value){}
		private void INTERNAL_set_relativeForce(ref Vector2 value){}
		public ConstantForce2D(){}
		public Vector2 force{ get	{} set	{} }
		public Vector2 relativeForce{ get	{} set	{} }
		public float torque{ get	{} set	{} }
	}

	public class	Effector2D: Behaviour
	{
		public Effector2D(){}
		public int colliderMask{ get	{} set	{} }
		bool requiresCollider{ get	{} }
		bool designedForTrigger{ get	{} }
		bool designedForNonTrigger{ get	{} }
	}

	public sealed class	AreaEffector2D: Effector2D
	{
		public AreaEffector2D(){}
		public float forceDirection{ get	{} set	{} }
		public float forceMagnitude{ get	{} set	{} }
		public float forceVariation{ get	{} set	{} }
		public float drag{ get	{} set	{} }
		public float angularDrag{ get	{} set	{} }
		public EffectorSelection2D forceTarget{ get	{} set	{} }
	}

	public sealed class	PointEffector2D: Effector2D
	{
		public PointEffector2D(){}
		public float forceMagnitude{ get	{} set	{} }
		public float forceVariation{ get	{} set	{} }
		public float distanceScale{ get	{} set	{} }
		public float drag{ get	{} set	{} }
		public float angularDrag{ get	{} set	{} }
		public EffectorSelection2D forceSource{ get	{} set	{} }
		public EffectorSelection2D forceTarget{ get	{} set	{} }
		public EffectorForceMode2D forceMode{ get	{} set	{} }
	}

	public sealed class	PlatformEffector2D: Effector2D
	{
		public PlatformEffector2D(){}
		public bool oneWay{ get	{} set	{} }
		public bool sideFriction{ get	{} set	{} }
		public bool sideBounce{ get	{} set	{} }
		public bool useOneWay{ get	{} set	{} }
		public bool useSideFriction{ get	{} set	{} }
		public bool useSideBounce{ get	{} set	{} }
		public float sideAngleVariance{ get	{} set	{} }
	}

	public sealed class	SurfaceEffector2D: Effector2D
	{
		public SurfaceEffector2D(){}
		public float speed{ get	{} set	{} }
		public float speedVariation{ get	{} set	{} }
		public float forceScale{ get	{} set	{} }
		public bool useContactForce{ get	{} set	{} }
		public bool useFriction{ get	{} set	{} }
		public bool useBounce{ get	{} set	{} }
	}

	public sealed class	NavMeshAgent: Behaviour
	{
		public bool SetDestination(Vector3 target){}
		private static bool INTERNAL_CALL_SetDestination(NavMeshAgent self, ref Vector3 target){}
		private void INTERNAL_get_destination(out Vector3 value){}
		private void INTERNAL_set_destination(ref Vector3 value){}
		private void INTERNAL_get_velocity(out Vector3 value){}
		private void INTERNAL_set_velocity(ref Vector3 value){}
		private void INTERNAL_get_nextPosition(out Vector3 value){}
		private void INTERNAL_set_nextPosition(ref Vector3 value){}
		private void INTERNAL_get_steeringTarget(out Vector3 value){}
		private void INTERNAL_get_desiredVelocity(out Vector3 value){}
		public void ActivateCurrentOffMeshLink(bool activated){}
		internal OffMeshLinkData GetCurrentOffMeshLinkDataInternal(){}
		internal OffMeshLinkData GetNextOffMeshLinkDataInternal(){}
		public void CompleteOffMeshLink(){}
		private void INTERNAL_get_pathEndPosition(out Vector3 value){}
		public bool Warp(Vector3 newPosition){}
		private static bool INTERNAL_CALL_Warp(NavMeshAgent self, ref Vector3 newPosition){}
		public void Move(Vector3 offset){}
		private static void INTERNAL_CALL_Move(NavMeshAgent self, ref Vector3 offset){}
		public void Stop(){}
		internal void StopInternal(){}
		public void Stop(bool stopUpdates){}
		public void Resume(){}
		public void ResetPath(){}
		public bool SetPath(NavMeshPath path){}
		internal void CopyPathTo(NavMeshPath path){}
		public bool FindClosestEdge(out NavMeshHit hit){}
		public bool Raycast(Vector3 targetPosition, out NavMeshHit hit){}
		private static bool INTERNAL_CALL_Raycast(NavMeshAgent self, ref Vector3 targetPosition, out NavMeshHit hit){}
		public bool CalculatePath(Vector3 targetPosition, NavMeshPath path){}
		private bool CalculatePathInternal(Vector3 targetPosition, NavMeshPath path){}
		private static bool INTERNAL_CALL_CalculatePathInternal(NavMeshAgent self, ref Vector3 targetPosition, NavMeshPath path){}
		public bool SamplePathPosition(int areaMask, float maxDistance, out NavMeshHit hit){}
		public void SetLayerCost(int layer, float cost){}
		public float GetLayerCost(int layer){}
		public void SetAreaCost(int areaIndex, float areaCost){}
		public float GetAreaCost(int areaIndex){}
		public NavMeshAgent(){}
		public Vector3 destination{ get	{} set	{} }
		public float stoppingDistance{ get	{} set	{} }
		public Vector3 velocity{ get	{} set	{} }
		public Vector3 nextPosition{ get	{} set	{} }
		public Vector3 steeringTarget{ get	{} }
		public Vector3 desiredVelocity{ get	{} }
		public float remainingDistance{ get	{} }
		public float baseOffset{ get	{} set	{} }
		public bool isOnOffMeshLink{ get	{} }
		public OffMeshLinkData currentOffMeshLinkData{ get	{} }
		public OffMeshLinkData nextOffMeshLinkData{ get	{} }
		public bool autoTraverseOffMeshLink{ get	{} set	{} }
		public bool autoBraking{ get	{} set	{} }
		public bool autoRepath{ get	{} set	{} }
		public bool hasPath{ get	{} }
		public bool pathPending{ get	{} }
		public bool isPathStale{ get	{} }
		public NavMeshPathStatus pathStatus{ get	{} }
		public Vector3 pathEndPosition{ get	{} }
		public NavMeshPath path{ get	{} set	{} }
		public int walkableMask{ get	{} set	{} }
		public int areaMask{ get	{} set	{} }
		public float speed{ get	{} set	{} }
		public float angularSpeed{ get	{} set	{} }
		public float acceleration{ get	{} set	{} }
		public bool updatePosition{ get	{} set	{} }
		public bool updateRotation{ get	{} set	{} }
		public float radius{ get	{} set	{} }
		public float height{ get	{} set	{} }
		public ObstacleAvoidanceType obstacleAvoidanceType{ get	{} set	{} }
		public int avoidancePriority{ get	{} set	{} }
		public bool isOnNavMesh{ get	{} }
	}

	public sealed class	NavMesh: Object
	{
		public static bool Raycast(Vector3 sourcePosition, Vector3 targetPosition, out NavMeshHit hit, int areaMask){}
		private static bool INTERNAL_CALL_Raycast(ref Vector3 sourcePosition, ref Vector3 targetPosition, out NavMeshHit hit, int areaMask){}
		public static bool CalculatePath(Vector3 sourcePosition, Vector3 targetPosition, int areaMask, NavMeshPath path){}
		internal static bool CalculatePathInternal(Vector3 sourcePosition, Vector3 targetPosition, int areaMask, NavMeshPath path){}
		private static bool INTERNAL_CALL_CalculatePathInternal(ref Vector3 sourcePosition, ref Vector3 targetPosition, int areaMask, NavMeshPath path){}
		public static bool FindClosestEdge(Vector3 sourcePosition, out NavMeshHit hit, int areaMask){}
		private static bool INTERNAL_CALL_FindClosestEdge(ref Vector3 sourcePosition, out NavMeshHit hit, int areaMask){}
		public static bool SamplePosition(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask){}
		private static bool INTERNAL_CALL_SamplePosition(ref Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask){}
		public static void SetLayerCost(int layer, float cost){}
		public static float GetLayerCost(int layer){}
		public static int GetNavMeshLayerFromName(string layerName){}
		public static void SetAreaCost(int areaIndex, float cost){}
		public static float GetAreaCost(int areaIndex){}
		public static int GetAreaFromName(string areaName){}
		public static NavMeshTriangulation CalculateTriangulation(){}
		internal static void TriangulateInternal(ref Vector3[] vertices, ref Int32[] indices, ref Int32[] areas){}
		public static void Triangulate(out Vector3[] vertices, out Int32[] indices){}
		public static void AddOffMeshLinks(){}
		public static void RestoreNavMesh(){}
		internal static void SetAvoidancePredictionTime(float t){}
		internal static float GetAvoidancePredictionTime(){}
		internal static void SetPathfindingIterationsPerFrame(int iter){}
		internal static int GetPathfindingIterationsPerFrame(){}
		public NavMesh(){}
		public static float avoidancePredictionTime{ get	{} set	{} }
		public static int pathfindingIterationsPerFrame{ get	{} set	{} }
		public const int AllAreas = null;
	}

	public sealed class	NavMeshObstacle: Behaviour
	{
		private void INTERNAL_get_velocity(out Vector3 value){}
		private void INTERNAL_set_velocity(ref Vector3 value){}
		private void INTERNAL_get_center(out Vector3 value){}
		private void INTERNAL_set_center(ref Vector3 value){}
		private void INTERNAL_get_size(out Vector3 value){}
		private void INTERNAL_set_size(ref Vector3 value){}
		internal void FitExtents(){}
		public NavMeshObstacle(){}
		public float height{ get	{} set	{} }
		public float radius{ get	{} set	{} }
		public Vector3 velocity{ get	{} set	{} }
		public bool carving{ get	{} set	{} }
		public bool carveOnlyStationary{ get	{} set	{} }
		public float carvingMoveThreshold{ get	{} set	{} }
		public float carvingTimeToStationary{ get	{} set	{} }
		public NavMeshObstacleShape shape{ get	{} set	{} }
		public Vector3 center{ get	{} set	{} }
		public Vector3 size{ get	{} set	{} }
	}

	public sealed class	NavMeshPath: Object
	{
		private void DestroyNavMeshPath(){}
		protected virtual void Finalize(){}
		public int GetCornersNonAlloc(Vector3[] results){}
		private Vector3[] CalculateCornersInternal(){}
		private void ClearCornersInternal(){}
		public void ClearCorners(){}
		private void CalculateCorners(){}
		public NavMeshPath(){}
		public Vector3[] corners{ get	{} }
		public NavMeshPathStatus status{ get	{} }
		internal IntPtr m_Ptr;
		internal Vector3[] m_corners;
	}

	public sealed class	OffMeshLink: Component
	{
		public void UpdatePositions(){}
		public OffMeshLink(){}
		public bool activated{ get	{} set	{} }
		public bool occupied{ get	{} }
		public float costOverride{ get	{} set	{} }
		public bool biDirectional{ get	{} set	{} }
		public int navMeshLayer{ get	{} set	{} }
		public int area{ get	{} set	{} }
		public bool autoUpdatePositions{ get	{} set	{} }
		public Transform startTransform{ get	{} set	{} }
		public Transform endTransform{ get	{} set	{} }
	}

	public sealed class	AudioSettings: Object
	{
		public static void GetDSPBufferSize(out int bufferLength, out int numBuffers){}
		public static void SetDSPBufferSize(int bufferLength, int numBuffers){}
		public static AudioConfiguration GetConfiguration(){}
		public static bool Reset(AudioConfiguration config){}
		private static bool INTERNAL_CALL_Reset(ref AudioConfiguration config){}
		internal void InvokeOnAudioConfigurationChanged(bool deviceWasChanged){}
		public AudioSettings(){}
		public static AudioSpeakerMode driverCapabilities{ get	{} }
		public static AudioSpeakerMode driverCaps{ get	{} }
		public static AudioSpeakerMode speakerMode{ get	{} set	{} }
		public static double dspTime{ get	{} }
		public static int outputSampleRate{ get	{} set	{} }
		bool editingInPlaymode{ get	{} set	{} }
		public static event	AudioConfigurationChangeHandler OnAudioConfigurationChanged;
	}

	public sealed class	AudioClip: Object
	{
		public bool LoadAudioData(){}
		public bool UnloadAudioData(){}
		public bool GetData(Single[] data, int offsetSamples){}
		public bool SetData(Single[] data, int offsetSamples){}
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream){}
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback){}
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback){}
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream){}
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback){}
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback){}
		private void InvokePCMReaderCallback_Internal(Single[] data){}
		private void InvokePCMSetPositionCallback_Internal(int position){}
		private static AudioClip Construct_Internal(){}
		private void Init_Internal(string name, int lengthSamples, int channels, int frequency, bool stream){}
		public AudioClip(){}
		public float length{ get	{} }
		public int samples{ get	{} }
		public int channels{ get	{} }
		public int frequency{ get	{} }
		public bool isReadyToPlay{ get	{} }
		public AudioClipLoadType loadType{ get	{} }
		public bool preloadAudioData{ get	{} }
		public AudioDataLoadState loadState{ get	{} }
		public bool loadInBackground{ get	{} }
		event	PCMReaderCallback m_PCMReaderCallback;
		event	PCMSetPositionCallback m_PCMSetPositionCallback;
	}

	public sealed class	AudioListener: Behaviour
	{
		private static void GetOutputDataHelper(Single[] samples, int channel){}
		private static void GetSpectrumDataHelper(Single[] samples, int channel, FFTWindow window){}
		public static Single[] GetOutputData(int numSamples, int channel){}
		public static void GetOutputData(Single[] samples, int channel){}
		public static Single[] GetSpectrumData(int numSamples, int channel, FFTWindow window){}
		public static void GetSpectrumData(Single[] samples, int channel, FFTWindow window){}
		public AudioListener(){}
		public static float volume{ get	{} set	{} }
		public static bool pause{ get	{} set	{} }
		public AudioVelocityUpdateMode velocityUpdateMode{ get	{} set	{} }
	}

	public sealed class	AudioSource: Behaviour
	{
		public void Play(ulong delay){}
		public void Play(){}
		public void PlayDelayed(float delay){}
		public void PlayScheduled(double time){}
		public void SetScheduledStartTime(double time){}
		public void SetScheduledEndTime(double time){}
		public void Stop(){}
		public void Pause(){}
		private static void INTERNAL_CALL_Pause(AudioSource self){}
		public void UnPause(){}
		private static void INTERNAL_CALL_UnPause(AudioSource self){}
		public void PlayOneShot(AudioClip clip, float volumeScale){}
		public void PlayOneShot(AudioClip clip){}
		public static void PlayClipAtPoint(AudioClip clip, Vector3 position){}
		public static void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume){}
		private void GetOutputDataHelper(Single[] samples, int channel){}
		public Single[] GetOutputData(int numSamples, int channel){}
		public void GetOutputData(Single[] samples, int channel){}
		private void GetSpectrumDataHelper(Single[] samples, int channel, FFTWindow window){}
		public Single[] GetSpectrumData(int numSamples, int channel, FFTWindow window){}
		public void GetSpectrumData(Single[] samples, int channel, FFTWindow window){}
		public AudioSource(){}
		public float volume{ get	{} set	{} }
		public float pitch{ get	{} set	{} }
		public float time{ get	{} set	{} }
		public int timeSamples{ get	{} set	{} }
		public AudioClip clip{ get	{} set	{} }
		public AudioMixerGroup outputAudioMixerGroup{ get	{} set	{} }
		public bool isPlaying{ get	{} }
		public bool loop{ get	{} set	{} }
		public bool ignoreListenerVolume{ get	{} set	{} }
		public bool playOnAwake{ get	{} set	{} }
		public bool ignoreListenerPause{ get	{} set	{} }
		public AudioVelocityUpdateMode velocityUpdateMode{ get	{} set	{} }
		public float panStereo{ get	{} set	{} }
		public float spatialBlend{ get	{} set	{} }
		public float reverbZoneMix{ get	{} set	{} }
		public float panLevel{ get	{} set	{} }
		public float pan{ get	{} set	{} }
		public bool bypassEffects{ get	{} set	{} }
		public bool bypassListenerEffects{ get	{} set	{} }
		public bool bypassReverbZones{ get	{} set	{} }
		public float dopplerLevel{ get	{} set	{} }
		public float spread{ get	{} set	{} }
		public int priority{ get	{} set	{} }
		public bool mute{ get	{} set	{} }
		public float minDistance{ get	{} set	{} }
		public float maxDistance{ get	{} set	{} }
		public AudioRolloffMode rolloffMode{ get	{} set	{} }
		public float minVolume{ get	{} set	{} }
		public float maxVolume{ get	{} set	{} }
		public float rolloffFactor{ get	{} set	{} }
	}

	public sealed class	AudioReverbZone: Behaviour
	{
		public AudioReverbZone(){}
		public float minDistance{ get	{} set	{} }
		public float maxDistance{ get	{} set	{} }
		public AudioReverbPreset reverbPreset{ get	{} set	{} }
		public int room{ get	{} set	{} }
		public int roomHF{ get	{} set	{} }
		public int roomLF{ get	{} set	{} }
		public float decayTime{ get	{} set	{} }
		public float decayHFRatio{ get	{} set	{} }
		public int reflections{ get	{} set	{} }
		public float reflectionsDelay{ get	{} set	{} }
		public int reverb{ get	{} set	{} }
		public float reverbDelay{ get	{} set	{} }
		public float HFReference{ get	{} set	{} }
		public float LFReference{ get	{} set	{} }
		public float roomRolloffFactor{ get	{} set	{} }
		public float diffusion{ get	{} set	{} }
		public float density{ get	{} set	{} }
	}

	public sealed class	AudioLowPassFilter: Behaviour
	{
		public AudioLowPassFilter(){}
		public float cutoffFrequency{ get	{} set	{} }
		public float lowpassResonanceQ{ get	{} set	{} }
		public float lowpassResonaceQ{ get	{} set	{} }
	}

	public sealed class	AudioHighPassFilter: Behaviour
	{
		public AudioHighPassFilter(){}
		public float cutoffFrequency{ get	{} set	{} }
		public float highpassResonanceQ{ get	{} set	{} }
		public float highpassResonaceQ{ get	{} set	{} }
	}

	public sealed class	AudioDistortionFilter: Behaviour
	{
		public AudioDistortionFilter(){}
		public float distortionLevel{ get	{} set	{} }
	}

	public sealed class	AudioEchoFilter: Behaviour
	{
		public AudioEchoFilter(){}
		public float delay{ get	{} set	{} }
		public float decayRatio{ get	{} set	{} }
		public float dryMix{ get	{} set	{} }
		public float wetMix{ get	{} set	{} }
	}

	public sealed class	AudioChorusFilter: Behaviour
	{
		public AudioChorusFilter(){}
		public float dryMix{ get	{} set	{} }
		public float wetMix1{ get	{} set	{} }
		public float wetMix2{ get	{} set	{} }
		public float wetMix3{ get	{} set	{} }
		public float delay{ get	{} set	{} }
		public float rate{ get	{} set	{} }
		public float depth{ get	{} set	{} }
		public float feedback{ get	{} set	{} }
	}

	public sealed class	AudioReverbFilter: Behaviour
	{
		public AudioReverbFilter(){}
		public AudioReverbPreset reverbPreset{ get	{} set	{} }
		public float dryLevel{ get	{} set	{} }
		public float room{ get	{} set	{} }
		public float roomHF{ get	{} set	{} }
		public float roomRolloff{ get	{} set	{} }
		public float decayTime{ get	{} set	{} }
		public float decayHFRatio{ get	{} set	{} }
		public float reflectionsLevel{ get	{} set	{} }
		public float reflectionsDelay{ get	{} set	{} }
		public float reverbLevel{ get	{} set	{} }
		public float reverbDelay{ get	{} set	{} }
		public float diffusion{ get	{} set	{} }
		public float density{ get	{} set	{} }
		public float hfReference{ get	{} set	{} }
		public float roomLF{ get	{} set	{} }
		public float lfReference{ get	{} set	{} }
		public float lFReference{ get	{} set	{} }
	}

	public sealed class	Microphone: Object
	{
		public static AudioClip Start(string deviceName, bool loop, int lengthSec, int frequency){}
		public static void End(string deviceName){}
		public static bool IsRecording(string deviceName){}
		public static int GetPosition(string deviceName){}
		public static void GetDeviceCaps(string deviceName, out int minFreq, out int maxFreq){}
		public Microphone(){}
		public static String[] devices{ get	{} }
	}

	public sealed class	MovieTexture: Texture
	{
		public void Play(){}
		private static void INTERNAL_CALL_Play(MovieTexture self){}
		public void Stop(){}
		private static void INTERNAL_CALL_Stop(MovieTexture self){}
		public void Pause(){}
		private static void INTERNAL_CALL_Pause(MovieTexture self){}
		public MovieTexture(){}
		public AudioClip audioClip{ get	{} }
		public bool loop{ get	{} set	{} }
		public bool isPlaying{ get	{} }
		public bool isReadyToPlay{ get	{} }
		public float duration{ get	{} }
	}

	public sealed class	WebCamTexture: Texture
	{
		private static void Internal_CreateWebCamTexture(WebCamTexture self, string scriptingDevice, int requestedWidth, int requestedHeight, int maxFramerate){}
		public void Play(){}
		private static void INTERNAL_CALL_Play(WebCamTexture self){}
		public void Pause(){}
		private static void INTERNAL_CALL_Pause(WebCamTexture self){}
		public void Stop(){}
		private static void INTERNAL_CALL_Stop(WebCamTexture self){}
		public void MarkNonReadable(){}
		public Color GetPixel(int x, int y){}
		public Color[] GetPixels(){}
		public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight){}
		public Color32[] GetPixels32(Color32[] colors){}
		public Color32[] GetPixels32(){}
		public WebCamTexture(string deviceName, int requestedWidth, int requestedHeight, int requestedFPS){}
		public WebCamTexture(string deviceName, int requestedWidth, int requestedHeight){}
		public WebCamTexture(string deviceName){}
		public WebCamTexture(int requestedWidth, int requestedHeight, int requestedFPS){}
		public WebCamTexture(int requestedWidth, int requestedHeight){}
		public WebCamTexture(){}
		public bool isPlaying{ get	{} }
		public string deviceName{ get	{} set	{} }
		public float requestedFPS{ get	{} set	{} }
		public int requestedWidth{ get	{} set	{} }
		public int requestedHeight{ get	{} set	{} }
		public bool isReadable{ get	{} }
		public static WebCamDevice[] devices{ get	{} }
		public int videoRotationAngle{ get	{} }
		public bool videoVerticallyMirrored{ get	{} }
		public bool didUpdateThisFrame{ get	{} }
	}

	public sealed class	AnimationClipPair: Object
	{
		public AnimationClipPair(){}
		public AnimationClip originalClip;
		public AnimationClip overrideClip;
	}

	public sealed class	AnimatorOverrideController: RuntimeAnimatorController
	{
		private static void Internal_CreateAnimationSet(AnimatorOverrideController self){}
		private AnimationClip Internal_GetClipByName(string name, bool returnEffectiveClip){}
		private void Internal_SetClipByName(string name, AnimationClip clip){}
		private AnimationClip Internal_GetClip(AnimationClip originalClip, bool returnEffectiveClip){}
		private void Internal_SetClip(AnimationClip originalClip, AnimationClip overrideClip){}
		internal static void OnInvalidateOverrideController(AnimatorOverrideController controller){}
		private AnimationClip[] GetOriginalClips(){}
		private AnimationClip[] GetOverrideClips(){}
		internal void PerformOverrideClipListCleanup(){}
		public AnimatorOverrideController(){}
		public RuntimeAnimatorController runtimeAnimatorController{ get	{} set	{} }
		public AnimationClip this[string name] { get	{} set	{} }
		public AnimationClip this[AnimationClip clip] { get	{} set	{} }
		public AnimationClipPair[] clips{ get	{} set	{} }
		internal OnOverrideControllerDirtyCallback OnOverrideControllerDirty;
	}

	public sealed class	AnimationEvent: Object
	{
		public AnimationEvent(){}
		public string data{ get	{} set	{} }
		public string stringParameter{ get	{} set	{} }
		public float floatParameter{ get	{} set	{} }
		public int intParameter{ get	{} set	{} }
		public System.Object objectReferenceParameter{ get	{} set	{} }
		public string functionName{ get	{} set	{} }
		public float time{ get	{} set	{} }
		public SendMessageOptions messageOptions{ get	{} set	{} }
		public bool isFiredByLegacy{ get	{} }
		public bool isFiredByAnimator{ get	{} }
		public AnimationState animationState{ get	{} }
		public AnimatorStateInfo animatorStateInfo{ get	{} }
		public AnimatorClipInfo animatorClipInfo{ get	{} }
		internal float m_Time;
		internal string m_FunctionName;
		internal string m_StringParameter;
		internal System.Object m_ObjectReferenceParameter;
		internal float m_FloatParameter;
		internal int m_IntParameter;
		internal int m_MessageOptions;
		internal AnimationEventSource m_Source;
		internal AnimationState m_StateSender;
		internal AnimatorStateInfo m_AnimatorStateInfo;
		internal AnimatorClipInfo m_AnimatorClipInfo;
	}

	public sealed class	AnimationClip: Motion
	{
		public void SampleAnimation(GameObject go, float time){}
		private static void Internal_CreateAnimationClip(AnimationClip self){}
		public void SetCurve(string relativePath, Type type, string propertyName, AnimationCurve curve){}
		public void EnsureQuaternionContinuity(){}
		private static void INTERNAL_CALL_EnsureQuaternionContinuity(AnimationClip self){}
		public void ClearCurves(){}
		private static void INTERNAL_CALL_ClearCurves(AnimationClip self){}
		private void INTERNAL_get_localBounds(out Bounds value){}
		private void INTERNAL_set_localBounds(ref Bounds value){}
		public void AddEvent(AnimationEvent evt){}
		internal void AddEventInternal(System.Object evt){}
		internal void SetEventsInternal(Array value){}
		internal Array GetEventsInternal(){}
		public AnimationClip(){}
		public float length{ get	{} }
		float startTime{ get	{} }
		float stopTime{ get	{} }
		public float frameRate{ get	{} set	{} }
		public WrapMode wrapMode{ get	{} set	{} }
		public Bounds localBounds{ get	{} set	{} }
		public bool legacy{ get	{} set	{} }
		public bool humanMotion{ get	{} }
		public AnimationEvent[] events{ get	{} set	{} }
	}

	public sealed class	AnimationCurve: Object
	{
		private void Cleanup(){}
		protected virtual void Finalize(){}
		public float Evaluate(float time){}
		public int AddKey(float time, float value){}
		public int AddKey(Keyframe key){}
		private int AddKey_Internal(Keyframe key){}
		private static int INTERNAL_CALL_AddKey_Internal(AnimationCurve self, ref Keyframe key){}
		public int MoveKey(int index, Keyframe key){}
		private static int INTERNAL_CALL_MoveKey(AnimationCurve self, int index, ref Keyframe key){}
		public void RemoveKey(int index){}
		private void SetKeys(Keyframe[] keys){}
		private Keyframe GetKey_Internal(int index){}
		private Keyframe[] GetKeys(){}
		public void SmoothTangents(int index, float weight){}
		public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd){}
		public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd){}
		private void Init(Keyframe[] keys){}
		public AnimationCurve(Keyframe[] keys){}
		public AnimationCurve(){}
		public Keyframe[] keys{ get	{} set	{} }
		public Keyframe this[int index] { get	{} }
		public int length{ get	{} }
		public WrapMode preWrapMode{ get	{} set	{} }
		public WrapMode postWrapMode{ get	{} set	{} }
		internal IntPtr m_Ptr;
	}

	public sealed class	Animation: Behaviour, IEnumerable
	{
		public void Stop(){}
		private static void INTERNAL_CALL_Stop(Animation self){}
		public void Stop(string name){}
		private void Internal_StopByName(string name){}
		public void Rewind(string name){}
		private void Internal_RewindByName(string name){}
		public void Rewind(){}
		private static void INTERNAL_CALL_Rewind(Animation self){}
		public void Sample(){}
		private static void INTERNAL_CALL_Sample(Animation self){}
		public bool IsPlaying(string name){}
		public bool Play(){}
		public bool Play(PlayMode mode){}
		public bool Play(string animation, PlayMode mode){}
		public bool Play(string animation){}
		public void CrossFade(string animation, float fadeLength, PlayMode mode){}
		public void CrossFade(string animation, float fadeLength){}
		public void CrossFade(string animation){}
		public void Blend(string animation, float targetWeight, float fadeLength){}
		public void Blend(string animation, float targetWeight){}
		public void Blend(string animation){}
		public AnimationState CrossFadeQueued(string animation, float fadeLength, QueueMode queue, PlayMode mode){}
		public AnimationState CrossFadeQueued(string animation, float fadeLength, QueueMode queue){}
		public AnimationState CrossFadeQueued(string animation, float fadeLength){}
		public AnimationState CrossFadeQueued(string animation){}
		public AnimationState PlayQueued(string animation, QueueMode queue, PlayMode mode){}
		public AnimationState PlayQueued(string animation, QueueMode queue){}
		public AnimationState PlayQueued(string animation){}
		public void AddClip(AnimationClip clip, string newName){}
		public void AddClip(AnimationClip clip, string newName, int firstFrame, int lastFrame, bool addLoopFrame){}
		public void AddClip(AnimationClip clip, string newName, int firstFrame, int lastFrame){}
		public void RemoveClip(AnimationClip clip){}
		public void RemoveClip(string clipName){}
		public int GetClipCount(){}
		private void RemoveClip2(string clipName){}
		private bool PlayDefaultAnimation(PlayMode mode){}
		public bool Play(AnimationPlayMode mode){}
		public bool Play(string animation, AnimationPlayMode mode){}
		public void SyncLayer(int layer){}
		private static void INTERNAL_CALL_SyncLayer(Animation self, int layer){}
		public sealed virtual IEnumerator GetEnumerator(){}
		internal AnimationState GetState(string name){}
		internal AnimationState GetStateAtIndex(int index){}
		internal int GetStateCount(){}
		public AnimationClip GetClip(string name){}
		private void INTERNAL_get_localBounds(out Bounds value){}
		private void INTERNAL_set_localBounds(ref Bounds value){}
		public Animation(){}
		public AnimationClip clip{ get	{} set	{} }
		public bool playAutomatically{ get	{} set	{} }
		public WrapMode wrapMode{ get	{} set	{} }
		public bool isPlaying{ get	{} }
		public AnimationState this[string name] { get	{} }
		public bool animatePhysics{ get	{} set	{} }
		public bool animateOnlyIfVisible{ get	{} set	{} }
		public AnimationCullingType cullingType{ get	{} set	{} }
		public Bounds localBounds{ get	{} set	{} }
	}

	public sealed class	AnimationState: TrackedReference
	{
		public void AddMixingTransform(Transform mix, bool recursive){}
		public void AddMixingTransform(Transform mix){}
		public void RemoveMixingTransform(Transform mix){}
		public AnimationState(){}
		public bool enabled{ get	{} set	{} }
		public float weight{ get	{} set	{} }
		public WrapMode wrapMode{ get	{} set	{} }
		public float time{ get	{} set	{} }
		public float normalizedTime{ get	{} set	{} }
		public float speed{ get	{} set	{} }
		public float normalizedSpeed{ get	{} set	{} }
		public float length{ get	{} }
		public int layer{ get	{} set	{} }
		public AnimationClip clip{ get	{} }
		public string name{ get	{} set	{} }
		public AnimationBlendMode blendMode{ get	{} set	{} }
	}

	public sealed class	Animator: Behaviour
	{
		internal void WriteDefaultPose(){}
		public void Update(float deltaTime){}
		public void Rebind(){}
		internal void EvaluateSM(){}
		internal string GetCurrentStateName(int layerIndex){}
		internal string GetNextStateName(int layerIndex){}
		internal string ResolveHash(int hash){}
		public Vector3 GetVector(string name){}
		public Vector3 GetVector(int id){}
		public void SetVector(string name, Vector3 value){}
		public void SetVector(int id, Vector3 value){}
		public Quaternion GetQuaternion(string name){}
		public Quaternion GetQuaternion(int id){}
		public void SetQuaternion(string name, Quaternion value){}
		public void SetQuaternion(int id, Quaternion value){}
		public string GetLayerName(int layerIndex){}
		public int GetLayerIndex(string layerName){}
		public float GetLayerWeight(int layerIndex){}
		public void SetLayerWeight(int layerIndex, float weight){}
		public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex){}
		public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex){}
		public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex){}
		public AnimatorClipInfo[] GetCurrentAnimationClipState(int layerIndex){}
		public AnimatorClipInfo[] GetNextAnimationClipState(int layerIndex){}
		public AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex){}
		public AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex){}
		public bool IsInTransition(int layerIndex){}
		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime){}
		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime){}
		private static void INTERNAL_CALL_MatchTarget(Animator self, ref Vector3 matchPosition, ref Quaternion matchRotation, AvatarTarget targetBodyPart, ref MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime){}
		public void InterruptMatchTarget(bool completeMatch){}
		public void InterruptMatchTarget(){}
		public void ForceStateNormalizedTime(float normalizedTime){}
		public void CrossFade(string stateName, float transitionDuration, int layer){}
		public void CrossFade(string stateName, float transitionDuration){}
		public void CrossFade(string stateName, float transitionDuration, int layer, float normalizedTime){}
		public void CrossFade(int stateNameHash, float transitionDuration, int layer, float normalizedTime){}
		public void CrossFade(int stateNameHash, float transitionDuration, int layer){}
		public void CrossFade(int stateNameHash, float transitionDuration){}
		public void Play(string stateName, int layer){}
		public void Play(string stateName){}
		public void Play(string stateName, int layer, float normalizedTime){}
		public void Play(int stateNameHash, int layer, float normalizedTime){}
		public void Play(int stateNameHash, int layer){}
		public void Play(int stateNameHash){}
		public void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime){}
		public bool IsControlled(Transform transform){}
		internal bool IsBoneTransform(Transform transform){}
		public Transform GetBoneTransform(HumanBodyBones humanBoneId){}
		public void StartPlayback(){}
		public void StopPlayback(){}
		public void StartRecording(int frameCount){}
		public void StopRecording(){}
		public bool HasState(int layerIndex, int stateID){}
		public static int StringToHash(string name){}
		internal string GetStats(){}
		private void CheckIfInIKPass(){}
		private bool CheckIfInIKPassInternal(){}
		private void SetFloatString(string name, float value){}
		private void SetFloatID(int id, float value){}
		private float GetFloatString(string name){}
		private float GetFloatID(int id){}
		private void SetBoolString(string name, bool value){}
		private void SetBoolID(int id, bool value){}
		private bool GetBoolString(string name){}
		private bool GetBoolID(int id){}
		private void SetIntegerString(string name, int value){}
		private void SetIntegerID(int id, int value){}
		private int GetIntegerString(string name){}
		private int GetIntegerID(int id){}
		private void SetTriggerString(string name){}
		private void SetTriggerID(int id){}
		private void ResetTriggerString(string name){}
		private void ResetTriggerID(int id){}
		private bool IsParameterControlledByCurveString(string name){}
		private bool IsParameterControlledByCurveID(int id){}
		private void SetFloatStringDamp(string name, float value, float dampTime, float deltaTime){}
		private void SetFloatIDDamp(int id, float value, float dampTime, float deltaTime){}
		public float GetFloat(string name){}
		public float GetFloat(int id){}
		public void SetFloat(string name, float value){}
		public void SetFloat(string name, float value, float dampTime, float deltaTime){}
		public void SetFloat(int id, float value){}
		public void SetFloat(int id, float value, float dampTime, float deltaTime){}
		public bool GetBool(string name){}
		public bool GetBool(int id){}
		public void SetBool(string name, bool value){}
		public void SetBool(int id, bool value){}
		public int GetInteger(string name){}
		public int GetInteger(int id){}
		public void SetInteger(string name, int value){}
		public void SetInteger(int id, int value){}
		public void SetTrigger(string name){}
		public void SetTrigger(int id){}
		public void ResetTrigger(string name){}
		public void ResetTrigger(int id){}
		public bool IsParameterControlledByCurve(string name){}
		public bool IsParameterControlledByCurve(int id){}
		private void INTERNAL_get_rootPosition(out Vector3 value){}
		private void INTERNAL_set_rootPosition(ref Vector3 value){}
		private void INTERNAL_get_rootRotation(out Quaternion value){}
		private void INTERNAL_set_rootRotation(ref Quaternion value){}
		private void INTERNAL_get_bodyPosition(out Vector3 value){}
		private void INTERNAL_set_bodyPosition(ref Vector3 value){}
		private void INTERNAL_get_bodyRotation(out Quaternion value){}
		private void INTERNAL_set_bodyRotation(ref Quaternion value){}
		public Vector3 GetIKPosition(AvatarIKGoal goal){}
		internal Vector3 GetIKPositionInternal(AvatarIKGoal goal){}
		public void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition){}
		internal void SetIKPositionInternal(AvatarIKGoal goal, Vector3 goalPosition){}
		private static void INTERNAL_CALL_SetIKPositionInternal(Animator self, AvatarIKGoal goal, ref Vector3 goalPosition){}
		public Quaternion GetIKRotation(AvatarIKGoal goal){}
		internal Quaternion GetIKRotationInternal(AvatarIKGoal goal){}
		public void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation){}
		internal void SetIKRotationInternal(AvatarIKGoal goal, Quaternion goalRotation){}
		private static void INTERNAL_CALL_SetIKRotationInternal(Animator self, AvatarIKGoal goal, ref Quaternion goalRotation){}
		public float GetIKPositionWeight(AvatarIKGoal goal){}
		internal float GetIKPositionWeightInternal(AvatarIKGoal goal){}
		public void SetIKPositionWeight(AvatarIKGoal goal, float value){}
		internal void SetIKPositionWeightInternal(AvatarIKGoal goal, float value){}
		public float GetIKRotationWeight(AvatarIKGoal goal){}
		internal float GetIKRotationWeightInternal(AvatarIKGoal goal){}
		public void SetIKRotationWeight(AvatarIKGoal goal, float value){}
		internal void SetIKRotationWeightInternal(AvatarIKGoal goal, float value){}
		public Vector3 GetIKHintPosition(AvatarIKHint hint){}
		internal Vector3 GetIKHintPositionInternal(AvatarIKHint hint){}
		public void SetIKHintPosition(AvatarIKHint hint, Vector3 hintPosition){}
		internal void SetIKHintPositionInternal(AvatarIKHint hint, Vector3 hintPosition){}
		private static void INTERNAL_CALL_SetIKHintPositionInternal(Animator self, AvatarIKHint hint, ref Vector3 hintPosition){}
		public float GetIKHintPositionWeight(AvatarIKHint hint){}
		internal float GetHintWeightPositionInternal(AvatarIKHint hint){}
		public void SetIKHintPositionWeight(AvatarIKHint hint, float value){}
		internal void SetIKHintPositionWeightInternal(AvatarIKHint hint, float value){}
		public void SetLookAtPosition(Vector3 lookAtPosition){}
		internal void SetLookAtPositionInternal(Vector3 lookAtPosition){}
		private static void INTERNAL_CALL_SetLookAtPositionInternal(Animator self, ref Vector3 lookAtPosition){}
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight){}
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight){}
		public void SetLookAtWeight(float weight, float bodyWeight){}
		public void SetLookAtWeight(float weight){}
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight){}
		internal void SetLookAtWeightInternal(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight){}
		internal void SetLookAtWeightInternal(float weight, float bodyWeight, float headWeight, float eyesWeight){}
		internal void SetLookAtWeightInternal(float weight, float bodyWeight, float headWeight){}
		internal void SetLookAtWeightInternal(float weight, float bodyWeight){}
		internal void SetLookAtWeightInternal(float weight){}
		internal ScriptableObject GetBehaviour(Type type){}
		public T GetBehaviour(){}
		internal ScriptableObject[] GetBehaviours(Type type){}
		internal static T[] ConvertStateMachineBehaviour(ScriptableObject[] rawObjects){}
		public T[] GetBehaviours(){}
		public Animator(){}
		public bool isOptimizable{ get	{} }
		public bool isHuman{ get	{} }
		public bool hasRootMotion{ get	{} }
		bool isRootPositionOrRotationControlledByCurves{ get	{} }
		public float humanScale{ get	{} }
		public Vector3 deltaPosition{ get	{} }
		public Quaternion deltaRotation{ get	{} }
		public Vector3 velocity{ get	{} }
		public Vector3 angularVelocity{ get	{} }
		public Vector3 rootPosition{ get	{} set	{} }
		public Quaternion rootRotation{ get	{} set	{} }
		public bool applyRootMotion{ get	{} set	{} }
		public bool linearVelocityBlending{ get	{} set	{} }
		public bool animatePhysics{ get	{} set	{} }
		public AnimatorUpdateMode updateMode{ get	{} set	{} }
		public bool hasTransformHierarchy{ get	{} }
		bool allowConstantClipSamplingOptimization{ get	{} set	{} }
		public float gravityWeight{ get	{} }
		public Vector3 bodyPosition{ get	{} set	{} }
		public Quaternion bodyRotation{ get	{} set	{} }
		public bool stabilizeFeet{ get	{} set	{} }
		public int layerCount{ get	{} }
		public AnimatorControllerParameter[] parameters{ get	{} }
		public float feetPivotActive{ get	{} set	{} }
		public float pivotWeight{ get	{} }
		public Vector3 pivotPosition{ get	{} }
		public bool isMatchingTarget{ get	{} }
		public float speed{ get	{} set	{} }
		public Vector3 targetPosition{ get	{} }
		public Quaternion targetRotation{ get	{} }
		Transform avatarRoot{ get	{} }
		public AnimatorCullingMode cullingMode{ get	{} set	{} }
		public float playbackTime{ get	{} set	{} }
		public float recorderStartTime{ get	{} set	{} }
		public float recorderStopTime{ get	{} set	{} }
		public AnimatorRecorderMode recorderMode{ get	{} }
		public RuntimeAnimatorController runtimeAnimatorController{ get	{} set	{} }
		public Avatar avatar{ get	{} set	{} }
		public bool layersAffectMassCenter{ get	{} set	{} }
		public float leftFeetBottomHeight{ get	{} }
		public float rightFeetBottomHeight{ get	{} }
		bool supportsOnAnimatorMove{ get	{} }
		bool isInManagerList{ get	{} }
		public bool logWarnings{ get	{} set	{} }
		public bool fireEvents{ get	{} set	{} }
	}

	public sealed class	AnimatorControllerParameter: Object
	{
		public virtual bool Equals(System.Object o){}
		public virtual int GetHashCode(){}
		public AnimatorControllerParameter(){}
		public string name{ get	{} set	{} }
		public int nameHash{ get	{} }
		public AnimatorControllerParameterType type{ get	{} set	{} }
		public float defaultFloat{ get	{} set	{} }
		public int defaultInt{ get	{} set	{} }
		public bool defaultBool{ get	{} set	{} }
		internal string m_Name;
		internal AnimatorControllerParameterType m_Type;
		internal float m_DefaultFloat;
		internal int m_DefaultInt;
		internal bool m_DefaultBool;
	}

	public sealed class	AnimatorUtility: Object
	{
		public static void OptimizeTransformHierarchy(GameObject go, String[] exposedTransforms){}
		public static void DeoptimizeTransformHierarchy(GameObject go){}
		public AnimatorUtility(){}
	}

	public sealed class	AvatarBuilder: Object
	{
		public static Avatar BuildHumanAvatar(GameObject go, HumanDescription monoHumanDescription){}
		private static Avatar INTERNAL_CALL_BuildHumanAvatar(GameObject go, ref HumanDescription monoHumanDescription){}
		public static Avatar BuildGenericAvatar(GameObject go, string rootMotionTransformName){}
		public AvatarBuilder(){}
	}

	public class	RuntimeAnimatorController: Object
	{
		public RuntimeAnimatorController(){}
		public AnimationClip[] animationClips{ get	{} }
	}

	public sealed class	Avatar: Object
	{
		internal void SetMuscleMinMax(int muscleId, float min, float max){}
		internal void SetParameter(int parameterId, float value){}
		internal float GetAxisLength(int humanId){}
		internal Quaternion GetPreRotation(int humanId){}
		internal Quaternion GetPostRotation(int humanId){}
		internal Quaternion GetZYPostQ(int humanId, Quaternion parentQ, Quaternion q){}
		private static Quaternion INTERNAL_CALL_GetZYPostQ(Avatar self, int humanId, ref Quaternion parentQ, ref Quaternion q){}
		internal Quaternion GetZYRoll(int humanId, Vector3 uvw){}
		private static Quaternion INTERNAL_CALL_GetZYRoll(Avatar self, int humanId, ref Vector3 uvw){}
		internal Vector3 GetLimitSign(int humanId){}
		public Avatar(){}
		public bool isValid{ get	{} }
		public bool isHuman{ get	{} }
	}

	public sealed class	HumanTrait: Object
	{
		public static int MuscleFromBone(int i, int dofIndex){}
		public static int BoneFromMuscle(int i){}
		public static bool RequiredBone(int i){}
		internal static bool HasCollider(Avatar avatar, int i){}
		public static float GetMuscleDefaultMin(int i){}
		public static float GetMuscleDefaultMax(int i){}
		public HumanTrait(){}
		public static int MuscleCount{ get	{} }
		public static String[] MuscleName{ get	{} }
		public static int BoneCount{ get	{} }
		public static String[] BoneName{ get	{} }
		public static int RequiredBoneCount{ get	{} }
	}

	public sealed class	TreePrototype: Object
	{
		public TreePrototype(){}
		public GameObject prefab{ get	{} set	{} }
		public float bendFactor{ get	{} set	{} }
		internal GameObject m_Prefab;
		internal float m_BendFactor;
	}

	public sealed class	DetailPrototype: Object
	{
		public DetailPrototype(){}
		public GameObject prototype{ get	{} set	{} }
		public Texture2D prototypeTexture{ get	{} set	{} }
		public float minWidth{ get	{} set	{} }
		public float maxWidth{ get	{} set	{} }
		public float minHeight{ get	{} set	{} }
		public float maxHeight{ get	{} set	{} }
		public float noiseSpread{ get	{} set	{} }
		public float bendFactor{ get	{} set	{} }
		public Color healthyColor{ get	{} set	{} }
		public Color dryColor{ get	{} set	{} }
		public DetailRenderMode renderMode{ get	{} set	{} }
		public bool usePrototypeMesh{ get	{} set	{} }
		private GameObject m_Prototype;
		private Texture2D m_PrototypeTexture;
		private Color m_HealthyColor;
		private Color m_DryColor;
		private float m_MinWidth;
		private float m_MaxWidth;
		private float m_MinHeight;
		private float m_MaxHeight;
		private float m_NoiseSpread;
		private float m_BendFactor;
		private int m_RenderMode;
		private int m_UsePrototypeMesh;
	}

	public sealed class	SplatPrototype: Object
	{
		public SplatPrototype(){}
		public Texture2D texture{ get	{} set	{} }
		public Texture2D normalMap{ get	{} set	{} }
		public Vector2 tileSize{ get	{} set	{} }
		public Vector2 tileOffset{ get	{} set	{} }
		public Color specular{ get	{} set	{} }
		public float metallic{ get	{} set	{} }
		public float smoothness{ get	{} set	{} }
		private Texture2D m_Texture;
		private Texture2D m_NormalMap;
		private Vector2 m_TileSize;
		private Vector2 m_TileOffset;
		private Vector4 m_SpecularMetallic;
		private float m_Smoothness;
	}

	public sealed class	TerrainData: Object
	{
		internal void Internal_Create(TerrainData terrainData){}
		internal bool HasUser(GameObject user){}
		internal void AddUser(GameObject user){}
		internal void RemoveUser(GameObject user){}
		private void INTERNAL_get_size(out Vector3 value){}
		private void INTERNAL_set_size(ref Vector3 value){}
		public float GetHeight(int x, int y){}
		public float GetInterpolatedHeight(float x, float y){}
		public Single[,] GetHeights(int xBase, int yBase, int width, int height){}
		public void SetHeights(int xBase, int yBase, Single[,] heights){}
		private void Internal_SetHeights(int xBase, int yBase, int width, int height, Single[,] heights){}
		private void Internal_SetHeightsDelayLOD(int xBase, int yBase, int width, int height, Single[,] heights){}
		internal void SetHeightsDelayLOD(int xBase, int yBase, Single[,] heights){}
		public float GetSteepness(float x, float y){}
		public Vector3 GetInterpolatedNormal(float x, float y){}
		internal int GetAdjustedSize(int size){}
		private void INTERNAL_get_wavingGrassTint(out Color value){}
		private void INTERNAL_set_wavingGrassTint(ref Color value){}
		public void SetDetailResolution(int detailResolution, int resolutionPerPatch){}
		internal void ResetDirtyDetails(){}
		public void RefreshPrototypes(){}
		public Int32[] GetSupportedLayers(int xBase, int yBase, int totalWidth, int totalHeight){}
		public Int32[,] GetDetailLayer(int xBase, int yBase, int width, int height, int layer){}
		public void SetDetailLayer(int xBase, int yBase, int layer, Int32[,] details){}
		private void Internal_SetDetailLayer(int xBase, int yBase, int totalWidth, int totalHeight, int detailIndex, Int32[,] data){}
		public TreeInstance GetTreeInstance(int index){}
		public void SetTreeInstance(int index, TreeInstance instance){}
		private static void INTERNAL_CALL_SetTreeInstance(TerrainData self, int index, ref TreeInstance instance){}
		internal void RemoveTreePrototype(int index){}
		internal void RecalculateTreePositions(){}
		internal void RemoveDetailPrototype(int index){}
		public Single[,,] GetAlphamaps(int x, int y, int width, int height){}
		public void SetAlphamaps(int x, int y, Single[,,] map){}
		private void Internal_SetAlphamaps(int x, int y, int width, int height, Single[,,] map){}
		internal void RecalculateBasemapIfDirty(){}
		internal void SetBasemapDirty(bool dirty){}
		private Texture2D GetAlphamapTexture(int index){}
		internal void AddTree(out TreeInstance tree){}
		internal int RemoveTrees(Vector2 position, float radius, int prototypeIndex){}
		private static int INTERNAL_CALL_RemoveTrees(TerrainData self, ref Vector2 position, float radius, int prototypeIndex){}
		public TerrainData(){}
		public int heightmapWidth{ get	{} }
		public int heightmapHeight{ get	{} }
		public int heightmapResolution{ get	{} set	{} }
		public Vector3 heightmapScale{ get	{} }
		public Vector3 size{ get	{} set	{} }
		public float thickness{ get	{} set	{} }
		public float wavingGrassStrength{ get	{} set	{} }
		public float wavingGrassAmount{ get	{} set	{} }
		public float wavingGrassSpeed{ get	{} set	{} }
		public Color wavingGrassTint{ get	{} set	{} }
		public int detailWidth{ get	{} }
		public int detailHeight{ get	{} }
		public int detailResolution{ get	{} }
		int detailResolutionPerPatch{ get	{} }
		public DetailPrototype[] detailPrototypes{ get	{} set	{} }
		public TreeInstance[] treeInstances{ get	{} set	{} }
		public int treeInstanceCount{ get	{} }
		public TreePrototype[] treePrototypes{ get	{} set	{} }
		public int alphamapLayers{ get	{} }
		public int alphamapResolution{ get	{} set	{} }
		public int alphamapWidth{ get	{} }
		public int alphamapHeight{ get	{} }
		public int baseMapResolution{ get	{} set	{} }
		int alphamapTextureCount{ get	{} }
		Texture2D[] alphamapTextures{ get	{} }
		public SplatPrototype[] splatPrototypes{ get	{} set	{} }
	}

	public sealed class	Terrain: Behaviour
	{
		private void ShiftLightmapIndex(int offset){}
		private void GetClosestReflectionProbesInternal(System.Object result){}
		public void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result){}
		private void INTERNAL_get_legacySpecular(out Color value){}
		private void INTERNAL_set_legacySpecular(ref Color value){}
		public float SampleHeight(Vector3 worldPosition){}
		private static float INTERNAL_CALL_SampleHeight(Terrain self, ref Vector3 worldPosition){}
		internal void ApplyDelayedHeightmapModification(){}
		public void AddTreeInstance(TreeInstance instance){}
		private static void INTERNAL_CALL_AddTreeInstance(Terrain self, ref TreeInstance instance){}
		public void SetNeighbors(Terrain left, Terrain top, Terrain right, Terrain bottom){}
		public Vector3 GetPosition(){}
		public void Flush(){}
		internal void RemoveTrees(Vector2 position, float radius, int prototypeIndex){}
		private static void INTERNAL_CALL_RemoveTrees(Terrain self, ref Vector2 position, float radius, int prototypeIndex){}
		public static GameObject CreateTerrainGameObject(TerrainData assignTerrain){}
		public Terrain(){}
		public TerrainRenderFlags editorRenderFlags{ get	{} set	{} }
		public TerrainData terrainData{ get	{} set	{} }
		public float treeDistance{ get	{} set	{} }
		public float treeBillboardDistance{ get	{} set	{} }
		public float treeCrossFadeLength{ get	{} set	{} }
		public int treeMaximumFullLODCount{ get	{} set	{} }
		public float detailObjectDistance{ get	{} set	{} }
		public float detailObjectDensity{ get	{} set	{} }
		public bool collectDetailPatches{ get	{} set	{} }
		public float heightmapPixelError{ get	{} set	{} }
		public int heightmapMaximumLOD{ get	{} set	{} }
		public float basemapDistance{ get	{} set	{} }
		public float splatmapDistance{ get	{} set	{} }
		public int lightmapIndex{ get	{} set	{} }
		public bool castShadows{ get	{} set	{} }
		public ReflectionProbeUsage reflectionProbeUsage{ get	{} set	{} }
		public MaterialType materialType{ get	{} set	{} }
		public Material materialTemplate{ get	{} set	{} }
		public Color legacySpecular{ get	{} set	{} }
		public float legacyShininess{ get	{} set	{} }
		public bool drawHeightmap{ get	{} set	{} }
		public bool drawTreesAndFoliage{ get	{} set	{} }
		public bool bakeLightProbesForTrees{ get	{} set	{} }
		public static Terrain activeTerrain{ get	{} }
		public static Terrain[] activeTerrains{ get	{} }
	}

	public sealed class	Tree: Component
	{
		public Tree(){}
		public ScriptableObject data{ get	{} set	{} }
		public bool hasSpeedTreeWind{ get	{} }
	}

	public sealed class	GUIText: GUIElement
	{
		private void Internal_GetPixelOffset(out Vector2 output){}
		private void Internal_SetPixelOffset(Vector2 p){}
		private static void INTERNAL_CALL_Internal_SetPixelOffset(GUIText self, ref Vector2 p){}
		private void INTERNAL_get_color(out Color value){}
		private void INTERNAL_set_color(ref Color value){}
		public GUIText(){}
		public string text{ get	{} set	{} }
		public Material material{ get	{} set	{} }
		public Vector2 pixelOffset{ get	{} set	{} }
		public Font font{ get	{} set	{} }
		public TextAlignment alignment{ get	{} set	{} }
		public TextAnchor anchor{ get	{} set	{} }
		public float lineSpacing{ get	{} set	{} }
		public float tabSize{ get	{} set	{} }
		public int fontSize{ get	{} set	{} }
		public FontStyle fontStyle{ get	{} set	{} }
		public bool richText{ get	{} set	{} }
		public Color color{ get	{} set	{} }
	}

	public sealed class	TextMesh: Component
	{
		private void INTERNAL_get_color(out Color value){}
		private void INTERNAL_set_color(ref Color value){}
		public TextMesh(){}
		public string text{ get	{} set	{} }
		public Font font{ get	{} set	{} }
		public int fontSize{ get	{} set	{} }
		public FontStyle fontStyle{ get	{} set	{} }
		public float offsetZ{ get	{} set	{} }
		public TextAlignment alignment{ get	{} set	{} }
		public TextAnchor anchor{ get	{} set	{} }
		public float characterSize{ get	{} set	{} }
		public float lineSpacing{ get	{} set	{} }
		public float tabSize{ get	{} set	{} }
		public bool richText{ get	{} set	{} }
		public Color color{ get	{} set	{} }
	}

	public sealed class	Font: Object
	{
		public static String[] GetOSInstalledFontNames(){}
		private static void Internal_CreateFont(Font _font, string name){}
		private static void Internal_CreateDynamicFont(Font _font, String[] _names, int size){}
		public static Font CreateDynamicFontFromOSFont(string fontname, int size){}
		public static Font CreateDynamicFontFromOSFont(String[] fontnames, int size){}
		public bool HasCharacter(char c){}
		public void RequestCharactersInTexture(string characters, int size, FontStyle style){}
		public void RequestCharactersInTexture(string characters, int size){}
		public void RequestCharactersInTexture(string characters){}
		private static void InvokeTextureRebuilt_Internal(Font font){}
		public static int GetMaxVertsForString(string str){}
		public bool GetCharacterInfo(char ch, out CharacterInfo info, int size, FontStyle style){}
		public bool GetCharacterInfo(char ch, out CharacterInfo info, int size){}
		public bool GetCharacterInfo(char ch, out CharacterInfo info){}
		public Font(){}
		public Font(string name){}
		private Font(String[] names, int size){}
		public Material material{ get	{} set	{} }
		public String[] fontNames{ get	{} set	{} }
		public CharacterInfo[] characterInfo{ get	{} set	{} }
		public FontTextureRebuildCallback textureRebuildCallback{ get	{} set	{} }
		public bool dynamic{ get	{} }
		public int ascent{ get	{} }
		public int lineHeight{ get	{} }
		public int fontSize{ get	{} }
		public static event	Action<Font> textureRebuilt;
		event	FontTextureRebuildCallback m_FontTextureRebuildCallback;
	}

	public sealed class	TextGenerator: Object, IDisposable
	{
		private sealed virtual void System.IDisposable.Dispose(){}
		private void Init(){}
		private void Dispose_cpp(){}
		internal bool Populate_Internal(string str, Font font, Color color, int fontSize, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, VerticalWrapMode verticalOverFlow, HorizontalWrapMode horizontalOverflow, bool updateBounds, TextAnchor anchor, Vector2 extents, Vector2 pivot, bool generateOutOfBounds){}
		internal bool Populate_Internal_cpp(string str, Font font, Color color, int fontSize, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds){}
		private static bool INTERNAL_CALL_Populate_Internal_cpp(TextGenerator self, string str, Font font, ref Color color, int fontSize, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds){}
		private void GetVerticesInternal(System.Object vertices){}
		public UIVertex[] GetVerticesArray(){}
		private void GetCharactersInternal(System.Object characters){}
		public UICharInfo[] GetCharactersArray(){}
		private void GetLinesInternal(System.Object lines){}
		public UILineInfo[] GetLinesArray(){}
		protected virtual void Finalize(){}
		internal static void InvalidateAll(){}
		private TextGenerationSettings ValidatedSettings(TextGenerationSettings settings){}
		public void Invalidate(){}
		public void GetCharacters(List<UICharInfo> characters){}
		public void GetLines(List<UILineInfo> lines){}
		public void GetVertices(List<UIVertex> vertices){}
		public float GetPreferredWidth(string str, TextGenerationSettings settings){}
		public float GetPreferredHeight(string str, TextGenerationSettings settings){}
		public bool Populate(string str, TextGenerationSettings settings){}
		private bool PopulateAlways(string str, TextGenerationSettings settings){}
		public TextGenerator(){}
		public TextGenerator(int initialCapacity){}
		private static TextGenerator(){}
		public Rect rectExtents{ get	{} }
		public int vertexCount{ get	{} }
		public int characterCount{ get	{} }
		public int characterCountVisible{ get	{} }
		public int lineCount{ get	{} }
		public int fontSizeUsedForBestFit{ get	{} }
		public IList<UIVertex> verts{ get	{} }
		public IList<UICharInfo> characters{ get	{} }
		public IList<UILineInfo> lines{ get	{} }
		internal IntPtr m_Ptr;
		private string m_LastString;
		private TextGenerationSettings m_LastSettings;
		private bool m_HasGenerated;
		private bool m_LastValid;
		private readonly List<UIVertex> m_Verts;
		private readonly List<UICharInfo> m_Characters;
		private readonly List<UILineInfo> m_Lines;
		private bool m_CachedVerts;
		private bool m_CachedCharacters;
		private bool m_CachedLines;
		private int m_Id;
		private static int s_NextId;
		private readonly static Dictionary<Int32, WeakReference> s_Instances;
	}

	public sealed class	Canvas: Behaviour
	{
		private void INTERNAL_get_pixelRect(out Rect value){}
		public static Material GetDefaultCanvasMaterial(){}
		public static Material GetDefaultCanvasTextMaterial(){}
		private static void SendWillRenderCanvases(){}
		public static void ForceUpdateCanvases(){}
		public Canvas(){}
		public RenderMode renderMode{ get	{} set	{} }
		public bool isRootCanvas{ get	{} }
		public Camera worldCamera{ get	{} set	{} }
		public Rect pixelRect{ get	{} }
		public float scaleFactor{ get	{} set	{} }
		public float referencePixelsPerUnit{ get	{} set	{} }
		public bool overridePixelPerfect{ get	{} set	{} }
		public bool pixelPerfect{ get	{} set	{} }
		public float planeDistance{ get	{} set	{} }
		public int renderOrder{ get	{} }
		public bool overrideSorting{ get	{} set	{} }
		public int sortingOrder{ get	{} set	{} }
		public int sortingLayerID{ get	{} set	{} }
		public string sortingLayerName{ get	{} set	{} }
		public static event	WillRenderCanvases willRenderCanvases;
	}

	public interface ICanvasRaycastFilter	{
		bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera);
	}

	public sealed class	CanvasGroup: Component, ICanvasRaycastFilter
	{
		public sealed virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera){}
		public CanvasGroup(){}
		public float alpha{ get	{} set	{} }
		public bool interactable{ get	{} set	{} }
		public bool blocksRaycasts{ get	{} set	{} }
		public bool ignoreParentGroups{ get	{} set	{} }
	}

	public sealed class	CanvasRenderer: Component
	{
		public void SetColor(Color color){}
		private static void INTERNAL_CALL_SetColor(CanvasRenderer self, ref Color color){}
		public Color GetColor(){}
		public float GetAlpha(){}
		public void SetAlpha(float alpha){}
		public void SetMaterial(Material material, Texture texture){}
		public Material GetMaterial(){}
		public void SetVertices(List<UIVertex> vertices){}
		private void SetVerticesInternal(System.Object vertices){}
		public void SetVertices(UIVertex[] vertices, int size){}
		private void SetVerticesInternalArray(UIVertex[] vertices, int size){}
		public void Clear(){}
		private static void RequestRefresh(){}
		public CanvasRenderer(){}
		public bool isMask{ get	{} set	{} }
		public int relativeDepth{ get	{} }
		public int absoluteDepth{ get	{} }
		public static event	OnRequestRebuild onRequestRebuild;
	}

	public sealed class	RectTransformUtility: Object
	{
		public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam){}
		private static bool INTERNAL_CALL_RectangleContainsScreenPoint(RectTransform rect, ref Vector2 screenPoint, Camera cam){}
		public static Vector2 PixelAdjustPoint(Vector2 point, Transform elementTransform, Canvas canvas){}
		private static void PixelAdjustPoint(Vector2 point, Transform elementTransform, Canvas canvas, out Vector2 output){}
		private static void INTERNAL_CALL_PixelAdjustPoint(ref Vector2 point, Transform elementTransform, Canvas canvas, out Vector2 output){}
		public static Rect PixelAdjustRect(RectTransform rectTransform, Canvas canvas){}
		public static bool ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector3 worldPoint){}
		public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint){}
		public static Ray ScreenPointToRay(Camera cam, Vector2 screenPos){}
		public static Vector2 WorldToScreenPoint(Camera cam, Vector3 worldPoint){}
		public static Bounds CalculateRelativeRectTransformBounds(Transform root, Transform child){}
		public static Bounds CalculateRelativeRectTransformBounds(Transform trans){}
		public static void FlipLayoutOnAxis(RectTransform rect, int axis, bool keepPositioning, bool recursive){}
		public static void FlipLayoutAxes(RectTransform rect, bool keepPositioning, bool recursive){}
		private static Vector2 GetTransposed(Vector2 input){}
		private RectTransformUtility(){}
		private static RectTransformUtility(){}
		private static Vector3[] s_Corners;
	}

	public sealed class	TerrainCollider: Collider
	{
		public TerrainCollider(){}
		public TerrainData terrainData{ get	{} set	{} }
	}

	public sealed class	AndroidJavaException: Exception, ISerializable, _Exception
	{
		internal AndroidJavaException(string message){}
	}

	public class	AndroidJavaProxy: Object
	{
		public virtual AndroidJavaObject Invoke(string methodName, Object[] args){}
		public virtual AndroidJavaObject Invoke(string methodName, AndroidJavaObject[] javaArgs){}
		public AndroidJavaProxy(string javaInterface){}
		public AndroidJavaProxy(AndroidJavaClass javaInterface){}
		public readonly AndroidJavaClass javaInterface;
	}

	public sealed class	DisallowMultipleComponent: Attribute, _Attribute
	{
		public DisallowMultipleComponent(){}
	}

	public sealed class	RequireComponent: Attribute, _Attribute
	{
		public RequireComponent(Type requiredComponent){}
		public RequireComponent(Type requiredComponent, Type requiredComponent2){}
		public RequireComponent(Type requiredComponent, Type requiredComponent2, Type requiredComponent3){}
		public Type m_Type0;
		public Type m_Type1;
		public Type m_Type2;
	}

	public sealed class	AddComponentMenu: Attribute, _Attribute
	{
		public AddComponentMenu(string menuName){}
		public AddComponentMenu(string menuName, int order){}
		public string componentMenu{ get	{} }
		public int componentOrder{ get	{} }
		private string m_AddComponentMenu;
		private int m_Ordering;
	}

	public sealed class	ContextMenu: Attribute, _Attribute
	{
		public ContextMenu(string name){}
		public string menuItem{ get	{} }
		private string m_ItemName;
	}

	public sealed class	ExecuteInEditMode: Attribute, _Attribute
	{
		public ExecuteInEditMode(){}
	}

	public sealed class	HideInInspector: Attribute, _Attribute
	{
		public HideInInspector(){}
	}

	public class	ThreadSafeAttribute: Attribute, _Attribute
	{
		public ThreadSafeAttribute(){}
	}

	public class	ConstructorSafeAttribute: Attribute, _Attribute
	{
		public ConstructorSafeAttribute(){}
	}

	public class	AssemblyIsEditorAssembly: Attribute, _Attribute
	{
		public AssemblyIsEditorAssembly(){}
	}

	public class	ImplementedInActionScriptAttribute: Attribute, _Attribute
	{
		public ImplementedInActionScriptAttribute(){}
	}

	public sealed abstract	class	Social: Object
	{
		public static void LoadUsers(String[] userIDs, Action<IUserProfile[]> callback){}
		public static void ReportProgress(string achievementID, double progress, Action<Boolean> callback){}
		public static void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback){}
		public static void LoadAchievements(Action<IAchievement[]> callback){}
		public static void ReportScore(long score, string board, Action<Boolean> callback){}
		public static void LoadScores(string leaderboardID, Action<IScore[]> callback){}
		public static ILeaderboard CreateLeaderboard(){}
		public static IAchievement CreateAchievement(){}
		public static void ShowAchievementsUI(){}
		public static void ShowLeaderboardUI(){}
		public static ISocialPlatform Active{ get	{} set	{} }
		public static ILocalUser localUser{ get	{} }
	}

	public abstract	class	PropertyAttribute: Attribute, _Attribute
	{
		protected PropertyAttribute(){}
		public int order{ get	{} set	{} }
		private int <order>k__BackingField;
	}

	public class	ContextMenuItemAttribute: PropertyAttribute, _Attribute
	{
		public ContextMenuItemAttribute(string name, string function){}
		public readonly string name;
		public readonly string function;
	}

	public class	TooltipAttribute: PropertyAttribute, _Attribute
	{
		public TooltipAttribute(string tooltip){}
		public readonly string tooltip;
	}

	public class	SpaceAttribute: PropertyAttribute, _Attribute
	{
		public SpaceAttribute(float height){}
		public readonly float height;
	}

	public class	HeaderAttribute: PropertyAttribute, _Attribute
	{
		public HeaderAttribute(string header){}
		public readonly string header;
	}

	public sealed class	RangeAttribute: PropertyAttribute, _Attribute
	{
		public RangeAttribute(float min, float max){}
		public readonly float min;
		public readonly float max;
	}

	public sealed class	MultilineAttribute: PropertyAttribute, _Attribute
	{
		public MultilineAttribute(){}
		public MultilineAttribute(int lines){}
		public readonly int lines;
	}

	public sealed class	TextAreaAttribute: PropertyAttribute, _Attribute
	{
		public TextAreaAttribute(){}
		public TextAreaAttribute(int minLines, int maxLines){}
		public readonly int minLines;
		public readonly int maxLines;
	}

	public class	RuntimeInitializeOnLoadMethodAttribute: Attribute, _Attribute
	{
		public RuntimeInitializeOnLoadMethodAttribute(){}
	}

	public sealed abstract	class	Types: Object
	{
		public static Type GetType(string typeName, string assemblyName){}
	}

	public class	SelectionBaseAttribute: Attribute, _Attribute
	{
		public SelectionBaseAttribute(){}
	}

	public class	StackTraceUtility: Object
	{
		internal static void SetProjectFolder(string folder){}
		public static string ExtractStackTrace(){}
		private static bool IsSystemStacktraceType(System.Object name){}
		public static string ExtractStringFromException(System.Object exception){}
		internal static void ExtractStringFromExceptionInternal(System.Object exceptiono, out string message, out string stackTrace){}
		internal static string PostprocessStacktrace(string oldString, bool stripEngineInternalInformation){}
		internal static string ExtractFormattedStackTrace(StackTrace stackTrace){}
		public StackTraceUtility(){}
		private static StackTraceUtility(){}
		private static string projectFolder;
	}

	public class	UnityException: SystemException, ISerializable, _Exception
	{
		public UnityException(){}
		public UnityException(string message){}
		public UnityException(string message, Exception innerException){}
		protected UnityException(SerializationInfo info, StreamingContext context){}
		private string unityStackTrace;
		private const int Result = null;
	}

	public class	MissingComponentException: SystemException, ISerializable, _Exception
	{
		public MissingComponentException(){}
		public MissingComponentException(string message){}
		public MissingComponentException(string message, Exception innerException){}
		protected MissingComponentException(SerializationInfo info, StreamingContext context){}
		private string unityStackTrace;
		private const int Result = null;
	}

	public class	UnassignedReferenceException: SystemException, ISerializable, _Exception
	{
		public UnassignedReferenceException(){}
		public UnassignedReferenceException(string message){}
		public UnassignedReferenceException(string message, Exception innerException){}
		protected UnassignedReferenceException(SerializationInfo info, StreamingContext context){}
		private string unityStackTrace;
		private const int Result = null;
	}

	public class	MissingReferenceException: SystemException, ISerializable, _Exception
	{
		public MissingReferenceException(){}
		public MissingReferenceException(string message){}
		public MissingReferenceException(string message, Exception innerException){}
		protected MissingReferenceException(SerializationInfo info, StreamingContext context){}
		private string unityStackTrace;
		private const int Result = null;
	}

	public sealed class	SharedBetweenAnimatorsAttribute: Attribute, _Attribute
	{
		public SharedBetweenAnimatorsAttribute(){}
	}

	public abstract	class	StateMachineBehaviour: ScriptableObject
	{
		public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){}
		public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){}
		public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){}
		public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){}
		public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){}
		public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash){}
		public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash){}
		protected StateMachineBehaviour(){}
	}

	public class	TextEditor: Object
	{
		private void ClearCursorPos(){}
		public void OnFocus(){}
		public void OnLostFocus(){}
		private void GrabGraphicalCursorPos(){}
		public bool HandleKeyEvent(Event e){}
		public bool DeleteLineBack(){}
		public bool DeleteWordBack(){}
		public bool DeleteWordForward(){}
		public bool Delete(){}
		public bool CanPaste(){}
		public bool Backspace(){}
		public void SelectAll(){}
		public void SelectNone(){}
		public bool DeleteSelection(){}
		public void ReplaceSelection(string replace){}
		public void Insert(char c){}
		public void MoveSelectionToAltCursor(){}
		public void MoveRight(){}
		public void MoveLeft(){}
		public void MoveUp(){}
		public void MoveDown(){}
		public void MoveLineStart(){}
		public void MoveLineEnd(){}
		public void MoveGraphicalLineStart(){}
		public void MoveGraphicalLineEnd(){}
		public void MoveTextStart(){}
		public void MoveTextEnd(){}
		public void MoveParagraphForward(){}
		public void MoveParagraphBackward(){}
		public void MoveCursorToPosition(Vector2 cursorPosition){}
		public void MoveAltCursorToPosition(Vector2 cursorPosition){}
		public bool IsOverSelection(Vector2 cursorPosition){}
		public void SelectToPosition(Vector2 cursorPosition){}
		public void SelectLeft(){}
		public void SelectRight(){}
		public void SelectUp(){}
		public void SelectDown(){}
		public void SelectTextEnd(){}
		public void SelectTextStart(){}
		public void MouseDragSelectsWholeWords(bool on){}
		public void DblClickSnap(DblClickSnapping snapping){}
		private int GetGraphicalLineStart(int p){}
		private int GetGraphicalLineEnd(int p){}
		private int FindNextSeperator(int startPos){}
		private static bool isLetterLikeChar(char c){}
		private int FindPrevSeperator(int startPos){}
		public void MoveWordRight(){}
		public void MoveToStartOfNextWord(){}
		public void MoveToEndOfPreviousWord(){}
		public void SelectToStartOfNextWord(){}
		public void SelectToEndOfPreviousWord(){}
		private CharacterType ClassifyChar(char c){}
		public int FindStartOfNextWord(int p){}
		private int FindEndOfPreviousWord(int p){}
		public void MoveWordLeft(){}
		public void SelectWordRight(){}
		public void SelectWordLeft(){}
		public void ExpandSelectGraphicalLineStart(){}
		public void ExpandSelectGraphicalLineEnd(){}
		public void SelectGraphicalLineStart(){}
		public void SelectGraphicalLineEnd(){}
		public void SelectParagraphForward(){}
		public void SelectParagraphBackward(){}
		public void SelectCurrentWord(){}
		private int FindEndOfClassification(int p, int dir){}
		public void SelectCurrentParagraph(){}
		public void UpdateScrollOffsetIfNeeded(){}
		private void UpdateScrollOffset(){}
		public void DrawCursor(string text){}
		private bool PerformOperation(TextEditOp operation){}
		public void SaveBackup(){}
		public void Undo(){}
		public bool Cut(){}
		public void Copy(){}
		private static string ReplaceNewlinesWithSpaces(string value){}
		public bool Paste(){}
		private static void MapKey(string key, TextEditOp action){}
		private void InitKeyActions(){}
		public void ClampPos(){}
		public TextEditor(){}
		public bool hasSelection{ get	{} }
		public string SelectedText{ get	{} }
		public int pos;
		public int selectPos;
		public int controlID;
		public GUIContent content;
		public GUIStyle style;
		public Rect position;
		public bool multiline;
		public bool hasHorizontalCursorPos;
		public bool isPasswordField;
		internal bool m_HasFocus;
		public Vector2 scrollOffset;
		private bool m_TextHeightPotentiallyChanged;
		public Vector2 graphicalCursorPos;
		public Vector2 graphicalSelectCursorPos;
		private bool m_MouseDragSelectsWholeWords;
		private int m_DblClickInitPos;
		private DblClickSnapping m_DblClickSnap;
		private bool m_bJustSelected;
		private int m_iAltCursorPos;
		private string oldText;
		private int oldPos;
		private int oldSelectPos;
		private static Dictionary<Event, TextEditOp> s_Keyactions;
	}

	public class	TrackedReference: Object
	{
		public virtual bool Equals(System.Object o){}
		public virtual int GetHashCode(){}
		protected TrackedReference(){}
		internal IntPtr m_Ptr;
	}

	public class	UnityAPICompatibilityVersionAttribute: Attribute, _Attribute
	{
		public UnityAPICompatibilityVersionAttribute(string version){}
		public string version{ get	{} }
		private string _version;
	}

	delegate void WindowFunction(int id);

	delegate void SkinChangedDelegate();

	delegate void ReapplyDrivenProperties(RectTransform driven);

	delegate void LogCallback(string condition, string stackTrace, LogType type);

	delegate void CameraCallback(Camera cam);

	delegate void DisplaysUpdatedDelegate();

	delegate void AudioConfigurationChangeHandler(bool deviceWasChanged);

	delegate void PCMReaderCallback(Single[] data);

	delegate void PCMSetPositionCallback(int position);

	delegate void OnOverrideControllerDirtyCallback();

	delegate void FontTextureRebuildCallback();

	delegate void WillRenderCanvases();

	delegate void OnRequestRebuild();

	delegate void AndroidJavaRunnable();

}

namespace UnityEngineInternal {
	public sealed class	Reproduction: Object
	{
		public static void CaptureScreenshot(){}
		public Reproduction(){}
	}

	public sealed class	GIDebugVisualisation: Object
	{
		public static void ResetRuntimeInputTextures(){}
		public static void PlayCycleMode(){}
		public static void PauseCycleMode(){}
		public static void StopCycleMode(){}
		public static void CycleSkipInstances(int skip){}
		public static void CycleSkipSystems(int skip){}
		public GIDebugVisualisation(){}
		public static bool cycleMode{ get	{} }
		public static bool pauseCycleMode{ get	{} }
		public static GITextureType texType{ get	{} set	{} }
	}

	public sealed class	APIUpdaterRuntimeServices: Object
	{
		public static Component AddComponent(GameObject go, string sourceInfo, string name){}
		private static Type ResolveType(string name, Assembly callingAssembly, string sourceInfo){}
		private static bool IsMarkedAsObsolete(Type t){}
		private static IEnumerable<Type> <ResolveType>m__3(Assembly a){}
		public APIUpdaterRuntimeServices(){}
		private static APIUpdaterRuntimeServices(){}
		private static IList<Type> ComponentsFromUnityEngine;
		private static Func<Assembly, IEnumerable<Type>> <>f__am$cache1;
	}

	public class	TypeInferenceRuleAttribute: Attribute, _Attribute
	{
		public virtual string ToString(){}
		public TypeInferenceRuleAttribute(TypeInferenceRules rule){}
		public TypeInferenceRuleAttribute(string rule){}
		private readonly string _rule;
	}

	public class	GenericStack: Stack, ICollection, IEnumerable, ICloneable
	{
		public GenericStack(){}
	}

	delegate void FastCallExceptionHandler(Exception ex);

	delegate MethodInfo GetMethodDelegate(Type classType, string methodName, bool searchBaseTypes, bool instanceMethod, Type[] methodParamTypes);

}

namespace UnityEngine.Rendering {
	public sealed class	CommandBuffer: Object, IDisposable
	{
		protected virtual void Finalize(){}
		public sealed virtual void Dispose(){}
		private void Dispose(bool disposing){}
		private static void InitBuffer(CommandBuffer buf){}
		private void ReleaseBuffer(){}
		public void Release(){}
		public void Clear(){}
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties){}
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass){}
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex){}
		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material){}
		private static void INTERNAL_CALL_DrawMesh(CommandBuffer self, Mesh mesh, ref Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties){}
		public void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass){}
		public void DrawRenderer(Renderer renderer, Material material, int submeshIndex){}
		public void DrawRenderer(Renderer renderer, Material material){}
		public void SetRenderTarget(RenderTargetIdentifier rt){}
		public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth){}
		public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth){}
		private void SetRenderTarget_Single(ref RenderTargetIdentifier rt){}
		private void SetRenderTarget_ColDepth(ref RenderTargetIdentifier color, ref RenderTargetIdentifier depth){}
		private void SetRenderTarget_Multiple(RenderTargetIdentifier[] color, ref RenderTargetIdentifier depth){}
		public void Blit(Texture source, RenderTargetIdentifier dest){}
		public void Blit(Texture source, RenderTargetIdentifier dest, Material mat){}
		public void Blit(Texture source, RenderTargetIdentifier dest, Material mat, int pass){}
		private void Blit_Texture(Texture source, ref RenderTargetIdentifier dest, Material mat, int pass){}
		public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest){}
		public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat){}
		public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest, Material mat, int pass){}
		private void Blit_Identifier(ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, Material mat, int pass){}
		private void Blit_Identifier(ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, Material mat){}
		private void Blit_Identifier(ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest){}
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing){}
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format, RenderTextureReadWrite readWrite){}
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter, RenderTextureFormat format){}
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer, FilterMode filter){}
		public void GetTemporaryRT(int nameID, int width, int height, int depthBuffer){}
		public void GetTemporaryRT(int nameID, int width, int height){}
		public void ReleaseTemporaryRT(int nameID){}
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth){}
		public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor){}
		private static void INTERNAL_CALL_ClearRenderTarget(CommandBuffer self, bool clearDepth, bool clearColor, ref Color backgroundColor, float depth){}
		public void SetGlobalFloat(string name, float value){}
		public void SetGlobalFloat(int nameID, float value){}
		public void SetGlobalVector(string name, Vector4 value){}
		public void SetGlobalVector(int nameID, Vector4 value){}
		private static void INTERNAL_CALL_SetGlobalVector(CommandBuffer self, int nameID, ref Vector4 value){}
		public void SetGlobalColor(string name, Color value){}
		public void SetGlobalColor(int nameID, Color value){}
		private static void INTERNAL_CALL_SetGlobalColor(CommandBuffer self, int nameID, ref Color value){}
		public void SetGlobalMatrix(string name, Matrix4x4 value){}
		public void SetGlobalMatrix(int nameID, Matrix4x4 value){}
		private static void INTERNAL_CALL_SetGlobalMatrix(CommandBuffer self, int nameID, ref Matrix4x4 value){}
		public void SetGlobalTexture(string name, RenderTargetIdentifier value){}
		public void SetGlobalTexture(int nameID, RenderTargetIdentifier value){}
		private void SetGlobalTexture_Impl(int nameID, ref RenderTargetIdentifier rt){}
		public CommandBuffer(){}
		public string name{ get	{} set	{} }
		public int sizeInBytes{ get	{} }
		internal IntPtr m_Ptr;
	}

}

namespace UnityEngine.Sprites {
	public sealed class	DataUtility: Object
	{
		public static Vector4 GetInnerUV(Sprite sprite){}
		public static Vector4 GetOuterUV(Sprite sprite){}
		public static Vector4 GetPadding(Sprite sprite){}
		public static Vector2 GetMinSize(Sprite sprite){}
		private static void Internal_GetMinSize(Sprite sprite, out Vector2 output){}
		public DataUtility(){}
	}

}

namespace UnityEngine.iOS {
	public sealed class	ADBannerView: Object
	{
		private static IntPtr Native_CreateBanner(int type, int layout){}
		private static void Native_ShowBanner(IntPtr view, bool show){}
		private static void Native_MoveBanner(IntPtr view, Vector2 pos){}
		private static void INTERNAL_CALL_Native_MoveBanner(IntPtr view, ref Vector2 pos){}
		private static void Native_LayoutBanner(IntPtr view, int layout){}
		private static bool Native_BannerTypeAvailable(int type){}
		private static void Native_BannerPosition(IntPtr view, out Vector2 pos){}
		private static void Native_BannerSize(IntPtr view, out Vector2 pos){}
		private static bool Native_BannerAdLoaded(IntPtr view){}
		private static bool Native_BannerAdVisible(IntPtr view){}
		private static void Native_DestroyBanner(IntPtr view){}
		public static bool IsAvailable(Type type){}
		protected virtual void Finalize(){}
		private Vector2 OSToScreenCoords(Vector2 v){}
		private static void FireBannerWasClicked(){}
		private static void FireBannerWasLoaded(){}
		public ADBannerView(Type type, Layout layout){}
		private static ADBannerView(){}
		public bool loaded{ get	{} }
		public bool visible{ get	{} set	{} }
		public Layout layout{ get	{} set	{} }
		public Vector2 position{ get	{} set	{} }
		public Vector2 size{ get	{} }
		public static event	BannerWasClickedDelegate onBannerWasClicked;
		public static event	BannerWasLoadedDelegate onBannerWasLoaded;
		private Layout _layout;
		private IntPtr _bannerView;
		private static bool _AlwaysFalseDummy;
	}

	public sealed class	ADInterstitialAd: Object
	{
		private static IntPtr Native_CreateInterstitial(bool autoReload){}
		private static void Native_ShowInterstitial(IntPtr view){}
		private static void Native_ReloadInterstitial(IntPtr view){}
		private static bool Native_InterstitialAdLoaded(IntPtr view){}
		private static bool Native_InterstitialAvailable(){}
		private static void Native_DestroyInterstitial(IntPtr view){}
		private void CtorImpl(bool autoReload){}
		protected virtual void Finalize(){}
		public void Show(){}
		public void ReloadAd(){}
		private static void FireInterstitialWasLoaded(){}
		public ADInterstitialAd(bool autoReload){}
		public ADInterstitialAd(){}
		private static ADInterstitialAd(){}
		public static bool isAvailable{ get	{} }
		public bool loaded{ get	{} }
		public static event	InterstitialWasLoadedDelegate onInterstitialWasLoaded;
		private IntPtr interstitialView;
		private static bool _AlwaysFalseDummy;
	}

	public sealed class	Device: Object
	{
		public static void SetNoBackupFlag(string path){}
		public static void ResetNoBackupFlag(string path){}
		public Device(){}
		public static DeviceGeneration generation{ get	{} }
		public static string systemVersion{ get	{} }
		public static string vendorIdentifier{ get	{} }
		public static string advertisingIdentifier{ get	{} }
		public static bool advertisingTrackingEnabled{ get	{} }
	}

	public sealed class	LocalNotification: Object
	{
		private double GetFireDate(){}
		private void SetFireDate(double dt){}
		private void Destroy(){}
		protected virtual void Finalize(){}
		private void InitWrapper(){}
		public LocalNotification(){}
		private static LocalNotification(){}
		public DateTime fireDate{ get	{} set	{} }
		public string timeZone{ get	{} set	{} }
		public CalendarUnit repeatInterval{ get	{} set	{} }
		public CalendarIdentifier repeatCalendar{ get	{} set	{} }
		public string alertBody{ get	{} set	{} }
		public string alertAction{ get	{} set	{} }
		public bool hasAction{ get	{} set	{} }
		public string alertLaunchImage{ get	{} set	{} }
		public int applicationIconBadgeNumber{ get	{} set	{} }
		public string soundName{ get	{} set	{} }
		public static string defaultSoundName{ get	{} }
		public IDictionary userInfo{ get	{} set	{} }
		private IntPtr notificationWrapper;
		private static long m_NSReferenceDateTicks;
	}

	public sealed class	RemoteNotification: Object
	{
		private void Destroy(){}
		protected virtual void Finalize(){}
		private RemoteNotification(){}
		public string alertBody{ get	{} }
		public bool hasAction{ get	{} }
		public int applicationIconBadgeNumber{ get	{} }
		public string soundName{ get	{} }
		public IDictionary userInfo{ get	{} }
		private IntPtr notificationWrapper;
	}

	public sealed class	NotificationServices: Object
	{
		public static LocalNotification GetLocalNotification(int index){}
		public static void ScheduleLocalNotification(LocalNotification notification){}
		public static void PresentLocalNotificationNow(LocalNotification notification){}
		public static void CancelLocalNotification(LocalNotification notification){}
		public static void CancelAllLocalNotifications(){}
		public static RemoteNotification GetRemoteNotification(int index){}
		public static void ClearLocalNotifications(){}
		public static void ClearRemoteNotifications(){}
		public static void RegisterForNotifications(NotificationType notificationTypes){}
		public static void RegisterForNotifications(NotificationType notificationTypes, bool registerForRemote){}
		public static void UnregisterForRemoteNotifications(){}
		public NotificationServices(){}
		public static int localNotificationCount{ get	{} }
		public static LocalNotification[] localNotifications{ get	{} }
		public static LocalNotification[] scheduledLocalNotifications{ get	{} }
		public static int remoteNotificationCount{ get	{} }
		public static RemoteNotification[] remoteNotifications{ get	{} }
		public static NotificationType enabledNotificationTypes{ get	{} }
		public static Byte[] deviceToken{ get	{} }
		public static string registrationError{ get	{} }
	}

	delegate void BannerWasClickedDelegate();

	delegate void BannerWasLoadedDelegate();

	delegate void InterstitialWasLoadedDelegate();

}

namespace UnityEngine.Audio {
	public class	AudioMixer: Object
	{
		public AudioMixerGroup[] FindMatchingGroups(string subPath){}
		public AudioMixerSnapshot FindSnapshot(string name){}
		private void TransitionToSnapshot(AudioMixerSnapshot snapshot, float timeToReach){}
		public void TransitionToSnapshots(AudioMixerSnapshot[] snapshots, Single[] weights, float timeToReach){}
		public bool SetFloat(string name, float value){}
		public bool ClearFloat(string name){}
		public bool GetFloat(string name, out float value){}
		internal AudioMixer(){}
		public AudioMixerGroup outputAudioMixerGroup{ get	{} set	{} }
	}

	public class	AudioMixerSnapshot: Object
	{
		public void TransitionTo(float timeToReach){}
		internal AudioMixerSnapshot(){}
		public AudioMixer audioMixer{ get	{} }
	}

	public class	AudioMixerGroup: Object
	{
		internal AudioMixerGroup(){}
		public AudioMixer audioMixer{ get	{} }
	}

}

namespace AOT {
	public class	MonoPInvokeCallbackAttribute: Attribute, _Attribute
	{
		public MonoPInvokeCallbackAttribute(Type type){}
	}

}

namespace UnityEngine.SocialPlatforms.GameCenter {
	public class	GameCenterPlatform: Local, ISocialPlatform
	{
		public static void ResetAllAchievements(Action<Boolean> callback){}
		public static void ShowDefaultAchievementCompletionBanner(bool value){}
		public static void ShowLeaderboardUI(string leaderboardID, TimeScope timeScope){}
		public GameCenterPlatform(){}
	}

}

namespace JetBrains.Annotations {
	public sealed class	CanBeNullAttribute: Attribute, _Attribute
	{
		public CanBeNullAttribute(){}
	}

	public sealed class	NotNullAttribute: Attribute, _Attribute
	{
		public NotNullAttribute(){}
	}

	public sealed class	StringFormatMethodAttribute: Attribute, _Attribute
	{
		public StringFormatMethodAttribute(string formatParameterName){}
		public string FormatParameterName{ get	{} set	{} }
		private string <FormatParameterName>k__BackingField;
	}

	public sealed class	InvokerParameterNameAttribute: Attribute, _Attribute
	{
		public InvokerParameterNameAttribute(){}
	}

	public sealed class	NotifyPropertyChangedInvocatorAttribute: Attribute, _Attribute
	{
		public NotifyPropertyChangedInvocatorAttribute(){}
		public NotifyPropertyChangedInvocatorAttribute(string parameterName){}
		public string ParameterName{ get	{} set	{} }
		private string <ParameterName>k__BackingField;
	}

	public sealed class	ContractAnnotationAttribute: Attribute, _Attribute
	{
		public ContractAnnotationAttribute(string contract){}
		public ContractAnnotationAttribute(string contract, bool forceFullStates){}
		public string Contract{ get	{} set	{} }
		public bool ForceFullStates{ get	{} set	{} }
		private string <Contract>k__BackingField;
		private bool <ForceFullStates>k__BackingField;
	}

	public sealed class	LocalizationRequiredAttribute: Attribute, _Attribute
	{
		public LocalizationRequiredAttribute(){}
		public LocalizationRequiredAttribute(bool required){}
		public bool Required{ get	{} set	{} }
		private bool <Required>k__BackingField;
	}

	public sealed class	CannotApplyEqualityOperatorAttribute: Attribute, _Attribute
	{
		public CannotApplyEqualityOperatorAttribute(){}
	}

	public sealed class	BaseTypeRequiredAttribute: Attribute, _Attribute
	{
		public BaseTypeRequiredAttribute(Type baseType){}
		public Type BaseType{ get	{} set	{} }
		private Type <BaseType>k__BackingField;
	}

	public sealed class	UsedImplicitlyAttribute: Attribute, _Attribute
	{
		public UsedImplicitlyAttribute(){}
		public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags){}
		public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags){}
		public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags){}
		public ImplicitUseKindFlags UseKindFlags{ get	{} set	{} }
		public ImplicitUseTargetFlags TargetFlags{ get	{} set	{} }
		private ImplicitUseKindFlags <UseKindFlags>k__BackingField;
		private ImplicitUseTargetFlags <TargetFlags>k__BackingField;
	}

	public sealed class	MeansImplicitUseAttribute: Attribute, _Attribute
	{
		public MeansImplicitUseAttribute(){}
		public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags){}
		public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags){}
		public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags){}
		public ImplicitUseKindFlags UseKindFlags{ get	{} set	{} }
		public ImplicitUseTargetFlags TargetFlags{ get	{} set	{} }
		private ImplicitUseKindFlags <UseKindFlags>k__BackingField;
		private ImplicitUseTargetFlags <TargetFlags>k__BackingField;
	}

	public sealed class	PublicAPIAttribute: Attribute, _Attribute
	{
		public PublicAPIAttribute(){}
		public PublicAPIAttribute(string comment){}
		public string Comment{ get	{} set	{} }
		private string <Comment>k__BackingField;
	}

	public sealed class	InstantHandleAttribute: Attribute, _Attribute
	{
		public InstantHandleAttribute(){}
	}

	public sealed class	PureAttribute: Attribute, _Attribute
	{
		public PureAttribute(){}
	}

	public class	PathReferenceAttribute: Attribute, _Attribute
	{
		public PathReferenceAttribute(){}
		public PathReferenceAttribute(string basePath){}
		public string BasePath{ get	{} set	{} }
		private string <BasePath>k__BackingField;
	}

	public sealed class	NoEnumerationAttribute: Attribute, _Attribute
	{
		public NoEnumerationAttribute(){}
	}

	public sealed class	AssertionMethodAttribute: Attribute, _Attribute
	{
		public AssertionMethodAttribute(){}
	}

	public sealed class	LinqTunnelAttribute: Attribute, _Attribute
	{
		public LinqTunnelAttribute(){}
	}

}

namespace UnityEngine.SocialPlatforms.Impl {
	public class	LocalUser: UserProfile, IUserProfile, ILocalUser
	{
		public sealed virtual void Authenticate(Action<Boolean> callback){}
		public sealed virtual void LoadFriends(Action<Boolean> callback){}
		public void SetFriends(IUserProfile[] friends){}
		public void SetAuthenticated(bool value){}
		public void SetUnderage(bool value){}
		public LocalUser(){}
		public sealed virtual IUserProfile[] friends{ get	{} }
		public sealed virtual bool authenticated{ get	{} }
		public sealed virtual bool underage{ get	{} }
		private IUserProfile[] m_Friends;
		private bool m_Authenticated;
		private bool m_Underage;
	}

	public class	UserProfile: Object, IUserProfile
	{
		public virtual string ToString(){}
		public void SetUserName(string name){}
		public void SetUserID(string id){}
		public void SetImage(Texture2D image){}
		public void SetIsFriend(bool value){}
		public void SetState(UserState state){}
		public UserProfile(){}
		public UserProfile(string name, string id, bool friend){}
		public UserProfile(string name, string id, bool friend, UserState state, Texture2D image){}
		public sealed virtual string userName{ get	{} }
		public sealed virtual string id{ get	{} }
		public sealed virtual bool isFriend{ get	{} }
		public sealed virtual UserState state{ get	{} }
		public sealed virtual Texture2D image{ get	{} }
		protected string m_UserName;
		protected string m_ID;
		protected bool m_IsFriend;
		protected UserState m_State;
		protected Texture2D m_Image;
	}

	public class	Achievement: Object, IAchievement
	{
		public virtual string ToString(){}
		public sealed virtual void ReportProgress(Action<Boolean> callback){}
		public void SetCompleted(bool value){}
		public void SetHidden(bool value){}
		public void SetLastReportedDate(DateTime date){}
		public Achievement(string id, double percentCompleted, bool completed, bool hidden, DateTime lastReportedDate){}
		public Achievement(string id, double percent){}
		public Achievement(){}
		public sealed virtual string id{ get	{} set	{} }
		public sealed virtual double percentCompleted{ get	{} set	{} }
		public sealed virtual bool completed{ get	{} }
		public sealed virtual bool hidden{ get	{} }
		public sealed virtual DateTime lastReportedDate{ get	{} }
		private bool m_Completed;
		private bool m_Hidden;
		private DateTime m_LastReportedDate;
		private string <id>k__BackingField;
		private double <percentCompleted>k__BackingField;
	}

	public class	AchievementDescription: Object, IAchievementDescription
	{
		public virtual string ToString(){}
		public void SetImage(Texture2D image){}
		public AchievementDescription(string id, string title, Texture2D image, string achievedDescription, string unachievedDescription, bool hidden, int points){}
		public sealed virtual string id{ get	{} set	{} }
		public sealed virtual string title{ get	{} }
		public sealed virtual Texture2D image{ get	{} }
		public sealed virtual string achievedDescription{ get	{} }
		public sealed virtual string unachievedDescription{ get	{} }
		public sealed virtual bool hidden{ get	{} }
		public sealed virtual int points{ get	{} }
		private string m_Title;
		private Texture2D m_Image;
		private string m_AchievedDescription;
		private string m_UnachievedDescription;
		private bool m_Hidden;
		private int m_Points;
		private string <id>k__BackingField;
	}

	public class	Score: Object, IScore
	{
		public virtual string ToString(){}
		public sealed virtual void ReportScore(Action<Boolean> callback){}
		public void SetDate(DateTime date){}
		public void SetFormattedValue(string value){}
		public void SetUserID(string userID){}
		public void SetRank(int rank){}
		public Score(){}
		public Score(string leaderboardID, long value){}
		public Score(string leaderboardID, long value, string userID, DateTime date, string formattedValue, int rank){}
		public sealed virtual string leaderboardID{ get	{} set	{} }
		public sealed virtual long value{ get	{} set	{} }
		public sealed virtual DateTime date{ get	{} }
		public sealed virtual string formattedValue{ get	{} }
		public sealed virtual string userID{ get	{} }
		public sealed virtual int rank{ get	{} }
		private DateTime m_Date;
		private string m_FormattedValue;
		private string m_UserID;
		private int m_Rank;
		private string <leaderboardID>k__BackingField;
		private long <value>k__BackingField;
	}

	public class	Leaderboard: Object, ILeaderboard
	{
		public sealed virtual void SetUserFilter(String[] userIDs){}
		public virtual string ToString(){}
		public sealed virtual void LoadScores(Action<Boolean> callback){}
		public void SetLocalUserScore(IScore score){}
		public void SetMaxRange(uint maxRange){}
		public void SetScores(IScore[] scores){}
		public void SetTitle(string title){}
		public String[] GetUserFilter(){}
		public Leaderboard(){}
		public sealed virtual bool loading{ get	{} }
		public sealed virtual string id{ get	{} set	{} }
		public sealed virtual UserScope userScope{ get	{} set	{} }
		public sealed virtual Range range{ get	{} set	{} }
		public sealed virtual TimeScope timeScope{ get	{} set	{} }
		public sealed virtual IScore localUserScore{ get	{} }
		public sealed virtual uint maxRange{ get	{} }
		public sealed virtual IScore[] scores{ get	{} }
		public sealed virtual string title{ get	{} }
		private bool m_Loading;
		private IScore m_LocalUserScore;
		private uint m_MaxRange;
		private IScore[] m_Scores;
		private string m_Title;
		private String[] m_UserIDs;
		private string <id>k__BackingField;
		private UserScope <userScope>k__BackingField;
		private Range <range>k__BackingField;
		private TimeScope <timeScope>k__BackingField;
	}

}

namespace UnityEngine.SocialPlatforms {
	public class	Local: Object, ISocialPlatform
	{
		private sealed virtual void UnityEngine.SocialPlatforms.ISocialPlatform.Authenticate(ILocalUser user, Action<Boolean> callback){}
		private sealed virtual void UnityEngine.SocialPlatforms.ISocialPlatform.LoadFriends(ILocalUser user, Action<Boolean> callback){}
		private sealed virtual void UnityEngine.SocialPlatforms.ISocialPlatform.LoadScores(ILeaderboard board, Action<Boolean> callback){}
		private sealed virtual bool UnityEngine.SocialPlatforms.ISocialPlatform.GetLoading(ILeaderboard board){}
		public sealed virtual void LoadUsers(String[] userIDs, Action<IUserProfile[]> callback){}
		public sealed virtual void ReportProgress(string id, double progress, Action<Boolean> callback){}
		public sealed virtual void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback){}
		public sealed virtual void LoadAchievements(Action<IAchievement[]> callback){}
		public sealed virtual void ReportScore(long score, string board, Action<Boolean> callback){}
		public sealed virtual void LoadScores(string leaderboardID, Action<IScore[]> callback){}
		private void SortScores(Leaderboard board){}
		private void SetLocalPlayerScore(Leaderboard board){}
		public sealed virtual void ShowAchievementsUI(){}
		public sealed virtual void ShowLeaderboardUI(){}
		public sealed virtual ILeaderboard CreateLeaderboard(){}
		public sealed virtual IAchievement CreateAchievement(){}
		private bool VerifyUser(){}
		private void PopulateStaticData(){}
		private Texture2D CreateDummyTexture(int width, int height){}
		private static int <SortScores>m__0(Score s1, Score s2){}
		public Local(){}
		private static Local(){}
		public sealed virtual ILocalUser localUser{ get	{} }
		private List<UserProfile> m_Friends;
		private List<UserProfile> m_Users;
		private List<AchievementDescription> m_AchievementDescriptions;
		private List<Achievement> m_Achievements;
		private List<Leaderboard> m_Leaderboards;
		private Texture2D m_DefaultTexture;
		private static LocalUser m_LocalUser;
		private static Comparison<Score> <>f__am$cache7;
	}

	public interface ISocialPlatform	{
		void LoadUsers(String[] userIDs, Action<IUserProfile[]> callback);
		void ReportProgress(string achievementID, double progress, Action<Boolean> callback);
		void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback);
		void LoadAchievements(Action<IAchievement[]> callback);
		IAchievement CreateAchievement();
		void ReportScore(long score, string board, Action<Boolean> callback);
		void LoadScores(string leaderboardID, Action<IScore[]> callback);
		ILeaderboard CreateLeaderboard();
		void ShowAchievementsUI();
		void ShowLeaderboardUI();
		void Authenticate(ILocalUser user, Action<Boolean> callback);
		void LoadFriends(ILocalUser user, Action<Boolean> callback);
		void LoadScores(ILeaderboard board, Action<Boolean> callback);
		bool GetLoading(ILeaderboard board);
		ILocalUser localUser{ get; }
	}

	public interface ILocalUser: IUserProfile
	{
		void Authenticate(Action<Boolean> callback);
		void LoadFriends(Action<Boolean> callback);
		IUserProfile[] friends{ get; }
		bool authenticated{ get; }
		bool underage{ get; }
	}

	public interface IUserProfile	{
		string userName{ get; }
		string id{ get; }
		bool isFriend{ get; }
		UserState state{ get; }
		Texture2D image{ get; }
	}

	public interface IAchievement	{
		void ReportProgress(Action<Boolean> callback);
		string id{ get; set; }
		double percentCompleted{ get; set; }
		bool completed{ get; }
		bool hidden{ get; }
		DateTime lastReportedDate{ get; }
	}

	public interface IAchievementDescription	{
		string id{ get; set; }
		string title{ get; }
		Texture2D image{ get; }
		string achievedDescription{ get; }
		string unachievedDescription{ get; }
		bool hidden{ get; }
		int points{ get; }
	}

	public interface IScore	{
		void ReportScore(Action<Boolean> callback);
		string leaderboardID{ get; set; }
		long value{ get; set; }
		DateTime date{ get; }
		string formattedValue{ get; }
		string userID{ get; }
		int rank{ get; }
	}

	public interface ILeaderboard	{
		void SetUserFilter(String[] userIDs);
		void LoadScores(Action<Boolean> callback);
		bool loading{ get; }
		string id{ get; set; }
		UserScope userScope{ get; set; }
		Range range{ get; set; }
		TimeScope timeScope{ get; set; }
		IScore localUserScore{ get; }
		uint maxRange{ get; }
		IScore[] scores{ get; }
		string title{ get; }
	}

}

namespace UnityEngine.Events {
	public abstract	class	UnityEventBase: Object, ISerializationCallbackReceiver
	{
		private sealed virtual void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize(){}
		private sealed virtual void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize(){}
		protected abstract virtual MethodInfo FindMethod_Impl(string name, System.Object targetObj);
		internal abstract virtual BaseInvokableCall GetDelegate(System.Object target, MethodInfo theFunction);
		internal MethodInfo FindMethod(PersistentCall call){}
		internal MethodInfo FindMethod(string name, System.Object listener, PersistentListenerMode mode, Type argumentType){}
		public int GetPersistentEventCount(){}
		public System.Object GetPersistentTarget(int index){}
		public string GetPersistentMethodName(int index){}
		private void DirtyPersistentCalls(){}
		private void RebuildPersistentCallsIfNeeded(){}
		public void SetPersistentListenerState(int index, UnityEventCallState state){}
		protected void AddListener(System.Object targetObj, MethodInfo method){}
		internal void AddCall(BaseInvokableCall call){}
		protected void RemoveListener(System.Object targetObj, MethodInfo method){}
		public void RemoveAllListeners(){}
		protected void Invoke(Object[] parameters){}
		public virtual string ToString(){}
		public static MethodInfo GetValidMethodInfo(System.Object obj, string functionName, Type[] argumentTypes){}
		protected bool ValidateRegistration(MethodInfo method, System.Object targetObj, PersistentListenerMode mode){}
		protected bool ValidateRegistration(MethodInfo method, System.Object targetObj, PersistentListenerMode mode, Type argumentType){}
		internal void AddPersistentListener(){}
		protected void RegisterPersistentListener(int index, System.Object targetObj, MethodInfo method){}
		internal void RemovePersistentListener(System.Object target, MethodInfo method){}
		internal void RemovePersistentListener(int index){}
		internal void UnregisterPersistentListener(int index){}
		internal void AddVoidPersistentListener(UnityAction call){}
		internal void RegisterVoidPersistentListener(int index, UnityAction call){}
		internal void AddIntPersistentListener(UnityAction<Int32> call, int argument){}
		internal void RegisterIntPersistentListener(int index, UnityAction<Int32> call, int argument){}
		internal void AddFloatPersistentListener(UnityAction<Single> call, float argument){}
		internal void RegisterFloatPersistentListener(int index, UnityAction<Single> call, float argument){}
		internal void AddBoolPersistentListener(UnityAction<Boolean> call, bool argument){}
		internal void RegisterBoolPersistentListener(int index, UnityAction<Boolean> call, bool argument){}
		internal void AddStringPersistentListener(UnityAction<String> call, string argument){}
		internal void RegisterStringPersistentListener(int index, UnityAction<String> call, string argument){}
		internal void AddObjectPersistentListener(UnityAction<T> call, T argument){}
		internal void RegisterObjectPersistentListener(int index, UnityAction<T> call, T argument){}
		protected UnityEventBase(){}
		private InvokableCallList m_Calls;
		private PersistentCallGroup m_PersistentCalls;
		private string m_TypeName;
		private bool m_CallsDirty;
	}

	public class	UnityEvent: UnityEventBase, ISerializationCallbackReceiver
	{
		public void AddListener(UnityAction call){}
		public void RemoveListener(UnityAction call){}
		protected virtual MethodInfo FindMethod_Impl(string name, System.Object targetObj){}
		internal virtual BaseInvokableCall GetDelegate(System.Object target, MethodInfo theFunction){}
		private static BaseInvokableCall GetDelegate(UnityAction action){}
		public void Invoke(){}
		internal void AddPersistentListener(UnityAction call){}
		internal void AddPersistentListener(UnityAction call, UnityEventCallState callState){}
		internal void RegisterPersistentListener(int index, UnityAction call){}
		public UnityEvent(){}
		private readonly Object[] m_InvokeArray;
	}

	public abstract	class	UnityEvent<T0>: UnityEventBase, ISerializationCallbackReceiver
	{
		public void AddListener(UnityAction<T0> call){}
		public void RemoveListener(UnityAction<T0> call){}
		protected virtual MethodInfo FindMethod_Impl(string name, System.Object targetObj){}
		internal virtual BaseInvokableCall GetDelegate(System.Object target, MethodInfo theFunction){}
		private static BaseInvokableCall GetDelegate(UnityAction<T0> action){}
		public void Invoke(T0 arg0){}
		internal void AddPersistentListener(UnityAction<T0> call){}
		internal void AddPersistentListener(UnityAction<T0> call, UnityEventCallState callState){}
		internal void RegisterPersistentListener(int index, UnityAction<T0> call){}
		protected UnityEvent(){}
		private readonly Object[] m_InvokeArray;
	}

	public abstract	class	UnityEvent<T0, T1>: UnityEventBase, ISerializationCallbackReceiver
	{
		public void AddListener(UnityAction<T0, T1> call){}
		public void RemoveListener(UnityAction<T0, T1> call){}
		protected virtual MethodInfo FindMethod_Impl(string name, System.Object targetObj){}
		internal virtual BaseInvokableCall GetDelegate(System.Object target, MethodInfo theFunction){}
		private static BaseInvokableCall GetDelegate(UnityAction<T0, T1> action){}
		public void Invoke(T0 arg0, T1 arg1){}
		internal void AddPersistentListener(UnityAction<T0, T1> call){}
		internal void AddPersistentListener(UnityAction<T0, T1> call, UnityEventCallState callState){}
		internal void RegisterPersistentListener(int index, UnityAction<T0, T1> call){}
		protected UnityEvent(){}
		private readonly Object[] m_InvokeArray;
	}

	public abstract	class	UnityEvent<T0, T1, T2>: UnityEventBase, ISerializationCallbackReceiver
	{
		public void AddListener(UnityAction<T0, T1, T2> call){}
		public void RemoveListener(UnityAction<T0, T1, T2> call){}
		protected virtual MethodInfo FindMethod_Impl(string name, System.Object targetObj){}
		internal virtual BaseInvokableCall GetDelegate(System.Object target, MethodInfo theFunction){}
		private static BaseInvokableCall GetDelegate(UnityAction<T0, T1, T2> action){}
		public void Invoke(T0 arg0, T1 arg1, T2 arg2){}
		internal void AddPersistentListener(UnityAction<T0, T1, T2> call){}
		internal void AddPersistentListener(UnityAction<T0, T1, T2> call, UnityEventCallState callState){}
		internal void RegisterPersistentListener(int index, UnityAction<T0, T1, T2> call){}
		protected UnityEvent(){}
		private readonly Object[] m_InvokeArray;
	}

	public abstract	class	UnityEvent<T0, T1, T2, T3>: UnityEventBase, ISerializationCallbackReceiver
	{
		public void AddListener(UnityAction<T0, T1, T2, T3> call){}
		public void RemoveListener(UnityAction<T0, T1, T2, T3> call){}
		protected virtual MethodInfo FindMethod_Impl(string name, System.Object targetObj){}
		internal virtual BaseInvokableCall GetDelegate(System.Object target, MethodInfo theFunction){}
		private static BaseInvokableCall GetDelegate(UnityAction<T0, T1, T2, T3> action){}
		public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3){}
		internal void AddPersistentListener(UnityAction<T0, T1, T2, T3> call){}
		internal void AddPersistentListener(UnityAction<T0, T1, T2, T3> call, UnityEventCallState callState){}
		internal void RegisterPersistentListener(int index, UnityAction<T0, T1, T2, T3> call){}
		protected UnityEvent(){}
		private readonly Object[] m_InvokeArray;
	}

	delegate void UnityAction();

	delegate void UnityAction<T0>(T0 arg0);

	delegate void UnityAction<T0, T1>(T0 arg0, T1 arg1);

	delegate void UnityAction<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);

	delegate void UnityAction<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3);

}

namespace UnityEngine.Internal {
	public class	DefaultValueAttribute: Attribute, _Attribute
	{
		public virtual bool Equals(System.Object obj){}
		public virtual int GetHashCode(){}
		public DefaultValueAttribute(string value){}
		public System.Object Value{ get	{} }
		private System.Object DefaultValue;
	}

	public class	ExcludeFromDocsAttribute: Attribute, _Attribute
	{
		public ExcludeFromDocsAttribute(){}
	}

}

namespace UnityEngine.Serialization {
	public class	FormerlySerializedAsAttribute: Attribute, _Attribute
	{
		public FormerlySerializedAsAttribute(string oldName){}
		public string oldName{ get	{} }
		private string m_oldName;
	}

	public class	UnitySurrogateSelector: Object, ISurrogateSelector
	{
		public sealed virtual ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector){}
		public sealed virtual void ChainSelector(ISurrogateSelector selector){}
		public sealed virtual ISurrogateSelector GetNextSelector(){}
		public UnitySurrogateSelector(){}
	}

}

