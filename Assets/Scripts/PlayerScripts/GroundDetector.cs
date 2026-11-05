using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkRadius = 0.2f;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void FixedUpdate()
    {
        if(_feetPosition != null)
        {
            _isGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkRadius);
        }
    }

    private void OnDrawGizmos()
    {
        if (_feetPosition != null)
        {
            Gizmos.color = _isGrounded ? Color.green : Color.yellow;
            Gizmos.DrawWireSphere(_feetPosition.position, _checkRadius);
        }
    }
}
