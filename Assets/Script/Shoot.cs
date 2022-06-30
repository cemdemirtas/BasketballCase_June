using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magiclab.InputHandler;
using DG.Tweening;
public class Shoot : MonoBehaviour
{
    public static Shoot instance;

    public float bounceUP = 100f;
    public Camera mainCam;
    public GameObject target;
    private Vector3 endPos;
    public GameObject basket;
    public float distance;
    private Rigidbody rb;
    float Lerp = 1.5f;

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
        basket = GameObject.FindWithTag("Basket");
        endPos = target.transform.position;
    }
    private void LateUpdate()
    {
        GetCam();
    }
    void CallSideCamera()
    {

        Cinemachine.instance.SideCamMethod();

    }
    void GetCam()
    {
        //when we shoot get the cinemachine cams.
        if (transform.position.y > 2.5f)
        {
            Invoke("CallSideCamera",0f);
            Cinemachine.instance.UpwardCamMethod();
        }
    }

    public void GetShoot()
    {
        if (InputHandler.SwipeDirection == SwipeDirection.Up && BallController.instance.isBounce) // While swap to up on the screen and bounce true, we try shoot
        {

            Cinemachine.instance.MainCamMethod();
            //Closest bug has fixed, throw back -2f and move to endPos.
            if (distance <= 3)
            {
                Debug.Log("we are too closer to basket");
                //transform.DOMoveZ(-2f,0.2f)
                transform.DOMoveZ(-5f, 0.3f)
                .OnComplete(() =>
            transform.DOMove(endPos + new Vector3(0, 0.5f, 0) * Lerp, 0.8f));
                BallController.instance.isBounce = false;
            }
            //If we too closer the basket get unique shoot
            if (distance <= 6.5f && distance > 3)
            {
                Debug.Log("we closer");
                //rb.AddForce((endPos - transform.position + new Vector3(0, 0.5f,0)) * 21f);
                transform.DOMove(endPos + new Vector3(0, 0.5f, 0) * Lerp, 0.8f);
                BallController.instance.isBounce = false;

                //StartCoroutine(UniqueShoot());
            }
            if (distance > 6.5f) //free throw
            {
                rb.AddForce((endPos - transform.position + new Vector3(0, 3.5f, 0)) * Random.Range(18.1f, 20.1f));
                BallController.instance.isBounce = false;
            }
        }

    }
    // We check to basket with 2 trigger(bottom and top)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FirstTrigger")
        {
            BasketController.instance.OnTriggerEnter(other);
            BasketController.instance.transform.GetComponent<BoxCollider>().isTrigger = true; // avoid 2 points on one shoot.
        }
    }
}





