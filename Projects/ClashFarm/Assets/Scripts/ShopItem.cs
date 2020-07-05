using UnityEngine;

[CreateAssetMenu(menuName ="ShopItem",fileName ="NewItem")]
public class ShopItem : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public string price;
    public string description;
    public Vector3 scale;
    public GameObject prefab;
}
