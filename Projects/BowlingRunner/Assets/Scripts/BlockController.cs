using UnityEngine;
using TMPro;

public class BlockController : MonoBehaviour
{
    [SerializeField] private PlayerSpeed _speed;
    [SerializeField] private CountBlocks _count;
    float MoveDelta => _speed.speed * Time.deltaTime;
    float StopTimeDelta => _speed._stopTime * Time.deltaTime;
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
            if (gameObject.tag == "Block")
            {
                _speed.speed = Mathf.Lerp(_speed.speed, 0, StopTimeDelta);
                Destroy(gameObject, 0.5f);
            }
            else if (gameObject.tag == "Coin")
            {
                _count._new++;
                Destroy(gameObject.transform.GetChild(1).gameObject);
            }
        }
        
    }
}
