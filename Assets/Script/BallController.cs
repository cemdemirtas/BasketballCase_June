using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magiclab.InputHandler;
public class BallController : MonoBehaviour
{
    public static BallController instance;
    private Rigidbody rb;
    public bool isBounce = true;
    public GameObject BounceEffect;




    private void Awake() //Singleton Pattern.
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Shoot.instance.distance = Mathf.Abs(transform.position.z - Shoot.instance.basket.transform.position.z); // Distance between ball and basket.
    }

    void FixedUpdate()
    {
        Movement.instance.Move();
        Shoot.instance.GetShoot();
        if (rb.velocity.magnitude == 0) //While ball be hanging on the basket, throw right.
        {
            rb.AddForce(Vector3.right * 20);
        }
    }







    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") // Each collision with ground, bounces the ball
        {
            GameObject dustClone = Instantiate(BounceEffect, transform.position + new Vector3(0, -0.2f, 0), transform.rotation);
            Destroy(dustClone, 1f);
            isBounce = true;
            rb.AddForce(Vector3.up * Shoot.instance.bounceUP);
        }
    }




}
