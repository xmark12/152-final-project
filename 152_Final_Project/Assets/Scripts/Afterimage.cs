using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afterimage : MonoBehaviour
{
    public Movement m;

    public GameObject afterImage;
    public GameObject afterImageJump;
    public GameObject afterImageDuck;

    private float timer;
    private float velocity;

    void Start()
    {
        timer = 0.1f;
        velocity = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            GameObject afterEffect;
            if (m.jump && !m.grounded && !m.duck)
            {
                afterEffect = Instantiate(afterImageJump, transform.position, transform.rotation);
                afterEffect.transform.localScale = this.transform.localScale;
            }
            else if (m.duck && m.grounded && !m.jump)
            {
                afterEffect = Instantiate(afterImageDuck, transform.position, transform.rotation);
                afterEffect.transform.localScale = this.transform.localScale;
            }
            else
            {
                afterEffect = Instantiate(afterImage, transform.position, transform.rotation);
                afterEffect.transform.localScale = this.transform.localScale;
            }
            timer = 0.1f;
            Destroy(afterEffect, 1f);
        }
    }
}
