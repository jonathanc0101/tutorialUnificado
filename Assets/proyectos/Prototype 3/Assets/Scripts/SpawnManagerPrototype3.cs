using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerPrototype3 : MonoBehaviour
{
    public int ObstacleIndex;
    public GameObject[] ObstaclePrefabs;
    private PlayerControllerPrototype3 playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        this.InvokeRepeating("spawnRandomRandomObstacle", 1.0f, 5.0f);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerPrototype3>();
    }

    void spawnRandomRandomObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {


            float randomTime = Random.Range(0, 5);

            this.Invoke("spawnRandomObstacle", randomTime);
        }
    }
    void spawnRandomObstacle()
    {

        ObstacleIndex = Random.Range(0, ObstaclePrefabs.Length);
        // Spawn Obstacle
        Instantiate(ObstaclePrefabs[ObstacleIndex], transform.position, ObstaclePrefabs[ObstacleIndex].transform.rotation);
    }
}
