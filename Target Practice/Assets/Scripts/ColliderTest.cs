using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    // This method is called when a trigger collider is entered.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a specific tag (optional).
        if (other.CompareTag("ArrowCollider"))
        {
            // Replace "Player" with the tag of the object you want to detect collisions with.

            // Do something when the trigger is entered, for example, print a message.
            print("Trigger entered by Arrow bullseye");
        }
    }
}

