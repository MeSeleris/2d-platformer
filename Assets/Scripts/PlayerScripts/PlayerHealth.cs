using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    

    public Action<int, int> ChangeHealth;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    private void Start()
    {
        ChangeHealth?.Invoke(CurrentHealth, _maxHealth);
    }

    public void TakeDamage(int enemyDamage)
    {
        if(enemyDamage <= 0 || CurrentHealth < 0)
            return;

        CurrentHealth = Mathf.Max(0, CurrentHealth - enemyDamage);
        ChangeHealth?.Invoke(CurrentHealth, _maxHealth);
    }
}
