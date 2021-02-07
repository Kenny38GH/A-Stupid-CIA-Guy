using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollide : MonoBehaviour
{
public GameObject cam;
public GameObject collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool CollisionDetected(Vector3[] clipPoints, Vector3 fromPosition){
        for (int i = 0; i < clipPoints.Length; i++)
        {
            Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
            float distance = new Vector3.Distance(clipPoints[i], fromPosition);
            if (Physics.Raycast(ray, distance, collisionLayer))
            {
                return true;
            }
        }
        return false;
    }
}
