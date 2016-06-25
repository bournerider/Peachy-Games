using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]

public class Player : MonoBehaviour
    {
    
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float walkSpeed = 6;
    public float sprintSpeed = 10;
    
    Vector3 velocity;
    float moveSpeed;
    float gravity = -20;
    float jumpVelocity = 8;
    float velocityXSmoothing;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    int jumpCount = 0;

    int hashRightFace = Animator.StringToHash("RightFace");

    Controller2D controller;
    Animator myAnimator;
    
    void Start()
    {
        controller = GetComponent<Controller2D>();
        myAnimator = GetComponent<Animator>();
        gravity = -(2 * jumpHeight) / (Mathf.Pow(timeToJumpApex, 2));
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity " + gravity + " Jump Velocity: " + jumpVelocity);
    }
    
    void Update()
    {

    //Stops vertical movement upon collision
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

    //Resets jump counter
        if (controller.collisions.below)
        {
            jumpCount = 0;
        }
    
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        

    //Animation transition code
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myAnimator.SetBool(hashRightFace, true);
            Debug.Log(myAnimator.GetBool(hashRightFace));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myAnimator.SetBool(hashRightFace, false);
            Debug.Log(myAnimator.GetBool(hashRightFace));
        }

    //Jump code
        if (jumpCount > 1)
        {

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpVelocity;
            jumpCount = jumpCount + 1;
        }

    //Movespeed code
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

    //Player movement code
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    
    }
}            