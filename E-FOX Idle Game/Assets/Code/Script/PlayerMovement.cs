using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public MouseLook MouseLookFile;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;

    public float x;
    public float z;

    public Transform groundCheck;

    public LayerMask groundMask;

    public float jumpHeight = 3f;

    bool isGrounded;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (MouseLookFile.isManette)
        {
            x = Input.GetAxis("HorizontalManetteRight");
            z = Input.GetAxis("VerticalManetteForward");
        }*/
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
