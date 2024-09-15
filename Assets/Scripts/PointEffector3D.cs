using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PointEffector3D : MonoBehaviour
{
    //Stats
    public float radius = 5f; // Radius of the effector (the range)
    public float forceStrength = 10f;  // Strength of the force applied
    public bool applyAttraction = true; // Set to true for attraction, false for repulsion
    public List<int> layerMask = new List<int>(); // Layers affected by force
    private ForceMode forceMode = ForceMode.Force;
    public bool playerJump;
    private float initialForceStrength;

    //References
    private Controls controls;
    private InnieController innieController;

    private void Awake()
    {
        if (playerJump)
        {
            innieController = GameObject.Find("Innie").GetComponent<InnieController>();
            controls = new Controls();
            controls.Enable();
            initialForceStrength = forceStrength;
        }
    }

    void FixedUpdate()
    {
        OnJump();

        // Get all objects within the effector's radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in colliders)
        {
            // Check if the object has a Rigidbody
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null && layerMask.Contains(rb.gameObject.layer))
            {
                // Calculate the direction from the effector's center to the object
                Vector3 direction = collider.transform.position - transform.position;

                // Apply force towards or away from the center
                if (applyAttraction)
                {
                    // Apply attraction force towards the center
                    rb.AddForce(-direction.normalized * forceStrength, forceMode);

                    //Reset if jumping
                    if(forceMode == ForceMode.Impulse)
                    {
                        applyAttraction = false;
                        forceStrength = initialForceStrength;
                        forceMode = ForceMode.Force;
                    }
                }
                else
                {
                    // Apply repulsion force away from the center
                    rb.AddForce(direction.normalized * forceStrength, ForceMode.Force);
                }
            }
        }
    }

    private void OnJump()
    {
        if (innieController.grounded && controls.Player.InnieJump.IsPressed())
        {
            forceMode = ForceMode.Impulse;
            forceStrength = 3;
            applyAttraction = true;
        }
    }
}
