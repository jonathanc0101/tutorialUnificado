using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerXChallenge3 : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce;
    private float forwardForce = 3;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 2, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        handleInput();

        // keep going forward
        if (!gameOver)
        {
            playerRb.AddForce(Vector3.forward * forwardForce, ForceMode.Impulse);
        }

        // prevent player from going too high
        if (transform.position.y > 13)
        {
            Vector3 pos = transform.position;
            pos.y = 13;
            transform.position = pos;
        }
    }

    void handleInput()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown("space") && !gameOver && transform.position.y < 13)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        if (Input.touchCount > 0)
        {

            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");

            Destroy(other.gameObject);

            Invoke("makeInvis", 1f);

        }


        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        // if player collides with ground make it bounce
        if (other.gameObject.CompareTag("Ground"))
        {
            playerAudio.PlayOneShot(bounceSound, 1.0f);
            // playerRb.AddForce(Vector3.up * 7 * floatForce, ForceMode.Impulse);
        }

    }

    void makeInvis()
    {
        gameObject.SetActive(false);
    }

}
