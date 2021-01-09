using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : CalcController
{
    private string[] parsedString;
    public override void ClickButton()
    {
        try
        {
            if (calcHelper.whatDoYouInput == "Numbers")
            {
                parsedString = inputZone.text.Split(calcHelper.symbolSplit);

                calcHelper.whatDoYouInput = "Result";
                InteractableSymbols(true);

                inputZone.text = ArithmeticOperation(int.Parse(parsedString[0]), int.Parse(parsedString[1]), calcHelper.symbolSplit).ToString();
            }
        }
        catch
        {
            inputZone.text = calcHelper.whatDoYouInput = "Error";
        }
    }

    float ArithmeticOperation(int num1, int num2, char symbol)
    {
        float result = 0;
        switch (symbol)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 == 0)
                    result = 0;
                else
                    result = (float)num1 / num2;
                break;
        }
        return result;
    }
}
