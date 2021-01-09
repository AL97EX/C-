using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new CalculatorHelper",menuName = "CalculatorHelper")]
public class CalculatorHelper : ScriptableObject
{
    public GameObject[] culcNumbers;
    public GameObject[] culcSymbols;

    public string whatDoYouInput;
    public char symbolSplit;
}
