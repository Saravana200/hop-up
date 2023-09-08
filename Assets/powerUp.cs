using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    int i;
    float timer;
    public Collider2D col;
    public GameObject body;
    [SerializeField]

    float delay=2;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("brick"))
        { 
            body.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        
    }

    void Start()
    {
        i=0;   
        this.col.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > delay)
        {
            timer = 0;
            destoryPowerUp();
        }
        //Debug.Log("reached this place " + this.body.transform.position.y);
        /*if (this.body.transform.position.y<=0.7f)
        {
           Debug.Log("reached this place "+this.body.transform.position.y);
            i++;
            this.col.isTrigger=false;
            
        }*/
        
    }

    private void destoryPowerUp()
    {
        Debug.Log("reached this place and deleted");
        Destroy(this.col.gameObject);
    }
}
