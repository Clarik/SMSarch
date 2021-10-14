using UnityEngine;

public class SpawnerEnvironment : MonoBehaviour
{
    public int totalEnvironment;

    public GameObject[] environment;

    public float minX, maxX;
    public float minY, maxY;
    Vector2 pos;
    private void Start()
    {
        for (int i = 0; i < totalEnvironment; i++)
        {
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(environment[Random.Range(0, environment.Length)], pos, Quaternion.identity);
        }
    }
}
