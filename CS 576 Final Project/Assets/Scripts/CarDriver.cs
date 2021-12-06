using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    public float speed = 0;
    public float speedMax;
    public float acceleration;
    public float deceleration;
    public float mass;
    public float brakespeed;
    public float turnSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            //float acceleration = car.mass;
            speed += acceleration * Time.deltaTime;
            //rb.AddRelativeForce(Vector3.forward * speed);
            //speed = car.speed;
        }
        else
        {
            if(speed > 0.1)
            {
                speed -= mass  * Time.deltaTime;
            }
            if (speed < -0.1)
            {
                speed += mass  * Time.deltaTime;
            }
            //rb.AddRelativeForce(Vector3.forward * speed);
            //speed = car.speed;
        }
       
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= brakespeed * Time.deltaTime;
            //rb.AddRelativeForce(Vector3.forward * speed);
            //speed = car.speed;
        }
        //speed = car.speed;
        //Debug.Log(speed);
        //speed = Mathf.Clamp(speed, 0f, speedMax);
        if (speed >= 0 && speed >= speedMax)
        {
            speed = speedMax;
        }
        else if(speed < 0 && speed <= -speedMax / 2)
        {
            speed = -speedMax / 2;
        }
        rb.AddRelativeForce(Vector3.forward * speed* 8);


        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    rb.AddRelativeForce(Vector3.forward * speed * 10);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    rb.AddRelativeForce(-Vector3.forward * speed * 10);
        //}

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(Vector3.up * turnSpeed * 5);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(-Vector3.up * turnSpeed * 5);
        }
    }
}
