using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public bool isInAction;
    public float rotationSpeed = 30;
    public void RotationManager()
    {
        while (isInAction == true){
            transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
        }
        transform.rotation = Quaternion.identity;
    }
}
