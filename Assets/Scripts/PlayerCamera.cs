using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public GameObject keypadDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void updateSensitivity (float sensitivityAdjustment)
    {
        mouseSensitivity = sensitivityAdjustment;
    }

    // Update is called once per frame
    void Update()
    {
        if(!keypadDisplay.activeSelf) {
            float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * MouseX);
        }
    }
}
