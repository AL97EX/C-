using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    [SerializeField] private List<Transform> _blockPoints;
    [SerializeField] private float _minTimeToSpawn;
    [SerializeField] private float _maxTimeToSpawn;
    [SerializeField] private List<GameObject> _prefabs;
    public float _timeToSpawn;
    public float _timerToSpawn;

    private void Start()
    {
        _timeToSpawn = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
    }

    void Update()
    {
        if (_timerToSpawn >= _timeToSpawn)
        {
            Instantiate(_prefabs[Random.Range(0,_prefabs.Count)], _blockPoints[Random.Range(0, _blockPoints.Count)].position, Quaternion.identity);
            _timeToSpawn = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
            _timerToSpawn = 0;
        }
        _timerToSpawn += Time.deltaTime;
    }
}
