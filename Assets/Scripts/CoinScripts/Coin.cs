using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int _coinValue = 1;
    [SerializeField] private AudioClip _coinPickUpSound;

    public event Action<Coin> OnCollect;

    public int Value => _coinValue;

    public void Collect(PlayerTriggerHandler collector)
    {
        if(collector.CoinWallet != null)
        {
            collector.CoinWallet.AddCoin(_coinValue);
        }

        if(_coinPickUpSound != null)
        {
            AudioSource.PlayClipAtPoint(_coinPickUpSound, transform.position);
        }

        if(TryGetComponent<Collider2D>(out var collider))
        {
            collider.enabled = false;
        }

        OnCollect?.Invoke(this);
    }    
}