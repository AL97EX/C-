using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force;
    [SerializeField] private GameObject explosionAsteroidPrefab;
    [SerializeField] private GameObject explosionSpaceShipPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Asteroid")
        {
            Instantiate(explosionAsteroidPrefab, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
