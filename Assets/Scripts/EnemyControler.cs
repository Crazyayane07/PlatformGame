using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour {
    private static float enemySpeed;
    public float xMoveDirection;

    public const float enemySpeed_1 = 0.8f;
    public const float enemySpeed_2 = 2.0f;
    public const float enemySpeed_3 = 4.0f;
    public const float enemyWait = 0f;

    public GameObject player;
    public float enemyJumpPower = 12.5f;
    public float distance;
    public AudioClip enemy_crack;
    public bool isGrounded;

    private void Start()
    {
        isGrounded = true;
        enemySpeed = enemySpeed_1;
        //player = GameObject.FindObjectOfType<PlayerControler>();
        distance = Vector3.Distance(transform.position, player.transform.position);
    }
    void Update ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 1f && isGrounded)
        {
            Jump();
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            FlipEnemy();
        }
        if (collision.gameObject.tag == "Player")
        {
            setSpeed();
        }
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void FlipEnemy()
    {
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        if (xMoveDirection > 0)
        {
            xMoveDirection = -1;
        }
        else
        {
            xMoveDirection = 1;
        }
    }
   
    public static void Wait()
    {
        enemySpeed = enemyWait;
    }

    public static void MoveAgain()
    {
        setSpeed();
    }

    public static void setSpeed()
    {
        if(PlayerHealth.health == 3)
        {
            enemySpeed = enemySpeed_1;
        }
        if (PlayerHealth.health == 2)
        {
            enemySpeed = enemySpeed_2;
        }
        else if (PlayerHealth.health == 1)
        {
            enemySpeed = enemySpeed_3;
        }
    }

    private void Jump()
    {
        AudioSource.PlayClipAtPoint(enemy_crack, transform.position);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * enemyJumpPower);
        isGrounded = false;
    }
}
