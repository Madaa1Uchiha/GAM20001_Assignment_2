using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject cube;
    public GameObject prefab;

    public AudioSource audioSource;
    public AudioClip soundClip;

    private GameObject spawnedObject;
    private PlayerControls controls;

    // PR04 - Input System setup
    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        controls.Player.Jump.performed -= OnJump;
        controls.Disable();
    }

    private void Update()
    {
        // Movement (PR04)
        Vector2 moveValue = controls.Player.Move.ReadValue<Vector2>();

        if (cube != null)
        {
            cube.transform.Translate(new Vector3(moveValue.x, 0, 0) * 5f * Time.deltaTime);
        }

        // Optional key trigger for sound (AU01)
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            PlaySound();
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump button pressed");
    }

    // PR02 - Show / Hide
    public void ShowObject()
    {
        cube.SetActive(true);
    }

    public void HideObject()
    {
        cube.SetActive(false);
    }

    // PR02 - Spawn / Delete
    public void SpawnObject()
    {
        spawnedObject = Instantiate(prefab, new Vector3(0, 1, 0), Quaternion.identity);
    }

    public void DeleteObject()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
    }

    // PR03 - Scene switching
    public void LoadScene1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Scene2");
    }

    // PR03 - Exit game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit button pressed");
    }

    // PR03 - Fullscreen toggle
    public void ToggleFullscreen()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
        }
        else
        {
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
        }

        Debug.Log("Fullscreen toggled");
    }

    // AU01 - Play sound (single button)
    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
            Debug.Log("Sound played");
        }
    }
}