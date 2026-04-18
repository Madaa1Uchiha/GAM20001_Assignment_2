using UnityEngine;
using UnityEngine.InputSystem;

public class EllaR_PlayingAudio : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (myAudioSource != null)
            {
                myAudioSource.Play();
            }
        }
    }
}