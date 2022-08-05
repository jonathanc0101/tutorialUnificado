using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerPrototype2 : MonoBehaviour
{
    public int animalIndex = 1;
    public float xOffset = 15;
    public GameObject[] animalPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        this.InvokeRepeating("spawnRandomRandomAnimal", 1.0f, 0.1f);
    }

    void spawnRandomRandomAnimal()
    {
        float randomTime = Random.Range(0, 1);

        this.Invoke("spawnRandomAnimal", randomTime);
    }
    void spawnRandomAnimal()
    {
        //create position
        Vector3 positionVector = new Vector3(Random.Range(-xOffset, xOffset), 0.0f, 0.0f) + transform.position;

        animalIndex = Random.Range(0, animalPrefabs.Length);
        // Spawn animal
        Instantiate(animalPrefabs[animalIndex], positionVector, animalPrefabs[animalIndex].transform.rotation);
    }
}
