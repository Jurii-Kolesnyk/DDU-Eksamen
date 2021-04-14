using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Component player;
    public Component Enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "obstacle")
        {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.isKinematic = true;
        Invoke("destroyBullet", 5f);
        }

        enemy enemy = trigger.GetComponent<enemy>();

        if(enemy != null && player != Enemy){
            enemy.TakeDamage(20);
            Destroy(gameObject);
        }
    }

    void destroyBullet()
    {
        Destroy(gameObject);
    }

}
