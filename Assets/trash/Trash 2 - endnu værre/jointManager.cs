// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Mirror;

// public class jointManager : NetworkBehaviour
// {
//     //public GameObject player;
//     //GameObject weapon;
//     FixedJoint2D jointRed;
//     GameObject manager;
//     networking m;
//     Player p;
//     Rigidbody2D rb;
//     Vector2 lookDirection;

//     [SyncVar]
//     public int typo;
//     void Start()
//     {
//         manager = GameObject.FindWithTag("NetworkManager");
//         m = manager.GetComponent<networking>();
//         p = m.player.GetComponent<Player>();
//         rb = m.weapon.GetComponent<Rigidbody2D>();
//         jointRed = GetComponent<FixedJoint2D>();
//         weaponMovement();
//         //weapon = GameObject.FindWithTag("sp");
//     }

//     void Update()
//     {
//         lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         if (Input.GetButtonDown("Fire1"))
//         {
//             m.Shoot();
//         }
//     }

//     void FixedUpdate()
//     {
//         Vector2 lookDir = lookDirection - rb.position;
//         float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
//         rb.rotation = angle;
//     }

//     [Command]
//     public void weaponMovement()
//     {
//         if (p.type == typo)
//         {
//             jointRed.connectedBody = m.player.GetComponent<Rigidbody2D>();
//             Debug.Log("succesful connection!");
//         }
//         //m.weapon.transform.position = m.player.transform.position;
//     }
// }
