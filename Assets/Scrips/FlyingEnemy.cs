using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1.0f;
    public bool hitWater;
    public bool hitLedge;


    public bool facingRight = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
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
        if (collision.gameObject.tag == "flyStart")
        {
            Flip();
        }

        if (collision.gameObject.tag == "flyEnd")
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "playerJump")
        {
            Destroy(this.gameObject);
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