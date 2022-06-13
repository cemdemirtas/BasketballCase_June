using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChase : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset = new Vector3(0, 1.7f, -5f);
    private GameObject basket;

    public bool cam3;

    private float someValue;
    float multiplier = 10;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        basket = GameObject.FindWithTag("Basket");
    }

    void LateUpdate()
    {

        Vector3 moveVector3 = player.transform.position + new Vector3(0, 1f, -5);
        moveVector3.y = 3f;

        Vector3 distance = player.transform.position - basket.transform.position;
        distance.y = 0;

        float distanceX = player.transform.position.x - basket.transform.position.x;
        float distanceZ = player.transform.position.z - basket.transform.position.z;



        if (-distanceZ > 8)
        {
            multiplier = Mathf.Lerp(multiplier, 4, 1f * Time.deltaTime);
        }
        else
        {
            multiplier = Mathf.Lerp(multiplier, 10, 1f * Time.deltaTime);
        }

        if (-distanceZ < 5)
        {
            multiplier = Mathf.Lerp(multiplier, 15, 1f * Time.deltaTime);
        }
        else
        {
            multiplier = Mathf.Lerp(multiplier, 10, 1f * Time.deltaTime);
        }

        Camera.main.transform.rotation = Quaternion.Euler(8f, -distanceX * multiplier, 0);

        moveVector3.x += Mathf.Lerp(moveVector3.x, distanceX * .5f + .1f / (distanceZ * .5f), .3f);


        if (!player.GetComponent<BallController>().isBounce)
        {
            moveVector3.y = player.transform.position.y;
        }

        Camera.main.transform.position = moveVector3 + distance.normalized;

    }
}
