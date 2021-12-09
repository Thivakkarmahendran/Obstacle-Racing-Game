using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderScipt : MonoBehaviour
{

    public float speed = 2;
    private Rigidbody rb;
    public GameObject carGameObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DestroyObjectDelayed();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0.0f, v);
        rb.AddForce(movement * speed);
    }

    // Kills the game object in 20 seconds after loading the object
    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 20);
    }

     private void OnTriggerEnter(Collider other){
         
         if(other.name.Equals("Body")){
                Debug.Log("Car Damaged");
                
                var carController = carGameObject.GetComponent<CarController>();
                carController.gethit = true;
         }
         
    }
}
