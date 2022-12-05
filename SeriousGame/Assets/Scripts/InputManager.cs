using UnityEngine;
using UnityEngine.InputSystem;


[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviourSingleton<InputManager>
{

    #region Events 
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion 

    private PlayerControls playerControls;
    [SerializeField] private Camera mainCamera;

    [SerializeField] public GameObject cameraSystem;

    private void Awake()
    {
        playerControls = new PlayerControls();
        //mainCamera = Camera.current; 
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public Vector3 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()); 
    }
}
