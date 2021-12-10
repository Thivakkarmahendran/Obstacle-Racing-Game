using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windArea : MonoBehaviour
{
    public float windStrength;
    public Vector3 windDirection;

    public void Start(){
        windStrength = 0.01f;
        windDirection = new Vector3(0f, 1f, Random.Range(-5f,5f));
    }
}
