using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpHeight = 15f;
    private float _gravity = 1.2f;
    private float _yVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if(_characterController == null)
        {
            Debug.LogError("Character Controller is Null!");
        }
    }

    void Update()
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

        _characterController.Move(velocity * Time.deltaTime);
    }
}
