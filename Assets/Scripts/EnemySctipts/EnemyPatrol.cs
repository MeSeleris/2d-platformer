using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Rotator2D))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("Точки маршрута")]
    [SerializeField] private Transform[] _waypoints;

    [Header("Настройки дистанции и ожидания")]
    [SerializeField] private float _reachDistance = 0.2f;
    [SerializeField] private float _waitTimeAtPoint = 1f;

    private EnemyMover _mover;
    private Rotator2D _rotator;

    private int _currentWaypointIndex = 0;
    private float _waitTimer = 0f;
    private bool _isWaiting = false;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _rotator = GetComponent<Rotator2D>();
    }

    private void Update()
    {
        if (_waypoints == null || _waypoints.Length == 0)
        {
            _mover.Stop();
            return;
        }

        if (_isWaiting)
        {
            _waitTimer -= Time.deltaTime;

            if (_waitTimer <= 0f)
            {
                _isWaiting = false;
                SwitchToNextWayPoint();
            }

            return;
        }

        Transform targetPoint = _waypoints[_currentWaypointIndex];

        if (targetPoint == null)
            return;

        float distanceX = targetPoint.position.x - transform.position.x;

        if (Mathf.Abs(distanceX) <= _reachDistance)
        {
            _mover.Stop();
            _isWaiting = true;
            _waitTimer = _waitTimeAtPoint;
            return;
        }

        float directionX = Mathf.Sign(distanceX);

        if (directionX > 0)
        {
            _rotator.FaceRight();
        }

        else if (directionX < 0)
        {
            _rotator.FaceLeft();
        }

        _mover.Move(directionX);
    }

    private void SwitchToNextWayPoint()
    {
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
    }

    private void OnDrawGizmosSelected()
    {
        if (_waypoints == null || _waypoints.Length == 0)
            return;

        Gizmos.color = Color.cyan;
        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] == null) continue;

            Gizmos.DrawWireSphere(_waypoints[i].position, 0.2f);

            int nextIndex = (i + 1) % _waypoints.Length;
            if (_waypoints[nextIndex] != null)
            {
                Gizmos.DrawLine(_waypoints[i].position, _waypoints[nextIndex].position);
            }
        }
    }
}
