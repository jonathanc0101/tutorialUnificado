using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyOutOfBoundsPrototype2 : MonoBehaviour
{
    public float topBound = 10;

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.z) > topBound)
        {
            Destroy(gameObject);
        }
    }
}
