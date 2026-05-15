
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float YRotation = 0f;

    public Transform playerBody; // Player 루트 오브젝트 연결

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        YRotation += mouseX;

        // 카메라는 상하만
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // 플레이어 몸체는 좌우만
        playerBody.localRotation = Quaternion.Euler(0f, YRotation, 0f);
    }
}