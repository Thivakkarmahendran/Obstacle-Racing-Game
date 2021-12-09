using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject carGameObject;

     private void OnTriggerEnter(Collider other){
         if(other.name.Equals("Body")){
                Debug.Log("Car Damaged");

                var carController = carGameObject.GetComponent<CarController>();
                carController.gethit = true;
                carController.Hit();
         }
         
    }
}
