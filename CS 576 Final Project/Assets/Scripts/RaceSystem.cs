using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RaceSystem : MonoBehaviour
{
    // Start is called before the first frame update
    int totalLaps;
    int currentLap;
    public Text lapCounter;
    public Text lapTime;
    float startTime;
    float elapsedTime;
    public bool crossed_front;
    

    void Start()
    {
        totalLaps = 3;
        currentLap = 0;
        startTime = Time.time;
        elapsedTime = 0;
        crossed_front = false;
        lapCounter.text =  "Lap " + currentLap + "/" + totalLaps;
        lapTime.text = "00:00:00";

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time - startTime;
        Vector3 newTime = convertTime(elapsedTime);
        lapTime.text = newTime[0].ToString("00") + ":" + newTime[1].ToString("00") + ":" + newTime[2].ToString("00");
        
        if(crossed_front && checkpointTracker.reachedAllCheckpoints()){
            currentLap += 1;
            crossed_front = false;
            lapCounter.text =  "Lap " + currentLap + "/" + totalLaps;
            checkpointTracker.restartAllCheckpoints();
        }

    }

    private Vector3 convertTime(float elapsed){
        int elapsedInt = (int) (elapsed * 100);
        int ms = elapsedInt % 100;
        int sec = elapsedInt / 100;
        int min = sec / 60;
        sec -= 60 * min;

        
        return new Vector3(min, sec, ms);
    }
}
