using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcNumber : CalcController
{
    public override void ClickButton()
    {
        if (calcHelper.whatDoYouInput == "Result" || calcHelper.whatDoYouInput == "Error" || inputZone.text == "0")
        {
            inputZone.text = "";
        }
        calcHelper.whatDoYouInput = "Numbers";
        inputZone.text += gameObject.name;
    }
}
