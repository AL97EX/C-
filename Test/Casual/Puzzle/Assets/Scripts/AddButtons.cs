using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField] private RectTransform _puzzleField;
    [SerializeField] private GameObject _puzzleButtonPrefab;

    private GameObject _instantiateBtn;
    void Awake()
    {
        for(int i = 0; i < 12; i++)
        {
            _instantiateBtn = Instantiate(_puzzleButtonPrefab);
            _instantiateBtn.name = $"{i}";
            _instantiateBtn.transform.SetParent(_puzzleField);
        }
    }

    void Update()
    {
        
    }
}
