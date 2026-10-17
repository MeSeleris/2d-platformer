using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private KnockbackAfterDamage _knockback;

    private int _maxHealth = 3;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;

        if (_knockback == null)
            _knockback = GetComponent<KnockbackAfterDamage>();
    }

    public void HealthLoss(int enemyDamage, Vector2 attackerPosition)
    {
        if (_knockback != null && _knockback.IsKnocked)
            return;

        _currentHealth -= enemyDamage;
        _currentHealth = Math.Clamp(_currentHealth, 0, _maxHealth);//не позволяет выйти за диапозон от 0 до макс хп

        _animator.SetInteger("CurrentHealth", _currentHealth);

        if (_knockback != null)
            _knockback.PlayerKnocked(attackerPosition );
    }
}
