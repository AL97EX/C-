using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputText;
    public void ResetCounter()
    {
        inputText.text = "0";
    }
}
