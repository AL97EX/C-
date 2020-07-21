using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlHit : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0.1f;
            _audioSource.Play();
        }
    }
}
