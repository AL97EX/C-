using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private PlayerSpeed _speed;
    [SerializeField] private float _stopTime;
    float MoveDelta => _speed.speed * Time.deltaTime;
    float StopTimeDelta => _stopTime * Time.deltaTime;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * MoveDelta;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            _speed.speed = Mathf.Lerp(_speed.speed, 0, StopTimeDelta);
            Destroy(gameObject,0.5f);
        }
        
    }
}
