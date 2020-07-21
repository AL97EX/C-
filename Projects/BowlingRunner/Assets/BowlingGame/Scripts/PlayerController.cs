using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private PlayerSpeed _speed;
    private Vector3 _target;
    private int _index;
    private float _rotateSpeed;
    private float MoveDelta => _speed.speed * Time.deltaTime;
    float AccelerationDelta => _speed.acceleration * Time.deltaTime;

    void Start()
    {
        _target = transform.position;
        SwipeController.SwipeEvent += CheckInput;
    }

    void CheckInput(SwipeController.SwipeType type)
    {
        if (type== SwipeController.SwipeType.RIGHT)
        {
            if (_index > 0)
                _index--;
            else
                _index = 0;
        }
        else if (type== SwipeController.SwipeType.LEFT)
        {
            if (_index < _points.Count-1)
                _index++;
            else
                _index = _points.Count-1;
        }
        _target = _points[_index].position;
    }
    private void Update()
    {
        if (_speed.speed < _speed.maxSpeed)
            _speed.speed = Mathf.Lerp(_speed.speed, _speed.maxSpeed, AccelerationDelta);
        transform.position = Vector3.MoveTowards(transform.position, _target, MoveDelta);
        transform.rotation = Quaternion.Euler(_rotateSpeed -= _speed.speed, 0, 0);
    }
    private void OnDisable()
    {
        SwipeController.SwipeEvent -= CheckInput;
    }
}
