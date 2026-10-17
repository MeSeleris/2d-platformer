using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class KnockbackAfterDamage : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _force =  new Vector2 (6f, 2f);
    [SerializeField] private float _durationUntoucheble = 0.5f;

    private bool isKnockedBack;
    public bool IsKnocked => isKnockedBack;

    private void Awake()
    {
        if (_rigidbody == null)
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void PlayerKnocked (Vector2 attackedPosition)
    {
        Debug.Log("Вызван PlayKnockback! Направление от: " + attackedPosition);

        if (isKnockedBack)
        {
            Debug.Log("Отскок уже активен, выход.");
            return;
        }

        if (isKnockedBack == true) return;

        StopAllCoroutines();
        StartCoroutine(KnockbackEffect(attackedPosition));
    }

    private IEnumerator  KnockbackEffect(Vector2 attackedPosition)
    {
        isKnockedBack = true;

        float directionX = transform.position.x < attackedPosition.x ? -1f : 1f;
        _rigidbody.linearVelocity = Vector2.zero;

        Vector2 impulse = new Vector2(directionX * _force.x, _force.y);
        _rigidbody.AddForce(impulse, ForceMode2D.Impulse);

        yield return new WaitForSeconds(_durationUntoucheble);

        isKnockedBack = false;
    }
}
