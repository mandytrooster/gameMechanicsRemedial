using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int speed = 5;
    private bool facingright = false;
    private float movementX;
    private int jumpPower = 2000;
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
        if(grounded == true)
        {
            doubleJump = false;
        }

        if (grounded == true && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpPower);
        }

        if (Input.GetButtonDown("Jump") && !doubleJump && !grounded)
        {
            rb.AddForce(Vector2.up * doubleJumpPower);
            doubleJump = true;
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

    void Flip()
    {
        facingright = !facingright;
        Vector2 scale = gameObject.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
