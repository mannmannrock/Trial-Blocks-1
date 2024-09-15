using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InnieController : MonoBehaviour
{
    //State Info
    public bool grounded;
    public float lookRotationSpeed = 5.0f; // Speed of rotation
    public float moveSpeed = 5;
    private float hMovement;
    private float vMovement;

    //References
    private Controls controls;
    private Transform lookTarget; // The object to look at
    private Rigidbody rb;

    void Update()
    {
        // Calculate the direction to the target
        Vector3 direction = lookTarget.position - transform.position;

        // Create a rotation that points in the direction of the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly interpolate between the current rotation and the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookRotationSpeed * Time.deltaTime);

        rb.AddRelativeForce(new Vector3(hMovement * moveSpeed, 0, vMovement * moveSpeed));
    }

    private void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody>();
        //lookTarget = GameObject.Find("Cube").transform;
        lookTarget = Camera.main.transform;
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.InnieMovementH.performed += OnHMove;
        controls.Player.InnieMovementH.canceled += OnHMove;
        controls.Player.InnieMovementV.performed += OnVMove;
        controls.Player.InnieMovementV.canceled += OnVMove;
    }

    private void OnDisable()
    {
        controls.Player.InnieMovementH.performed -= OnHMove;
        controls.Player.InnieMovementH.canceled -= OnHMove;
        controls.Player.InnieMovementV.performed -= OnVMove;
        controls.Player.InnieMovementV.canceled -= OnVMove;
        controls.Disable();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = false;
    }

    private void OnVMove(InputAction.CallbackContext context)
    {
        vMovement = context.ReadValue<float>();
    }

    private void OnHMove(InputAction.CallbackContext context)
    {
        hMovement = context.ReadValue<float>();
    }
}
