using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 5f;

    private float _moveInput;

    private void Update()
    {
        float left = Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed ? -1f : 0f;
        float right = Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed ? 1f : 0f;

        _moveInput = left + right;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2 (_moveInput * _speed, _rigidbody2D.linearVelocity.y);
    }
}
