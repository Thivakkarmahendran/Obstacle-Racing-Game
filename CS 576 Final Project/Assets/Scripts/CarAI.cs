using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform carPath;
    private List<Transform> nodes;
    public float maxSteerAngle = 40f;
    public float motorForce = 50f;
    public float max_speed = 100f;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    private int curNode;
    void Start()
    {
        Transform[] pathTransforms = carPath.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i < pathTransforms.Length; i++){
            if(pathTransforms[i] != carPath.transform){
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleSteering();
        HandleMotor();
        IncrementWaypoint();
    }

    void HandleSteering(){
        Vector3 vec = transform.InverseTransformPoint(nodes[curNode].position);
        vec = vec/Vector3.Magnitude(vec);
        float steerAngle = (vec.x/Vector3.Magnitude(vec)) * maxSteerAngle;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }
    void HandleMotor(){
        if(2 * Mathf.PI * frontLeftWheelCollider.radius * frontLeftWheelCollider.rpm * 60 / 1000 < max_speed){
            frontLeftWheelCollider.motorTorque = motorForce;
            frontRightWheelCollider.motorTorque = motorForce;
        }
        else{
            frontLeftWheelCollider.motorTorque = 0;
            frontRightWheelCollider.motorTorque = 0;
        }
    }
    void IncrementWaypoint(){
        if(Vector3.Distance(transform.position, nodes[curNode].position) < 2){
            curNode += 1;
            if(curNode == nodes.Count)
                curNode = 0;
        }
    }
}
