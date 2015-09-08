// WARNING:Skipped nested type: UnityEngine.EventSystems.EventTrigger+TriggerEvent
// WARNING:Skipped nested type: UnityEngine.EventSystems.EventTrigger+Entry
// WARNING:Skipped nested type: UnityEngine.EventSystems.PointerInputModule+ButtonState
// WARNING:Skipped nested type: UnityEngine.EventSystems.PointerInputModule+MouseState
// WARNING:Skipped nested type: UnityEngine.EventSystems.PointerInputModule+MouseButtonEventData
// WARNING:Skipped nested type: UnityEngine.UI.CoroutineTween.TweenRunner`1+<Start>c__Iterator0[T]
// WARNING:Skipped nested type: UnityEngine.UI.Button+ButtonClickedEvent
// WARNING:Skipped nested type: UnityEngine.UI.InputField+SubmitEvent
// WARNING:Skipped nested type: UnityEngine.UI.InputField+OnChangeEvent
// WARNING:Skipped nested type: UnityEngine.UI.Scrollbar+ScrollEvent
// WARNING:Skipped nested type: UnityEngine.UI.ScrollRect+ScrollRectEvent
// WARNING:Skipped nested type: UnityEngine.UI.Slider+SliderEvent
// WARNING:Skipped nested type: UnityEngine.UI.StencilMaterial+MatEntry
// WARNING:Skipped nested type: UnityEngine.UI.Toggle+ToggleEvent
// WARNING:Skipped nested type: UnityEngine.UI.Button+<OnFinishSubmit>c__Iterator1
// WARNING:Skipped nested type: UnityEngine.UI.InputField+<CaretBlink>c__Iterator2
// WARNING:Skipped nested type: UnityEngine.UI.InputField+<MouseDragOutsideRect>c__Iterator3
// WARNING:Skipped nested type: UnityEngine.UI.Scrollbar+<ClickRepeat>c__Iterator4

// INFO:MMCSReflector::ImportedAssembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

namespace UnityEngine.EventSystems {
	public interface IEventSystemHandler	{
	}

	public interface IPointerEnterHandler: IEventSystemHandler
	{
		void OnPointerEnter(PointerEventData eventData);
	}

	public interface IPointerExitHandler: IEventSystemHandler
	{
		void OnPointerExit(PointerEventData eventData);
	}

	public interface IPointerDownHandler: IEventSystemHandler
	{
		void OnPointerDown(PointerEventData eventData);
	}

	public interface IPointerUpHandler: IEventSystemHandler
	{
		void OnPointerUp(PointerEventData eventData);
	}

	public interface IPointerClickHandler: IEventSystemHandler
	{
		void OnPointerClick(PointerEventData eventData);
	}

	public interface IBeginDragHandler: IEventSystemHandler
	{
		void OnBeginDrag(PointerEventData eventData);
	}

	public interface IInitializePotentialDragHandler: IEventSystemHandler
	{
		void OnInitializePotentialDrag(PointerEventData eventData);
	}

	public interface IDragHandler: IEventSystemHandler
	{
		void OnDrag(PointerEventData eventData);
	}

	public interface IEndDragHandler: IEventSystemHandler
	{
		void OnEndDrag(PointerEventData eventData);
	}

	public interface IDropHandler: IEventSystemHandler
	{
		void OnDrop(PointerEventData eventData);
	}

	public interface IScrollHandler: IEventSystemHandler
	{
		void OnScroll(PointerEventData eventData);
	}

	public interface IUpdateSelectedHandler: IEventSystemHandler
	{
		void OnUpdateSelected(BaseEventData eventData);
	}

	public interface ISelectHandler: IEventSystemHandler
	{
		void OnSelect(BaseEventData eventData);
	}

	public interface IDeselectHandler: IEventSystemHandler
	{
		void OnDeselect(BaseEventData eventData);
	}

	public interface IMoveHandler: IEventSystemHandler
	{
		void OnMove(AxisEventData eventData);
	}

	public interface ISubmitHandler: IEventSystemHandler
	{
		void OnSubmit(BaseEventData eventData);
	}

	public interface ICancelHandler: IEventSystemHandler
	{
		void OnCancel(BaseEventData eventData);
	}

	public class	EventSystem: UIBehaviour
	{
		public void UpdateModules(){}
		public void SetSelectedGameObject(GameObject selected, BaseEventData pointer){}
		public void SetSelectedGameObject(GameObject selected){}
		private static int RaycastComparer(RaycastResult lhs, RaycastResult rhs){}
		public void RaycastAll(PointerEventData eventData, List<RaycastResult> raycastResults){}
		public bool IsPointerOverGameObject(){}
		public bool IsPointerOverGameObject(int pointerId){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		private void TickModules(){}
		protected virtual void Update(){}
		private void ChangeEventModule(BaseInputModule module){}
		public virtual string ToString(){}
		protected EventSystem(){}
		private static EventSystem(){}
		public static EventSystem current{ get	{} set	{} }
		public bool sendNavigationEvents{ get	{} set	{} }
		public int pixelDragThreshold{ get	{} set	{} }
		public BaseInputModule currentInputModule{ get	{} }
		public GameObject firstSelectedGameObject{ get	{} set	{} }
		public GameObject currentSelectedGameObject{ get	{} }
		public GameObject lastSelectedGameObject{ get	{} }
		public bool alreadySelecting{ get	{} }
		BaseEventData baseEventDataCache{ get	{} }
		private List<BaseInputModule> m_SystemInputModules;
		private BaseInputModule m_CurrentInputModule;
		private GameObject m_FirstSelected;
		private bool m_sendNavigationEvents;
		private int m_DragThreshold;
		private GameObject m_CurrentSelected;
		private GameObject m_LastSelected;
		private bool m_SelectionGuard;
		private BaseEventData m_DummyData;
		private readonly static Comparison<RaycastResult> s_RaycastComparer;
		private static EventSystem <current>k__BackingField;
	}

	public class	EventTrigger: MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IInitializePotentialDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler
	{
		private void Execute(EventTriggerType id, BaseEventData eventData){}
		public virtual void OnPointerEnter(PointerEventData eventData){}
		public virtual void OnPointerExit(PointerEventData eventData){}
		public virtual void OnDrag(PointerEventData eventData){}
		public virtual void OnDrop(PointerEventData eventData){}
		public virtual void OnPointerDown(PointerEventData eventData){}
		public virtual void OnPointerUp(PointerEventData eventData){}
		public virtual void OnPointerClick(PointerEventData eventData){}
		public virtual void OnSelect(BaseEventData eventData){}
		public virtual void OnDeselect(BaseEventData eventData){}
		public virtual void OnScroll(PointerEventData eventData){}
		public virtual void OnMove(AxisEventData eventData){}
		public virtual void OnUpdateSelected(BaseEventData eventData){}
		public virtual void OnInitializePotentialDrag(PointerEventData eventData){}
		public virtual void OnBeginDrag(PointerEventData eventData){}
		public virtual void OnEndDrag(PointerEventData eventData){}
		public virtual void OnSubmit(BaseEventData eventData){}
		public virtual void OnCancel(BaseEventData eventData){}
		protected EventTrigger(){}
		public List<Entry> delegates;
	}

	public sealed abstract	class	ExecuteEvents: Object
	{
		public static T ValidateEventData(BaseEventData data){}
		private static void Execute(IPointerEnterHandler handler, BaseEventData eventData){}
		private static void Execute(IPointerExitHandler handler, BaseEventData eventData){}
		private static void Execute(IPointerDownHandler handler, BaseEventData eventData){}
		private static void Execute(IPointerUpHandler handler, BaseEventData eventData){}
		private static void Execute(IPointerClickHandler handler, BaseEventData eventData){}
		private static void Execute(IInitializePotentialDragHandler handler, BaseEventData eventData){}
		private static void Execute(IBeginDragHandler handler, BaseEventData eventData){}
		private static void Execute(IDragHandler handler, BaseEventData eventData){}
		private static void Execute(IEndDragHandler handler, BaseEventData eventData){}
		private static void Execute(IDropHandler handler, BaseEventData eventData){}
		private static void Execute(IScrollHandler handler, BaseEventData eventData){}
		private static void Execute(IUpdateSelectedHandler handler, BaseEventData eventData){}
		private static void Execute(ISelectHandler handler, BaseEventData eventData){}
		private static void Execute(IDeselectHandler handler, BaseEventData eventData){}
		private static void Execute(IMoveHandler handler, BaseEventData eventData){}
		private static void Execute(ISubmitHandler handler, BaseEventData eventData){}
		private static void Execute(ICancelHandler handler, BaseEventData eventData){}
		private static void GetEventChain(GameObject root, IList<Transform> eventChain){}
		public static bool Execute(GameObject target, BaseEventData eventData, EventFunction<T> functor){}
		public static GameObject ExecuteHierarchy(GameObject root, BaseEventData eventData, EventFunction<T> callbackFunction){}
		private static bool ShouldSendToComponent(Component component){}
		private static void GetEventList(GameObject go, IList<IEventSystemHandler> results){}
		public static bool CanHandleEvent(GameObject go){}
		public static GameObject GetEventHandler(GameObject root){}
		private static void <s_HandlerListPool>m__0(List<IEventSystemHandler> l){}
		private static ExecuteEvents(){}
		public static EventFunction<IPointerEnterHandler> pointerEnterHandler{ get	{} }
		public static EventFunction<IPointerExitHandler> pointerExitHandler{ get	{} }
		public static EventFunction<IPointerDownHandler> pointerDownHandler{ get	{} }
		public static EventFunction<IPointerUpHandler> pointerUpHandler{ get	{} }
		public static EventFunction<IPointerClickHandler> pointerClickHandler{ get	{} }
		public static EventFunction<IInitializePotentialDragHandler> initializePotentialDrag{ get	{} }
		public static EventFunction<IBeginDragHandler> beginDragHandler{ get	{} }
		public static EventFunction<IDragHandler> dragHandler{ get	{} }
		public static EventFunction<IEndDragHandler> endDragHandler{ get	{} }
		public static EventFunction<IDropHandler> dropHandler{ get	{} }
		public static EventFunction<IScrollHandler> scrollHandler{ get	{} }
		public static EventFunction<IUpdateSelectedHandler> updateSelectedHandler{ get	{} }
		public static EventFunction<ISelectHandler> selectHandler{ get	{} }
		public static EventFunction<IDeselectHandler> deselectHandler{ get	{} }
		public static EventFunction<IMoveHandler> moveHandler{ get	{} }
		public static EventFunction<ISubmitHandler> submitHandler{ get	{} }
		public static EventFunction<ICancelHandler> cancelHandler{ get	{} }
		private readonly static EventFunction<IPointerEnterHandler> s_PointerEnterHandler;
		private readonly static EventFunction<IPointerExitHandler> s_PointerExitHandler;
		private readonly static EventFunction<IPointerDownHandler> s_PointerDownHandler;
		private readonly static EventFunction<IPointerUpHandler> s_PointerUpHandler;
		private readonly static EventFunction<IPointerClickHandler> s_PointerClickHandler;
		private readonly static EventFunction<IInitializePotentialDragHandler> s_InitializePotentialDragHandler;
		private readonly static EventFunction<IBeginDragHandler> s_BeginDragHandler;
		private readonly static EventFunction<IDragHandler> s_DragHandler;
		private readonly static EventFunction<IEndDragHandler> s_EndDragHandler;
		private readonly static EventFunction<IDropHandler> s_DropHandler;
		private readonly static EventFunction<IScrollHandler> s_ScrollHandler;
		private readonly static EventFunction<IUpdateSelectedHandler> s_UpdateSelectedHandler;
		private readonly static EventFunction<ISelectHandler> s_SelectHandler;
		private readonly static EventFunction<IDeselectHandler> s_DeselectHandler;
		private readonly static EventFunction<IMoveHandler> s_MoveHandler;
		private readonly static EventFunction<ISubmitHandler> s_SubmitHandler;
		private readonly static EventFunction<ICancelHandler> s_CancelHandler;
		private readonly static ObjectPool<List<IEventSystemHandler>> s_HandlerListPool;
		private readonly static List<Transform> s_InternalTransformList;
		private static UnityAction<List<IEventSystemHandler>> <>f__am$cache13;
	}

	public abstract	class	UIBehaviour: MonoBehaviour
	{
		protected virtual void Awake(){}
		protected virtual void OnEnable(){}
		protected virtual void Start(){}
		protected virtual void OnDisable(){}
		protected virtual void OnDestroy(){}
		public virtual bool IsActive(){}
		protected virtual void OnRectTransformDimensionsChange(){}
		protected virtual void OnBeforeTransformParentChanged(){}
		protected virtual void OnTransformParentChanged(){}
		protected virtual void OnDidApplyAnimationProperties(){}
		protected virtual void OnCanvasGroupChanged(){}
		public bool IsDestroyed(){}
		protected UIBehaviour(){}
	}

	public class	AxisEventData: BaseEventData
	{
		public AxisEventData(EventSystem eventSystem){}
		public Vector2 moveVector{ get	{} set	{} }
		public MoveDirection moveDir{ get	{} set	{} }
		private Vector2 <moveVector>k__BackingField;
		private MoveDirection <moveDir>k__BackingField;
	}

	public class	BaseEventData: Object
	{
		public void Reset(){}
		public void Use(){}
		public BaseEventData(EventSystem eventSystem){}
		public bool used{ get	{} }
		public BaseInputModule currentInputModule{ get	{} }
		public GameObject selectedObject{ get	{} set	{} }
		private readonly EventSystem m_EventSystem;
		private bool m_Used;
	}

	public class	PointerEventData: BaseEventData
	{
		public bool IsPointerMoving(){}
		public bool IsScrolling(){}
		public virtual string ToString(){}
		public PointerEventData(EventSystem eventSystem){}
		public GameObject pointerEnter{ get	{} set	{} }
		public GameObject lastPress{ get	{} set	{} }
		public GameObject rawPointerPress{ get	{} set	{} }
		public GameObject pointerDrag{ get	{} set	{} }
		public RaycastResult pointerCurrentRaycast{ get	{} set	{} }
		public RaycastResult pointerPressRaycast{ get	{} set	{} }
		public bool eligibleForClick{ get	{} set	{} }
		public int pointerId{ get	{} set	{} }
		public Vector2 position{ get	{} set	{} }
		public Vector2 delta{ get	{} set	{} }
		public Vector2 pressPosition{ get	{} set	{} }
		public Vector3 worldPosition{ get	{} set	{} }
		public Vector3 worldNormal{ get	{} set	{} }
		public float clickTime{ get	{} set	{} }
		public int clickCount{ get	{} set	{} }
		public Vector2 scrollDelta{ get	{} set	{} }
		public bool useDragThreshold{ get	{} set	{} }
		public bool dragging{ get	{} set	{} }
		public InputButton button{ get	{} set	{} }
		public Camera enterEventCamera{ get	{} }
		public Camera pressEventCamera{ get	{} }
		public GameObject pointerPress{ get	{} set	{} }
		private GameObject m_PointerPress;
		private GameObject <pointerEnter>k__BackingField;
		private GameObject <lastPress>k__BackingField;
		private GameObject <rawPointerPress>k__BackingField;
		private GameObject <pointerDrag>k__BackingField;
		private RaycastResult <pointerCurrentRaycast>k__BackingField;
		private RaycastResult <pointerPressRaycast>k__BackingField;
		private bool <eligibleForClick>k__BackingField;
		private int <pointerId>k__BackingField;
		private Vector2 <position>k__BackingField;
		private Vector2 <delta>k__BackingField;
		private Vector2 <pressPosition>k__BackingField;
		private Vector3 <worldPosition>k__BackingField;
		private Vector3 <worldNormal>k__BackingField;
		private float <clickTime>k__BackingField;
		private int <clickCount>k__BackingField;
		private Vector2 <scrollDelta>k__BackingField;
		private bool <useDragThreshold>k__BackingField;
		private bool <dragging>k__BackingField;
		private InputButton <button>k__BackingField;
	}

	public abstract	class	BaseInputModule: UIBehaviour
	{
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		public abstract virtual void Process();
		protected static RaycastResult FindFirstRaycast(List<RaycastResult> candidates){}
		protected static MoveDirection DetermineMoveDirection(float x, float y){}
		protected static MoveDirection DetermineMoveDirection(float x, float y, float deadZone){}
		protected static GameObject FindCommonRoot(GameObject g1, GameObject g2){}
		protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget){}
		protected virtual AxisEventData GetAxisEventData(float x, float y, float moveDeadZone){}
		protected virtual BaseEventData GetBaseEventData(){}
		public virtual bool IsPointerOverGameObject(int pointerId){}
		public virtual bool ShouldActivateModule(){}
		public virtual void DeactivateModule(){}
		public virtual void ActivateModule(){}
		public virtual void UpdateModule(){}
		public virtual bool IsModuleSupported(){}
		protected BaseInputModule(){}
		EventSystem eventSystem{ get	{} }
		protected List<RaycastResult> m_RaycastResultCache;
		private AxisEventData m_AxisEventData;
		private EventSystem m_EventSystem;
		private BaseEventData m_BaseEventData;
	}

	public abstract	class	PointerInputModule: BaseInputModule
	{
		protected bool GetPointerData(int id, out PointerEventData data, bool create){}
		protected void RemovePointerData(PointerEventData data){}
		protected PointerEventData GetTouchPointerEventData(Touch input, out bool pressed, out bool released){}
		private void CopyFromTo(PointerEventData from, PointerEventData to){}
		protected static FramePressState StateForMouseButton(int buttonId){}
		protected virtual MouseState GetMousePointerEventData(){}
		protected PointerEventData GetLastPointerEventData(int id){}
		private static bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold){}
		protected virtual void ProcessMove(PointerEventData pointerEvent){}
		protected virtual void ProcessDrag(PointerEventData pointerEvent){}
		public virtual bool IsPointerOverGameObject(int pointerId){}
		protected void ClearSelection(){}
		public virtual string ToString(){}
		protected void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent){}
		protected PointerInputModule(){}
		protected Dictionary<Int32, PointerEventData> m_PointerData;
		private readonly MouseState m_MouseState;
		public const int kMouseLeftId = null;
		public const int kMouseRightId = null;
		public const int kMouseMiddleId = null;
		public const int kFakeTouchesId = null;
	}

	public class	StandaloneInputModule: PointerInputModule
	{
		public virtual void UpdateModule(){}
		public virtual bool IsModuleSupported(){}
		public virtual bool ShouldActivateModule(){}
		public virtual void ActivateModule(){}
		public virtual void DeactivateModule(){}
		public virtual void Process(){}
		private bool SendSubmitEventToSelectedObject(){}
		private bool AllowMoveEventProcessing(float time){}
		private Vector2 GetRawMoveVector(){}
		private bool SendMoveEventToSelectedObject(){}
		private void ProcessMouseEvent(){}
		private static bool UseMouse(bool pressed, bool released, PointerEventData pointerData){}
		private bool SendUpdateEventToSelectedObject(){}
		private void ProcessMousePress(MouseButtonEventData data){}
		protected StandaloneInputModule(){}
		public InputMode inputMode{ get	{} }
		public bool allowActivationOnMobileDevice{ get	{} set	{} }
		public float inputActionsPerSecond{ get	{} set	{} }
		public string horizontalAxis{ get	{} set	{} }
		public string verticalAxis{ get	{} set	{} }
		public string submitButton{ get	{} set	{} }
		public string cancelButton{ get	{} set	{} }
		private float m_NextAction;
		private Vector2 m_LastMousePosition;
		private Vector2 m_MousePosition;
		private string m_HorizontalAxis;
		private string m_VerticalAxis;
		private string m_SubmitButton;
		private string m_CancelButton;
		private float m_InputActionsPerSecond;
		private bool m_AllowActivationOnMobileDevice;
	}

	public class	TouchInputModule: PointerInputModule
	{
		public virtual void UpdateModule(){}
		public virtual bool IsModuleSupported(){}
		public virtual bool ShouldActivateModule(){}
		private bool UseFakeInput(){}
		public virtual void Process(){}
		private void FakeTouches(){}
		private void ProcessTouchEvents(){}
		private void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released){}
		public virtual void DeactivateModule(){}
		public virtual string ToString(){}
		protected TouchInputModule(){}
		public bool allowActivationOnStandalone{ get	{} set	{} }
		private Vector2 m_LastMousePosition;
		private Vector2 m_MousePosition;
		private bool m_AllowActivationOnStandalone;
	}

	public abstract	class	BaseRaycaster: UIBehaviour
	{
		public abstract virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		protected BaseRaycaster(){}
		public abstract virtual Camera eventCamera{ get	{} }
		public virtual int priority{ get	{} }
		public virtual int sortOrderPriority{ get	{} }
		public virtual int renderOrderPriority{ get	{} }
	}

	public class	Physics2DRaycaster: PhysicsRaycaster
	{
		public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList){}
		protected Physics2DRaycaster(){}
	}

	public class	PhysicsRaycaster: BaseRaycaster
	{
		public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList){}
		private static int <Raycast>m__1(RaycastHit r1, RaycastHit r2){}
		protected PhysicsRaycaster(){}
		public virtual Camera eventCamera{ get	{} }
		public virtual int depth{ get	{} }
		public int finalEventMask{ get	{} }
		public LayerMask eventMask{ get	{} set	{} }
		protected Camera m_EventCamera;
		protected LayerMask m_EventMask;
		private static Comparison<RaycastHit> <>f__am$cache2;
		protected const int kNoEventMaskSet = null;
	}

	delegate void EventFunction<T1>(T1 handler, BaseEventData eventData);

}

namespace UnityEngine.UI.CoroutineTween {
	internal class	ColorTweenCallback: UnityEvent<Color>, ISerializationCallbackReceiver
	{
		public ColorTweenCallback(){}
	}

}

namespace UnityEngine.UI {
	public class	AnimationTriggers: Object
	{
		public AnimationTriggers(){}
		public string normalTrigger{ get	{} set	{} }
		public string highlightedTrigger{ get	{} set	{} }
		public string pressedTrigger{ get	{} set	{} }
		public string disabledTrigger{ get	{} set	{} }
		private string m_NormalTrigger;
		private string m_HighlightedTrigger;
		private string m_PressedTrigger;
		private string m_DisabledTrigger;
		private const string kDefaultNormalAnimName = null;
		private const string kDefaultSelectedAnimName = null;
		private const string kDefaultPressedAnimName = null;
		private const string kDefaultDisabledAnimName = null;
	}

	public class	Button: Selectable, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler, IMoveHandler, IPointerClickHandler, ISubmitHandler
	{
		private void Press(){}
		public virtual void OnPointerClick(PointerEventData eventData){}
		public virtual void OnSubmit(BaseEventData eventData){}
		private IEnumerator OnFinishSubmit(){}
		protected Button(){}
		public ButtonClickedEvent onClick{ get	{} set	{} }
		private ButtonClickedEvent m_OnClick;
	}

	public interface ICanvasElement	{
		void Rebuild(CanvasUpdate executing);
		bool IsDestroyed();
		Transform transform{ get; }
	}

	public class	CanvasUpdateRegistry: Object
	{
		private bool ObjectValidForUpdate(ICanvasElement element){}
		private void PerformUpdate(){}
		private static int ParentCount(Transform child){}
		private static int SortLayoutList(ICanvasElement x, ICanvasElement y){}
		public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element){}
		private void InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element){}
		public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element){}
		private void InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element){}
		public static void UnRegisterCanvasElementForRebuild(ICanvasElement element){}
		private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element){}
		private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element){}
		public static bool IsRebuildingLayout(){}
		public static bool IsRebuildingGraphics(){}
		private static bool <PerformUpdate>m__2(ICanvasElement x){}
		private static bool <PerformUpdate>m__3(ICanvasElement x){}
		protected CanvasUpdateRegistry(){}
		private static CanvasUpdateRegistry(){}
		public static CanvasUpdateRegistry instance{ get	{} }
		private bool m_PerformingLayoutUpdate;
		private bool m_PerformingGraphicUpdate;
		private readonly IndexedSet<ICanvasElement> m_LayoutRebuildQueue;
		private readonly IndexedSet<ICanvasElement> m_GraphicRebuildQueue;
		private static CanvasUpdateRegistry s_Instance;
		private readonly static Comparison<ICanvasElement> s_SortLayoutFunction;
		private static Predicate<ICanvasElement> <>f__am$cache6;
		private static Predicate<ICanvasElement> <>f__am$cache7;
	}

	public class	FontData: Object, ISerializationCallbackReceiver
	{
		private sealed virtual void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize(){}
		private sealed virtual void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize(){}
		public FontData(){}
		public static FontData defaultFontData{ get	{} }
		public Font font{ get	{} set	{} }
		public int fontSize{ get	{} set	{} }
		public FontStyle fontStyle{ get	{} set	{} }
		public bool bestFit{ get	{} set	{} }
		public int minSize{ get	{} set	{} }
		public int maxSize{ get	{} set	{} }
		public TextAnchor alignment{ get	{} set	{} }
		public bool richText{ get	{} set	{} }
		public HorizontalWrapMode horizontalOverflow{ get	{} set	{} }
		public VerticalWrapMode verticalOverflow{ get	{} set	{} }
		public float lineSpacing{ get	{} set	{} }
		private Font m_Font;
		private int m_FontSize;
		private FontStyle m_FontStyle;
		private bool m_BestFit;
		private int m_MinSize;
		private int m_MaxSize;
		private TextAnchor m_Alignment;
		private bool m_RichText;
		private HorizontalWrapMode m_HorizontalOverflow;
		private VerticalWrapMode m_VerticalOverflow;
		private float m_LineSpacing;
	}

	public sealed abstract	class	FontUpdateTracker: Object
	{
		public static void TrackText(Text t){}
		private static void RebuildForFont(Font f){}
		public static void UntrackText(Text t){}
		private static FontUpdateTracker(){}
		private static Dictionary<Font, List<Text>> m_Tracked;
	}

	public abstract	class	Graphic: UIBehaviour, ICanvasElement
	{
		public virtual void SetAllDirty(){}
		public virtual void SetLayoutDirty(){}
		public virtual void SetVerticesDirty(){}
		public virtual void SetMaterialDirty(){}
		protected virtual void OnRectTransformDimensionsChange(){}
		protected virtual void OnBeforeTransformParentChanged(){}
		protected virtual void OnTransformParentChanged(){}
		private void CacheCanvas(){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		private void SendGraphicEnabledDisabled(){}
		public virtual void Rebuild(CanvasUpdate update){}
		protected virtual void UpdateGeometry(){}
		protected virtual void UpdateMaterial(){}
		protected virtual void OnFillVBO(List<UIVertex> vbo){}
		protected virtual void OnDidApplyAnimationProperties(){}
		public virtual void SetNativeSize(){}
		public virtual bool Raycast(Vector2 sp, Camera eventCamera){}
		public Vector2 PixelAdjustPoint(Vector2 point){}
		public Rect GetPixelAdjustedRect(){}
		public void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha){}
		private void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB){}
		private static Color CreateColorFromAlpha(float alpha){}
		public void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale){}
		public void RegisterDirtyLayoutCallback(UnityAction action){}
		public void UnregisterDirtyLayoutCallback(UnityAction action){}
		public void RegisterDirtyVerticesCallback(UnityAction action){}
		public void UnregisterDirtyVerticesCallback(UnityAction action){}
		public void RegisterDirtyMaterialCallback(UnityAction action){}
		public void UnregisterDirtyMaterialCallback(UnityAction action){}
		private static void <s_VboPool>m__4(List<UIVertex> x){}
		private static void <s_VboPool>m__5(List<UIVertex> l){}
		private virtual bool UnityEngine.UI.ICanvasElement.IsDestroyed(){}
		private virtual Transform UnityEngine.UI.ICanvasElement.get_transform(){}
		protected Graphic(){}
		private static Graphic(){}
		public static Material defaultGraphicMaterial{ get	{} }
		public Color color{ get	{} set	{} }
		public int depth{ get	{} }
		public RectTransform rectTransform{ get	{} }
		public Canvas canvas{ get	{} }
		public CanvasRenderer canvasRenderer{ get	{} }
		public virtual Material defaultMaterial{ get	{} }
		public virtual Material material{ get	{} set	{} }
		public virtual Material materialForRendering{ get	{} }
		public virtual Texture mainTexture{ get	{} }
		protected Material m_Material;
		private Color m_Color;
		private RectTransform m_RectTransform;
		private CanvasRenderer m_CanvasRender;
		private Canvas m_Canvas;
		private bool m_VertsDirty;
		private bool m_MaterialDirty;
		protected UnityAction m_OnDirtyLayoutCallback;
		protected UnityAction m_OnDirtyVertsCallback;
		protected UnityAction m_OnDirtyMaterialCallback;
		private readonly TweenRunner<ColorTween> m_ColorTweenRunner;
		protected static Material s_DefaultUI;
		protected static Texture2D s_WhiteTexture;
		private readonly static ObjectPool<List<UIVertex>> s_VboPool;
		private static UnityAction<List<UIVertex>> <>f__am$cacheE;
		private static UnityAction<List<UIVertex>> <>f__am$cacheF;
	}

	public class	GraphicRaycaster: BaseRaycaster
	{
		public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList){}
		private static void Raycast(Canvas canvas, Camera eventCamera, Vector2 pointerPosition, List<Graphic> results){}
		private static int <Raycast>m__6(Graphic g1, Graphic g2){}
		protected GraphicRaycaster(){}
		private static GraphicRaycaster(){}
		public virtual int sortOrderPriority{ get	{} }
		public virtual int renderOrderPriority{ get	{} }
		public bool ignoreReversedGraphics{ get	{} set	{} }
		public BlockingObjects blockingObjects{ get	{} set	{} }
		Canvas canvas{ get	{} }
		public virtual Camera eventCamera{ get	{} }
		private bool m_IgnoreReversedGraphics;
		private BlockingObjects m_BlockingObjects;
		protected LayerMask m_BlockingMask;
		private Canvas m_Canvas;
		private List<Graphic> m_RaycastResults;
		private readonly static List<Graphic> s_SortedGraphics;
		private static Comparison<Graphic> <>f__am$cache6;
		protected const int kNoEventMaskSet = null;
	}

	public class	GraphicRegistry: Object
	{
		public static void RegisterGraphicForCanvas(Canvas c, Graphic graphic){}
		public static void UnregisterGraphicForCanvas(Canvas c, Graphic graphic){}
		public static IList<Graphic> GetGraphicsForCanvas(Canvas canvas){}
		protected GraphicRegistry(){}
		private static GraphicRegistry(){}
		public static GraphicRegistry instance{ get	{} }
		private readonly Dictionary<Canvas, IndexedSet<Graphic>> m_Graphics;
		private static GraphicRegistry s_Instance;
		private readonly static List<Graphic> s_EmptyList;
	}

	public class	Image: MaskableGraphic, ICanvasElement, IMaskable, ICanvasRaycastFilter, ISerializationCallbackReceiver, ILayoutElement
	{
		public virtual void OnBeforeSerialize(){}
		public virtual void OnAfterDeserialize(){}
		private Vector4 GetDrawingDimensions(bool shouldPreserveAspect){}
		public virtual void SetNativeSize(){}
		protected virtual void OnFillVBO(List<UIVertex> vbo){}
		private void GenerateSimpleSprite(List<UIVertex> vbo, bool preserveAspect){}
		private void GenerateSlicedSprite(List<UIVertex> vbo){}
		private void GenerateTiledSprite(List<UIVertex> vbo){}
		private void AddQuad(List<UIVertex> vbo, UIVertex v, Vector2 posMin, Vector2 posMax, Vector2 uvMin, Vector2 uvMax){}
		private Vector4 GetAdjustedBorders(Vector4 border, Rect rect){}
		private void GenerateFilledSprite(List<UIVertex> vbo, bool preserveAspect){}
		private static bool RadialCut(Vector2[] xy, Vector2[] uv, float fill, bool invert, int corner){}
		private static void RadialCut(Vector2[] xy, float cos, float sin, bool invert, int corner){}
		public virtual void CalculateLayoutInputHorizontal(){}
		public virtual void CalculateLayoutInputVertical(){}
		public virtual bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera){}
		private Vector2 MapCoordinate(Vector2 local, Rect rect){}
		protected Image(){}
		private static Image(){}
		public Sprite sprite{ get	{} set	{} }
		public Sprite overrideSprite{ get	{} set	{} }
		public Type type{ get	{} set	{} }
		public bool preserveAspect{ get	{} set	{} }
		public bool fillCenter{ get	{} set	{} }
		public FillMethod fillMethod{ get	{} set	{} }
		public float fillAmount{ get	{} set	{} }
		public bool fillClockwise{ get	{} set	{} }
		public int fillOrigin{ get	{} set	{} }
		public float eventAlphaThreshold{ get	{} set	{} }
		public virtual Texture mainTexture{ get	{} }
		public bool hasBorder{ get	{} }
		public float pixelsPerUnit{ get	{} }
		public virtual float minWidth{ get	{} }
		public virtual float preferredWidth{ get	{} }
		public virtual float flexibleWidth{ get	{} }
		public virtual float minHeight{ get	{} }
		public virtual float preferredHeight{ get	{} }
		public virtual float flexibleHeight{ get	{} }
		public virtual int layoutPriority{ get	{} }
		private Sprite m_Sprite;
		private Sprite m_OverrideSprite;
		private Type m_Type;
		private bool m_PreserveAspect;
		private bool m_FillCenter;
		private FillMethod m_FillMethod;
		private float m_FillAmount;
		private bool m_FillClockwise;
		private int m_FillOrigin;
		private float m_EventAlphaThreshold;
		private readonly static Vector2[] s_VertScratch;
		private readonly static Vector2[] s_UVScratch;
		private readonly static Vector2[] s_Xy;
		private readonly static Vector2[] s_Uv;
	}

	public interface IMask	{
		bool MaskEnabled();
	}

	public interface IMaskable	{
		void ParentMaskStateChanged();
	}

	public class	InputField: Selectable, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler, IMoveHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IUpdateSelectedHandler, ISubmitHandler, ICanvasElement
	{
		protected void ClampPos(ref int pos){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		private IEnumerator CaretBlink(){}
		private void SetCaretVisible(){}
		private void SetCaretActive(){}
		protected void OnFocus(){}
		protected void SelectAll(){}
		public void MoveTextEnd(bool shift){}
		public void MoveTextStart(bool shift){}
		private bool InPlaceEditing(){}
		protected virtual void LateUpdate(){}
		public Vector2 ScreenToLocal(Vector2 screen){}
		private int GetUnclampedCharacterLineFromPosition(Vector2 pos, TextGenerator generator){}
		protected int GetCharacterIndexFromPosition(Vector2 pos){}
		private bool MayDrag(PointerEventData eventData){}
		public virtual void OnBeginDrag(PointerEventData eventData){}
		public virtual void OnDrag(PointerEventData eventData){}
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData){}
		public virtual void OnEndDrag(PointerEventData eventData){}
		public virtual void OnPointerDown(PointerEventData eventData){}
		protected EditState KeyPressed(Event evt){}
		private bool IsValidChar(char c){}
		public void ProcessEvent(Event e){}
		public virtual void OnUpdateSelected(BaseEventData eventData){}
		private string GetSelectedString(){}
		private int FindtNextWordBegin(){}
		private void MoveRight(bool shift, bool ctrl){}
		private int FindtPrevWordBegin(){}
		private void MoveLeft(bool shift, bool ctrl){}
		private int DetermineCharacterLine(int charPos, TextGenerator generator){}
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar){}
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar){}
		private void MoveDown(bool shift){}
		private void MoveDown(bool shift, bool goToLastChar){}
		private void MoveUp(bool shift){}
		private void MoveUp(bool shift, bool goToFirstChar){}
		private void Delete(){}
		private void ForwardSpace(){}
		private void Backspace(){}
		private void Insert(char c){}
		private void SendOnValueChangedAndUpdateLabel(){}
		private void SendOnValueChanged(){}
		protected void SendOnSubmit(){}
		protected virtual void Append(string input){}
		protected virtual void Append(char input){}
		protected void UpdateLabel(){}
		private bool IsSelectionVisible(){}
		private static int GetLineStartPosition(TextGenerator gen, int line){}
		private static int GetLineEndPosition(TextGenerator gen, int line){}
		private void SetDrawRangeToContainCaretPosition(TextGenerator gen, int caretPos, ref int drawStart, ref int drawEnd){}
		private void MarkGeometryAsDirty(){}
		public virtual void Rebuild(CanvasUpdate update){}
		private void UpdateGeometry(){}
		private void AssignPositioningIfNeeded(){}
		private void OnFillVBO(List<UIVertex> vbo){}
		private void GenerateCursor(List<UIVertex> vbo, Vector2 roundingOffset){}
		private void CreateCursorVerts(){}
		private float SumLineHeights(int endLine, TextGenerator generator){}
		private void GenerateHightlight(List<UIVertex> vbo, Vector2 roundingOffset){}
		protected char Validate(string text, int pos, char ch){}
		public void ActivateInputField(){}
		private void ActivateInputFieldInternal(){}
		public virtual void OnSelect(BaseEventData eventData){}
		public virtual void OnPointerClick(PointerEventData eventData){}
		public void DeactivateInputField(){}
		public virtual void OnDeselect(BaseEventData eventData){}
		public virtual void OnSubmit(BaseEventData eventData){}
		private void EnforceContentType(){}
		private void SetToCustomIfContentTypeIsNot(ContentType[] allowedContentTypes){}
		private void SetToCustom(){}
		protected virtual void DoStateTransition(SelectionState state, bool instant){}
		private virtual bool UnityEngine.UI.ICanvasElement.IsDestroyed(){}
		private virtual Transform UnityEngine.UI.ICanvasElement.get_transform(){}
		protected InputField(){}
		private static InputField(){}
		TextGenerator cachedInputTextGenerator{ get	{} }
		public bool shouldHideMobileInput{ get	{} set	{} }
		public string text{ get	{} set	{} }
		public bool isFocused{ get	{} }
		public float caretBlinkRate{ get	{} set	{} }
		public Text textComponent{ get	{} set	{} }
		public Graphic placeholder{ get	{} set	{} }
		public Color selectionColor{ get	{} set	{} }
		public SubmitEvent onEndEdit{ get	{} set	{} }
		public OnChangeEvent onValueChange{ get	{} set	{} }
		public OnValidateInput onValidateInput{ get	{} set	{} }
		public int characterLimit{ get	{} set	{} }
		public ContentType contentType{ get	{} set	{} }
		public LineType lineType{ get	{} set	{} }
		public InputType inputType{ get	{} set	{} }
		public TouchScreenKeyboardType keyboardType{ get	{} set	{} }
		public CharacterValidation characterValidation{ get	{} set	{} }
		public bool multiLine{ get	{} }
		public char asteriskChar{ get	{} set	{} }
		public bool wasCanceled{ get	{} }
		int caretPosition{ get	{} set	{} }
		int caretSelectPos{ get	{} set	{} }
		bool hasSelection{ get	{} }
		string clipboard{ get	{} set	{} }
		protected Text m_TextComponent;
		protected Graphic m_Placeholder;
		private ContentType m_ContentType;
		private InputType m_InputType;
		private char m_AsteriskChar;
		private TouchScreenKeyboardType m_KeyboardType;
		private LineType m_LineType;
		private bool m_HideMobileInput;
		private CharacterValidation m_CharacterValidation;
		private int m_CharacterLimit;
		private SubmitEvent m_EndEdit;
		private OnChangeEvent m_OnValueChange;
		private OnValidateInput m_OnValidateInput;
		private Color m_SelectionColor;
		protected string m_Text;
		private float m_CaretBlinkRate;
		protected int m_CaretPosition;
		protected int m_CaretSelectPosition;
		private RectTransform caretRectTrans;
		protected UIVertex[] m_CursorVerts;
		private TextGenerator m_InputTextCache;
		private CanvasRenderer m_CachedInputRenderer;
		private readonly List<UIVertex> m_Vbo;
		private bool m_AllowInput;
		private bool m_ShouldActivateNextUpdate;
		private bool m_UpdateDrag;
		private bool m_DragPositionOutOfBounds;
		protected bool m_CaretVisible;
		private Coroutine m_BlickCoroutine;
		private float m_BlinkStartTime;
		protected int m_DrawStart;
		protected int m_DrawEnd;
		private Coroutine m_DragCoroutine;
		private string m_OriginalText;
		private bool m_WasCanceled;
		private bool m_HasDoneFocusTransition;
		private Event m_ProcessingEvent;
		protected static TouchScreenKeyboard m_Keyboard;
		private readonly static Char[] kSeparators;
		private const float kHScrollSpeed = null;
		private const float kVScrollSpeed = null;
		private const string kEmailSpecialCharacters = null;
	}

	public abstract	class	MaskableGraphic: Graphic, ICanvasElement, IMaskable
	{
		private void UpdateInternalState(){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		protected virtual void OnTransformParentChanged(){}
		public virtual void ParentMaskStateChanged(){}
		private void ClearMaskMaterial(){}
		public virtual void SetMaterialDirty(){}
		private int GetStencilForGraphic(){}
		protected MaskableGraphic(){}
		public bool maskable{ get	{} set	{} }
		public virtual Material material{ get	{} set	{} }
		private bool m_Maskable;
		protected Material m_MaskMaterial;
		protected bool m_IncludeForMasking;
		protected int m_StencilValue;
		protected bool m_ShouldRecalculate;
	}

	public class	RawImage: MaskableGraphic, ICanvasElement, IMaskable
	{
		public virtual void SetNativeSize(){}
		protected virtual void OnFillVBO(List<UIVertex> vbo){}
		protected RawImage(){}
		public virtual Texture mainTexture{ get	{} }
		public Texture texture{ get	{} set	{} }
		public Rect uvRect{ get	{} set	{} }
		private Texture m_Texture;
		private Rect m_UVRect;
	}

	public class	Scrollbar: Selectable, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler, IMoveHandler, IBeginDragHandler, IInitializePotentialDragHandler, IDragHandler, ICanvasElement
	{
		public virtual void Rebuild(CanvasUpdate executing){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		private void UpdateCachedReferences(){}
		private void Set(float input){}
		private void Set(float input, bool sendCallback){}
		protected virtual void OnRectTransformDimensionsChange(){}
		private void UpdateVisuals(){}
		private void UpdateDrag(PointerEventData eventData){}
		private bool MayDrag(PointerEventData eventData){}
		public virtual void OnBeginDrag(PointerEventData eventData){}
		public virtual void OnDrag(PointerEventData eventData){}
		public virtual void OnPointerDown(PointerEventData eventData){}
		protected IEnumerator ClickRepeat(PointerEventData eventData){}
		public virtual void OnPointerUp(PointerEventData eventData){}
		public virtual void OnMove(AxisEventData eventData){}
		public virtual Selectable FindSelectableOnLeft(){}
		public virtual Selectable FindSelectableOnRight(){}
		public virtual Selectable FindSelectableOnUp(){}
		public virtual Selectable FindSelectableOnDown(){}
		public virtual void OnInitializePotentialDrag(PointerEventData eventData){}
		public void SetDirection(Direction direction, bool includeRectLayouts){}
		private virtual bool UnityEngine.UI.ICanvasElement.IsDestroyed(){}
		private virtual Transform UnityEngine.UI.ICanvasElement.get_transform(){}
		protected Scrollbar(){}
		public RectTransform handleRect{ get	{} set	{} }
		public Direction direction{ get	{} set	{} }
		public float value{ get	{} set	{} }
		public float size{ get	{} set	{} }
		public int numberOfSteps{ get	{} set	{} }
		public ScrollEvent onValueChanged{ get	{} set	{} }
		float stepSize{ get	{} }
		Axis axis{ get	{} }
		bool reverseValue{ get	{} }
		private RectTransform m_HandleRect;
		private Direction m_Direction;
		private float m_Value;
		private float m_Size;
		private int m_NumberOfSteps;
		private ScrollEvent m_OnValueChanged;
		private RectTransform m_ContainerRect;
		private Vector2 m_Offset;
		private DrivenRectTransformTracker m_Tracker;
		private Coroutine m_PointerDownRepeat;
		private bool isPointerDownAndNotDragging;
	}

	public class	ScrollRect: UIBehaviour, IEventSystemHandler, IBeginDragHandler, IInitializePotentialDragHandler, IDragHandler, IEndDragHandler, IScrollHandler, ICanvasElement
	{
		public virtual void Rebuild(CanvasUpdate executing){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		public virtual bool IsActive(){}
		private void EnsureLayoutHasRebuilt(){}
		public virtual void StopMovement(){}
		public virtual void OnScroll(PointerEventData data){}
		public virtual void OnInitializePotentialDrag(PointerEventData eventData){}
		public virtual void OnBeginDrag(PointerEventData eventData){}
		public virtual void OnEndDrag(PointerEventData eventData){}
		public virtual void OnDrag(PointerEventData eventData){}
		protected virtual void SetContentAnchoredPosition(Vector2 position){}
		protected virtual void LateUpdate(){}
		private void UpdatePrevData(){}
		private void UpdateScrollbars(Vector2 offset){}
		private void SetHorizontalNormalizedPosition(float value){}
		private void SetVerticalNormalizedPosition(float value){}
		private void SetNormalizedPosition(float value, int axis){}
		private static float RubberDelta(float overStretching, float viewSize){}
		private void UpdateBounds(){}
		private Bounds GetBounds(){}
		private Vector2 CalculateOffset(Vector2 delta){}
		private virtual bool UnityEngine.UI.ICanvasElement.IsDestroyed(){}
		private virtual Transform UnityEngine.UI.ICanvasElement.get_transform(){}
		protected ScrollRect(){}
		public RectTransform content{ get	{} set	{} }
		public bool horizontal{ get	{} set	{} }
		public bool vertical{ get	{} set	{} }
		public MovementType movementType{ get	{} set	{} }
		public float elasticity{ get	{} set	{} }
		public bool inertia{ get	{} set	{} }
		public float decelerationRate{ get	{} set	{} }
		public float scrollSensitivity{ get	{} set	{} }
		public Scrollbar horizontalScrollbar{ get	{} set	{} }
		public Scrollbar verticalScrollbar{ get	{} set	{} }
		public ScrollRectEvent onValueChanged{ get	{} set	{} }
		RectTransform viewRect{ get	{} }
		public Vector2 velocity{ get	{} set	{} }
		public Vector2 normalizedPosition{ get	{} set	{} }
		public float horizontalNormalizedPosition{ get	{} set	{} }
		public float verticalNormalizedPosition{ get	{} set	{} }
		private RectTransform m_Content;
		private bool m_Horizontal;
		private bool m_Vertical;
		private MovementType m_MovementType;
		private float m_Elasticity;
		private bool m_Inertia;
		private float m_DecelerationRate;
		private float m_ScrollSensitivity;
		private Scrollbar m_HorizontalScrollbar;
		private Scrollbar m_VerticalScrollbar;
		private ScrollRectEvent m_OnValueChanged;
		private Vector2 m_PointerStartLocalCursor;
		private Vector2 m_ContentStartPosition;
		private RectTransform m_ViewRect;
		private Bounds m_ContentBounds;
		private Bounds m_ViewBounds;
		private Vector2 m_Velocity;
		private bool m_Dragging;
		private Vector2 m_PrevPosition;
		private Bounds m_PrevContentBounds;
		private Bounds m_PrevViewBounds;
		private bool m_HasRebuiltLayout;
		private readonly Vector3[] m_Corners;
	}

	public class	Selectable: UIBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler, IMoveHandler
	{
		protected virtual void Awake(){}
		protected virtual void OnCanvasGroupChanged(){}
		public virtual bool IsInteractable(){}
		protected virtual void OnDidApplyAnimationProperties(){}
		protected virtual void OnEnable(){}
		private void OnSetProperty(){}
		protected virtual void OnDisable(){}
		protected virtual void InstantClearState(){}
		protected virtual void DoStateTransition(SelectionState state, bool instant){}
		public Selectable FindSelectable(Vector3 dir){}
		private static Vector3 GetPointOnRectEdge(RectTransform rect, Vector2 dir){}
		private void Navigate(AxisEventData eventData, Selectable sel){}
		public virtual Selectable FindSelectableOnLeft(){}
		public virtual Selectable FindSelectableOnRight(){}
		public virtual Selectable FindSelectableOnUp(){}
		public virtual Selectable FindSelectableOnDown(){}
		public virtual void OnMove(AxisEventData eventData){}
		private void StartColorTween(Color targetColor, bool instant){}
		private void DoSpriteSwap(Sprite newSprite){}
		private void TriggerAnimation(string triggername){}
		protected bool IsHighlighted(BaseEventData eventData){}
		protected bool IsPressed(BaseEventData eventData){}
		protected bool IsPressed(){}
		protected void UpdateSelectionState(BaseEventData eventData){}
		private void EvaluateAndTransitionToSelectionState(BaseEventData eventData){}
		private void InternalEvaluateAndTransitionToSelectionState(bool instant){}
		public virtual void OnPointerDown(PointerEventData eventData){}
		public virtual void OnPointerUp(PointerEventData eventData){}
		public virtual void OnPointerEnter(PointerEventData eventData){}
		public virtual void OnPointerExit(PointerEventData eventData){}
		public virtual void OnSelect(BaseEventData eventData){}
		public virtual void OnDeselect(BaseEventData eventData){}
		public virtual void Select(){}
		protected Selectable(){}
		private static Selectable(){}
		public static List<Selectable> allSelectables{ get	{} }
		public Navigation navigation{ get	{} set	{} }
		public Transition transition{ get	{} set	{} }
		public ColorBlock colors{ get	{} set	{} }
		public SpriteState spriteState{ get	{} set	{} }
		public AnimationTriggers animationTriggers{ get	{} set	{} }
		public Graphic targetGraphic{ get	{} set	{} }
		public bool interactable{ get	{} set	{} }
		bool isPointerInside{ get	{} set	{} }
		bool isPointerDown{ get	{} set	{} }
		bool hasSelection{ get	{} set	{} }
		public Image image{ get	{} set	{} }
		public Animator animator{ get	{} }
		SelectionState currentSelectionState{ get	{} }
		private Navigation m_Navigation;
		private Transition m_Transition;
		private ColorBlock m_Colors;
		private SpriteState m_SpriteState;
		private AnimationTriggers m_AnimationTriggers;
		private bool m_Interactable;
		private Graphic m_TargetGraphic;
		private bool m_GroupsAllowInteraction;
		private SelectionState m_CurrentSelectionState;
		private readonly List<CanvasGroup> m_CanvasGroupCache;
		private bool <isPointerInside>k__BackingField;
		private bool <isPointerDown>k__BackingField;
		private bool <hasSelection>k__BackingField;
		private static List<Selectable> s_List;
	}

	public class	Slider: Selectable, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler, IMoveHandler, IInitializePotentialDragHandler, IDragHandler, ICanvasElement
	{
		public virtual void Rebuild(CanvasUpdate executing){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		private void UpdateCachedReferences(){}
		private void Set(float input){}
		private void Set(float input, bool sendCallback){}
		protected virtual void OnRectTransformDimensionsChange(){}
		private void UpdateVisuals(){}
		private void UpdateDrag(PointerEventData eventData, Camera cam){}
		private bool MayDrag(PointerEventData eventData){}
		public virtual void OnPointerDown(PointerEventData eventData){}
		public virtual void OnDrag(PointerEventData eventData){}
		public virtual void OnMove(AxisEventData eventData){}
		public virtual Selectable FindSelectableOnLeft(){}
		public virtual Selectable FindSelectableOnRight(){}
		public virtual Selectable FindSelectableOnUp(){}
		public virtual Selectable FindSelectableOnDown(){}
		public virtual void OnInitializePotentialDrag(PointerEventData eventData){}
		public void SetDirection(Direction direction, bool includeRectLayouts){}
		private virtual bool UnityEngine.UI.ICanvasElement.IsDestroyed(){}
		private virtual Transform UnityEngine.UI.ICanvasElement.get_transform(){}
		protected Slider(){}
		public RectTransform fillRect{ get	{} set	{} }
		public RectTransform handleRect{ get	{} set	{} }
		public Direction direction{ get	{} set	{} }
		public float minValue{ get	{} set	{} }
		public float maxValue{ get	{} set	{} }
		public bool wholeNumbers{ get	{} set	{} }
		public float value{ get	{} set	{} }
		public float normalizedValue{ get	{} set	{} }
		public SliderEvent onValueChanged{ get	{} set	{} }
		float stepSize{ get	{} }
		Axis axis{ get	{} }
		bool reverseValue{ get	{} }
		private RectTransform m_FillRect;
		private RectTransform m_HandleRect;
		private Direction m_Direction;
		private float m_MinValue;
		private float m_MaxValue;
		private bool m_WholeNumbers;
		private float m_Value;
		private SliderEvent m_OnValueChanged;
		private Image m_FillImage;
		private Transform m_FillTransform;
		private RectTransform m_FillContainerRect;
		private Transform m_HandleTransform;
		private RectTransform m_HandleContainerRect;
		private Vector2 m_Offset;
		private DrivenRectTransformTracker m_Tracker;
	}

	public sealed abstract	class	StencilMaterial: Object
	{
		public static Material Add(Material baseMat, int stencilID){}
		public static void Remove(Material customMat){}
		private static StencilMaterial(){}
		private static List<MatEntry> m_List;
	}

	public class	Text: MaskableGraphic, ICanvasElement, IMaskable, ILayoutElement
	{
		public void FontTextureChanged(){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		protected virtual void UpdateGeometry(){}
		public TextGenerationSettings GetGenerationSettings(Vector2 extents){}
		public static Vector2 GetTextAnchorPivot(TextAnchor anchor){}
		protected virtual void OnFillVBO(List<UIVertex> vbo){}
		public virtual void CalculateLayoutInputHorizontal(){}
		public virtual void CalculateLayoutInputVertical(){}
		protected Text(){}
		private static Text(){}
		public TextGenerator cachedTextGenerator{ get	{} }
		public TextGenerator cachedTextGeneratorForLayout{ get	{} }
		public virtual Material defaultMaterial{ get	{} }
		public virtual Texture mainTexture{ get	{} }
		public Font font{ get	{} set	{} }
		public virtual string text{ get	{} set	{} }
		public bool supportRichText{ get	{} set	{} }
		public bool resizeTextForBestFit{ get	{} set	{} }
		public int resizeTextMinSize{ get	{} set	{} }
		public int resizeTextMaxSize{ get	{} set	{} }
		public TextAnchor alignment{ get	{} set	{} }
		public int fontSize{ get	{} set	{} }
		public HorizontalWrapMode horizontalOverflow{ get	{} set	{} }
		public VerticalWrapMode verticalOverflow{ get	{} set	{} }
		public float lineSpacing{ get	{} set	{} }
		public FontStyle fontStyle{ get	{} set	{} }
		public float pixelsPerUnit{ get	{} }
		public virtual float minWidth{ get	{} }
		public virtual float preferredWidth{ get	{} }
		public virtual float flexibleWidth{ get	{} }
		public virtual float minHeight{ get	{} }
		public virtual float preferredHeight{ get	{} }
		public virtual float flexibleHeight{ get	{} }
		public virtual int layoutPriority{ get	{} }
		private FontData m_FontData;
		protected string m_Text;
		private TextGenerator m_TextCache;
		private TextGenerator m_TextCacheForLayout;
		private bool m_DisableFontTextureRebuiltCallback;
		private static float kEpsilon;
		protected static Material s_DefaultText;
	}

	public class	Toggle: Selectable, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler, IMoveHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement
	{
		public virtual void Rebuild(CanvasUpdate executing){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		private void SetToggleGroup(ToggleGroup newGroup, bool setMemberValue){}
		private void Set(bool value){}
		private void Set(bool value, bool sendCallback){}
		private void PlayEffect(bool instant){}
		protected virtual void Start(){}
		private void InternalToggle(){}
		public virtual void OnPointerClick(PointerEventData eventData){}
		public virtual void OnSubmit(BaseEventData eventData){}
		private virtual bool UnityEngine.UI.ICanvasElement.IsDestroyed(){}
		private virtual Transform UnityEngine.UI.ICanvasElement.get_transform(){}
		protected Toggle(){}
		public ToggleGroup group{ get	{} set	{} }
		public bool isOn{ get	{} set	{} }
		public ToggleTransition toggleTransition;
		public Graphic graphic;
		private ToggleGroup m_Group;
		public ToggleEvent onValueChanged;
		private bool m_IsOn;
	}

	public class	ToggleGroup: UIBehaviour
	{
		private void ValidateToggleIsInGroup(Toggle toggle){}
		public void NotifyToggleOn(Toggle toggle){}
		public void UnregisterToggle(Toggle toggle){}
		public void RegisterToggle(Toggle toggle){}
		public bool AnyTogglesOn(){}
		public IEnumerable<Toggle> ActiveToggles(){}
		public void SetAllTogglesOff(){}
		private static bool <AnyTogglesOn>m__7(Toggle x){}
		private static bool <ActiveToggles>m__8(Toggle x){}
		protected ToggleGroup(){}
		public bool allowSwitchOff{ get	{} set	{} }
		private bool m_AllowSwitchOff;
		private List<Toggle> m_Toggles;
		private static Predicate<Toggle> <>f__am$cache2;
		private static Func<Toggle, Boolean> <>f__am$cache3;
	}

	public class	AspectRatioFitter: UIBehaviour, ILayoutController, ILayoutSelfController
	{
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		protected virtual void OnRectTransformDimensionsChange(){}
		private void UpdateRect(){}
		private float GetSizeDeltaToProduceSize(float size, int axis){}
		private Vector2 GetParentSize(){}
		public virtual void SetLayoutHorizontal(){}
		public virtual void SetLayoutVertical(){}
		protected void SetDirty(){}
		protected AspectRatioFitter(){}
		public AspectMode aspectMode{ get	{} set	{} }
		public float aspectRatio{ get	{} set	{} }
		RectTransform rectTransform{ get	{} }
		private AspectMode m_AspectMode;
		private float m_AspectRatio;
		private RectTransform m_Rect;
		private DrivenRectTransformTracker m_Tracker;
	}

	public class	CanvasScaler: UIBehaviour
	{
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		protected virtual void Update(){}
		protected virtual void Handle(){}
		protected virtual void HandleWorldCanvas(){}
		protected virtual void HandleConstantPixelSize(){}
		protected virtual void HandleScaleWithScreenSize(){}
		protected virtual void HandleConstantPhysicalSize(){}
		protected void SetScaleFactor(float scaleFactor){}
		protected void SetReferencePixelsPerUnit(float referencePixelsPerUnit){}
		protected CanvasScaler(){}
		public ScaleMode uiScaleMode{ get	{} set	{} }
		public float referencePixelsPerUnit{ get	{} set	{} }
		public float scaleFactor{ get	{} set	{} }
		public Vector2 referenceResolution{ get	{} set	{} }
		public ScreenMatchMode screenMatchMode{ get	{} set	{} }
		public float matchWidthOrHeight{ get	{} set	{} }
		public Unit physicalUnit{ get	{} set	{} }
		public float fallbackScreenDPI{ get	{} set	{} }
		public float defaultSpriteDPI{ get	{} set	{} }
		public float dynamicPixelsPerUnit{ get	{} set	{} }
		private ScaleMode m_UiScaleMode;
		protected float m_ReferencePixelsPerUnit;
		protected float m_ScaleFactor;
		protected Vector2 m_ReferenceResolution;
		protected ScreenMatchMode m_ScreenMatchMode;
		protected float m_MatchWidthOrHeight;
		protected Unit m_PhysicalUnit;
		protected float m_FallbackScreenDPI;
		protected float m_DefaultSpriteDPI;
		protected float m_DynamicPixelsPerUnit;
		private Canvas m_Canvas;
		private float m_PrevScaleFactor;
		private float m_PrevReferencePixelsPerUnit;
		private const float kLogBase = null;
	}

	public class	ContentSizeFitter: UIBehaviour, ILayoutController, ILayoutSelfController
	{
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		protected virtual void OnRectTransformDimensionsChange(){}
		private void HandleSelfFittingAlongAxis(int axis){}
		public virtual void SetLayoutHorizontal(){}
		public virtual void SetLayoutVertical(){}
		protected void SetDirty(){}
		protected ContentSizeFitter(){}
		public FitMode horizontalFit{ get	{} set	{} }
		public FitMode verticalFit{ get	{} set	{} }
		RectTransform rectTransform{ get	{} }
		protected FitMode m_HorizontalFit;
		protected FitMode m_VerticalFit;
		private RectTransform m_Rect;
		private DrivenRectTransformTracker m_Tracker;
	}

	public class	GridLayoutGroup: LayoutGroup, ILayoutElement, ILayoutController, ILayoutGroup
	{
		public virtual void CalculateLayoutInputHorizontal(){}
		public virtual void CalculateLayoutInputVertical(){}
		public virtual void SetLayoutHorizontal(){}
		public virtual void SetLayoutVertical(){}
		private void SetCellsAlongAxis(int axis){}
		protected GridLayoutGroup(){}
		public Corner startCorner{ get	{} set	{} }
		public Axis startAxis{ get	{} set	{} }
		public Vector2 cellSize{ get	{} set	{} }
		public Vector2 spacing{ get	{} set	{} }
		public Constraint constraint{ get	{} set	{} }
		public int constraintCount{ get	{} set	{} }
		protected Corner m_StartCorner;
		protected Axis m_StartAxis;
		protected Vector2 m_CellSize;
		protected Vector2 m_Spacing;
		protected Constraint m_Constraint;
		protected int m_ConstraintCount;
	}

	public class	HorizontalLayoutGroup: HorizontalOrVerticalLayoutGroup, ILayoutElement, ILayoutController, ILayoutGroup
	{
		public virtual void CalculateLayoutInputHorizontal(){}
		public virtual void CalculateLayoutInputVertical(){}
		public virtual void SetLayoutHorizontal(){}
		public virtual void SetLayoutVertical(){}
		protected HorizontalLayoutGroup(){}
	}

	public abstract	class	HorizontalOrVerticalLayoutGroup: LayoutGroup, ILayoutElement, ILayoutController, ILayoutGroup
	{
		protected void CalcAlongAxis(int axis, bool isVertical){}
		protected void SetChildrenAlongAxis(int axis, bool isVertical){}
		protected HorizontalOrVerticalLayoutGroup(){}
		public float spacing{ get	{} set	{} }
		public bool childForceExpandWidth{ get	{} set	{} }
		public bool childForceExpandHeight{ get	{} set	{} }
		protected float m_Spacing;
		protected bool m_ChildForceExpandWidth;
		protected bool m_ChildForceExpandHeight;
	}

	public interface ILayoutElement	{
		void CalculateLayoutInputHorizontal();
		void CalculateLayoutInputVertical();
		float minWidth{ get; }
		float preferredWidth{ get; }
		float flexibleWidth{ get; }
		float minHeight{ get; }
		float preferredHeight{ get; }
		float flexibleHeight{ get; }
		int layoutPriority{ get; }
	}

	public interface ILayoutController	{
		void SetLayoutHorizontal();
		void SetLayoutVertical();
	}

	public interface ILayoutGroup: ILayoutController
	{
	}

	public interface ILayoutSelfController: ILayoutController
	{
	}

	public interface ILayoutIgnorer	{
		bool ignoreLayout{ get; }
	}

	public class	LayoutElement: UIBehaviour, ILayoutElement, ILayoutIgnorer
	{
		public virtual void CalculateLayoutInputHorizontal(){}
		public virtual void CalculateLayoutInputVertical(){}
		protected virtual void OnEnable(){}
		protected virtual void OnTransformParentChanged(){}
		protected virtual void OnDisable(){}
		protected virtual void OnDidApplyAnimationProperties(){}
		protected virtual void OnBeforeTransformParentChanged(){}
		protected void SetDirty(){}
		protected LayoutElement(){}
		public virtual bool ignoreLayout{ get	{} set	{} }
		public virtual float minWidth{ get	{} set	{} }
		public virtual float minHeight{ get	{} set	{} }
		public virtual float preferredWidth{ get	{} set	{} }
		public virtual float preferredHeight{ get	{} set	{} }
		public virtual float flexibleWidth{ get	{} set	{} }
		public virtual float flexibleHeight{ get	{} set	{} }
		public virtual int layoutPriority{ get	{} }
		private bool m_IgnoreLayout;
		private float m_MinWidth;
		private float m_MinHeight;
		private float m_PreferredWidth;
		private float m_PreferredHeight;
		private float m_FlexibleWidth;
		private float m_FlexibleHeight;
	}

	public abstract	class	LayoutGroup: UIBehaviour, ILayoutElement, ILayoutController, ILayoutGroup
	{
		public virtual void CalculateLayoutInputHorizontal(){}
		public abstract virtual void CalculateLayoutInputVertical();
		public abstract virtual void SetLayoutHorizontal();
		public abstract virtual void SetLayoutVertical();
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		protected virtual void OnDidApplyAnimationProperties(){}
		protected float GetTotalMinSize(int axis){}
		protected float GetTotalPreferredSize(int axis){}
		protected float GetTotalFlexibleSize(int axis){}
		protected float GetStartOffset(int axis, float requiredSpaceWithoutPadding){}
		protected void SetLayoutInputForAxis(float totalMin, float totalPreferred, float totalFlexible, int axis){}
		protected void SetChildAlongAxis(RectTransform rect, int axis, float pos, float size){}
		protected virtual void OnRectTransformDimensionsChange(){}
		protected virtual void OnTransformChildrenChanged(){}
		protected void SetProperty(ref T currentValue, T newValue){}
		protected void SetDirty(){}
		protected LayoutGroup(){}
		public RectOffset padding{ get	{} set	{} }
		public TextAnchor childAlignment{ get	{} set	{} }
		RectTransform rectTransform{ get	{} }
		List<RectTransform> rectChildren{ get	{} }
		public virtual float minWidth{ get	{} }
		public virtual float preferredWidth{ get	{} }
		public virtual float flexibleWidth{ get	{} }
		public virtual float minHeight{ get	{} }
		public virtual float preferredHeight{ get	{} }
		public virtual float flexibleHeight{ get	{} }
		public virtual int layoutPriority{ get	{} }
		bool isRootLayoutGroup{ get	{} }
		protected RectOffset m_Padding;
		protected TextAnchor m_ChildAlignment;
		private RectTransform m_Rect;
		protected DrivenRectTransformTracker m_Tracker;
		private Vector2 m_TotalMinSize;
		private Vector2 m_TotalPreferredSize;
		private Vector2 m_TotalFlexibleSize;
		private List<RectTransform> m_RectChildren;
	}

	public sealed abstract	class	LayoutUtility: Object
	{
		public static float GetMinSize(RectTransform rect, int axis){}
		public static float GetPreferredSize(RectTransform rect, int axis){}
		public static float GetFlexibleSize(RectTransform rect, int axis){}
		public static float GetMinWidth(RectTransform rect){}
		public static float GetPreferredWidth(RectTransform rect){}
		public static float GetFlexibleWidth(RectTransform rect){}
		public static float GetMinHeight(RectTransform rect){}
		public static float GetPreferredHeight(RectTransform rect){}
		public static float GetFlexibleHeight(RectTransform rect){}
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, Single> property, float defaultValue){}
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, Single> property, float defaultValue, out ILayoutElement source){}
		private static float <GetMinWidth>m__E(ILayoutElement e){}
		private static float <GetPreferredWidth>m__F(ILayoutElement e){}
		private static float <GetPreferredWidth>m__10(ILayoutElement e){}
		private static float <GetFlexibleWidth>m__11(ILayoutElement e){}
		private static float <GetMinHeight>m__12(ILayoutElement e){}
		private static float <GetPreferredHeight>m__13(ILayoutElement e){}
		private static float <GetPreferredHeight>m__14(ILayoutElement e){}
		private static float <GetFlexibleHeight>m__15(ILayoutElement e){}
		private static Func<ILayoutElement, Single> <>f__am$cache0;
		private static Func<ILayoutElement, Single> <>f__am$cache1;
		private static Func<ILayoutElement, Single> <>f__am$cache2;
		private static Func<ILayoutElement, Single> <>f__am$cache3;
		private static Func<ILayoutElement, Single> <>f__am$cache4;
		private static Func<ILayoutElement, Single> <>f__am$cache5;
		private static Func<ILayoutElement, Single> <>f__am$cache6;
		private static Func<ILayoutElement, Single> <>f__am$cache7;
	}

	public class	VerticalLayoutGroup: HorizontalOrVerticalLayoutGroup, ILayoutElement, ILayoutController, ILayoutGroup
	{
		public virtual void CalculateLayoutInputHorizontal(){}
		public virtual void CalculateLayoutInputVertical(){}
		public virtual void SetLayoutHorizontal(){}
		public virtual void SetLayoutVertical(){}
		protected VerticalLayoutGroup(){}
	}

	public interface IMaterialModifier	{
		Material GetModifiedMaterial(Material baseMaterial);
	}

	public class	Mask: UIBehaviour, IGraphicEnabledDisabled, IMask, ICanvasRaycastFilter, IMaterialModifier
	{
		public virtual bool MaskEnabled(){}
		public virtual void OnSiblingGraphicEnabledDisabled(){}
		private void NotifyMaskStateChanged(){}
		private void ClearCachedMaterial(){}
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera){}
		public virtual Material GetModifiedMaterial(Material baseMaterial){}
		protected Mask(){}
		Graphic graphic{ get	{} }
		public bool showMaskGraphic{ get	{} set	{} }
		public RectTransform rectTransform{ get	{} }
		private bool m_ShowMaskGraphic;
		private Material m_RenderMaterial;
		private Graphic m_Graphic;
		private RectTransform m_RectTransform;
	}

	public abstract	class	BaseVertexEffect: UIBehaviour, IVertexModifier
	{
		protected virtual void OnEnable(){}
		protected virtual void OnDisable(){}
		public abstract virtual void ModifyVertices(List<UIVertex> verts);
		protected BaseVertexEffect(){}
		Graphic graphic{ get	{} }
		private Graphic m_Graphic;
	}

	public interface IVertexModifier	{
		void ModifyVertices(List<UIVertex> verts);
	}

	public class	Outline: Shadow, IVertexModifier
	{
		public virtual void ModifyVertices(List<UIVertex> verts){}
		protected Outline(){}
	}

	public class	PositionAsUV1: BaseVertexEffect, IVertexModifier
	{
		public virtual void ModifyVertices(List<UIVertex> verts){}
		protected PositionAsUV1(){}
	}

	public class	Shadow: BaseVertexEffect, IVertexModifier
	{
		protected void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y){}
		public virtual void ModifyVertices(List<UIVertex> verts){}
		protected Shadow(){}
		public Color effectColor{ get	{} set	{} }
		public Vector2 effectDistance{ get	{} set	{} }
		public bool useGraphicAlpha{ get	{} set	{} }
		private Color m_EffectColor;
		private Vector2 m_EffectDistance;
		private bool m_UseGraphicAlpha;
	}

	delegate char OnValidateInput(string text, int charIndex, char addedChar);

}

