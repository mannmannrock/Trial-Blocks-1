using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutieController : MonoBehaviour
{
    //References
    private Controls controls;
    [HideInInspector] public Rigidbody rb;

    //State Info
    private float hRotation;
    private float vRotation;
    public float rotationSpeed;

    private void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.OutieRotationH.performed += OnHRotation;
        controls.Player.OutieRotationH.canceled += OnHRotation;
        controls.Player.OutieRotationV.performed += OnVRotation;
        controls.Player.OutieRotationV.canceled += OnVRotation;
    }

    private void OnDisable()
    {
        controls.Player.OutieRotationH.performed -= OnHRotation;
        controls.Player.OutieRotationH.canceled -= OnHRotation;
        controls.Player.OutieRotationV.performed -= OnVRotation;
        controls.Player.OutieRotationV.canceled -= OnVRotation;
        controls.Disable();
    }

    private void OnHRotation(InputAction.CallbackContext context)
    {
        hRotation = context.ReadValue<float>();
    }

    private void OnVRotation(InputAction.CallbackContext context)
    {
        vRotation = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        rb.AddTorque(new Vector3(vRotation * rotationSpeed, hRotation * rotationSpeed));
    }
}
