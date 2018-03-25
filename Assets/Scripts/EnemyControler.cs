using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour {
    public float enemySpeed;
    public float xMoveDirection;

    void Update ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            FlipEnemy();
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
}
