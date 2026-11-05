using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundDetector _groundDetector;

    private bool _isGround;

    private void Awake()
    {
       _rigidbody = GetComponent<Rigidbody2D>();

        if( _rigidbody == null)
        {
            Debug.Log("Null RB");
        }
    }

    private void Update()
    {
        bool isGrounded = _groundDetector != null && _groundDetector.IsGrounded;

        if(_playerAnimator != null)
        {
            _playerAnimator.SetGrounded(isGrounded);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGround)
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

}
