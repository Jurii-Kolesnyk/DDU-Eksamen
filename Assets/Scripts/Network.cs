/*using UnityEngine;

namespace Mirror.Examples.Pong
{
    [AddComponentMenu("")]

        public struct createCharacterMessage : NetworkMessage{
        public Players number;
    }
    public enum Players{
        Player1,
        Player2
    }

    public class Network : NetworkManager
    {
        //public GameObject playerPrefab2;
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<createCharacterMessage>(OnCreateCharacter);
        }
        
        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);

            createCharacterMessage characterMessage = new createCharacterMessage{
                number = Players.Player1
            };

            if(numPlayers == 1){
                characterMessage = new createCharacterMessage{
                    number = Players.Player2
                };
            };

            conn.Send(characterMessage);
            // add player at correct spawn position
            /*GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);*/       /*
        }
        void OnCreateCharacter(NetworkConnection conn, createCharacterMessage message)
        {
            GameObject gameobject = Instantiate(playerPrefab);

            Player player = gameobject.GetComponent<Player>();
            player.number = message.number;

            NetworkServer.AddPlayerForConnection(conn, gameobject);
        }
    }
}

/*if (message.number.Equals("Player2"))
                {
                    GameObject gameobject = Instantiate(playerPrefab2, start.position, start.rotation);
                    Player player = gameobject.GetComponent<Player>();
                    NetworkServer.AddPlayerForConnection(conn, gameobject);
                } else if (message.number.Equals("Player1"))
                {
                    GameObject gameobject = Instantiate(playerPrefab, start.position, start.rotation);
                    Player player = gameobject.GetComponent<Player>();
                    NetworkServer.AddPlayerForConnection(conn, gameobject);
                }*/

            /*if(message.number == NumberPlayer.Player1){
                gameobject = Instantiate(playerPrefab, start.position, start.rotation);
            } else if(message.number == NumberPlayer.Player2){
                gameobject = Instantiate(playerPrefab2, start.position, start.rotation);
            }*/
