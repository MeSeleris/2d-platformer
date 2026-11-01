using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Rigidbody2D _foeRigidbody2D;

    private void Awake()
    {
        _foeRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float directionX)
    {
        _foeRigidbody2D.linearVelocity = new Vector2(directionX * _speed, _foeRigidbody2D.linearVelocity.y);
    }

    public void Stop()
    {
        _foeRigidbody2D.linearVelocity = new Vector2(0f, _foeRigidbody2D.linearVelocity.y);
    }
}
