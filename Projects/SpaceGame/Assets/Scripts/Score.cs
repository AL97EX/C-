using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Score", menuName ="Score")]
public class Score : ScriptableObject
{
    public float oldScore;
    public float newScore;
}
