using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardPrototype3 : MonoBehaviour
{
    private float speed;

    public float minSpeed = 1f;
    public float maxSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
