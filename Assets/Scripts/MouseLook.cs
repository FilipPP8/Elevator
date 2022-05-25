using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  public float _mouseSensitivity = 100f;

  public Transform _playerBody;

  public float xRotation = 0f;

  private void Start() 
  {
    // Cursor.lockState = CursorLockMode.Locked;    
  }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
