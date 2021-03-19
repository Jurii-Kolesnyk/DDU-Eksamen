using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public float Speed;
    public float JumpPower;

    public Rigidbody2D RB;

    // Dette bruges til at lave en layer mask så vores raycast ikke dector Player
    public LayerMask Mask;

    public Animator PlayerAnimator;
    public SpriteRenderer SR;

    private float _startJumpPower;
    private float _startSpeed;
    // Denne bliver brugt til at gøre så man ikke kan uendeligt hoppe i luften
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _startJumpPower = JumpPower;
        _startSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Dette styrer movement a og d på spilleren 
        Vector2 movement = new Vector2(0, RB.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -Speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = Speed;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RB.AddForce(new Vector2(0, JumpPower));
        }

        if (movement.x >= 0)
        {
            SR.flipX = false;
        }
        else
        {
            SR.flipX = true;
        }

        RB.velocity = movement;
    }
}