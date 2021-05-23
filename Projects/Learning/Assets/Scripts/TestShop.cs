using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestShop : MonoBehaviour
{
    public Apple apple;
    public Orange orange;

    public Image appleImage;
    public Image orangeImage;

    private void Awake()
    {
        appleImage.sprite = apple.Picture;
        orangeImage.sprite = orange.Picture;
    }

    #region Apple
    public void ShowInfoApple()
    {
        ShowInfo(apple);
    }

    public void BuyApple()
    {
        Buy(apple);
    }

    public void SellApple()
    {
        Sell(apple);
    }
    #endregion

    #region Orange
    public void ShowInfoOrange()
    {
        ShowInfo(orange);
    }

    public void BuyOrange()
    {
        Buy(orange);
    }

    public void SellOrange()
    {
        Sell(orange);
    }
    #endregion

    #region Core
    void ShowInfo(IInfo info)
    {
        info.Show();
    }
    void Buy(IService service)
    {
        service.Buy();
    }
    void Sell(IService service)
    {
        service.Sell();
    }
#endregion
}

interface IProductItem
{
    int BuyPrice { get; }
    int SellPrice { get; }
    int Term { get; }
}
interface IInfo
{
    void Show();
}

interface IService
{
    void Buy();
    void Sell();
}

public abstract class Products : IProductItem, IInfo, IService
{
    public abstract int BuyPrice { get; }
    public abstract int SellPrice { get; }

    public abstract int Term { get; }

    public abstract void Show();

    public abstract void Buy();

    public abstract void Sell();

    public Sprite Picture;
}

[System.Serializable]
public class Apple : Products
{
    public override int BuyPrice => 10;
    public override int SellPrice => 5;

    public override int Term => 10;

    public override void Show()
    {
        Debug.Log($"{GetType().Name} \n\n Price: {BuyPrice} \n Term: {Term}");
    }

    public override void Buy()
    {
        Debug.Log($"{GetType().Name} Buyed for {BuyPrice}");
    }

    public override void Sell()
    {
        Debug.Log($"{GetType().Name} Selled for {SellPrice}");
    }
}

[System.Serializable]
public class Orange : Products
{
    public override int BuyPrice => 20;
    public override int SellPrice => 10;

    public override int Term => 10;

    public override void Show()
    {
        Debug.Log($"{GetType().Name} \n\n Price: {BuyPrice} \n Term: {Term}");
    }

    public override void Buy()
    {
        Debug.Log($"{GetType().Name} Buyed for {BuyPrice}");
    }

    public override void Sell()
    {
        Debug.Log($"{GetType().Name} Selled for {SellPrice}");
    }
}