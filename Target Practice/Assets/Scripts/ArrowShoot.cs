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

    private int arrowsShotWind = 0; // Keep track of the number of arrows shot
    private int arrowsShotScore = 0;
    private bool isArrowInAir = false; // Track if an arrow is in the air

    private WindManager windManager; // Reference to the WindManager script

    public GameObject playerObject; // This is a public field to assign a player GameObject

    public PointSystem pointSystem; // Reference to the PointSystem script


    private void Start()
    {
        mainCamera = Camera.main;
        HandArrow.gameObject.SetActive(false);

        pointSystem = FindObjectOfType<PointSystem>();

        // Find the WindManager script in the scene
        windManager = FindObjectOfType<WindManager>();
    }

    private void Update()
    {
        /* First Arrow shoots fine but I couldnt find the reason why after the first arrow shoots two arrows
         however the score doesnt increase even if the second arrow hits the target because there is a 
         cooldown on when a player can score. This second arrow can be seen as a "scouting" arrow to see where
         the wind will do next shot */
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
            arrowsShotWind++;
            arrowsShotScore++;
            isAiming = false;


            // Check if the player has shot three arrows, and update wind
            if (arrowsShotWind >= 3)
            {
                windManager.UpdateWind(); // Call a method to update the wind parameters
                arrowsShotWind = 0;
                Vector3 temp = new Vector3(200.0f, 0, 0);
                playerObject.transform.position += temp;

            }
            if (arrowsShotScore >= 9) // Check if nine arrows have been shot
            {
                // Reset score and arrows shot count
                arrowsShotScore = 0;
                pointSystem.AddPoints(-pointSystem.GetPoints()); // Reset the points to zero
            }
        }


        // Removed the StartCoroutine for CooldownTimer(), as it's not needed
        // Check for cooldown completion
        if (!canShoot && Time.time - lastShotTime >= cooldownTime)
        {
            canShoot = true; // The cooldown is over, allowing the player to shoot again.
        }
        /* Made it so that if esc is pressed in game scene the game would just close instead of going 
         to Main menu scene */
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
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
