using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayarMovement : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 100f;
    public float healthAmount = 100f;
 
    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;

        rotationY = Mathf.Clamp(rotationY, -50f, 50f);
        rotationX = Mathf.Clamp(rotationX, -30f, 15f);

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

    }
}
