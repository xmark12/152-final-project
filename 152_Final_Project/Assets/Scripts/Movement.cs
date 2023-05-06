using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool grounded;
    public bool jump;
    public bool duck;
    public bool isJumping;

    public Animator a;

    private Rigidbody2D rb;
    public float jumpForce = 10;

    public Transform feetPos;
    public float checkRadius = 0.3F;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime = 0.35F;

    public BoxCollider2D collider;
    public Vector2 regularSize;
    public Vector2 duckingSize;
    public Vector2 regularOffset;
    public float duckingOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        jump = false;
        duck = false;
        isJumping = false;

        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();

        regularSize = collider.size;
        duckingSize = collider.size;
        duckingSize.y = duckingSize.y / 2;

        regularOffset = collider.offset;
        duckingOffsetY = -duckingSize.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        jump = !grounded;

        if (grounded && (Input.GetKeyDown("space") || Input.GetKeyDown("w")))
        {
            isJumping = true;
            duck = false;
            collider.size = regularSize;
            collider.offset = regularOffset;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        } else if (grounded && Input.GetKeyDown("s"))
        {
            duck = true;
            collider.size = duckingSize;
            collider.offset = new Vector2(regularOffset.x, duckingOffsetY);
        }

        if ((Input.GetKey("space") || Input.GetKey("w")) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp("space") || Input.GetKeyUp("w"))
        {
            isJumping = false;
        } else if (Input.GetKeyUp("s"))
        {
            duck = false;
            collider.size = regularSize;
            collider.offset = regularOffset;
        }


        if (jump && !grounded && !duck)
        {
            a.Play("Jump");
        }
        else if (duck && grounded && !jump)
        {
            a.Play("Duck");
        }
        else
        {
            a.Play("Grounded");
        }
    }
}
