using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehavior : MonoBehaviour
{
    public GameObject mainShape;
    public GameObject cameraPoint;
    public Vector3 gravity = new Vector3(0, -1, 0);
    public void Rotate(Vector2 input)
    {
        transform.Rotate(new Vector3(input.y, -input.x, 0));
        /*Quaternion storedRotation = mainShape.transform.rotation;
        transform.rotation = Quaternion.identity;
        mainShape.transform.localRotation = storedRotation;*/
        gravity = -cameraPoint.transform.up;
        Debug.DrawLine(cameraPoint.transform.position, cameraPoint.transform.position - gravity*2);
    }

    private void LateUpdate()
    {
        
    }
}
