using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private CharacterController _controller;
    private GameObject _player;
    Vector3 _direction, _velocity;
    [SerializeField] private float _speed = 1; 
    [SerializeField] private float _speedVariance;
    private float _gravity;    
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    [SerializeField] private EnemyState _currentState = EnemyState.Chase;
    private Health _playerHealth;

    private float _attackDelay = 1.5f;
    private float _nextAttack = -1f;    

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

        _playerHealth = _player.GetComponent<Health>();
        if(_playerHealth == null)
        {
            Debug.LogError("Player Health is NULL");
        }

        //Variables
        _gravity = 1.2f;
        _speedVariance = Random.Range(0f,.6f);
        
    }

    void Update()
    {   
        switch(_currentState)
        {
            case(EnemyState.Chase):
            CalculateMovement();
            break;
            case(EnemyState.Attack):
            Attack();
            break;
        }        
    }

    void Attack()
    {
            if(Time.time > _nextAttack)
            {
                if (_playerHealth != null)
                {
                    _playerHealth.Damage(10);
                }
                
                _nextAttack = Time.time + _attackDelay;
            }
    }

    void CalculateMovement()
    {
         if(_controller.isGrounded)
        {
            _direction = _player.transform.position - transform.position;
            _direction.y = 0;
            _direction.Normalize();
            _velocity = _direction * (_speed + _speedVariance);            
        }

        //turn to look at player
        transform.rotation = Quaternion.LookRotation(_direction);

        _velocity.y -= _gravity;
        _controller.Move(_velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _currentState = EnemyState.Attack;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _currentState = EnemyState.Chase;
        }
    }

}
