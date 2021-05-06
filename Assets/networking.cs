using UnityEngine;
using Mirror;

[AddComponentMenu("")]
public class networking : NetworkManager
{
    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;
    public GameObject weapon;

    public GameObject livePlayer;
    //GameObject bulletPrefab;
    public float bulletForce = 20f;


    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        Player p = player.GetComponent<Player>();
        if (numPlayers > 0)
        {
            p.type = 2;
            p.tag = "Player2";

        }
        else
        {
            p.type = 1;
            p.tag = "Player1";
        }
        NetworkServer.AddPlayerForConnection(conn, player);


        // spawn ball if two players
        if (p.tag == "Player1")
        {
            livePlayer = GameObject.FindWithTag("Player1");
            weapon = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "shootingPoint"), p.transform.position, p.transform.rotation);
            NetworkServer.Spawn(weapon, livePlayer);
        }
        if (p.tag == "Player2")
        {
            livePlayer = GameObject.FindWithTag("Player2");
            weapon = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "shootingPoint"), p.transform.position, p.transform.rotation);
            NetworkServer.Spawn(weapon, livePlayer);
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Bullet"), weapon.transform.position, weapon.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weapon.transform.right * bulletForce, ForceMode2D.Impulse);
        NetworkServer.Spawn(bullet, weapon);
    }
}

//     public override void OnServerDisconnect(NetworkConnection conn)
//     {
//         // destroy ball
//         if (ball != null)
//             NetworkServer.Destroy(ball);

//         // call base functionality (actually destroys the player)
//         base.OnServerDisconnect(conn);
//     }
// }


