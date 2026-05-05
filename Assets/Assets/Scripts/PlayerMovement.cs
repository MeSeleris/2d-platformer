using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 5f;

    private float _moveInput;
    private bool _isFacingRight = true;

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
        _rigidbody2D.linearVelocity = new Vector2 (_moveInput * _speed, _rigidbody2D.linearVelocity.y);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 scaler = transform.localScale;

        scaler.x *= -1;

        transform.localScale = scaler;
    }
}
