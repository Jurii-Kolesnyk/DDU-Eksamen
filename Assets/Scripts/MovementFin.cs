using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFin : MonoBehaviour
{
    public SpriteRenderer SR;
    public float speed;
    public float jumpPower;
    private Vector2 change;
    public Rigidbody2D rb;
    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        //myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // For hvert frame resetter jeg hvor meget player har ændret sig

        // Man bruger GetAxisRaw for at undgå acceleration eller modstands acceleration som gør movement kommer til føle mere "snappy"
        horizontal = Input.GetAxis("Horizontal");
        Vector2 change = (transform.forward * horizontal) * speed * Time.fixedDeltaTime;
        myRigidBody.velocity.x = change.x;
    }
}