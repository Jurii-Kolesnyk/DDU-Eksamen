using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public bool isGrounded;
    public float jumpForce;
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
        float x = Input.GetAxis("Horizontal") * 0.001f;
        Vector2 move = new Vector2(x * speed, rb.velocity.y);
        //rb.velocity = move;
        rb.MovePosition(rb.position + move);
    }
}