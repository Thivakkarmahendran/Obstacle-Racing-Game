using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectStage : MonoBehaviour
{

    public void chooseStage(int stageNum){
        
        SceneManager.LoadScene(stageNum);
    }
}
