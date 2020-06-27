using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

}
