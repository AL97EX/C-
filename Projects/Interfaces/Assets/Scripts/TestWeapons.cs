using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapons : MonoBehaviour
{
    Gun _gun;
    Knife _knife;
    LazerGun _lazerGun;

    private void Awake()
    {
        _gun = new Gun();
        _knife = new Knife();
        _lazerGun = new LazerGun();
    }

    public void ShowGun()
    {
        CheckInfo(_gun);
        Fire(_gun);
    }
    public void ShowKnife()
    {
        CheckInfo(_knife);
        Fire(_knife);
    }
    public void ShowLazerGun()
    {
        CheckInfo(_lazerGun);
        Fire(_lazerGun);
    }

    void CheckInfo(IHasInfo hasInfo)
    {
        hasInfo.Info();
    }
    void Fire(IWeapon weapon)
    {
        weapon.Fire();
    }
}
interface IWeapon
{
    int Damage { get; }
    void Fire();
}

interface IHasInfo
{
    void Info();
}

abstract class Weapon : IWeapon, IHasInfo
{
    public abstract int Damage { get; }
    public abstract void Fire();

    public abstract void Info();
}

class Gun : Weapon
{
    public override int Damage => 8;

    public override void Fire()
    {
        Debug.Log($"{GetType().Name} Fire");
    }

    public override void Info()
    {
        Debug.Log($"{GetType().Name} Info \n\n Damage: {Damage}");
    }
}

class LazerGun : Weapon
{
    public override int Damage => 12;
    public int Deffence => 10;

    public override void Fire()
    {
        Debug.Log($"{GetType().Name} Fire");
    }

    public override void Info()
    {
        Debug.Log($"{GetType().Name} Info \n\n Damage: {Damage} \n Deffence: {Deffence}");
    }
}

class Knife : Weapon
{
    public override int Damage => 3;

    public override void Fire()
    {
        Debug.Log($"{GetType().Name} Fire");
    }

    public override void Info()
    {
        Debug.Log($"{GetType().Name} Info \n\n Damage: {Damage}");
    }
}