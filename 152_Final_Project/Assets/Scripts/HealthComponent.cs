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
        }
        else if (HP == 3) //keep this or else everything breaks
        {
            
        }
    }
}
