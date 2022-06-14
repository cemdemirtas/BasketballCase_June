using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    private float speed = 0.5f;
    private Vector3 pos1, pos2;
    void Start()
    {
        pos1 = new Vector3(-1.53f, transform.position.y, transform.position.z);
        pos2 = new Vector3(-11.56f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }

}
