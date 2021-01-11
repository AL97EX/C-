using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    [SerializeField] protected float protection;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject[] bulletArray;
    [SerializeField] protected Transform bulletSpawn;

    protected abstract void Move();
    protected abstract void Fire();

}
