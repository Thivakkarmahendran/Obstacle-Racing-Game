using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTracker : MonoBehaviour
{

  private static GameObject snow;
  private static GameObject waterfall;
  private static GameObject wreckingBalls;


  void Start(){
    snow = GameObject.Find("Particle System Snow");
    waterfall = GameObject.Find("Waterfall");
    wreckingBalls = GameObject.Find("Wrecking Balls");

    snow.SetActive(false);
    waterfall.SetActive(false);
    wreckingBalls.SetActive(false);
  }

   public static void checkPointReached(string name){

       if(name.Equals("Checkpoint1")){ // before snow
         Debug.Log("Entered Checkpoint1");

         snow.SetActive(true);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);
       }
       else if(name.Equals("Checkpoint2")){ // after snow
         Debug.Log("Entered Checkpoint2");

         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);
       }
       else if(name.Equals("Checkpoint3")){ // before wrecking balls
         Debug.Log("Entered Checkpoint3");

         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(true);
       }
       else if(name.Equals("Checkpoint4")){// after wrecking balls and before beach
         Debug.Log("Entered Checkpoint4");

         snow.SetActive(false);
         waterfall.SetActive(true);
         wreckingBalls.SetActive(false);
       }
       else if(name.Equals("Checkpoint5")){ // after beach
         Debug.Log("Entered Checkpoint5");

         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);
       }
       else if(name.Equals("Checkpoint6")){ // before wind tunnel
         Debug.Log("Entered Checkpoint6");
         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);
       }
       else{
         Debug.Log("checkpoint not found");
       }
   }

}
