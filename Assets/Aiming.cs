using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

    float sleepTimer, sleepTrigger;
    float mousePosY, mousePosX;
    float beforeY, beforeX;

    // Use this for initialization
    void Start () {
        sleepTimer = 0;
        sleepTrigger = 15f;
        mousePosX = 0;
        mousePosY = 0;
    }

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        updateVisibility();
        //Cursor.visible = true;
        SetPositions();
        RotateAiming();

    }

    void SetPositions()
    {
        if ((Input.GetAxis("Mouse X") > -0.4 && Input.GetAxis("Mouse X") < 0.4) &&
            (Input.GetAxis("Mouse Y") > -0.4 && Input.GetAxis("Mouse Y") < 0.4))
        {
            return;
        }
        beforeY = mousePosY;
        beforeX = mousePosX;

        mousePosX = Input.GetAxis("Mouse X");
        mousePosY = Input.GetAxis("Mouse Y");

        //Debug.Log(Input.GetAxis("Mouse X") + " " + Input.GetAxis("Mouse Y"));

    }

    void RotateAiming()
    {
        transform.rotation = Quaternion.Euler(0, 0, GetRotation());
    }

    public float GetRotation()
    {
        float beforeRadians = Mathf.Atan2(beforeY, beforeX);
        float beforeAngle = 1 * beforeRadians * (180 / Mathf.PI);

        float radians = Mathf.Atan2( mousePosY, mousePosX);
        float angle = 1 * radians * (180 / Mathf.PI);

        angle = getAvgAngle(angle, beforeAngle);

        //Debug.Log(angle + " " + beforeAngle);

        if ((180+ beforeAngle+45 <= angle) && (180 + beforeAngle-45 >= angle))
        {
            return beforeAngle;
        }

        return angle;
    }

    protected float getAvgAngle(float angle, float beforeAngle)
    {
        if ((angle - beforeAngle) <= 20 && (angle - beforeAngle) >= -20)
        {
            float avg = (angle + beforeAngle) / 2;
            //Debug.Log("avg: " + avg);
            return avg;
        }
        return angle;
    }

    protected void updateVisibility()
    {
        updateTimer();
        if (Sleeping())
            GetComponent<Renderer>().enabled = false;
        else
            GetComponent<Renderer>().enabled = true;

        //Debug.Log(sleepTimer);
    }

    private void updateTimer()
    {
        if (beforeX == mousePosX && beforeY == mousePosY)
        {
            if (sleepTimer < sleepTrigger)
            {
                sleepTimer += Time.deltaTime;
            }else
                sleepTimer = sleepTrigger;
        }
        else
            sleepTimer = 0;
    }

    public bool Sleeping()
    {
        bool sleeping = sleepTimer >= sleepTrigger;
        //Debug.Log(sleeping);
        return sleeping;
    }
}
