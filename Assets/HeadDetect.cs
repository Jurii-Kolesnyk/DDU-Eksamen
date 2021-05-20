using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class HeadDetect : NetworkBehaviour
{
    GameObject manager;
    Networker n;
    GameObject parent;
    public Player ourp;
    [SyncVar]
    public bool collEnt = false;
    [SyncVar]
    public bool healthLoss = false;
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
            collEnt = true;
            Debug.Log("Collision detected on player " + ourp.type);
            healthLoss = true;
        }
    }
}
