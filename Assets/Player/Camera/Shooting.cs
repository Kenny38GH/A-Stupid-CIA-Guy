using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public GameObject impactEffect;
    private int munitions;
    public int chargeur;
    public float impactForce = 60f;
    public Text amoText;
    public string Recharger;
    public float rangeramasser = 20f;
    public Transform Player;
    public float X;
    public float Y;
    public float Z;
    public Hold hold;

    void Start()
    {
        munitions = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && munitions != 0 && hold.oui == true)
        {
            Shoot();
            munitions -=1;
        }
        if(Input.GetKeyDown(Recharger) && hold.oui == true)
        {
            munitions = chargeur;
        }
        SetMun(munitions);
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,2f);
        }
    }
    void SetMun(int amount)
    {
        amoText.text = amount.ToString();
        if (amount == 0)
        {
            amoText.text = "Reload [R]";
        }
    }
}
