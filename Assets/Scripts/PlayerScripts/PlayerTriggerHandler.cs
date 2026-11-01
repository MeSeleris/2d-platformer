using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerTriggerHandler : MonoBehaviour
{
    [SerializeField] private CoinWallet _coinCollector;

    public CoinWallet CoinWallet => _coinCollector;

    private void Awake()
    {
        if(_coinCollector == null)
        {
            _coinCollector = GetComponentInChildren<CoinWallet>();
        }
    }

    private void OnTriggerEnter2D (Collider2D colision)
    {
        if(colision.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect(this);
            return;
        }
    }
}
