using System.Xml.Serialization;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private bool _isMovingRight = true;

    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _groundRayDistance = 0.5f;
    [SerializeField] private float _wallRayDistance = 0.3f;
    [SerializeField] private LayerMask _groundLayer; 

    Rigidbody2D _enemyRigidbody;

    private void Awake()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float directionX = _isMovingRight ? 1f : -1f;
        Vector2 castRayToDirection = _isMovingRight ? Vector2.right : Vector2.left;
        Vector2 castRayInGround = Vector2.down;

        _enemyRigidbody.linearVelocity = new Vector2(directionX *  _speed, _enemyRigidbody.linearVelocity.y);

        if(_groundCheckPoint == null) return;

        RaycastHit2D groundHit = CastRay(castRayInGround, _groundRayDistance);
        RaycastHit2D wallHit = CastRay(castRayInGround, _wallRayDistance);


        if (groundHit.collider == null || wallHit.collider != null)
        {
            Flip();
        }
    }

    private RaycastHit2D CastRay( Vector2 direction, float distance)
    {
        return Physics2D.Raycast(_groundCheckPoint.position, direction, distance, _groundLayer);
    }

    private void Flip()
    {
        _isMovingRight = !_isMovingRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1f;
        transform.localScale = scaler;
    }

    private void OnDrawGizmosSelected()
    {
        if(_groundCheckPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_groundCheckPoint.position, _groundCheckPoint.position + Vector3.down * _groundRayDistance);
        }
    }
}
