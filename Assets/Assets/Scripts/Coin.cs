using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue = 1;
    [SerializeField] private AudioClip _coinPickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<CoinCollector>(out CoinCollector collector))
            {
                collector.AddCoin(_coinValue);

                if(_coinPickUpSound != null)
                {
                    AudioSource.PlayClipAtPoint(_coinPickUpSound, transform.position);
                }

                Destroy(gameObject);
            }
        }
    }
}