using UnityEngine;
using Mirror;


// Custom NetworkManager that simply assigns the correct racket positions when
// spawning players. The built in RoundRobin spawn method wouldn't work after
// someone reconnects (both players would be on the same side).
[AddComponentMenu("")]
public class Networker : NetworkManager
{
    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;
    public GameObject player;

    public Transform start;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        player = Instantiate(playerPrefab, start.position, start.rotation);
        Player p = player.GetComponent<Player>();
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
    }
}