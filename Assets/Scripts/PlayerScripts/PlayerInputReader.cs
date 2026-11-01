using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public float MoveDirection { get; private set; }

    private void Update()
    {
        MoveDirection = ReadMovementInput();
    }

    private float ReadMovementInput()
    {
        if (Keyboard.current == null)
            return 0f;

        float left = (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) ? -1f : 0f;
        float right = (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) ? 1f : 0f;

        return left + right;
    }
}
