using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int _coinValue = 1;
    [SerializeField] private AudioClip _coinPickUpSound;

    public event Action<Coin> OnCollect;

    public int Value => _coinValue;

    public void Collect()
    {
        PickUpSoundPlay();
        OnCollect?.Invoke(this);
    }    

    private void PickUpSoundPlay()
    {
        if (_coinPickUpSound != null)
        {
            AudioSource.PlayClipAtPoint(_coinPickUpSound, transform.position);
        }
    }
}