using UnityEngine;


public class EnemyDamage : MonoBehaviour
{
    private int _enemyDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.TakeDamage(_enemyDamage);
        }

        if (collision.gameObject.TryGetComponent<KnockbackAfterDamage>(out var knockback))
        {
            knockback.PlayerKnocked(transform.position);
        }
    }
}
