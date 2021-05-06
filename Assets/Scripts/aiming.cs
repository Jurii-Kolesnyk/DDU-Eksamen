using UnityEngine;
using Mirror;

public class aiming : NetworkBehaviour
{
    Rigidbody2D rb;
    GameObject manager;
    networking m;
    Vector2 lookDirection;

    void Start()
    {
        manager = GameObject.FindWithTag("NetworkManager");
        m = manager.GetComponent<networking>();
        rb = m.weapon.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isLocalPlayer) return;
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        Vector2 lookDir = lookDirection - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}