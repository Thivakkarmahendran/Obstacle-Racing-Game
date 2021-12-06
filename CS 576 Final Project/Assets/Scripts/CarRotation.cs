using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotation : MonoBehaviour
{
    GameObject car1;
    GameObject car2;
    GameObject car3;

    void Start()
    {
        car1 = GameObject.Find("SmallCar");
        car2 = GameObject.Find("NormalCar"); 
        car3 = GameObject.Find("BigCar");   
    }

    // Update is called once per frame
    void Update()
    {
        
        car1.transform.Rotate(0, -1 * 30 * Time.deltaTime, 0);
        car2.transform.Rotate(0, -1 * 30 * Time.deltaTime, 0);
        car3.transform.Rotate(0, -1 * 30 * Time.deltaTime, 0);
    }
}
