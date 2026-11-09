using UnityEngine;

public class Rotator2D : MonoBehaviour
{
    [SerializeField] private bool _isFacingRight = true;

    private readonly Quaternion _faceRight = Quaternion.identity;
    private readonly Quaternion _faceLeft = Quaternion.Euler(0f, 180f, 0f);

    public bool IsFacingRight => _isFacingRight;

    public void FaceRight()
    {
        if (_isFacingRight)
            return;

        _isFacingRight = true;
        transform.rotation = _faceRight;
    }

    public void FaceLeft()
    {
        if (!_isFacingRight)
            return;

        _isFacingRight = false;
        transform.rotation = _faceLeft;
    }

    public void Flip()
    {
        if (_isFacingRight)
            FaceLeft();
        else
            FaceRight();
    }
}
