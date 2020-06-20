//Движение пули
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletSetting _bulletPower;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _kickBloodPrefab;

    private TargetPoint _targetPoint;
    private Rigidbody _rigidbody;
    private float MoveDelta => _speed * Time.deltaTime;
    void Start()
    {
        _targetPoint = transform.parent.GetComponent<TargetPoint>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(_targetPoint.Target() * _bulletPower.power, ForceMode.Impulse);
        
    }

    void Update()
    {
        _rigidbody.AddForce(_targetPoint.Target() * MoveDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            Destroy(other);
            Instantiate(_kickBloodPrefab, transform.position, Quaternion.identity);
            other.GetComponent<DeathPlayer>().EnablePhysics();
            Destroy(gameObject);
        }
    }
}
