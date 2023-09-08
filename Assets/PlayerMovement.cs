using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private int i = 0;
    private int j = 0;

    public LayerMask land;
    private Transform feet;
    bool isTouchingGround;
    public float radius;
    public Animator animator;
    public Tilemap tile;
    Rigidbody2D rb;
    public GameObject bricks;
    bool isFacingRight=true;
    [SerializeField] 
    public float speed;
    public float start_index_x,start_index_y;
    public float end_index;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "powerUp")
        {
            spawnTile();
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("walls"))
        {
            SceneManager.LoadScene(0);
            //transform.position = new Vector2(-3.29f, 3.0f);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        feet=GameObject.Find("feet").transform;
        i = 0;
        j = 0;
    }

    // Update is called once per frame  
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if(x<0 && isFacingRight)
        {
            flip();
        }
        if(x>0 && !isFacingRight)
        {
            flip();
        }
        isTouchingGround = Physics2D.OverlapCircle(feet.position,radius,land);
        if (Input.GetKeyDown("space") && isTouchingGround)
        {
            animator.SetBool("jump", true);
            rb.velocity = new Vector3(0, 10, 0);
        }
        else if (isTouchingGround && animator.GetBool("jump"))
        {
            Debug.Log(isTouchingGround);
            animator.SetBool("jump", false);
        }
        rb.velocity=new Vector2(x*speed,rb.velocity.y);
        animator.SetBool("run", x!=0);


    }
    public void onTouchGround()
    {
        animator.SetBool("jump", false);
    }

    private void flip()
    {
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
    void spawnTile()
    {

        if(i<end_index)
        {
            GameObject tile = Instantiate(bricks, new Vector2(start_index_x + 1.6f * i, start_index_y + j), Quaternion.identity);
            tile.name = tile.name + tile.transform.position.x.ToString();
            i++;
            return;
        }
        j++;
        i = 0;

    }
}
