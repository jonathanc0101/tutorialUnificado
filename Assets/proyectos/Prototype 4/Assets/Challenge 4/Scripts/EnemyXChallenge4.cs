using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXChallenge4 : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectsWithTag("player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move 
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime, ForceMode.Force);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
