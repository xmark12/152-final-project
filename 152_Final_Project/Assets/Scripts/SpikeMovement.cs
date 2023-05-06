using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - moveSpeed, transform.position.y), 0.1f);
    }
}
