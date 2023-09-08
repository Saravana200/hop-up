using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad : MonoBehaviour
{
    Rigidbody2D pad_board;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pad_board= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal_2");
        pad_board.velocity = new Vector2(x * speed, pad_board.velocity.y);


    }
}
