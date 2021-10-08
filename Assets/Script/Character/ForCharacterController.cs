using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ForCharacterController : MonoBehaviour
{
    Vector3 moveVector;
    Vector3 move;
    Vector3 startPos = new Vector3();
    Vector3 endPos;
    Vector3 velocity;

    //public float gravity = -9.8f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public bool isGrounded = true;
    public float jumpHeight = 20f; // JH: 4f->.7f

    public float yVelocity = 0;
    public float gravity = -20;
    public float jumpPower = 5f;
    public bool ReadyJump = false;


    float speed = 4.0f;
    public CharacterController controller;
    bool timerStart = false;
    bool returnPos = false;
    float timer = 0f;
    float time = 0.5f;          //Key
    bool jumpB = false;
    float jumpF = 20f;
    //Assign out controller
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPos = transform.position;
        endPos = transform.position + new Vector3(10, 0, 0);
    }


    private void OnCollisionEnter(Collision collision)
    {
        ReadyJump = true;
    }
    void Update()
    {

        if (timerStart)
        {
            timer += Time.deltaTime;
        }

        if (returnPos)
        {


            move = transform.right;
            controller.Move(-move * speed * Time.deltaTime);

            if (startPos.x > transform.position.x)
            {
                Debug.Log(startPos.x + "   " + transform.position.x);
                returnPos = false;
            }
        }







        //REeset the MoveVector
        moveVector = Vector3.zero;

        //Check if cjharacter is grounded
        if (controller.isGrounded == false)
        {
            //Add our gravity Vecotr
            moveVector += Physics.gravity;
        }

        //Apply our move Vector , remeber to multiply by Time.delta
        controller.Move(moveVector * Time.deltaTime);



        if (GameManager.Instance.inGame)
        {
            if (Input.GetMouseButton(0))
            {
                returnPos = false;
                if (!timerStart)
                    timerStart = true;


                if (timer > time)
                {
                    jumpB = false;

                    move = transform.right;
                    if (transform.position.x < endPos.x)
                        controller.Move(move * speed * Time.deltaTime);


                }
            }
            if (Input.GetMouseButtonUp(0))
            {

                if (timer < time)
                {
                    jumpB = true;
                }
                timerStart = false;
                timer = 0f;
                returnPos = true;

            }
        }
        if (jumpB)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpB = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }

}