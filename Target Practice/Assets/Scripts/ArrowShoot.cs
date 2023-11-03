using System.Collections;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowForce = 10f;
    public float timeBetweenShots = 3f; // Adjust this value as needed.
    private bool isAiming = false;
    private Vector3 aimDirection;
    private Camera mainCamera;
    private bool canShoot = true;
    private bool isArrowActive = false; // Flag to track if an arrow is in flight.
    private float lastShotTime;

    public GameObject HandArrow;

    private void Start()
    {
        mainCamera = Camera.main;
        HandArrow.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time - lastShotTime >= timeBetweenShots && canShoot)
        {
            isAiming = true;
            HandArrow.gameObject.SetActive(true);
        }

        if (isAiming)
        {
            // Continuously update the aim direction while the right mouse button is held down.
            aimDirection = (arrowSpawnPoint.position - transform.position).normalized;

            // You can also visualize the aim direction with a line renderer or other methods.
        }

        if (Input.GetButtonUp("Fire1") && isAiming && canShoot)
        {
            shoot();
            isAiming = false;
            HandArrow.gameObject.SetActive(false);
            lastShotTime = Time.time;
        }
    }

    private void shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 arrowDirection = (hit.point - transform.position).normalized;
            GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.LookRotation(arrowDirection));
            Rigidbody arrowRigidbody = newArrow.GetComponent<Rigidbody>();
            arrowRigidbody.velocity = arrowDirection * arrowForce;
            canShoot = false;
        }
    }


    private IEnumerator EnableShootingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}






