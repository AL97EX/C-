using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcSymbol : CalcController
{
    public override void ClickButton()
    {
        inputZone.text += gameObject.name;
        calcHelper.symbolSplit = char.Parse(gameObject.name);
        InteractableSymbols(false);
        calcHelper.whatDoYouInput = "Symbols";
    }
}
