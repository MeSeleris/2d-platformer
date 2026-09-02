using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _maxHealth = 3;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void HealthLoss(int enemyDamage)
    {
        _currentHealth -= enemyDamage;
        _animator.SetInteger("CurrentHealth", _currentHealth);
    }
}
