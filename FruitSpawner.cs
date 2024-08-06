using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs; 
    public GameObject bombPrefab;
    public Transform[] spawnPoints;
    public float fminDelay = 3f;
    public float fmaxDelay = 5f;
    public float bminDelay = 3f;
    public float bmaxDelay = 5f;

    void Start()
    {
        StartCoroutine(SpawnFruits());
		float delay = Random.Range(bminDelay, bmaxDelay);
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(fminDelay, fmaxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            int fruitIndex = Random.Range(0, fruitPrefabs.Length); 
            GameObject spawnedFruit = Instantiate(fruitPrefabs[fruitIndex], spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }

    IEnumerator SpawnBomb()
    {
        while (true)
        {

			
            float delay = Random.Range(bminDelay, bmaxDelay);
            yield return new WaitForSeconds(delay);
			
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];


            GameObject spawnedBomb = Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedBomb, 5f);
        }
    }
}
