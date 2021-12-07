using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RaceSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static int myGlobal = 1;
    int totalLaps;
    int currentLap;
    public Text lapCounter;
    public Text lapTime;
    string lTime;
    float startTime;
    float elapsedTime;
    public bool crossed_front;
    public bool crossed_midpoint;
    bool race_completed;
    public GameObject winPanel;
    public GameObject pauseMenu;
    void Start()
    {
        Time.timeScale = 1;
        winPanel.SetActive(false);
        pauseMenu.SetActive(false);
        totalLaps = 1;
        currentLap = 0;
        startTime = Time.time;
        elapsedTime = 0;
        crossed_front = false;
        crossed_midpoint = false;
        race_completed = false;
        lapCounter.text =  "Lap " + currentLap + "/" + totalLaps;
        lapTime.text = "00:00:00";

    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        if(race_completed){
            Time.timeScale = 0;
            winPanel.SetActive(true);
            GameObject.Find("WinText").GetComponent<Text>().text = "Race Completed!\n\nYourTime\n\n" + lTime;
            //winPanel.GetComponentInChildren<Text>().text = "Race Completed!\n\nYourTime\n\n" + lTime;
        }
        else{
            elapsedTime = Time.time - startTime;
            Vector3 newTime = convertTime(elapsedTime);
            lTime = newTime[0].ToString("00") + ":" + newTime[1].ToString("00") + ":" + newTime[2].ToString("00");
            lapTime.text = lTime;
            if(crossed_front){
                currentLap += 1;
                crossed_front = false;
                crossed_midpoint = false;
                lapCounter.text =  "Lap " + currentLap + "/" + totalLaps;
            }
            if(currentLap == totalLaps){
                race_completed = true;
            }
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
