using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "obstacle")
        {
        Destroy(gameObject);
        }

        enemy enemy = trigger.GetComponent<enemy>();

        if(enemy != null){
            enemy.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
