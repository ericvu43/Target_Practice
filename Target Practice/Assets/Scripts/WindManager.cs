using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public float minWindSpeed = 5f; // Minimum wind speed
    public float maxWindSpeed = 15f; // Maximum wind speed

    private float currentWindSpeed; // Current wind speed
    private Vector3 windDirection; // Current wind direction

    private void Start()
    {
        // Initialize the wind parameters
        UpdateWind();
    }

    public void UpdateWind()
    {
        // Generate a new random wind speed
        currentWindSpeed = Random.Range(minWindSpeed, maxWindSpeed);

        // Generate a new random wind direction
        windDirection = Random.insideUnitSphere.normalized;

        // Apply the new wind parameters to the Wind Zone
        ApplyWindToWindZone();
    }

    public Vector3 GetWindDirection()
    {
        return windDirection;
    }

    public float GetCurrentWindSpeed()
    {
        return currentWindSpeed;
    }

    private void ApplyWindToWindZone()
    {
        // Apply the wind speed to the Wind Zone
        GetComponent<WindZone>().windMain = currentWindSpeed;

        // Set the wind direction to the forward direction of the WindZone
        GetComponent<WindZone>().transform.forward = windDirection;
    }

    // You can add more methods or logic here as needed.
}








