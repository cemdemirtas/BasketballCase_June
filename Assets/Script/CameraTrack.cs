using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Transform Player;
    //public float distanceFromObject = 3f;
    [SerializeField] Vector3 offset = new Vector3(0, 0, 0);
    private void LateUpdate()
    {
        Vector3 lookOnObject = Player.position - transform.position;
        lookOnObject = Player.position - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 playerLastPosition;
        playerLastPosition = Player.position - lookOnObject.normalized + offset/** distanceFromObject*/;
        playerLastPosition.y = 4.2f; //Player.position.y + distanceFromObject / 2
        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.position = playerLastPosition;
    }

}
