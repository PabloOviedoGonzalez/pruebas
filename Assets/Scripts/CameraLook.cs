using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSens = 60f;
    public Transform playerTransform;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // evitar romperse el cuello
        transform.localRotation = Quaternion.Lerp(transform.localRotation , Quaternion.Euler(xRotation, 0, 0), 0.25f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
