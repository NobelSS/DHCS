using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxcamera : MonoBehaviour
{
   public Transform targetCamera;
    
    
    public float lockedYPosition = 5.0f;


    void LateUpdate()
    {
        if (targetCamera != null)
        {
           
            Vector3 targetPosition = targetCamera.position;
            

            targetPosition.y = lockedYPosition;

           
            transform.position = targetPosition;

            transform.rotation = targetCamera.rotation;
        }
    }
}
