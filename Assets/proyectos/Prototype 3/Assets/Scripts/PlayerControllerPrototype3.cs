using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerControllerPrototype3 : MonoBehaviour
{
    public float jumpForce = 1000;
    public float gravityModifier = 3;

    public bool isOnGround = true;

    public bool gameOver = false;

    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround && !gameOver)
        {
            dirtParticle.Play();
        }

        handleInput();
    }

    void handleInput()
    {

        // jump
        if (Input.GetKeyDown("space") && isOnGround && !gameOver)
        {
            jump();
        }

        //jump mobile
        if (Input.touchCount == 1)
        {
            // touch on screen
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                jump();
            }
        }

    }

    void jump()
    {
        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound, 1.0f);

        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        isOnGround = false;

        playerAnim.SetTrigger("Jump_trig");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            triggerDeathAnimation();
        }
    }

    void triggerDeathAnimation()
    {
        playerAudio.PlayOneShot(crashSound, 1.0f);
        explosionParticle.Play();
        dirtParticle.Stop();

        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
    }

}


