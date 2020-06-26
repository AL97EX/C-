using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CountBlock", fileName ="New Block Count")]
public class CountBlocks : ScriptableObject
{
    public int count;

    public int COUNT_BLOCK_TO_BOWLS;

    [Header("Coin count")]
    public float _new;
    public float _old;
    public float _total;
}
