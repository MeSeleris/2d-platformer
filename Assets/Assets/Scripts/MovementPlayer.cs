using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _moveInput;


    private void Awake()
    {
        if(_rigidbody2D == null)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    private void Update()
    {
        _moveInput = Input.GetAxis("Horzontal");
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2 (_moveInput * _speed, _rigidbody2D.linearVelocity.y);
    }
}
