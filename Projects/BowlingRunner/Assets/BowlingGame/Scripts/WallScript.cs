using UnityEngine;
using TMPro;
using System.Collections;

public class WallScript : MonoBehaviour
{
    [SerializeField] PlayerSpeed _speed;
    [SerializeField] private GameObject _win;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioClip _winClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block" || other.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "Bowl")
        {
            _backgroundMusic.clip = _winClip;
            _backgroundMusic.loop = false;
            _backgroundMusic.volume = .5f;
            _backgroundMusic.Play();
            _win.SetActive(true);
            _speed.speed = 0;
            Time.timeScale = 0f;
            Destroy(other.gameObject);
        }
    }
}
