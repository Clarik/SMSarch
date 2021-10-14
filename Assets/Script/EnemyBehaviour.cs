using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    Transform player;

    float distance;
    public float minDistance;
    public float maxDistance;

    Vector2[] patrolPoint;
    int randomPoint;

    float movementSpeed;
    public float minMovementSpeed;
    public float maxMovementSpeed;

    Vector2 target;
    public float waitTime;
    float startWaitTime;

    GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    private void Start()
    {

        // Locate the player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // Random fov bot;
        distance = Random.Range(minDistance, maxDistance);

        // Make Random Point to Patrolling
        randomPoint = Random.Range(3, 10);
        patrolPoint = new Vector2[randomPoint];
        for (int i = 0; i < randomPoint; i++)
            patrolPoint[i] = new Vector2(transform.position.x + Random.Range(-5f,5f), transform.position.y + Random.Range(-5f,5f));
        target = patrolPoint[Random.Range(0, randomPoint)];
        
        // Random movement speed every mob
        movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
    }

    private void Update()
    {
        if (!gm.IsGamePause())
        {
            // Chasing Player
            if (Vector2.Distance(transform.position, player.position) <= distance)
                // Moving toward player
                transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
            // Patrolling
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, target) < 2f)
                {
                    if (startWaitTime <= 0)
                    {
                        target = patrolPoint[Random.Range(0, randomPoint)];
                        startWaitTime = waitTime;
                    }
                    else
                    {
                        startWaitTime -= Time.deltaTime;
                    }
                }
            }
        }
    }
}
