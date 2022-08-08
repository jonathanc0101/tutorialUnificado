using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public int scoreValue = 0;

    private float xRange = 4;
    private float yPos = -6;
    private float maxTorque = 6;
    private float minForce = 19;
    private float maxForce = 22;
    private Rigidbody targetRb;
    public ParticleSystem explosionParticle;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(randomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), ForceMode.Impulse);

        transform.position = newSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 newSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPos);
    }
    Vector3 randomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
    }
    Vector3 randomForce()
    {
        return (Vector3.up * Random.Range(minForce, maxForce));
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.updateScore(scoreValue);
        Instantiate(this.explosionParticle, transform.position, transform.rotation);

        if (gameObject.CompareTag("bad"))
        {
            gameManager.gameOver();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("bad"))
        {
            gameManager.gameOver();
        }
    }

}
