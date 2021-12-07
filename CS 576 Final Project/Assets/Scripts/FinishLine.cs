using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject finishLine;

    private void OnTriggerEnter(Collider collider){
        if(collider.name == "Body"){
            if(transform.name == "Front"){
                finishLine.GetComponent<RaceSystem>().crossed_front = true;
            }
        }
    }
}
