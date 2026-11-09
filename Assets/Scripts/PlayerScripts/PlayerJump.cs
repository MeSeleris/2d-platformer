using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerInputReader _playerInput;

    private bool _isGround;

    private void Awake()
    {
        if( _rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();

        if( _playerInput == null )
            _playerInput = GetComponent<PlayerInputReader>(); 

        if(_groundDetector == null)
            _groundDetector = GetComponent<GroundDetector>();

        if(_playerAnimator == null )
            _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        if (_playerInput != null)
            _playerInput.JumpTrigger += OnJump;
    }

    private void OnDisable()
    {
        if (_playerInput != null)
            _playerInput.JumpTrigger -= OnJump;
    }

    private void Update()
    {
        if(_playerAnimator != null && _groundDetector != null)
        {
            _playerAnimator.SetGrounded(_groundDetector.IsGrounded);
        }
    }

    private void OnJump()
    {
        if (_groundDetector != null && _groundDetector.IsGrounded)
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
