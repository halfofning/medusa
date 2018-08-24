using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 5;
    public int playerJumpPower = 650;
    private float moveX;
    public bool grounded;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void CheckInAir()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.5)
        {
            grounded = false;
        }
    }

    void PlayerMove()
    {
        // CONTROLS
        moveX = Input.GetAxisRaw("Horizontal");
        CheckInAir();

        // Jump when player presses the space button, or up key (arrow keys).
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Jump();
            grounded = false;
        }

        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        // If player is grounded, allow Jump.
        if (grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check grounded
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}