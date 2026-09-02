using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyDamage : MonoBehaviour
{
    private int _enemyDamage = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.HealthLoss(_enemyDamage);
        }
    }
}
