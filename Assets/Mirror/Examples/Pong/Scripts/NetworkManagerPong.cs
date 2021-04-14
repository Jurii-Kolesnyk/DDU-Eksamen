using UnityEngine;
using Mirror;

    // Custom NetworkManager that simply assigns the correct racket positions when
    // spawning players. The built in RoundRobin spawn method wouldn't work after
    // someone reconnects (both players would be on the same side).
    [AddComponentMenu("")]
    public class NetworkManagerPong : NetworkManager
    {
        public GameObject playerPrefab2;
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;
        private int playercount = 0;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        
                GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
                playercount = 1;
                NetworkServer.AddPlayerForConnection(conn, player);
        

            if(numPlayers == 1 && Input.GetKeyDown(KeyCode.X)){
                GameObject player2 = Instantiate(playerPrefab2, start.position, start.rotation);
                NetworkServer.AddPlayerForConnection(conn, player2);
            }
        }
    }
