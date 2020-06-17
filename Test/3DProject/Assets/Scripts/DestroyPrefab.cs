//Уничтожение префаба через время
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
