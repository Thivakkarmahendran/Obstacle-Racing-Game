﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {

    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 230;

    private Transform needleTranform;
    private Transform speedLabelTemplateTransform;

    private float speedMax;
    private float speed;

    private void Awake() {
        needleTranform = transform.Find("needle");
        speedLabelTemplateTransform = transform.Find("speedLabelTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        speedMax = 100f;

        CreateSpeedLabels();
    }

    private void Update() {
        HandlePlayerInput();

        //speed += 30f * Time.deltaTime;
        //if (speed > speedMax) speed = speedMax;

        needleTranform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private void HandlePlayerInput() {
        CarController car = FindObjectOfType<CarController>();
        //Debug.Log(car);
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    float acceleration = 80f;
        //    //float acceleration = car.mass;
        //    speed += acceleration * Time.deltaTime;
        //    speed = car.speed;
        //} else {
        //    float deceleration = 20f;
        //    speed -= deceleration * Time.deltaTime;
        //    speed = car.speed;
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    float brakespeed = 100f;
        //    speed -= brakespeed * Time.deltaTime;
        //    speed = car.speed;
        //}
        speed = car.rspeed;
        //Debug.Log(speed);
        speed = Mathf.Clamp(speed, 0f, speedMax);
    }

    private void CreateSpeedLabels() {
        int labelAmount = 10;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for (int i = 0; i <= labelAmount; i++) {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmount;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("speedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            speedLabelTransform.Find("speedText").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);
        }

        needleTranform.SetAsLastSibling();
    }

    private float GetSpeedRotation() {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
