using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableDogCounterChallenge2 : MonoBehaviour
{
    public GameObject[] counterPrefabs;

    public int availableItems = 0;
    private PlayerControllerXChallenge2 playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerXChallenge2>();
    }

    // Update is called once per frame
    void Update()
    {
        availableItems = playerController.tokens;
        for (int i = 0; i < availableItems && i < counterPrefabs.Length; i++)
        {
            if (i < availableItems)
            {
                counterPrefabs[i].SetActive(true);
            }
            else
            {
                counterPrefabs[i].SetActive(false);
            }

        }
    }
}
