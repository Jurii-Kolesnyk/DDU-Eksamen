using UnityEngine;
using Mirror;
using UnityEngine.UI;


// Custom NetworkManager that simply assigns the correct racket positions when
// spawning players. The built in RoundRobin spawn method wouldn't work after
// someone reconnects (both players would be on the same side).
[AddComponentMenu("")]
public class Networker : NetworkManager
{
    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;
    public GameObject player;
    public Player p;
    public Transform SpawnPointTimer;
    public Transform start;
    public Transform h11;
    public Transform h12;
    // public Transform h13;
    // public Transform h21;
    // public Transform h22;
    // public Transform h23;
    public bool hasEntered = true;
    public bool indZero = false;


    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        player = Instantiate(playerPrefab, start.position, start.rotation);
        p = player.GetComponent<Player>();
        //HeadDetect c = p.GetComponentInChildren<HeadDetect>().GetComponent<HeadDetect>();
        if (numPlayers > 0)
        {
            p.type = 2;

        }
        else
        {
            p.type = 1;
        }
        NetworkServer.AddPlayerForConnection(conn, player);
        blabla();
    }
    void blabla()
    {
        if (p.type == 1)
        {
            GameObject health = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "HealthHearts"), h11.position, h11.rotation);
            NetworkServer.Spawn(health, player);
        }
        if (p.type == 2)
        {
            GameObject toxt = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canvas"), SpawnPointTimer.position, SpawnPointTimer.rotation);
            NetworkServer.Spawn(toxt);
            GameObject health = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "HealthHearts"), h12.position, h12.rotation);
            NetworkServer.Spawn(health, player);
        }
    }
}