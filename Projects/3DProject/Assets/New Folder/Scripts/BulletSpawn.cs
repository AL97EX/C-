//Создание пули. Бросаем рейкаст от персонажа (точки спавна пули) к точке нажатия по врагу
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletEmitter;
    [SerializeField] private Transform _balletParent;
    [SerializeField] private TargetPoint _targetPoint;

    private void OnMouseDown()
    {
        _targetPoint.a = _bulletEmitter.position;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.tag=="Enemy")
            {
                _targetPoint.b = hit.point;
                Instantiate(_bulletPrefab, _bulletEmitter.position, _bulletEmitter.localRotation, _balletParent);
            }
        }
        
    }
}
