﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class HP : NetworkBehaviour
{
    [SyncVar]
    public int health;
    [SyncVar]
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    GameObject[] player;
    Player p;

    [SyncVar]
    public int playerSync;
    public bool hasFound = false;

    GameObject manager;

    Networker n;

    void Start()
    {
        manager = GameObject.FindWithTag("NetworkManager");
        n = manager.GetComponent<Networker>();
    }
    void Update()
    {
        if (!hasFound && n.isFound == false)
        {
            player = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject Player in player)
            {
                p = Player.GetComponent<Player>();
                if (p.type == playerSync)
                {
                    hasFound = true;
                    Debug.Log("bool got activated - " + hasFound);
                    Debug.Log("bool got true at player number - " + p.type);
                    //children = player.GetComponentInChildren<HeadDetect>();
                    //Debug.Log("the type of children - " + p.type);

                    numOfHearts = p.health;
                    //--------------------------------------------------------------------------------------------------
                    // p.h = gameObject;
                    // p.HP = p.h.GetComponent<HP>();
                    //--------------------------------------------------------------------------------------------------
                }
                //else return;
            }

        }
        // if (health > numOfHearts)
        // {
        //     health = numOfHearts;
        // }
        if (hasFound)
        {
            health = p.health;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
                //Debug.Log("lost live on player " + p.type);
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }


    }

}