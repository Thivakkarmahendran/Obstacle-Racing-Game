using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetBestTime : MonoBehaviour
{
    public Text time;
    private string bestTime;
    // Start is called before the first frame update
    void Start()
    {
        bestTime = System.IO.File.ReadAllText("bestTime.txt");
        time.text = "Best Time:\n" + bestTime;
    }

}
