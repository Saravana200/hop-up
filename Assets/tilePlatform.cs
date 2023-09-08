using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilePlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "powerUp")
        {
            collision.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
