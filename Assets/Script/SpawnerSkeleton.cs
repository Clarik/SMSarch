using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSkeleton : MonoBehaviour
{
    public float minX, maxX, minY, maxY;

    public float spawnTime;
    float startSpawnTime;

    public GameObject skeleton;

   

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector2 randomLocation = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(skeleton, randomLocation, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        if(startSpawnTime <= 0)
        {
            Vector2 randomLocation = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(skeleton, randomLocation, Quaternion.identity);
            startSpawnTime = spawnTime;
        }
        else
        {
            startSpawnTime -= Time.fixedDeltaTime;
        }
    }
}
