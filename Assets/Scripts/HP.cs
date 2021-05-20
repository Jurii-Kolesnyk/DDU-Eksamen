using System.Collections;
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
    Player p1;
    Player p2;

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

                if (p.type == 1)
                {
                    p1 = p;
                }
                if (p.type == 2)
                {
                    p2 = p;
                }
                if (p.type == playerSync)
                {
                    hasFound = true;
                    Debug.Log("bool got activated - " + hasFound);
                    Debug.Log("bool got true at player number - " + p.type);
                    p = Player.GetComponent<Player>();
                    numOfHearts = p.health;
                }

            }

        }
        if (hasFound && playerSync == p1.type)
        {
            health = p1.health;
        }
        else if (hasFound && playerSync == p2.type)
        {
            health = p2.health;
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