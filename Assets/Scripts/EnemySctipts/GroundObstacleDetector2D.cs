using UnityEngine;
using UnityEngine.EventSystems;

public class GroundObstacleDetector2D : MonoBehaviour
{
    [Header("Точка пуска лучей")]
    [SerializeField] private Transform _groundCheckPoint;

    [Header("Distance parametr")]
    [SerializeField] private float _groundRayDistance = 0.5f;
    [SerializeField] private float _wallRayDistance = 0.3f;

    [Header("Layers")]
    [SerializeField] private LayerMask _groundLayer;

    public bool HasGroundAhead()
    {
        if(_groundCheckPoint == null)
            return false;

        RaycastHit2D hitGround2D = Physics2D.Raycast(
            _groundCheckPoint.position,
            Vector2.down,
            _groundRayDistance,
            _groundLayer
            );

        return hitGround2D.collider != null;
    }

    public bool HasWallAhead()
    {
        if (_groundCheckPoint == null)
            return false;

        RaycastHit2D hitWall2D = Physics2D.Raycast(
            _groundCheckPoint.position,
            transform.right,
            _wallRayDistance,
            _groundLayer
            );

        return hitWall2D.collider != null;
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheckPoint == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(
            _groundCheckPoint.position,
            _groundCheckPoint.position + Vector3.down * _groundRayDistance
        );

        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            _groundCheckPoint.position,
            _groundCheckPoint.position + transform.right * _wallRayDistance
            );
    }
}
