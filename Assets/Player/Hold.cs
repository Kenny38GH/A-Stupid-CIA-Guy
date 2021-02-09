using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    public Transform theDesttps;
    public Transform theDestfps;
    public Transform emplacement;
    public Transform emplacementtps;
    public string Prendre; 
    public Camera cam;
    public float rangegrab = 30f;
    bool fpsCam;
    bool tpsCam;
    public string inputfps;
    public string inputtps;
    public Hold target;
    public Weapon arme;
    public bool oui = false;

    void Start ()
    {
        tpsCam = true;
        fpsCam = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(inputfps))
        {
            fpsCam = true;
            tpsCam = false;
        }
        if(Input.GetKeyDown(inputtps))
        {
            fpsCam = false;
            tpsCam = true;
        }

        if(Input.GetKey(Prendre))
        {
            Grab();
        }
        if (!Input.GetKey(Prendre))
        {
            Leave();
        }
    }
    void Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, rangegrab))
        {
            if(arme == null)
            {
                arme = hit.transform.GetComponent<Weapon>();
            }
            if(target == null)
            {
                target = hit.transform.GetComponent<Hold>();
            }
            if(target != null && arme == null)
            {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = true;
            if(tpsCam == true)
            {
                target.transform.position = theDesttps.position;
                target.transform.parent = GameObject.Find("Destination_tps").transform;
            }
            if(fpsCam == true)
            {
                target.transform.position = theDestfps.position;
                target.transform.parent = GameObject.Find("Destination_fps").transform;
            }
            
            }
            
            if(arme != null)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().freezeRotation = true;
                oui = true;
                if(fpsCam == true)
                {
                    arme.transform.position = emplacement.position;
                    arme.transform.parent = GameObject.Find("Emplacement_arme").transform;
                }
                if(tpsCam == true)
                {
                    arme.transform.position = emplacementtps.position;
                    arme.transform.parent = GameObject.Find("Emplacement_armetps").transform;
                }
                
            }
        }
    }

    void Leave()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        arme = null;
        target = null;
        oui = false;
    }
}
