using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 카메라 고정
public class Camera_works : MonoBehaviour
{
    public float rotateSpeed = 5.0f;
    public float limitAngle = 70.0f;

    private bool isRotate;
    private float mouseX;
    private float mouseY;

    public Transform targetTransform;
    public Vector3 CameraOffset;

    private void Start()
    {

    }

    private void Update()
    {

       
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }

        if (isRotate)
        {
            Rotation();
        }
    }

    public void Rotation()
    {
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed; // AxisX = Mouse Y
        mouseY = Mathf.Clamp(mouseY + Input.GetAxis("Mouse Y") * rotateSpeed, -limitAngle, limitAngle);

        transform.rotation = Quaternion.Euler(transform.rotation.x - mouseY, transform.rotation.y + mouseX, 0.0f);

        transform.position = targetTransform.position + CameraOffset;


    }
}