using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class CalcController : MonoBehaviour
{
    [SerializeField] protected CalculatorHelper calcHelper;
    [SerializeField] protected TextMeshProUGUI inputZone;

    public abstract void ClickButton();

    public void Awake()
    {
        calcHelper.culcNumbers = GameObject.FindGameObjectsWithTag("CalcNumber");
        calcHelper.culcSymbols = GameObject.FindGameObjectsWithTag("CalcSymbol");
    }

    public virtual void InteractableSymbols(bool isActive)
    {
        for (int i = 0; i < calcHelper.culcSymbols.Length; i++)
        {
            calcHelper.culcSymbols[i].GetComponent<Button>().interactable = isActive;
        }
    }

}
