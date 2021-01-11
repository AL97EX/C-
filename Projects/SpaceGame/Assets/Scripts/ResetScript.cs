using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    [SerializeField] private Score score;

    private void Awake()
    {
        score.newScore = score.oldScore = 0;
    }
}
