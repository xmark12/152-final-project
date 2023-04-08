using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool grounded;
    public bool jump;
    public bool duck;

    public Animator a;

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        jump = false;
        duck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (jump && !grounded && !duck)
        {
            a.Play("Jump");
        }
        else if (duck && grounded && !jump)
        {
            a.Play("Duck");
        }
        else
        {
            a.Play("Grounded");
        }
    }
}
