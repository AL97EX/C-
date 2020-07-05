using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Manager
{
    public GameObject obj;
    public ShopItem item;
}
[CreateAssetMenu(fileName ="New_ObjectManager", menuName ="Object Manager")]
public class ObjectsManager : ScriptableObject
{
    public Manager _manager;
    public List<Manager> _managerList;

}
