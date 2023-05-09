using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public ObstacleGenerator g; //getting the ObstacleGenerator script
    public float moveSpeed; //how fast the objects move to the left
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f; //moves at 0.5 speed
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //responsible for moving the objects to the left
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - moveSpeed, transform.position.y), 0.1f);
    }
}
