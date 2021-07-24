using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    EnemyAI _enemyAI;

    void Start()
    {
        _enemyAI = GetComponentInParent<EnemyAI>();
        if (_enemyAI == null)
        {
            Debug.LogError("_enemyAI is NULL");
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _enemyAI.StartAttack();
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _enemyAI.StopAttack();
        }
    }
}
