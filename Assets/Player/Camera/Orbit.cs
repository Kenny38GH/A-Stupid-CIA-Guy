using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
 
     public float turnSpeed = 10.0f;
     public Transform target;
     public Transform cam;
     

    public float height = 1f;
     public float distance = 2f;
     private Vector3 offsetX;
    private Vector3 offsetY;

    void Start () {
 
         offsetX = new Vector3 (0, height, distance);
         offsetY = new Vector3 (0, 0, distance);
     }
  

    void LateUpdate()
     {
         offsetX = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed  , Vector3.up) * offsetY;
         // transform.RotateAround(target.transform.position, new Vector3(1, 0, 0), 1.0f);
         offsetY = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed  , new Vector3(1,0,0)) * offsetX;

         transform.position = target.position + offsetX + offsetY;
        transform.LookAt(target.position);
        // transform.RotateAround(target.transform.position, new Vector3(1, 0, 0), 1.0f);
        
        // Visée
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position = cam.position + new Vector3(0,0,2);
        }




    }
 }