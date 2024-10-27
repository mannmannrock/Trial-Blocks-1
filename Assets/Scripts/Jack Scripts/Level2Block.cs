using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Block : MonoBehaviour
{
    public GameObject cameraPoint;
    RotationBehavior rotationBehavior;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotationBehavior = cameraPoint.GetComponent<RotationBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = rb.velocity + rotationBehavior.gravity*.2f;
    }
}
