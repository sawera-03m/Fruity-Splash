using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // FIX: ab ek array hai taake Apple/Banana/Orange/Strawberry/WaterMelon sab random spawn ho sakein
    public GameObject[] fruitPrefabs;
    public Transform[] spawnPoints;
    public float minDelay = 0.1f;
    public float maxDelay = 1f;

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            // FIX: delay variable ab actually use ho raha hai (pehle hamesha 1f tha)
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // FIX: fruitPrefabs array me se random fruit choose karta hai
            int fruitIndex = Random.Range(0, fruitPrefabs.Length);
            GameObject spawnedFruit = Instantiate(fruitPrefabs[fruitIndex], spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }
}
