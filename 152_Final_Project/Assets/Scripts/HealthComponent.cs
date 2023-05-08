using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthComponent : MonoBehaviour
{
    public int HP = 3; //the amount of HP the player starts off with
    public TextMeshProUGUI health; //getting the HP UI

    public GameObject can; //getting the overall canvas for the UI
    public GameObject men; //getting the main menu UI
    public GameObject but; //getting the button on the main menu

    public GameObject death; //getting the game over screen
    public GameObject but2; //getting the button on game over screen

    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "HP Remaining: " + HP; //displays HP remaining

        //if HP equals 0, open the menu once again and pause the game
        if (HP == 0)
        {
            Time.timeScale = 0; //pauses the game
            can.SetActive(true);
            men.SetActive(true);
            but.GetComponent<StartGame>().enabled = false; //disables starting the game until the button is pressed again
            HP = 3; //resets HP back to 3; allowing the script to enter the else if statement below

            death.SetActive(true);
            death.transform.localScale = new Vector3(1, 1, 1); //expands the death screen to cover the camera
            but2.GetComponent<StartGame>().enabled = false;
        }
        else if (HP == 3) //keep this or else everything breaks
        {
            
        }
    }
}
