using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject groundSpike;
    public GameObject airSpike;
    public int generationRateGround;
    public int generationRateAir;

    public int generalTimer;
    public int timeInSeconds;
    public TextMeshProUGUI time;

    private int timerGround;
    private int timerAir;
    private int timerGeneration;

    public bool speedUp;
    
    // Start is called before the first frame update
    void Start()
    {
        generalTimer = 0;
        timerGround = 0;
        timerAir = 0;
        timerGeneration = 0;
        speedUp = false;
        generationRateGround = Random.Range(100, 200);
        generationRateAir = Random.Range(100, 200);
    }

    void Update()
    {
        generalTimer++;
        timeInSeconds = generalTimer / 100;
        time.text = "Time: " + timeInSeconds.ToString() + " seconds";

        timerGeneration++;
        if(timerGeneration >= 500)
        {
            timerGeneration = 0;
            speedUp = true;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        timerGround++;
        if(timerGround >= generationRateGround)
        {
            timerGround = 0;
            generationRateGround = Random.Range(100, 200);
            GameObject newGroundSpike = Instantiate(groundSpike, new Vector2(groundSpike.transform.position.x, groundSpike.transform.position.y), groundSpike.transform.rotation);
            Destroy(newGroundSpike, 5f);
        }

        timerAir++;
        if(timerAir >= generationRateAir)
        {
            timerAir = 0;
            generationRateAir = Random.Range(100, 200);
            GameObject newAirSpike = Instantiate(airSpike, new Vector2(airSpike.transform.position.x, airSpike.transform.position.y + Random.Range(-1f, 2f)), airSpike.transform.rotation);
            Destroy(newAirSpike, 5f);
        }
    }
}
