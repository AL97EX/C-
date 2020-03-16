using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _tempEnemySpeed;
    [SerializeField] private float _timeStopEnemy;
    [SerializeField] private float _timeGoEnemy;

    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    [SerializeField] private float _moveDirection;
    [SerializeField] private Rigidbody2D _rigitbody;
    
    private Vector2 moveEnemy;

    private Vector2 _leftPointVector;
    private Vector2 _rightPointVector;
    private float _distanceLeft;
    private float _distanceRight;
    void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
        _tempEnemySpeed = _enemySpeed;
        _timeStopEnemy = Random.Range(5f, 10f);
    }

    void Update()
    {
        Distance();
        EnemyMove();
        EnemyDelay();
    }
    private void FixedUpdate()
    {
        _rigitbody.MovePosition(_rigitbody.position + moveEnemy * Time.fixedDeltaTime);
    }
    private void EnemyMove()
    {
        moveEnemy = Vector2.right * _moveDirection * _enemySpeed;
        if (_distanceLeft<=0.1f)
        {
            _moveDirection = 1;
        }
        else if (_distanceRight <= 0.1f)
        {
            _moveDirection = -1;
        }
    }
    private void Distance()
    {
        _leftPointVector = transform.position - _leftPoint.position;
        _rightPointVector = transform.position - _rightPoint.position;
        _distanceLeft = Mathf.Abs(Mathf.Sqrt(_leftPointVector.x * _leftPointVector.x + _leftPointVector.y * _leftPointVector.y));
        _distanceRight = Mathf.Abs(Mathf.Sqrt(_rightPointVector.x * _rightPointVector.x + _rightPointVector.y * _rightPointVector.y));
    }
    private void EnemyDelay()
    {
        if (_timeStopEnemy <= 0)
        {
            _enemySpeed = 0;
            if (_timeGoEnemy <= 0)
            {
                _enemySpeed = _tempEnemySpeed;
                _timeStopEnemy = _timeGoEnemy = Random.Range(5f, 10f);
            }
            _timeGoEnemy -= .1f;
        }
        _timeStopEnemy -= .1f;
    }
}
