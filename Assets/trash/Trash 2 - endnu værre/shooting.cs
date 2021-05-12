// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Mirror;

// public class shooting : NetworkBehaviour
// {
//     //GameObject firePoint;
//     //public GameObject bulletPrefab;
//     GameObject manager;
//     networking m;


//     //public float bulletForce = 20f;
//     void Start()
//     {
//         manager = GameObject.FindWithTag("NetworkManager");
//         m = manager.GetComponent<networking>();

//         //firePoint = GameObject.FindWithTag("sp");
//     }
//     public void Update()
//     {
//         if (Input.GetButtonDown("Fire1"))
//         {
//             m.Shoot();
//         }
//     }
//     /*void Shoot()
//     {
//         GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
//         Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
//         rb.AddForce(firePoint.transform.right * bulletForce, ForceMode2D.Impulse);
//         NetworkServer.Spawn(bullet, m.livePlayer);
//     }*/
// }
