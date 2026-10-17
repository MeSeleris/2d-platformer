using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int _coinsCount = 0;

    public int CoinCount => _coinsCount;

    public void AddCoin(int amount)
    {
        _coinsCount += amount;
        Debug.Log($"Монета подобрана! Число монет: {_coinsCount}");
    }
}
