using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpForce = 20f;
    public float gravityForce = -9.8f;
    public int ClicksSpace = 0;

    private CharacterController controller;
    private float playerYVelocity;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded && playerYVelocity < 0)
        {
            playerYVelocity = 0f;
        }

        float x = Input.GetAxis("HorizontalArrows");

        float z = Input.GetAxis("VerticalArrows");

        Vector3 move = transform.right * x + transform.forward * z; // vector unitario right * x + vector unitario forward * z (sale la direccion de movimiento)


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {
            playerYVelocity += Mathf.Sqrt(Mathf.Abs(jumpForce * gravityForce));
            ClicksSpace++;
        }
        

        playerYVelocity += -9.8f * Time.deltaTime;
        move *= playerSpeed;
        move.y = playerYVelocity;
        controller.Move(move * Time.deltaTime);
    }
}