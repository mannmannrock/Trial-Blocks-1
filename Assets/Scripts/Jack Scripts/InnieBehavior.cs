using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InnieBehavior : MonoBehaviour
{
    public GameObject cameraPoint;
    RotationBehavior rotationBehavior;
    Rigidbody rb;
    Vector2 joyInput;
    public float accelerationRate = 1;
    public float maxSpeed = 1;

    public void OnMove(InputAction.CallbackContext context)
    {
        joyInput = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotationBehavior = cameraPoint.GetComponent<RotationBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.MoveTowards(rb.velocity, new Vector3(joyInput.x, rb.velocity.y/maxSpeed, joyInput.y) * maxSpeed, accelerationRate * Time.fixedDeltaTime);
        rb.velocity = rb.velocity + rotationBehavior.gravity;
    }
}
