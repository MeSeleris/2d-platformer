using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private static readonly int SpeedHash = Animator.StringToHash("speed");
    private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");
    private static readonly int VerticalVelocityHash = Animator.StringToHash("VerticalVelocity");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void SetSpeed(float speed)
    {
        _animator.SetFloat(SpeedHash, speed);
    }

    public void SetGrounded(bool grounded)
    {
        _animator.SetBool(IsGroundedHash, grounded);
    }

    public void SetVerticalVelocity(float verticalVelocity)
    {
        _animator.SetFloat(VerticalVelocityHash, verticalVelocity);
    }
}
