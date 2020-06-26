using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Speed", menuName ="Speed")]
public class PlayerSpeed : ScriptableObject
{
    public float speed;
    public float maxSpeed;
    public float acceleration;
}
