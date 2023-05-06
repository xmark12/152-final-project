using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject bg; //getting the main menu
    public GameObject player; //getting the player
    public Transform startPos; //getting the starting position of the player
    public HealthComponent h; //getting the HealthComponent script
    public ObstacleGenerator o; //getting the ObstacleGenerator script

    private bool beginGame; //begins the game if true
    
    // Start is called upon clicking the button
    void Start()
    {
        beginGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        //once game begins, set HP to max, set player to starting position, reset the time, reset obstacle generation, remove main menu, and unpause the game
        if (beginGame)
        {
            h.HP = 3;
            player.transform.position = startPos.position;
            o.timeInSeconds = 0;
            o.generationRateGround = Random.Range(100, 200);
            o.generationRateAir = Random.Range(100, 200);
            bg.SetActive(false);
            Time.timeScale = 1;
        }
        //upon reaching 0 HP, reveal the main menu, pause the game, and set beginGame to false
        if(h.HP == 0)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        bg.SetActive(true);
        Time.timeScale = 0;
        beginGame = false;
    }
}
