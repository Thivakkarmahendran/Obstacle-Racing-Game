using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour{

        public GameObject checkpointsGameObject;
        public Text alertText;
   

        private void OnTriggerEnter(Collider other){
         if(other.name.Equals("Body")){

                var checkpointsTracker = checkpointsGameObject.GetComponent<checkpointTracker>();
                checkpointsTracker.checkPointReached(gameObject.name, transform.position);
         }
         
        }

}
