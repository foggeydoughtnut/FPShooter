using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float accelerationIncrease = 0.1f;
    public float acceleration = 1f;
    public float maxAcceleration = 1.6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float defaultAcceleration;

    private void Start()
    {
        defaultAcceleration = acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move != Vector3.zero)
        {
            if (acceleration <= maxAcceleration)
            {
                acceleration += accelerationIncrease;
            } else
            {
                acceleration = maxAcceleration;
            }
        } else
        {
            acceleration = defaultAcceleration;
        }

        controller.Move(move * speed * acceleration * Time.deltaTime);
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);



        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }
    }
}
