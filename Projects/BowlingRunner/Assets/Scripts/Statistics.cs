using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCount;
    [SerializeField] private CountBlocks _count;
    [SerializeField] private GameObject _prefabBowls;
    [SerializeField] Transform _bowlsSpawn;
    [SerializeField] SpawnBlock _spawnBlock;
    void Start()
    {
        _textCount.text = $"Coins: {_count._new} / {_count._total}";
    }

    // Update is called once per frame
    void Update()
    {
        if (_count._new != _count._old)
        {
            _textCount.text = $"Coins: {_count._new} / {_count._total}";
            _count._old = _count._new;
        }
        if (_count._new == _count._total)
        {
            _spawnBlock.enabled = false;
            Instantiate(_prefabBowls, _bowlsSpawn.position, Quaternion.identity);
            enabled = false;
        }
    }
}
