using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private KnockbackAfterDamage _knockback;

    private float _moveInput;
    private bool _isFacingRight = true;

    private void Awake()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();

        if (_knockback == null)
            _knockback = GetComponent<KnockbackAfterDamage>();
    }

    private void Update()
    {
        float left = Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed ? -1f : 0f;
        float right = Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed ? 1f : 0f;

        _moveInput = left + right;

        if((_moveInput > 0 && _isFacingRight == false) || (_moveInput < 0 && _isFacingRight == true))
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (_knockback != null && _knockback.IsKnocked)
            return;

        _rigidbody2D.linearVelocity = new Vector2(_moveInput * _speed, _rigidbody2D.linearVelocity.y);
        _animator.SetFloat("speed", Mathf.Abs(_rigidbody2D.linearVelocity.x));
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 scaler = transform.localScale;

        scaler.x *= -1;

        transform.localScale = scaler;
    }
}
