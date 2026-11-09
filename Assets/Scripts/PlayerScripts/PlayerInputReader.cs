using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputReader : MonoBehaviour
{
    public float MoveDirection { get; private set; }

    public event Action JumpTrigger;

    private void Update()
    {
        MoveDirection = ReadMovementInput();
        ReadJump();
    }

    private float ReadMovementInput()
    {
        if (Keyboard.current == null)
            return 0f;

        float left = (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) ? -1f : 0f;
        float right = (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) ? 1f : 0f;

        return left + right;
    }

    private void ReadJump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            JumpTrigger?.Invoke();
        }
    }
}
