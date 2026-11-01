using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rotator2D))]
[RequireComponent(typeof(PlayerInputReader))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Rotator2D _rotator2D;
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private KnockbackAfterDamage _knockback;

    private float _moveInput;

    private void Awake()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();

        if (_rotator2D == null)
            _rotator2D = GetComponent<Rotator2D>();

        if (_knockback == null)
            _knockback = GetComponent<KnockbackAfterDamage>();

        if (_inputReader == null)
            _inputReader = GetComponent<PlayerInputReader>();
    }

    private void Update()
    {
        float moveInput = _inputReader.MoveDirection;

        if (_moveInput > 0f)
        {
            _rotator2D.FaceRight();
        }
        else if (_moveInput < 0f)
        {
            _rotator2D.FaceLeft();
        }
    }

    private void FixedUpdate()
    {
        if (_knockback != null && _knockback.IsKnocked)
            return;

        float moveInput = _inputReader.MoveDirection;

        _rigidbody2D.linearVelocity = new Vector2(_moveInput * _speed, _rigidbody2D.linearVelocity.y);

        if (_animator != null)
            _animator.SetFloat("speed", Mathf.Abs(_rigidbody2D.linearVelocity.x));
    }
}

