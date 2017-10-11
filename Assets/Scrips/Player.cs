using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int speed = 5;
    private bool facingright = false;
    private float movementX;
    private int jumpPower = 1000;
    private int doubleJumpPower = 500;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask ground;
    private bool grounded;
    private bool doubleJump;

    public float pushBack;
    public float pushBackLength;
    public float pushBackCount;
    public bool pushFromRight;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
       
    }

    void Update()
    {

        if(pushBackCount <= 0)
        {
            Walk();
        }
        else
        {
            if (pushFromRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-pushBack, pushBack);
            }
            if (!pushFromRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(pushBack, pushBack);
            }
            pushBackCount -= Time.deltaTime;
        }

        //jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpPower));
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    doubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(0, jumpPower));
                }
            }
        }
    }

    void Walk()
    {
        movementX = Input.GetAxis("Horizontal");

        //flipping the player towards the direction they are walking
        if (movementX < 0.0f && facingright == false)
        {
            Flip();
        }
        else if (movementX > 0.0f && facingright == true)
        {
            Flip();
        }
        //walking
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ledges")
        {
            rb.gravityScale = 10.0F;
            jumpPower = 1500;
            doubleJumpPower = 1000;
        }
    }
    void Flip()
    {
        facingright = !facingright;
        Vector2 scale = gameObject.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
