using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 2.5f;
    public bool hitWater;
    public bool hitLedge;

    public bool facingRight = false;
    private float movementX;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.x < 0.0f)
        {
            facingRight = true;
        }
        else if (rb.velocity.x > 0.0f)
        {
            facingRight = false;
        }

        if (facingRight == false)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        if (facingRight == true)
        {
            rb.velocity = -new Vector3(speed, 0, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            Flip();
        }

        if (collision.gameObject.tag == "ledge")
        {
            Flip();
        }

        if (collision.gameObject.tag == "ledge2")
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        var playerHealth = collision.GetComponent<PlayerHealth>();
        var enemySpawner = collision.GetComponent<EnemySpawner>();

        if (collision.tag == "playerJump")
        {
            Destroy(this.gameObject);
            enemySpawner.enemiesKilled++;
        }
   
        player.pushBackCount = player.pushBackLength;
        playerHealth.health--;

        if (collision.transform.position.x < transform.position.x)
        {
            player.pushFromRight = true;
        }
         else
        {
            player.pushFromRight = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scale = gameObject.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
