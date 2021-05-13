using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class HP : NetworkBehaviour
{
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    GameObject player;
    Player p;
    HeadDetect children;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        children = player.GetComponentInChildren<HeadDetect>();
        Debug.Log("the type of children - " + children.ourp.type);
        Debug.Log("the type of collNum - " + children.collNum);
        //p = player.GetComponent<Player>();
        numOfHearts = children.ourp.health;
    }
    void Update()
    {
        health = children.ourp.health;

        if (health > numOfHearts)
        {
            health = numOfHearts;
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