﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static SwipeController instance;

    [SerializeField] private float throwForceXY = 1;
    [SerializeField] private float throwForceZ = 100;

    private Vector2 startPos, endPos, direction;
    private float startTapTime, endTapTime, totalTime;
    private GameObject targetObj;

    public GameObject TargetObj { get { return targetObj; } set { targetObj = value; } }

    private bool canSwipe = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
   
    }
    private void Update()
    {
        if (targetObj == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            startTapTime = Time.time;
            startPos = Input.mousePosition;
            canSwipe = true;
        }
        // etter første swipe kan man ikke styre ballen mer
        if(Input.GetMouseButtonUp(0))
        {
            endTapTime = Time.time;
            totalTime = endTapTime - startTapTime;
            endPos = Input.mousePosition;
            direction = endPos - startPos;

            targetObj.GetComponent<Rigidbody>().isKinematic = false;
            targetObj.GetComponent<Rigidbody>().AddForce(direction.x * throwForceXY, direction.y * throwForceXY, throwForceZ / totalTime);
            targetObj = null;
            canSwipe = false;
        }
    }
}
