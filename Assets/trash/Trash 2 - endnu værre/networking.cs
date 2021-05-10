// using UnityEngine;
// using Mirror;

// [AddComponentMenu("")]
// public class networking : NetworkManager
// {
//     public Transform leftRacketSpawn;
//     public Transform rightRacketSpawn;
//     GameObject weapon;
//     GameObject player;
//     Player p;

//     jointManager jM;

//     //public GameObject livePlayer;
//     public float bulletForce = 20f;

//     public override void OnServerAddPlayer(NetworkConnection conn)
//     {
//         // add player at correct spawn position
//         Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
//         player = Instantiate(playerPrefab, start.position, start.rotation);
//         p = player.GetComponent<Player>();
//         if (numPlayers > 0)
//         {
//             p.type = 2;
//             //p.tag = "Player2";
//         }
//         else
//         {
//             p.type = 1;
//             //p.tag = "Player1";
//         }
//         NetworkServer.AddPlayerForConnection(conn, player);
//         Debug.Log("playercount - " + numPlayers);

//         //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//     }
//     public void Spawn1()
//     {
//         if (p.type == 1)
//         {
//             weapon = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "shootingPoint"), player.transform.position, player.transform.rotation);
//             jM = weapon.GetComponent<jointManager>();
//             jM.typo = 1;
//             NetworkServer.Spawn(weapon, player);
//             Debug.Log("Weapon 1 spawned!");
//         }
//     }
//     public void Spawn2()
//     {
//         if (p.type == 2)
//         {
//             weapon = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "shootingPoint"), player.transform.position, player.transform.rotation);
//             jM = weapon.GetComponent<jointManager>();
//             jM.typo = 2;
//             NetworkServer.Spawn(weapon, player);
//             Debug.Log("Weapon 2 spawned!");
//         }
//     }
//     public void Shoot()
//     {
//         GameObject bullet = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Bullet"), weapon.transform.position, weapon.transform.rotation);
//         Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
//         rb.AddForce(weapon.transform.right * bulletForce, ForceMode2D.Impulse);
//         NetworkServer.Spawn(bullet, weapon);
//     }






// /*if (p.tag == "Player1")
// {
//     livePlayer = GameObject.FindWithTag("Player1");
//     weapon = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "shootingPoint"), p.transform.position, p.transform.rotation);
//     weapon.tag = "sp1";
//     NetworkServer.Spawn(weapon, livePlayer);
// }
// if (p.tag == "Player2")
// {
//     livePlayer = GameObject.FindWithTag("Player2");
//     weapon = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "shootingPoint"), p.transform.position, p.transform.rotation);
//     weapon.tag = "sp2";
//     NetworkServer.Spawn(weapon, livePlayer);
// }*/