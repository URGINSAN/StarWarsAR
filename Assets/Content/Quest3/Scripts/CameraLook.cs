using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
            Look();
    }

    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    public void Look()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(rotation.x, rotation.y) * lookSpeed;
        //Camera.main.transform.rotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
}
