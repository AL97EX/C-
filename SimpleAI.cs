using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    [SerializeField] private float _stopDistance = 2f;
    [SerializeField] private float speed;
    [SerializeField] private float _playerDetectionDistance = 20f;
    [SerializeField] private  float _playerAroundWaypointsMinDistance = 10f;
    [SerializeField] private Transform _player;
    [SerializeField] private List<Transform> _waypointsPatrol;
    [SerializeField] private List<Transform> _waypointsAroundPlayer;
    private float DistanceToPlayer => Vector3.Distance(transform.position, _player.position);
    private float MoveDelta => speed * Time.deltaTime;
    private int _waypointsIndexAroundPlayer;
    private int _waypointsIndex;
    private enum State { PATROL, CHASE }
    private State _state;

    private void Start()
    {
        _state = State.PATROL;
        StartCoroutine(DroneMove());
    }
    private IEnumerator DroneMove()
    {
        while (true)
        {
            switch (_state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
            }
            yield return null;
        }
    }
    private void Patrol()
    {
        Vector3 waypointPosition = _waypointsPatrol[_waypointsIndex].position;

        float distanceToWaypoint = Vector3.Distance(transform.position, waypointPosition);

        if (distanceToWaypoint > _stopDistance)
            transform.position = Vector3.MoveTowards(transform.position, waypointPosition, MoveDelta);

        else if (distanceToWaypoint < _stopDistance)
        {
            _waypointsIndex++;
            if (_waypointsIndex == _waypointsPatrol.Count)
                _waypointsIndex = 0;
        }

        if (DistanceToPlayer < _playerDetectionDistance)
            _state = State.CHASE;
    }
    private void Chase()
    {
        if (DistanceToPlayer < _playerDetectionDistance && DistanceToPlayer > _playerAroundWaypointsMinDistance)
            transform.position = Vector3.MoveTowards(transform.position, _player.position, MoveDelta);
        else if (DistanceToPlayer <= _playerAroundWaypointsMinDistance)
        {
            Vector3 waypointPosition = _waypointsAroundPlayer[_waypointsIndexAroundPlayer].position;
            
            float distanceToPlayerWaypoint = Vector3.Distance(transform.position, waypointPosition);

            if (distanceToPlayerWaypoint > _stopDistance)
                transform.position = Vector3.MoveTowards(transform.position, waypointPosition, MoveDelta);
            else
            {
                _waypointsIndexAroundPlayer++;
                if (_waypointsIndexAroundPlayer == _waypointsAroundPlayer.Count)
                    _waypointsIndexAroundPlayer = 0;
            }
        }

        if (DistanceToPlayer > _playerDetectionDistance)
            _state = State.PATROL;
    }
}
