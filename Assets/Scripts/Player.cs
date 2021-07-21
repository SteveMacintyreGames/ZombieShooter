using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [Header ("Player Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpHeight = 15f;
    [SerializeField] private float _gravity = 1.2f;
    private float _yVelocity;

    [SerializeField] Camera _mainCamera;

    float mouseX, mouseY;
    
    [Header ("Camera Settings")]
    [SerializeField] float cameraSensitivity = 3f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if(_characterController == null)
        {
            Debug.LogError("Character Controller is Null!");
        }
        LockAndHideCursor();        
    }
    void Update()
    {
        CharacterMovement();
        CameraMovement();
        PressESC();
    }

    private void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void PressESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }       
    }

    private void CharacterMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input. GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 velocity = direction * _speed;

        if (_characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _yVelocity = _jumpHeight;
            }
        }
        
        _yVelocity -= _gravity; 
        velocity.y = _yVelocity;

        velocity = transform.TransformDirection(velocity);

        _characterController.Move(velocity * Time.deltaTime);
    }
    private void CameraMovement()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        _mainCamera = Camera.main;

        if (_mainCamera == null)
        {
            Debug.LogError("Main camera is null");
        }
        
        LookLeftAndRight();
        LookUpAndDown();
    }

    private void LookLeftAndRight()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX * cameraSensitivity;
        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);
    }

    private float yClampMin = 0;
    private float yClampMax = 26f;
    private void LookUpAndDown()
    {
        Vector3 currentCameraRotation = _mainCamera.gameObject.transform.localEulerAngles;
        currentCameraRotation.x -= mouseY * cameraSensitivity;
        currentCameraRotation.x = Mathf.Clamp(currentCameraRotation.x, yClampMin,yClampMax);          
        _mainCamera.gameObject.transform.localRotation = Quaternion.AngleAxis(currentCameraRotation.x,Vector3.right);

    }
}
