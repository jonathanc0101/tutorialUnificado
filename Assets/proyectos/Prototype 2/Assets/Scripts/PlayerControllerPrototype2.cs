using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPrototype2 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 10;
    public float fireSpeed = 0.05f;

    public GameObject projectilePrefab;

    private bool isRunning = false;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // semiAutomatico();

        ametralladora();
    }

    void semiAutomatico()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isRunning == false)
        {
            // launch sandwich
            isRunning = true;
            StartCoroutine(Fire());
        }
    }
    void ametralladora()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > this.fireSpeed)
        {
            dispararSandwich();
        }
    }

    public IEnumerator Fire()
    {
        for (int x = 0; x <= 5; x++)
        {
            dispararSandwich();
            yield return new WaitForSeconds(0.005f);
        }
        isRunning = false;
    }

    void dispararSandwich()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
