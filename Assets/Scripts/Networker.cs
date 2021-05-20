using UnityEngine;
using Mirror;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("")]
public class Networker : NetworkManager
{
    public Transform Spawn1;
    public Transform Spawn2;
    public GameObject player;
    public Player p;
    public Transform SpawnPointTimer;
    public Transform start;
    public Transform h11;
    public Transform h12;
    public bool hasEntered = true;
    public bool indZero = false;
    public bool isFound = true;
    public bool endGame = false;


    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        start = numPlayers == 0 ? Spawn1 : Spawn2;
        player = Instantiate(playerPrefab, start.position, start.rotation);
        p = player.GetComponent<Player>();
        if (numPlayers > 0)
        {
            p.type = 2;
            isFound = false;

        }
        else
        {
            p.type = 1;
        }
        NetworkServer.AddPlayerForConnection(conn, player);
        blabla();
    }

    void Update()
    {
        if (endGame == true)
        {
            endGame = false;
            GameObject endScreen = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canvas 1"), SpawnPointTimer.position, SpawnPointTimer.rotation);
            NetworkServer.Spawn(endScreen);
            GameObject eSys = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "EventSystem"), SpawnPointTimer.position, SpawnPointTimer.rotation);
            NetworkServer.Spawn(eSys, endScreen);
        }
        else return;
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        if (indZero == true)
        {
            indZero = false;
        }
        //p.health = 3;
    }
    void blabla()
    {
        if (p.type == 1)
        {
            GameObject health = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "HealthHearts"), h11.position, h11.rotation);
            HP h = health.GetComponent<HP>();
            h.playerSync = 1;
            NetworkServer.Spawn(health, player);
        }
        if (p.type == 2)
        {
            GameObject toxt = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canvas"), SpawnPointTimer.position, SpawnPointTimer.rotation);
            NetworkServer.Spawn(toxt);
            GameObject health = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "HealthHearts2"), h12.position, h12.rotation);
            HP h = health.GetComponent<HP>();
            h.playerSync = 2;
            NetworkServer.Spawn(health, player);
        }
    }

    public void endManager()
    {
        NetworkManager.Shutdown();
    }
}