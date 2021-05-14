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
    public LayerMask Mask;
    private float _startJumpPower;
    private float _startSpeed;
    //--------------------------------------------------------------------------------------------------
    public GameObject h;
    public HP HP;
    //--------------------------------------------------------------------------------------------------
    GameObject manager;
    Networker n;
    HeadDetect child;

    // [SyncVar]
    // public bool healthLoss = false;

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
        child = gameObject.GetComponentInChildren<HeadDetect>().GetComponent<HeadDetect>();
        manager = GameObject.FindWithTag("NetworkManager");
        n = manager.GetComponent<Networker>();
    }

    //Update is called once per frame
    void Update()
    {

        // Dette styrer movement a og d på spilleren 
        if (isLocalPlayer && n.indZero == true)
        {
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

            if (child.collEnt == true)
            {
                child.ourp.respawnEngaged();
            }
        }
    }

    [Command]
    public void respawnEngaged()
    {
        Respawn();
        // child.collEnt = true;
    }
    [ClientRpc]
    public void Respawn()
    {

        //Debug.Log("death - " + child.ourp.type + " - with - " + child.ourp.health);
        // child.healthLoss = true;
        Debug.Log("status on player - " + child.ourp.type + " - of boolean - " + child.healthLoss);
        if (child.healthLoss == true)
        {
            child.healthLoss = false;
            Debug.Log("Lost health detected on player" + child.ourp.type);
            Debug.Log("Has Respawned!");

            if (child.ourp.type == 1)
            {
                child.ourp.transform.position = n.leftRacketSpawn.position;
                child.ourp.health -= 1;
                child.collEnt = false;
            }
            else
            {
                child.ourp.transform.position = n.rightRacketSpawn.position;
                child.ourp.health -= 1;
                child.collEnt = false;
            }
            Debug.Log("Player number - " + child.ourp.type + " - is the gameObject");
        }
    }

}