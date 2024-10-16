using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehavior : MonoBehaviour
{
    public GameObject mainShape;
    public void Rotate(Vector2 input)
    {
        transform.Rotate(new Vector3(input.y, -input.x, 0));
        Quaternion storedRotation = mainShape.transform.rotation;
        transform.rotation = Quaternion.identity;
        mainShape.transform.localRotation = storedRotation;
    }

    private void LateUpdate()
    {
        
    }
}
