using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 30;
    private float jumpForce = 8;
    private Rigidbody playerRB;

    private Vector3 playerPos;
    private float distToGround;
    private Camera cam;

    public GameObject mobsPrefab;

    private float cameraHeight;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;

        playerPos = transform.position;
        cam = Camera.main;

        cameraHeight = Camera.main.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        handleInputDesktop();
        handleInput();
    }

    void handleInputDesktop()
    {
        if (Input.GetMouseButton(0) && isGrounded())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("TransparentFX")))
            {
                transform.LookAt(hit.point);
                playerRB.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Force);
            }
        }

        if (Input.GetMouseButton(1) && this.name == "MainPlayer")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("TransparentFX")))
            {

                Instantiate(mobsPrefab, (hit.point - transform.position) /2, new Quaternion());
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void handleInput()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }


        foreach (Touch touch in Input.touches)
        {
            if (touch.tapCount == 2 && isGrounded())
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("TransparentFX")))
                {
                    transform.LookAt(hit.point);
                    playerRB.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Force);
                }
            }
        }
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1));
    }
}
