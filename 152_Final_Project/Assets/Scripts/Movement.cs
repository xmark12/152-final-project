using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool grounded;
    public bool jump;
    public bool duck;

    public Animator a;

    private Rigidbody2D rb;
    public float speed = 7;
    public float jumpForce = 13;
    public float moveInput;

    public Transform feetPos;
    public float checkRadius = 0.3;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime = 0.15;

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        jump = false;
        duck = false;

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (grounded && (Input.GetKeyDown("space") || Input.GetKeyDown("w")))
        {
            jump = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        } else if (Input.GetKeyDown("s"))
        {
            print("duck key was pressed");
        }

        if ((Input.GetKey("space") || Input.GetKey("w")) && jump)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                jump = false;
            }
        }

        if (Input.GetKeyUp("space") || Input.GetKeyUp("w"))
        {
            jump = false;
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
