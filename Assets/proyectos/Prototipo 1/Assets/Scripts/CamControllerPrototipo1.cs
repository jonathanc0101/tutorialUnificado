using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerPrototipo1 : MonoBehaviour
{
    public GameObject player;
    public Vector3 vectorCamara = new Vector3(0, 5, -10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + vectorCamara;
    }
}
