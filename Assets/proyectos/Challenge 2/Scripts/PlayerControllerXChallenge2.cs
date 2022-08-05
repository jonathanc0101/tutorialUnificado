using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerXChallenge2 : MonoBehaviour
{
    public GameObject dogPrefab;
    private int tokenInterval = 5;
    private int tokensPerInterval = 4;
    public int tokens;



    public GameObject[] counterPrefabs;



    // Update is called once per frame

    void Start()
    {
        InvokeRepeating("refillTokens", 0, tokenInterval);
        tokens = tokensPerInterval;
    }
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tryToShoot();
        }
    }

    void refillTokens()
    {
        tokens = tokensPerInterval;

        foreach (GameObject ball in counterPrefabs)
        {
            ball.SetActive(true);
        }
    }
    void tryToShoot()
    {
        if (tokens > 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            tokens--;

            counterPrefabs[tokens].SetActive(false);
        }
    }
}
