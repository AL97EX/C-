using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform asteroidSpawner;
    [SerializeField] private GameObject[] listAsteroids;

    private float asteroidSpawnerBoundary;
    private void Awake()
    {
        asteroidSpawner.localScale = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x * 2, .1f, 1);
        asteroidSpawnerBoundary = asteroidSpawner.localScale.x / 2;
    }
    private void Start()
    {
        StartCoroutine(spawnTimer(true, 1));
    }

    private void Update()
    {
        
    }

    private IEnumerator spawnTimer(bool isGame, float time)
    {
        while (isGame)
        {
            yield return new WaitForSeconds(time);
            Vector3 pos = new Vector3(Random.Range(-asteroidSpawnerBoundary, asteroidSpawnerBoundary), asteroidSpawner.position.y, asteroidSpawner.position.z);
            Instantiate(listAsteroids[Random.Range(0, listAsteroids.Length)], pos, Quaternion.identity);
        }
    }
}
