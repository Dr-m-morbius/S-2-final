using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemuattk : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 1;
    [SerializeField] private enemuMove _enemymovement;
    [SerializeField] private playerhealth _player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("I hit the player");
            _enemymovement.EnemyAttack();
            _player.TakeDamage(_damageAmount);
        }
    }
}