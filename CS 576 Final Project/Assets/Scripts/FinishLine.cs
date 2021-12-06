using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject finishLine;
    private void OnTriggerEnter(Collider collider){
        Debug.Log(collider.name);
        if(collider.name == "Body"){
            if(transform.name == "Midpoint"){
                finishLine.GetComponent<RaceSystem>().crossed_midpoint = true;
            }
            if(transform.name == "Front" && finishLine.GetComponent<RaceSystem>().crossed_midpoint){
                finishLine.GetComponent<RaceSystem>().crossed_front = true;
            }
        }
    }
}
