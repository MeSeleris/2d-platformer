using UnityEngine;

public class Rotator2D : MonoBehaviour
{
    [SerializeField] private bool _isFacingRight = true;

    public bool isFacingRight => _isFacingRight;

    public void FaceRight()
    {
        if (_isFacingRight)
            return;
        SetFacing(true);
    }

    public void FaceLeft()
    {
        if(!_isFacingRight)
            return;
        SetFacing(false);
    }

    public void Flip()
    {
        SetFacing(!_isFacingRight);
    }

    private void SetFacing(bool faceRight)
    {
       _isFacingRight = faceRight;

        float yAngle = _isFacingRight ? 0f : 180f;
        transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
    }
}
