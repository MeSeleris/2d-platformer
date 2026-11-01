using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private readonly List<Coin> _spawnedCoins = new List<Coin>();

    private void Start()
    {
        SpawnAllCoins();
    }

    public void SpawnAllCoins()
    {
        foreach (var point in _spawnPoints)
        {
            if (point != null)
            {
                SpawnCoin(point.position);
            }
        }
    }

    public Coin SpawnCoin(Vector3 position)
    {
        Coin coin = Instantiate(_coinPrefab, position, Quaternion.identity, transform);

        coin.OnCollect += HandleCoinCollected;
        _spawnedCoins.Add(coin);

        return coin;
    }

    private void HandleCoinCollected(Coin coin)
    {
        coin.OnCollect -= HandleCoinCollected;
        _spawnedCoins.Remove(coin);

        Destroy(coin.gameObject);
    }
}
