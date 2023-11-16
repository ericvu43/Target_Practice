using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Code for gamecamera third person */
public class CameraController : MonoBehaviour
{
    public float sensitivity = 50f;
    public Transform player;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * x);
    }
}
