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

    //Start is called before the first frame update
    void Start()
    {

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

        Vector2 movement = new Vector2(0, RB.velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -Speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = Speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
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