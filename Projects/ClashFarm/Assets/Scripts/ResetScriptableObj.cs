using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScriptableObj : MonoBehaviour
{
    public ObjectsManager _manager;
    void Start()
    {
        _manager._managerList.Clear();
    }

    void Update()
    {
        
    }
}
