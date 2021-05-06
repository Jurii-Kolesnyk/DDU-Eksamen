/*using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newNetwork : NetworkManager
{
    // public override void OnStartServer()
    // {
    //     base.OnStartServer();

    //     NetworkServer.RegisterHandler<CreateMMOCharacterMessage>(OnCreateCharacter);
    // }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        //Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        Debug.Log(numPlayers);
        GameObject gameobject = Instantiate(playerPrefab);

        Player player = gameobject.GetComponent<Player>();
        player.Spawn(numPlayers);

        // GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }

    // public override void OnClientConnect(NetworkConnection conn)
    // {
    //     base.OnClientConnect(conn);

    //     // you can send the message here, or wherever else you want
    //     CreateMMOCharacterMessage characterMessage = new CreateMMOCharacterMessage
    //     {
    //         playerId = numPlayers
    //     };
    //     Debug.Log(numPlayers);
    //     conn.Send(characterMessage);
    // }

    // void OnCreateCharacter(NetworkConnection conn, CreateMMOCharacterMessage message)
    // {
    //     // playerPrefab is the one assigned in the inspector in Network
    //     // Manager but you can use different prefabs per race for example
    //     GameObject gameobject = Instantiate(playerPrefab);

    //     // Apply data from the message however appropriate for your game
    //     // Typically Player would be a component you write with syncvars or properties
    //     Player player = gameobject.GetComponent<Player>();
    //     player.Spawn(message.playerId);
    //     //player.playercount = message.playercount;

    //     // call this to use this gameobject as the primary controller
    //     NetworkServer.AddPlayerForConnection(conn, gameobject);
    // }

}
// public struct CreateMMOCharacterMessage : NetworkMessage
// {
//     public int playerId;
// }

// public enum Number
// {
//     player1,
//     player2
// }
*/