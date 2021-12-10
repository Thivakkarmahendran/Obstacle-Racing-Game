using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTracker : MonoBehaviour
{

  private static bool reachedCheckpoint1;
  private static bool reachedCheckpoint2;
  private static bool reachedCheckpoint3;
  private static bool reachedCheckpoint4;
  private static bool reachedCheckpoint5;
  private static bool reachedCheckpoint6;
  
  private static GameObject snow;
  private static GameObject waterfall;
  private static GameObject wreckingBalls;


  void Start(){


    reachedCheckpoint1 = false;
    reachedCheckpoint2 = false;
    reachedCheckpoint3 = false;
    reachedCheckpoint4 = false;
    reachedCheckpoint5 = false;
    reachedCheckpoint6 = false;


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

         if(!reachedCheckpoint2 && !reachedCheckpoint3 && !reachedCheckpoint4 && !reachedCheckpoint5 && !reachedCheckpoint6){
           reachedCheckpoint1 = true;
         }
         else{
           Debug.Log("Missed Previous checkpoint");
         }
         
         terrainScipt.spawnBoulder = true;
         snow.SetActive(true);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);

       }
       else if(name.Equals("Checkpoint2")){ // after snow
         
         Debug.Log("Entered Checkpoint2");

         if(reachedCheckpoint1 && !reachedCheckpoint3 && !reachedCheckpoint4 && !reachedCheckpoint5 && !reachedCheckpoint6){
           reachedCheckpoint2 = true;
         }
         else{
           Debug.Log("Missed Previous checkpoint");
         }

         terrainScipt.spawnBoulder = true;
         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);

       }
       else if(name.Equals("Checkpoint3")){ // before wrecking balls
         
         Debug.Log("Entered Checkpoint3");
         
         if(reachedCheckpoint1 && reachedCheckpoint2 && !reachedCheckpoint4 && !reachedCheckpoint5 && !reachedCheckpoint6){
           reachedCheckpoint3 = true;
         }
         else{
           Debug.Log("Missed Previous checkpoint");
         }

         terrainScipt.spawnBoulder = false;
         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(true);

       }
       else if(name.Equals("Checkpoint4")){// after wrecking balls and before beach
         
         Debug.Log("Entered Checkpoint4");
         
         if(reachedCheckpoint1 && reachedCheckpoint2 && reachedCheckpoint3 && !reachedCheckpoint5 && !reachedCheckpoint6){
           reachedCheckpoint4 = true;
         }
         else{
           Debug.Log("Missed Previous checkpoint");
         }

         terrainScipt.spawnBoulder = false;
         snow.SetActive(false);
         waterfall.SetActive(true);
         wreckingBalls.SetActive(false);

       }
       else if(name.Equals("Checkpoint5")){ // after beach
         
         Debug.Log("Entered Checkpoint5");
         
         if(reachedCheckpoint1 && reachedCheckpoint2 && reachedCheckpoint3 && reachedCheckpoint4 && !reachedCheckpoint6){
           reachedCheckpoint5 = true;
         }
         else{
           Debug.Log("Missed Previous checkpoint");
         }

         terrainScipt.spawnBoulder = false;
         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);

       }
       else if(name.Equals("Checkpoint6")){ // before wind tunnel
         
         Debug.Log("Entered Checkpoint6");
         
         if(reachedCheckpoint1 && reachedCheckpoint2 && reachedCheckpoint3 && reachedCheckpoint4 && reachedCheckpoint5){
           reachedCheckpoint6 = true;
         }
         else{
           Debug.Log("Missed Previous checkpoint");
         }

         terrainScipt.spawnBoulder = false;
         snow.SetActive(false);
         waterfall.SetActive(false);
         wreckingBalls.SetActive(false);

       }
       else{
         Debug.Log("checkpoint not found");
       }
   }



   public static bool reachedAllCheckpoints(){
     return reachedCheckpoint1 && reachedCheckpoint2 && reachedCheckpoint3 && reachedCheckpoint4 && reachedCheckpoint5 && reachedCheckpoint6;
   }

   public static void restartAllCheckpoints(){
    reachedCheckpoint1 = false;
    reachedCheckpoint2 = false;
    reachedCheckpoint3 = false;
    reachedCheckpoint4 = false;
    reachedCheckpoint5 = false;
    reachedCheckpoint6 = false;
   }

}
