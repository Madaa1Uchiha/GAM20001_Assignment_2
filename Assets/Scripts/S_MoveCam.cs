using UnityEngine;

public class MoveCam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform camerPosition;

    public void Update()
    {
        transform.position = camerPosition.position;
    }
}
