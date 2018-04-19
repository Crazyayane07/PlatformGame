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
    public bool shooted = false;

    public AudioClip jump_crack;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public const int ILDE_CLIP = 0;
    public const int WALK_CLIP = 1;
    public const int JUMP_CLIP = 2;

    GameObject player;
    public GameObject ball;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        animator.SetBool("grounded", isGrounded);
        PlayerMove();

        if (Input.GetButton("Fire1") && !shooted)
        {
            Shoot();
        }
    }
    

    public void PlayerMove()
    {

        
        
        moveX = Input.GetAxis("Horizontal");
        animator.SetFloat("vspeed", Mathf.Abs(moveX));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            moveX = Input.GetAxis("Horizontal");
        }
        if((moveX < 0.0f && !facingLeft) || (moveX > 0.0f && facingLeft))
        {
            FlipPlayer();
           
        }
        //gameObject.GetComponent<AudioSource>().Stop();
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
        
        AudioSource.PlayClipAtPoint(jump_crack, transform.position);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box")
        {
            isGrounded = true;
            EnemyControler.MoveAgain();
        }
        if (collision.gameObject.tag == "Box")
        {
            if(PlayerHealth.health == 3)
            {
                EnemyControler.Wait();
            }
        }
    }

    private void Shoot()
    {
        float x;
        float x_force;
        float y_force = 2f;
        if (facingLeft)
        {
            x = player.transform.position.x - 0.3f;
            x_force = -25f;
        }
        else
        {
            x = player.transform.position.x + 0.3f;
            x_force = 25f;
        }
        
        float y = player.transform.position.y;
        Vector3 position = new Vector3(x, y, gameObject.transform.position.z);
        Instantiate(ball, position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(x_force,y_force));
        shooted = true;
        StartCoroutine(Wait4Shoot());
    }

    IEnumerator Wait4Shoot()
    {
        yield return new WaitForSeconds(1f);
        shooted = false;
    }
}
