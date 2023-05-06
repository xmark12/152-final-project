using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afterimage : MonoBehaviour
{
    public Movement m; //getting Movement.cs

    public GameObject afterImage; //getting afterimage for normal
    public GameObject afterImageJump; //getting afterimage for jumping
    public GameObject afterImageDuck; //getting afterimage for ducking

    private float timer; //how long the afterimage lasts

    void Start()
    {
        timer = 0.1f; //begin at 0.1 seconds
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; //subtract until reaches 0
        }
        else
        {
            //upon reaching 0, create an afterimage and destroy it after 1 second
            GameObject afterEffect;
            if (m.jump && !m.duck)
            {
                afterEffect = Instantiate(afterImageJump, transform.position, transform.rotation);
                afterEffect.transform.localScale = this.transform.localScale;
            }
            else if (m.duck && !m.jump)
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
