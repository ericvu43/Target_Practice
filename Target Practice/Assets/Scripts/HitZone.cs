using System.Collections;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public int pointValue = 10;
    private PointSystem pointSystem; // Reference to the PointSystem script.
    private bool canAddPoints = true;
    public float cooldownTime = 2f; // Set the cooldown time in seconds.

    private void Start()
    {
        // Find the PointSystem script in the scene and assign it to the reference.
        pointSystem = FindObjectOfType<PointSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a specific tag (optional).
        if (other.CompareTag("ArrowCollider") && canAddPoints)
        {
            // Pass the pointValue to the AddPoints method on the PointSystem script.
            pointSystem.AddPoints(pointValue);

            // Set canAddPoints to false to prevent adding points again immediately.
            canAddPoints = false;

            // Start the cooldown coroutine.
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);

        // Reset canAddPoints after the cooldown time.
        canAddPoints = true;
    }
}

