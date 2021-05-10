using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

// Dette bruges til hvor meget spilleren skal flyttes. Den skal være vector 3 da vi flytter på playeren
    public Vector3 playerChange;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
        // Her flyttes playerens position
            collision.transform.position += playerChange;
        }
    }

}
