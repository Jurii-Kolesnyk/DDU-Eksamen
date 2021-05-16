using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class HeadDetect : NetworkBehaviour
{
    GameObject manager;
    Networker n;
    // GameObject player;
    // Player p;
    GameObject parent;
    public Player ourp;

    [SyncVar]
    public bool collEnt = false;

    [SyncVar]
    public bool healthLoss = false;
    //private bool hasFound = false;


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
    void Update()
    {
        if (ourp.type == 2)
        {
            n.hasEntered = false;
        }
        if (ourp.health < 1 && n.indZero == true)
        {
            n.indZero = false;
            Invoke("changeEnd", 2);
        }

    }

    void changeEnd()
    {
        n.endGame = true;
    }

    [Client]
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collNum == ourp.type && collEnt == false)
        {
            /*Debug.Log(p.type + " - the killer");
            Debug.Log(collNum + " - the killed");*/
            collEnt = true;
            Debug.Log("Collision detected on player " + ourp.type);
            healthLoss = true;

            // ourp.health -= 1;
            // healthLoss = true;
            // Debug.Log("status on player - " + ourp.type + " - of boolean - " + healthLoss);
        }
    }
    //skal til for at man kun rammer 1 gang når man rammer hovedet, så man ikke detecter hver gang
    //der kollideres, så man ikke kan fjerne fx 2 liv på 1 hop
    // [Client]
    // public void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Player" && collNum == ourp.type && collEnt == true)
    //     {
    //         collEnt = false;
    //     }
    // }
}
