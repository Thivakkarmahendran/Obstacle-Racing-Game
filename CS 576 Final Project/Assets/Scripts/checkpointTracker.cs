using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkpointTracker : MonoBehaviour
{

  private  bool reachedCheckpoint1;
  private  bool reachedCheckpoint2;
  private  bool reachedCheckpoint3;
  private  bool reachedCheckpoint4;
  private  bool reachedCheckpoint5;
  private  bool reachedCheckpoint6;
  
  private  GameObject snow;
  private  GameObject waterfall;
  private  GameObject wreckingBalls;

  public Text alertText;


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

   public  void checkPointReached(string name){

       if(name.Equals("Checkpoint1")){ // before snow
         
         Debug.Log("Entered Checkpoint1");

         if(!reachedCheckpoint2 && !reachedCheckpoint3 && !reachedCheckpoint4 && !reachedCheckpoint5 && !reachedCheckpoint6){
           reachedCheckpoint1 = true;
           alertText.text = "Reached Checkpoint 1";
         }
         else{
           Debug.Log("Missed Previous checkpoint");
           alertText.text = "Missed Previous checkpoint";
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
           alertText.text = "Reached Checkpoint 2";
         }
         else{
           Debug.Log("Missed Previous checkpoint");
           alertText.text = "Missed Previous checkpoint";
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
           alertText.text = "Reached Checkpoint 3";
         }
         else{
           Debug.Log("Missed Previous checkpoint");
           alertText.text = "Missed Previous checkpoint";
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
           alertText.text = "Reached Checkpoint 4";
         }
         else{
           Debug.Log("Missed Previous checkpoint");
           alertText.text = "Missed Previous checkpoint";
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
           alertText.text = "Reached Checkpoint 5";
         }
         else{
           Debug.Log("Missed Previous checkpoint");
           alertText.text = "Missed Previous checkpoint";
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
           alertText.text = "Reached Checkpoint 6";
         }
         else{
           Debug.Log("Missed Previous checkpoint");
           alertText.text = "Missed Previous checkpoint";
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



   public  bool reachedAllCheckpoints(){
     return reachedCheckpoint1 && reachedCheckpoint2 && reachedCheckpoint3 && reachedCheckpoint4 && reachedCheckpoint5 && reachedCheckpoint6;
   }

   public  void restartAllCheckpoints(){
    reachedCheckpoint1 = false;
    reachedCheckpoint2 = false;
    reachedCheckpoint3 = false;
    reachedCheckpoint4 = false;
    reachedCheckpoint5 = false;
    reachedCheckpoint6 = false;
   }

}
