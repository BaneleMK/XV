using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Camera cam;
    public bool escapekey = false;

    float xAxisRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapekey == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                escapekey = false;
                Debug.Log("Lock");
            }
            else
            {
                escapekey = true;
                Debug.Log("UnLock");
                Cursor.lockState = CursorLockMode.Confined;

            }
        }

        if (escapekey == true && Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            escapekey = false;
            Debug.Log("Lock");
        }

        if (cam.enabled && !transform.GetComponentInParent<PlayerLookController>().focusmode && !escapekey)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xAxisRotation -= mouseY;
            xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f);

            playerBody.Rotate(Vector3.up * mouseX);
            transform.localRotation = Quaternion.Euler(xAxisRotation, 0f, 0f);
        }
    }
}
