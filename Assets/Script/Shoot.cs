using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magiclab.InputHandler;
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

    public void GetShoot()
    {
        if (InputHandler.SwipeDirection == SwipeDirection.Up && BallController.instance.isBounce) // While swap to up on the screen and bounce true, we try shoot
        {
            if (distance <= 4.5f) //If we too closer the basket get unique shoot
            {

                BallController.instance.isBounce = false;
                StartCoroutine(UniqueShoot());
            }
            if (distance > 4.5f) //free throw
            {
                rb.AddForce((endPos - transform.position + new Vector3(0, 2.5f, 0)) * Random.Range(18.1f, 20.1f));
                BallController.instance.isBounce = false;
            }
        }
    }

    public IEnumerator UniqueShoot()
    {
        Transform t = gameObject.transform;
        float counter = 0f;
        while (counter < .75f) 
        {
            t.position = Vector3.Lerp(t.position, endPos, counter);
            counter += Time.deltaTime * 2f;
            yield return 0;
        }
        yield break;
    }
}
