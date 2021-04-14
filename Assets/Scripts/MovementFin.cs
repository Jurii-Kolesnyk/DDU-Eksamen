using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFin : MonoBehaviour
{
public SpriteRenderer SR;
    public float speed;
    public float jumpPower;
    private Vector2 change;
    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // For hvert frame resetter jeg hvor meget player har ændret sig
        change = Vector2.zero;

        // Man bruger GetAxisRaw for at undgå acceleration eller modstands acceleration som gør movement kommer til føle mere "snappy"
        change.x = Input.GetAxisRaw("Horizontal");
    }
}