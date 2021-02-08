using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyControl : MonoBehaviour
{
    // Animations du perso
    Animation animations;

    // Vitesse de deplacement
    public float walkSpeed;
    public float turnSpeed;
    public float runSpeed;
    public float petitspas;
    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string inputRotRight;
    public string inputRotLeft;
    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;
    public GameObject cam;

    // Start is called before the first frame updatee
    //Add commentifezifbzif
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }
    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 1.2f);
    }
    // Update is called once per frame
    void Update()
    {
        // si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            animations.Play("walk");
            float yRotation = cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0,yRotation,0);
        }

        if (!Input.GetKey(inputFront) & !Input.GetKey(inputBack) & !Input.GetKey(inputLeft) & !Input.GetKey(inputRight)) 
        {
            animations.Stop("walk");
        }
        // Si on sprint
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animations.Play("walk");
            float yRotation = cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0,yRotation,0);
        }
        // si on recule
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
            animations.Play("walk");
        }
        // rotation a gauche
        if (Input.GetKey(inputLeft))
        {
            transform.Translate(-petitspas,0,0);
            animations.Play("walk");
        }

        // rotation a  droite
        if (Input.GetKey(inputRight))
        {
            transform.Translate(petitspas,0,0);
            animations.Play("walk");
        }
        // Si on saute
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Preparation du saut
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            // Saut
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
            animations.Play("jump");
        }
        
        
    }
}