using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class jointManager : NetworkBehaviour
{
    //public GameObject player;
    //GameObject weapon;
    GameObject manager;
    networking m;
    void Start()
    {
        manager = GameObject.FindWithTag("NetworkManager");
        m = manager.GetComponent<networking>();
        //jointRed = GetComponent<FixedJoint2D>();
        //weapon = GameObject.FindWithTag("sp");
    }

    // Update is called once per frame
    void Update()
    {
        m.weapon.transform.position = m.livePlayer.transform.position;
    }
}
