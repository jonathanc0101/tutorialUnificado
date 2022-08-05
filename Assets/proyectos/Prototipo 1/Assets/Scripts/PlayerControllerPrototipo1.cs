using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerControllerPrototipo1 : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        // pasa una vez
    }

    // Update is called once per frame
    void Update()
    {
        // pasa cada frame
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // por convencion es 1 es un metro en el mundo de los videojuegos, asi que nos movemos a 20 metros por segundo
        transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed * verticalInput);
    }
}
