using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magiclab.InputHandler;
public class BallController : MonoBehaviour
{ 
        private Rigidbody rb;
        public bool isBounce = true;
        public GameObject dust;
        //---Shoot---
        public float bounce = 175f;
        public Camera mainCam;
        public GameObject target;
        public GameObject target2;
        private Vector3 endPos;
        private GameObject basket;
        private float distance;
        //---Move----
        public float MoveSpeed = 0.1f;
        //---Joystick---
        private float horizontalMove;
        private float verticalMove;
        public float playerSpeed;


        void Start()
        {
            rb = GetComponent<Rigidbody>();
            basket = GameObject.FindWithTag("Basket");
            endPos = target.transform.position;
        }

        void Update()
        {
            distance = Mathf.Abs(transform.position.z - basket.transform.position.z);
        }

        void FixedUpdate()
        {
            Move();
            Shoot();
            if (rb.velocity.magnitude == 0) //Avoid to ball stucking
            {
                rb.AddForce(Vector3.right * 20);
            }
        }

        void Shoot()
        {
            if (InputHandler.SwipeDirection == SwipeDirection.Up && isBounce) //Input.GetKeyDown(KeyCode.Space)
            {
                if (distance <= 9.5f) //Successfull shot
                {

                    isBounce = false;
                    StartCoroutine(PerfectShoot());
                    //rb.DOMove(target.transform.position, 1f);
                    //rb.MovePosition(Vector3.Lerp(gameObject.transform.position, endPos, 2f));
                }
                if (distance > 9.5f) //free throw
                {
                    rb.AddForce((endPos - transform.position + new Vector3(0, 2.5f, 0)) * Random.Range(18.1f, 20.1f));
                    isBounce = false;
                }
            }
        }

        void Move()
        {
            if (isBounce)
            {
                horizontalMove = InputHandler.GetHorizontal() * playerSpeed;
                verticalMove = InputHandler.GetVertical() * playerSpeed;
                rb.velocity = new Vector3(horizontalMove, rb.velocity.y, verticalMove);
                //Debug.Log(InputHandler.SwipeDirection);

                //rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
            }
        }

        public IEnumerator PerfectShoot() //Successful shoot
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground") //Bounce
            {
                GameObject dustClone = Instantiate(dust, transform.position + new Vector3(0, -0.2f, 0), transform.rotation);
                Destroy(dustClone, 1f);
                isBounce = true;
                rb.AddForce(Vector3.up * bounce);
            }
        }


    

}
