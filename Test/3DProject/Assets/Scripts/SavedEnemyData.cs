using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedEnemyData : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _capsuleCollider;
    private float _capsuleHeight;
    private float _capsuleRadius;
    private Vector3 _capsuleCenter;

    void Awake()
    {
        _capsuleHeight = _capsuleCollider.height;
        _capsuleRadius = _capsuleCollider.radius;
        _capsuleCenter = _capsuleCollider.center;
    }
    public void LoadData()
    {
        gameObject.AddComponent<CapsuleCollider>();
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.001f);
        _capsuleCollider = GetComponent<CapsuleCollider>();
        yield return new WaitForSeconds(0.001f);
        _capsuleCollider.height = _capsuleHeight;
        _capsuleCollider.radius = _capsuleRadius;
        _capsuleCollider.center = _capsuleCenter;
    }
}
