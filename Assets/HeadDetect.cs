
using UnityEngine;
using Mirror;

public class HeadDetect : NetworkBehaviour
{
    GameObject manager;
    Networker n;
    // GameObject player;
    // Player p;
    GameObject parent;
    public Player ourp;
    bool collEnt = false;
    //public bool healthLoss = false;


    [SyncVar]
    public int collNum;

    void Start()
    {
        manager = GameObject.FindWithTag("NetworkManager");
        n = manager.GetComponent<Networker>();
        parent = transform.parent.gameObject;
        ourp = parent.GetComponent<Player>();
        Debug.Log("ourp type - " + ourp.type);

        collNum = ourp.type;
    }
    // void Update()
    // {
    //     if (healthLoss == true)
    //     {
    //         healthLoss = false;
    //         Debug.Log("Lost health detected on player" + ourp.type);
    //         ourp.respawnEngaged();
    //     }
    // }

    [Client]
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collNum == ourp.type && collEnt == false)
        {
            /*Debug.Log(p.type + " - the killer");
            Debug.Log(collNum + " - the killed");*/
            collEnt = true;
            Debug.Log("Collision detected on player " + ourp.type);

            ourp.health -= 1;
            ourp.healthLoss = true;
            Debug.Log("status on player - " + ourp.type + " - of boolean - " + ourp.healthLoss);
        }
    }
    //skal til for at man kun rammer 1 gang når man rammer hovedet, så man ikke detecter hver gang
    //der kollideres, så man ikke kan fjerne fx 2 liv på 1 hop
    [Client]
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collNum == ourp.type && collEnt == true)
        {
            collEnt = false;
        }
    }

    // [Command]
    // public void respawnEngaged()
    // {
    //     Respawn();
    // }
    // [ClientRpc]
    // public void Respawn()
    // {
    //     Debug.Log("Has Respawned!");
    //     ourp.transform.position = n.start.position;
    //     Debug.Log("Player number - " + ourp.type + " - is the gameObject");
    // }

}
