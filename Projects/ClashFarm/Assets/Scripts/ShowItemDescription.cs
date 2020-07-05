using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemDescription : MonoBehaviour
{
    public ShopItem _item;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _desription;
    void Start()
    {
        _name.text = _item.name;
        _image.sprite = _item.sprite;
        _price.text = $"{_item.price} $";
        _desription.text = _item.description;
    }

}
