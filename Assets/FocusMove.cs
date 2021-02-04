using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMove : MonoBehaviour
{
    public Transform target;
    public float offsetX = 1f;
    public float offsetY = 1f;
    public float profondeur = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + new Vector3(offsetX, offsetY, profondeur);
    }
}
