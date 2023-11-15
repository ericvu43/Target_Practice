using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowShoot : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowForce = 10f;
    public float cooldownTime = 3f; // Cooldown time between shots
    private bool isAiming = false;
    private Vector3 aimDirection;
    private Camera mainCamera;
    private bool canShoot = true;
    private float lastShotTime;
    public GameObject HandArrow;

    private int arrowsShot = 0; // Keep track of the number of arrows shot
    private bool isArrowInAir = false; // Track if an arrow is in the air

    private WindManager windManager; // Reference to the WindManager script


    private void Start()
    {
        mainCamera = Camera.main;
        HandArrow.gameObject.SetActive(false);

        

        // Find the WindManager script in the scene
        windManager = FindObjectOfType<WindManager>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            isAiming = true;
            HandArrow.gameObject.SetActive(true);
            
            // Continuously update the aim direction while the left mouse button is held down.
            aimDirection = (arrowSpawnPoint.position - transform.position).normalized;
            
            }
        if (Input.GetButtonUp("Fire1") && isAiming)
        {
            // Shoot an arrow and activate the cooldown
            shoot();
            canShoot = false;
            arrowsShot++;
            isAiming = false;
            Debug.Log(arrowsShot);


            // Check if the player has shot three arrows, and update wind
            if (arrowsShot >= 3)
            {
                arrowsShot = 0;
                windManager.UpdateWind(); // Call a method to update the wind parameters

                Vector3 newPosition = transform.position;
                newPosition.x = -23f; // Set the desired x position
                transform.position = newPosition;
                Debug.Log("Moving back");

            }
            // You can also visualize the aim direction with a line renderer or other methods.
        }

        // Removed the StartCoroutine for CooldownTimer(), as it's not needed
        // Check for cooldown completion
        if (!canShoot && Time.time - lastShotTime >= cooldownTime)
        {
            canShoot = true; // The cooldown is over, allowing the player to shoot again.
        }
    }

    private void shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && canShoot)
        {
            isArrowInAir = true; // Set the flag to indicate an arrow is in the air
            Vector3 arrowDirection = (hit.point - transform.position).normalized;

            GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.LookRotation(arrowDirection));
            Rigidbody arrowRigidbody = newArrow.GetComponent<Rigidbody>();

            // Apply wind force to the arrow
            arrowRigidbody.velocity = (arrowDirection * arrowForce) + (windManager.GetWindDirection() * windManager.GetCurrentWindSpeed());
        }
    }
}
