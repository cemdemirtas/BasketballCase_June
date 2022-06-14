using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magiclab.InputHandler;
public class Movement : MonoBehaviour
{
    public static Movement instance;
    //Input Joystick
    private float horizontalMove;
    private float verticalMove;
    public float playerSpeed;
    private Rigidbody rb;

    private void Awake() //Singleton Pattern.
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (transform.position.y<-3f)
        {
            GameManager.Instance.gamestate = GameManager.GameState.GameOver; // Fall the ball, show game over panel.
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        if (BallController.instance.isBounce)
        {
            horizontalMove = InputHandler.GetHorizontal() * playerSpeed;
            verticalMove = InputHandler.GetVertical() * playerSpeed;
            rb.velocity = new Vector3(horizontalMove, rb.velocity.y, verticalMove);
        }
    }
}
