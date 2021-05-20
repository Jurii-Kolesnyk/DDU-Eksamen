using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    public float speed = 0.1f;

    Renderer r;
    void Start()
    {
        r = gameObject.GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        r.material.mainTextureOffset = offset;
    }
}
