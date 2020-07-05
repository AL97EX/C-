using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    [SerializeField] private ShopItem _item;
    [SerializeField] private Transform _centerScreen;
    [SerializeField] private ObjectsManager _objectsManager;
    [SerializeField] private MapGenerate _gridManager;
    [SerializeField] private GameObject _appearenceEffect;
    [SerializeField] private float _timeToDestroyEffect;
    [SerializeField] private AudioSource _audioSource;

    public void Create()
    {
        Ray ray = Camera.main.ScreenPointToRay(_centerScreen.position);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Grid")
            {
                GameObject _tempEffect = Instantiate(_appearenceEffect, hit.transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(_tempEffect, _timeToDestroyEffect);

                int index = int.Parse(hit.transform.name);

                //Create the obj from the shop
                Vector3 pos =new Vector3(hit.transform.position.x,0, hit.transform.position.z);
                GameObject _temp = Instantiate(_item.prefab, pos, Quaternion.identity);
                
                _temp.transform.localScale = new Vector3(_item.scale.x, _item.scale.y, _item.scale.z);
                _audioSource.Play();
                _objectsManager._manager = new Manager();
                //Add obj into ObjectsManager after buying is the shop
                _objectsManager._manager.obj = _temp;
                _objectsManager._manager.obj.name = $"{index}";
                _objectsManager._manager.item = _item;
                _objectsManager._managerList.Add(_objectsManager._manager);
                
            }
        }
        
    }

    void Update()
    {
        
    }
}
