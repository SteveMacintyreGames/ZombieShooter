using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    EnemyAI _enemyAI;
    Animator _anim;

    void Start()
    {
        _enemyAI = GetComponentInParent<EnemyAI>();
        if (_enemyAI == null)
        {
            Debug.LogError("_enemyAI is NULL");
        }
        _anim = GetComponentInParent<Animator>();
        if(_anim == null)
        {
            Debug.LogError("_anim is NULL");
        }
        else
        {
            _anim.SetBool("Attacking", false);
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _anim.SetBool("Attacking", true);
            _enemyAI.StartAttack();
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _anim.SetBool("Attacking", false);
            _enemyAI.StopAttack();
        }
    }
}
