using UnityEngine;

public class ClickObjectToMove : MonoBehaviour
{
    public bool _firstSelect;
    public bool _secondSelect;
    public MapGenerate _map;
    public ObjectsManager _objectsManager;


    private GameObject _tempSelectedObj;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!_firstSelect && !_secondSelect)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag=="Object")
                    {
                        int index = int.Parse(hit.collider.name);
                        _map._gridList[index].isActive = true;
                        _tempSelectedObj = hit.collider.gameObject;
                        ObjInfo _info = _tempSelectedObj.GetComponent<ObjInfo>();
                        _firstSelect = true;

                        //Description in the Log
                        Debug.Log($"Name: {_info._item.name}\n" +
                            $"Price: { _info._item.price}\n" +
                            $"Description: {_info._item.description}");
                    }
                }
            }
            else if (!_secondSelect)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Grid")
                    {
                        int index = int.Parse(hit.collider.name);
                        if (!_map._gridList[index].isActive)
                        {
                            Debug.Log("NO");
                        }
                        else
                        {
                            _tempSelectedObj.name = hit.collider.name;
                            _tempSelectedObj.transform.position = hit.collider.transform.position;
                            _map._gridList[index].isActive = false;
                            _firstSelect = _secondSelect = false;
                        }
                    }
                }
            }
        }
        
    }
}
