using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int _maxHealth = 3;

    private int _currentHealth;
    
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    

    public Action<int, int> OnHealthChange;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int enemyDamage)
    {
        if(enemyDamage <= 0 || _currentHealth < 0)
            return;

        _currentHealth = Mathf.Max(0, _currentHealth - enemyDamage);
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }
}
