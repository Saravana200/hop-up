using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject powerUp;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject bricks;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPower",2,2);
        for(int i=0;i<15; i++)
        {
            Instantiate(bricks, new Vector2(-2.67f+ 1.6f * i,-1), Quaternion.identity);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPower()
    {
        Instantiate(powerUp, new Vector2(Random.Range(-2f,18f), 7.1f),Quaternion.identity);
    }

    
}
