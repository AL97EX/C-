using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
