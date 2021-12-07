using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour{

        private void OnTriggerEnter(Collider other){
         
         if(other.name.Equals("Body")){
                checkpointTracker.checkPointReached(gameObject.name);
         }
         
        }
}
