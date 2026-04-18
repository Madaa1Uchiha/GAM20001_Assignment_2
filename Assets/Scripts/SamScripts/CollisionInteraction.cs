using UnityEngine;

public class CollisionInteraction : MonoBehaviour
{
    public GameObject particlePrefab;
    public AudioClip collisionSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // spawn particle at collision point
            Vector3 hitPoint = collision.contacts[0].point;
            Instantiate(particlePrefab, hitPoint, Quaternion.identity);

            // play sound
            audioSource.PlayOneShot(collisionSound);
        }
    }
}