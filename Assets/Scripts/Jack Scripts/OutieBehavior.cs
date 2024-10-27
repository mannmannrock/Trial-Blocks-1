using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutieBehavior : MonoBehaviour
{
    Vector2 joyInput;
    public GameObject level;
    RotationBehavior rotationBehavior;
    public float maxSpeed;
    public float accelerationRate;

    public void OnMove(InputAction.CallbackContext context)
    {
        joyInput = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {

        rotationBehavior = level.GetComponent<RotationBehavior>();
    }

    void FixedUpdate()
    {
        rotationBehavior.Rotate(joyInput);
    }
}
