using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Button> _puzzleBtns;
    public Transform _puzzleField;
    public Sprite _buttonSprite;
    void Start()
    {
        for(int i = 0; i < _puzzleField.childCount; i++)
        {
            _puzzleBtns.Add(_puzzleField.GetChild(i).GetComponent<Button>());
            _puzzleBtns[i].image.sprite = _buttonSprite;
        }
    }

    void Update()
    {
        
    }
}
