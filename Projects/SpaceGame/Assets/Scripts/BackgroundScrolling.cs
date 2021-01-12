using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            Mathf.Repeat(Time.time * scrollSpeed, 15));
    }
}
