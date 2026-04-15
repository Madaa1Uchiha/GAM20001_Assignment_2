using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    public float senseX;
    public float senseY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private PlayerInputActions inputActions;
    private InputAction lookAction;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        lookAction = inputActions.Player.Look;
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;
        // analog input - mouse delta returns Vector2
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        float mouseX = lookInput.x * Time.deltaTime * senseX;
        float mouseY = lookInput.y * Time.deltaTime * senseY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
