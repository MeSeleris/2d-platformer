using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerTriggerHandler _triggerHandler;
    [SerializeField] private CoinWallet _wallet;

    public CoinWallet Wallet => _wallet;

    private void Awake()
    {
        if (_triggerHandler != null)
            _triggerHandler = GetComponentInChildren<PlayerTriggerHandler>();

        if( _wallet != null )
            _wallet = GetComponent<CoinWallet>();
    }

    private void OnEnable()
    {
        if (_triggerHandler != null)
            _triggerHandler.DetectedCollectable += OnCollectable;
    }

    private void OnDisable()
    {
        if ( _triggerHandler != null)
            _triggerHandler.DetectedCollectable -= OnCollectable;
    }

    private void OnCollectable(ICollectable collectable)
    {
        switch(collectable)
        {
            case Coin coin:
                if( _wallet != null)
                {
                    _wallet.AddCoin(coin.Value);
                    coin.Collect();
                }
                break;
        }
    }
}
