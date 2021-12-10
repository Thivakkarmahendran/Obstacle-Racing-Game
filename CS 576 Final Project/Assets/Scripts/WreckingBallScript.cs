using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallScript : MonoBehaviour
{


    Rigidbody2D rb2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.angularVelocity = velocityThreshold;

        /*
        // Make the hinge motor rotate with 90 degrees per second and a strong force.
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = 50f;
        hinge.motor = motor;
        */
    }

    void Update(){
        //push();
    }

    public void push(){

        if (transform.rotation.z > 0 && transform.rotation.z < rightPushRange && rb2d.angularVelocity > 0 && rb2d.angularVelocity < velocityThreshold){
            rb2d.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > leftPushRange && rb2d.angularVelocity < 0 && rb2d.angularVelocity > -1 * velocityThreshold){
            rb2d.angularVelocity = -1 * velocityThreshold;
        }


    }


}
