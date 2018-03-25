using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingLeft = false;
    public float playerJumpPower = 12.5f;
    private float moveX;
    public bool isGrounded = false;
    public float distanceToBottomOfPlayer = 0.9f;

    private void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            moveX = Input.GetAxis("Horizontal");
        }
        if((moveX < 0.0f && !facingLeft) || (moveX > 0.0f && facingLeft))
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void FlipPlayer()
    {
        facingLeft = !facingLeft;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box")
        {
            isGrounded = true;
        }
    }
}
