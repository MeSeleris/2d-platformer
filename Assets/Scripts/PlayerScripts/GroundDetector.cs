using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkRadius = 0.2f;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        if(_feetPosition != null)
        {
            IsGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkRadius, _layerMask);
        }
    }

    private void OnDrawGizmos()
    {
        if (_feetPosition != null)
        {
            Gizmos.color = IsGrounded ? Color.green : Color.yellow;
            Gizmos.DrawWireSphere(_feetPosition.position, _checkRadius);
        }
    }
}
