// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Mirror;

// public class bullet : NetworkBehaviour
// {
//     public float speed = 20f;
//     public Rigidbody2D rb;

//     GameObject p;
//     Transform player;
//     //public Component Enemy;
//     void Start()
//     {
//         rb.velocity = transform.right * speed;
//         p = GameObject.Find("Player(Clone)");
//         player = p.transform;
//     }

//     void OnTriggerEnter2D(Collider2D trigger)
//     {
//         if (trigger.gameObject.tag == "obstacle")
//         {
//             Destroy(gameObject);
//         }

//         //enemy enemy = trigger.GetComponent<enemy>();

//         /*if (enemy != null && player != Enemy)
//         {
//             enemy.TakeDamage(20);
//             Destroy(gameObject);
//         }*/
//     }
// }
