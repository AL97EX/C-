using UnityEngine;
using TMPro;
using System.Collections;

public class WallScript : MonoBehaviour
{
    [SerializeField] PlayerSpeed _speed;
    [SerializeField] private TMP_Text _winText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block" || other.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "Bowl")
        {
            _winText.enabled = true;
            _speed.speed = 0;
            Time.timeScale = 0f;
            Destroy(other.gameObject);
        }
    }
}
