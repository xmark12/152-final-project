using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject groundSpike; //getting the ground objects
    public GameObject airSpike; //getting the objects in the air
    public int generationRateGround; //getting timer for ground objects spawning
    public int generationRateAir; //getting timer for air objects spawning

    public float timeInSeconds; //timer for the game in-general
    public int trueTime; //used to convert the float above into an int for readability
    public TextMeshProUGUI time; //UI to display the above 2 variables
    public TextMeshProUGUI finalScore; //UI to display the score that the player ended on

    private int timerGround; //to time when to spawn a ground object
    private int timerAir; //to time when to spawn an air object
    
    // Start is called before the first frame update
    void Start()
    {
        //set the ground and air timers to 0 and set their generation to a random range of 100-200
        timerGround = 0;
        timerAir = 0;
        generationRateGround = Random.Range(100, 200);
        generationRateAir = Random.Range(100, 200);
    }

    void Update()
    {
        //the following 4 lines display the time
        timeInSeconds += Time.deltaTime;
        trueTime = (int)timeInSeconds;
        time.text = "Time: " + trueTime.ToString() + " seconds";
        finalScore.text = "Final Time: " + trueTime.ToString() + " seconds";

        //the following if and else if statements create ground and air objects at a faster rate every 10 seconds, maxing out at 80+ seconds
        if(trueTime == 10)
        {
            generationRateGround = Random.Range(90, 190);
            generationRateAir = Random.Range(90, 190);
        }
        else if (trueTime == 20)
        {
            generationRateGround = Random.Range(80, 180);
            generationRateAir = Random.Range(80, 180);
        }
        else if (trueTime == 30)
        {
            generationRateGround = Random.Range(70, 170);
            generationRateAir = Random.Range(70, 170);
        }
        else if (trueTime == 40)
        {
            generationRateGround = Random.Range(60, 160);
            generationRateAir = Random.Range(60, 160);
        }
        else if (trueTime == 50)
        {
            generationRateGround = Random.Range(50, 150);
            generationRateAir = Random.Range(50, 150);
        }
        else if (trueTime == 60)
        {
            generationRateGround = Random.Range(40, 140);
            generationRateAir = Random.Range(40, 140);
        }
        else if (trueTime == 70)
        {
            generationRateGround = Random.Range(30, 130);
            generationRateAir = Random.Range(30, 130);
        }
        else if (trueTime == 80)
        {
            generationRateGround = Random.Range(20, 120);
            generationRateAir = Random.Range(20, 120);
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //once ground timer is greater than or equal to the generation rate, spawn in the ground object and delete it after 5 seconds
        timerGround++;
        if(timerGround >= generationRateGround)
        {
            timerGround = 0;
            GameObject newGroundSpike = Instantiate(groundSpike, new Vector2(groundSpike.transform.position.x, groundSpike.transform.position.y), groundSpike.transform.rotation);
            Destroy(newGroundSpike, 8f);
        }
        //once air timer is greater than or equal to the generation rate, spawn in the air object and delete it after 5 seconds
        timerAir++;
        if (timerAir >= generationRateAir)
        {
            timerAir = 0;
            GameObject newAirSpike = Instantiate(airSpike, new Vector2(airSpike.transform.position.x, airSpike.transform.position.y + Random.Range(-5.5f, 0f)), airSpike.transform.rotation);
            Destroy(newAirSpike, 8f);
        }
    }
}
