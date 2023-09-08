using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private bool game_over;
    public float maxSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > maxSpeed)
        {
            Debug.Log("came here and reduced");
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        if (!game_over)
        {
            Vector2 pos = GameObject.Find("pad").transform.position;
            transform.position = new Vector2(pos.x, pos.y + 1);
        }
     
        if(Input.GetKey(KeyCode.UpArrow) && !game_over) 
        {
 
            game_over = true;
            rb.AddForce(new Vector2(Random.value,1)*maxSpeed);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="brick" )
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("walls"))
        {
            Debug.Log("reached here");
            rb.velocity = Vector2.zero;
            game_over = false;
        }
    }
}
