using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid
{
    public GameObject prefabGrid;
    public bool isActive;
}

public class MapGenerate : MonoBehaviour
{

    public List<Grid> _gridList;

    [SerializeField] private List<GameObject> prefabDecore;
    [SerializeField] private Transform parentDecore;
    [SerializeField] private Transform parentGrid;
    [SerializeField] private Collider col;

    [SerializeField] private GameObject prefabGrid;
    [SerializeField] private bool isActive;

    private int _indexGrid;
    private float xPos;
    private float zPos;
    private Vector3 _newPos;

    private void Awake()
    {
        xPos = Mathf.Pow(transform.localScale.x, 2) - prefabGrid.transform.localScale.x / 2;
        zPos = Mathf.Pow(transform.localScale.x, 2) - prefabGrid.transform.localScale.x / 2;
        Generate();
    }
    
    private void Generate()
    {
        for (float x= -xPos; x<=xPos; x++)
        {
            for (float z = -zPos; z <= zPos; z++)
            {
                _newPos = new Vector3(x, 0, z);
                if (x == -xPos || x == xPos || z == -zPos || z == zPos)
                {
                    Instantiate(prefabDecore[Random.Range(0, prefabDecore.Count)], _newPos, Quaternion.identity, parentDecore);
                }
                else
                {
                    Grid _manager = new Grid();
                    _manager.prefabGrid = Instantiate(prefabGrid, _newPos, Quaternion.Euler(90, 0, 0), parentGrid);
                    _manager.prefabGrid.name = $"{_indexGrid}";
                    _manager.isActive = true;
                    _gridList.Add(_manager);
                    _indexGrid++;
                }
                    
            }
        }
    }

}
