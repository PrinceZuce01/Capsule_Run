using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour
{
    public Transform target;  // The target object to follow
    public float distance = 5.0f;  // Distance from the target
    public float height = 2.0f;  // Height of the camera
    public float smoothSpeed = 10.0f;  // Speed of camera movement
    public float rotationSpeed = 2.0f;  // Speed of camera rotation
    public float zoomSpeed = 2.0f;  // Speed of camera zoom

    private float currentRotation = 0.0f;  // Current camera rotation around the target
    private float currentZoom = 0.0f;  // Current camera zoom level

    private void LateUpdate()
    {
        // Calculate the desired position for the camera based on rotation and zoom level
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance - currentZoom);
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Rotate the camera around the target based on cursor input
        if (Input.GetMouseButton(1))
        {
            currentRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        }

        // Zoom the camera based on cursor scroll input
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        // Clamp the zoom level to avoid going too close or too far
        currentZoom = Mathf.Clamp(currentZoom, -5.0f, 5.0f);

        // Rotate the camera to always look at the target
        transform.LookAt(target.position);
    }
}