using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public float Speed;
    public float JumpPower;

    public Rigidbody2D RB;
    public SpriteRenderer SR;

    private float _startJumpPower;
    private float _startSpeed;
    GameObject manager;
    Networker n;

    [SyncVar]
    public int type;

    [SyncVar]
    public int health = 3;

    // Denne bliver brugt til at gøre så man ikke kan uendeligt hoppe i luften
    private bool _isGrounded;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        _startJumpPower = JumpPower;
        _startSpeed = Speed;
        manager = GameObject.FindWithTag("NetworkManager");
        n = manager.GetComponent<Networker>();
    }

    //Update is called once per frame
    void Update()
    {
        // Dette styrer movement a og d på spilleren 
        if (!isLocalPlayer) return;
        // Her finder vi midten af playerens y og tager den nederste
        float DistanceToGround = GetComponent<Collider2D>().bounds.extents.y;

        // Her bruges Mask til at sørge for at raycast ikke rammer Player
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround + 0.05f, Mask);

        Vector2 movement = new Vector2(0, RB.velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -Speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = Speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
        }

        // != betyder ikke = 0 

        if (movement.x >= 0)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }

        RB.velocity = movement;

        if (health == health - 1)
        {
            Respawn();
        }

    }
    [ClientRpc]
    public void Respawn()
    {
        gameObject.transform.position = n.start.position;
    }
}