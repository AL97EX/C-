using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisable_Grid : MonoBehaviour
{
    [SerializeField] private List<Sprite> _powerImages;
    [SerializeField] private Image _im;
    [SerializeField] private MapGenerate _grid;
    bool _isActive;
    private void Start()
    {
        _isActive = true;
    }
    public void On_Off()
    {
        _isActive = !_isActive;
        for (int i = 0; i < _grid._gridList.Count; i++)
        {
            _grid._gridList[i].prefabGrid.GetComponent<MeshRenderer>().enabled = _isActive;
        }
        
        
        if (_isActive)
        {
            _im.sprite = _powerImages[0];
        }
        else
        {
            _im.sprite = _powerImages[1];
        }
        
    }
}
