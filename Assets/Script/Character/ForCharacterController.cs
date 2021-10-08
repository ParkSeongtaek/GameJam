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
    float time = 1.3f;          //Key
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
                  if(!timerStart)
                      timerStart = true;


                  if (timer > time)
                  {
                      jumpB = false;

                      move = transform.right;
                      if(transform.position.x < endPos.x)
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


 

    /*
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    */
    
}






/*
 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    

    //playermovement

    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    Vector3 velocity;
    bool isGrounded;
    float jumpHeight = 4f;
    public Vector3[,] StartLocation = new Vector3[7, 2]; //  [ RoomNum - 1 location, RoomNum - 1 rotation] 
    bool RE = false;

    private void Start()
    {
        StartLocation[0, 0] = new Vector3(20 , 21, 20);
        StartLocation[0, 1] = new Vector3(0, 180, 0);

        StartLocation[1, 0] = new Vector3(20, 21, 10);
        StartLocation[1, 1] = new Vector3(0, 180, 0);

        StartLocation[2, 0] = new Vector3(20, 21, 0);
        StartLocation[2, 1] = new Vector3(0, 180, 0);

        StartLocation[3, 0] = new Vector3(6, 21, -8);
        StartLocation[3, 1] = new Vector3(0, -90, 0);

        StartLocation[4, 0] = new Vector3(-4, 21, -8);
        StartLocation[4, 1] = new Vector3(0, -90, 0);

        StartLocation[5, 0] = new Vector3(-18, 21, -8);
        StartLocation[5, 1] = new Vector3(0, -90, 0);

        StartLocation[6, 0] = new Vector3(-26, 21, 5);
        StartLocation[6, 1] = new Vector3(0, 0, 0);

        
        transform.position = StartLocation[GameManager.Instance.RoomNum - 1, 0];
        transform.eulerAngles = StartLocation[GameManager.Instance.RoomNum - 1, 1];


    }

    private void Update()
    {
 

}

 */