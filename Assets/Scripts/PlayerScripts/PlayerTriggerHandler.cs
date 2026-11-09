using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerTriggerHandler : MonoBehaviour
{
    public event Action<ICollectable> DetectedCollectable;

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.TryGetComponent(out ICollectable collectable))
        {
            DetectedCollectable?.Invoke(collectable);
        }
    }
}
