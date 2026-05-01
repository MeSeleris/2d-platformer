using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Transform _feetPositon;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private float _checkRadius = 0.2f;

    private Rigidbody2D _rigidbody;
    private bool _isGround;

    private void Awake()
    {
       _rigidbody = GetComponent<Rigidbody2D>();

        if( _rigidbody != null)
        {
            Debug.Log("Null RB");
        }
    }

    private void Update()
    {
        _isGround = Physics2D.OverlapCircle(_feetPositon.position, _checkRadius, _groundLayer);

        if(Keyboard.current.spaceKey.wasPressedThisFrame && _isGround)
        {
            ApplyJump();
        }
    }

    private void ApplyJump()
    {
        float resetVerticalVelocity = 0f;
        Vector2 jumpDirection = Vector2.up;

        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, resetVerticalVelocity);
        _rigidbody.AddForce(jumpDirection * _jumpForce, ForceMode2D.Impulse);
    }
    
    private void OnDrawGizmos()
    {
        if(_feetPositon != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_feetPositon.position, _checkRadius);
        }
    }
}
