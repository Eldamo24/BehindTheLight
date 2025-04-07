using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float yOffset;
    [SerializeField] private float sensitivity;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        playerPos = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);
        yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }

    private void LateUpdate()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y +yOffset, playerPos.position.z);
    }
}
