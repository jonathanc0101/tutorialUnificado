using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftPrototype3 : MonoBehaviour
{
    private float speed = 15;
    private PlayerControllerPrototype3 playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerPrototype3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}