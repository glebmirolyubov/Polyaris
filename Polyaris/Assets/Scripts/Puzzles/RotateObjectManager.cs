using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectManager : MonoBehaviour
{
    public float rotationSpeed = 40f;


    private void OnEnable()
    {
        transform.localEulerAngles = new Vector3(0f, 90f, 0f);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotX, Space.World);
            transform.Rotate(Vector3.right, rotY, Space.World);
        }
    }
}
