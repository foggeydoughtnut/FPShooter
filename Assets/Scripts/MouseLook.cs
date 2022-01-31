using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 400f;
    public float scopedMouseSensitivity = 200f;
    public Transform playerBody;

    public static bool isScoped;

    private float currentSensitivity;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isScoped = false;
        currentSensitivity = mouseSensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoped)
        {
            currentSensitivity = scopedMouseSensitivity;
        } else
        {
            currentSensitivity = mouseSensitivity;
        }

        float mouseX = Input.GetAxis("Mouse X") * currentSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * currentSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void SetSensitivity()
    {
       
    }
}
