using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.0f;
    public float jumpHeight = 3;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        
        if (isGrounded && velocity.y<0)
        {
            velocity.y = -2f;

        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);  
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right* x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);

        
    }
}
