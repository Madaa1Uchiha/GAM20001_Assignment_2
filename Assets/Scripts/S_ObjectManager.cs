using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class ObjectManager : MonoBehaviour
{
    public GameObject targetObject;  // drag your crate here
    public GameObject spawnPrefab;   // drag a prefab to spawn here
    public Transform spawnPoint;     // where to spawn it
    private Vector3 spawnPosition;
     int maxObjects = 1;
    void Update()
    {
   
        // E - hide/show
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (targetObject != null)
                targetObject.SetActive(!targetObject.activeSelf);
        }

        // Q - destroy
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {   
            
            if (targetObject != null)
            {
                spawnPosition = targetObject.transform.position;
                Destroy(targetObject);
                maxObjects -= 1;
            }
        }
        // F - spawn
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if(maxObjects < 1)
            {
                targetObject =  Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);
            }
            else
            print("No destroyed object to recreate");
        }
    }
}