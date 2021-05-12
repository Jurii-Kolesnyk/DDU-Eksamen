using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player1 : NetworkBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    //[SyncVar]
    //public Number playercount;
    [SyncVar]
    public int playerId;
    public void Spawn(int input)
    {
        playerId = input;
        if (playerId == 0)
        {
            Instantiate(prefab1);
        }
        else if (playerId == 1)
        {
            Instantiate(prefab2);
        }
    }
}