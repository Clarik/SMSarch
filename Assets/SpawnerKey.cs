using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerKey : MonoBehaviour
{
    public GameObject goldKey;

    public float minX, maxX;
    public float minY, maxY;
    Vector2 pos;

    private void Start()
    {
        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(goldKey, pos, Quaternion.identity);
    }
}
