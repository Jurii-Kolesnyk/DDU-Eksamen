
using UnityEngine;
using Mirror;

public class HeadDetect : NetworkBehaviour
{
    // GameObject manager;
    // Networker n;
    // GameObject player;
    // Player p;
    GameObject parent;
    Player ourp;
    bool collEnt = false;

    [SyncVar]
    public int collNum;

    void Start()
    {
        // manager = GameObject.FindWithTag("NetworkManager");
        // n = manager.GetComponent<Networker>();
        parent = transform.parent.gameObject;
        ourp = parent.GetComponent<Player>();
        Debug.Log("ourp type - " + ourp.type);

        collNum = ourp.type;
    }

    [Client]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collNum == ourp.type && collEnt == false)
        {
            /*Debug.Log(p.type + " - the killer");
            Debug.Log(collNum + " - the killed");*/
            collEnt = true;
            Debug.Log("Collision detected!");

            ourp.health -= 1;
        }
    }
    //skal til for at man kun rammer 1 gang når man rammer hovedet, så man ikke detecter hver gang
    //der kollideres, så man ikke kan fjerne fx 2 liv på 1 hop
    [Client]
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collNum == ourp.type && collEnt == true)
        {
            /*Debug.Log(p.type + " - the killer");
            Debug.Log(collNum + " - the killed");*/
            collEnt = false;
        }
    }

}
