using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    public float MouseSense = 100.0f;
    public Transform PlayerBody;
    float XRotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * this.MouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * this.MouseSense * Time.deltaTime;

        this.XRotation -= mouseY;
        this.XRotation = Mathf.Clamp(this.XRotation, -90.0f, 90.0f);

        this.transform.localRotation = Quaternion.Euler(this.XRotation, 0.0f, 0.0f);
        this.PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
