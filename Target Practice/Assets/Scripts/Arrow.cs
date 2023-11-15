using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Create a delegate and event for arrow destruction.
    public delegate void ArrowDestroyedHandler();
    public event ArrowDestroyedHandler OnArrowDestroyed;

    private Rigidbody rb;
    private bool hasHit = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasHit) {

            hasHit = true;
            rb.isKinematic = true; // Stop the arrow's movement
            Destroy(gameObject, 2f); // Destroy the arrow after 2 seconds, change this value as needed.

            // Invoke the arrow destruction event.
            OnArrowDestroyed?.Invoke();

        }
    }
}






