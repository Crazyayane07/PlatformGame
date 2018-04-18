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

    public AudioClip jump_crack;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public AnimatorOverrideController animatorOverrideController;
    public AnimationClip[] znimClip;

    public const int ILDE_CLIP = 0;
    public const int WALK_CLIP = 1;
    public const int JUMP_CLIP = 2;

    Transform firePoint;

    void Awake()
    {
        firePoint = transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //animator.runtimeAnimatorController = animatorOverrideController;
    }

    private void Update()
    {
        animator.SetBool("grounded", isGrounded);
        PlayerMove();

        if (Input.GetButton("Fire1"))
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
        if(collision.gameObject.tag == "Ground")
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
        //Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 targetPointPosition;
        if (facingLeft)
        {
            targetPointPosition = new Vector2(firePoint.position.x - 2f, firePoint.position.y);
        }
        else
        {
            targetPointPosition = new Vector2(firePoint.position.x + 2f, firePoint.position.y);
        }
        RaycastHit2D hit2D = Physics2D.Raycast(firePointPosition, targetPointPosition,2);
        Debug.DrawLine(firePointPosition, targetPointPosition, Color.cyan);
        if(hit2D.collider != null)
        {
            Debug.Log("hit2D.sth");
            Debug.DrawLine(firePointPosition, hit2D.point, Color.red);
           /* if (hit2D.collider.tag == "Enemy")
            {
                Destroy(hit2D.collider);
            }*/
        }
    }
}
