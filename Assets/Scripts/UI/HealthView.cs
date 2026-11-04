using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [Header("Источник данных")]
    [SerializeField] private PlayerHealth _playerHealth;

    [Header("UI View")]
    [SerializeField] private SpriteRenderer[] _heartRenderers;
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;

    private void OnEnable()
    {
        if(_playerHealth != null)
           _playerHealth.OnHealthChange += UpdateHearts;
    }

    private void OnDisable()
    {
        if( _playerHealth != null )
            _playerHealth.OnHealthChange -= UpdateHearts;
    }

    private void UpdateHearts(int currentHealth, int maxHealth)
    {
        Debug.Log($"[HealthView] Получено событие! HP: {currentHealth}/{maxHealth}");
        for (int i = 0; i < _heartRenderers.Length;  i++)
        {
            if (_heartRenderers[i] == null)
                continue;

            bool isFull = i < currentHealth;

            if (_fullHeartSprite != null && _emptyHeartSprite != null)
            {
                _heartRenderers[i].sprite = (i<currentHealth) ? _fullHeartSprite : _emptyHeartSprite;
            }

            else
            {
                _heartRenderers[i].enabled = isFull;
            }
        }
    }
}
