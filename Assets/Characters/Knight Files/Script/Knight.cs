using UnityEngine;
using UnityEngine.InputSystem;

public class Knight : MonoBehaviour
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       /*
        //if click mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger the animation
            if (animator != null)
            {
                animator.SetTrigger("OnClick");
            }
        }
        */
          // Check left mouse click using the new Input System
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (animator != null)
            {
                animator.SetTrigger("OnClick");
            }
        }
    }
}
