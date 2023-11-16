using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Create a delegate and event for arrow destruction.
    public delegate void ArrowDestroyedHandler();
    public event ArrowDestroyedHandler OnArrowDestroyed;

    private Rigidbody rb;
    private bool hasHit = false;

    public AudioSource arrowHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //arrowHit.Play(); Tried to get audio to work but there was an audio problem
        if (!hasHit) {

            hasHit = true;
            rb.isKinematic = true; // Stop the arrow's movement

            Destroy(gameObject, 2f); // Destroy the arrow after 2 seconds, change this value as needed.

            // Invoke the arrow destruction event.
            OnArrowDestroyed?.Invoke();

        }
    }
}






