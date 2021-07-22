using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private CharacterController _controller;
    private GameObject _player;
    Vector3 _direction, _velocity;
    private float _speed, _gravity;    

    

    private void Start()
    {
        //Holders
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError("CharacterController is NULL");
        }
        
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("Player is NULL");
        }

        //Variables
        _speed = 6f;
        _gravity = 1.2f;
    }

    void Update()
    {
        if(_controller.isGrounded)
        {
            _direction = _player.transform.position - transform.position;
            _direction.y = 0;
            _direction.Normalize();
            _velocity = _direction * _speed;            
        }

        //turn to look at player
        transform.rotation = Quaternion.LookRotation(_direction);

        _velocity.y -= _gravity;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
