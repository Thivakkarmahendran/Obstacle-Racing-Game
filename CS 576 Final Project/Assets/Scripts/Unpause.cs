using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public void Resume(){
        Time.timeScale = 1; 
        pauseMenu.SetActive(false);
    }
}
