using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private int _minHP;
    [SerializeField] private int _currentHP;
    

    void Start()
    {
        _currentHP = _maxHP;
    }

    public void Damage(int damageAmount)
    {
        _currentHP -= damageAmount;

        if(_currentHP < _minHP)
        {
            Destroy(this.gameObject);
        }
    }
}
