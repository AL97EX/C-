using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] CountBlocks _blockCount;
    [SerializeField] SpawnBlock _spawnBlockScript;
    [SerializeField] GameObject _bowlsPrefab;
    [SerializeField] Transform _bowlsSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            Destroy(other.gameObject);
            _blockCount.COUNT_BLOCK_TO_BOWLS++;
            if (_blockCount.count <= _blockCount.COUNT_BLOCK_TO_BOWLS)
            {
                Instantiate(_bowlsPrefab, _bowlsSpawn.position, Quaternion.identity);
                _blockCount.COUNT_BLOCK_TO_BOWLS = 0;
            }
        }
    }
}
