using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Android;

public class TestingEvents : MonoBehaviour
{
    // ----- Part 1 ----
    // Create an event trigger everytime hit "space" and calculate how many time a "space" been hit in the TestingEvents script.
    
    // public event EventHandler<OnSpacePressEventArgs> OnSpacePress;
    // public class OnSpacePressEventArgs : EventArgs
    // {
    //     public int spaceCount;
    // }
    // int spaceCount;
    // public void Awake()
    // {
    //     OnSpacePress += Testing_OnSpacePress;
    // }
    //
    // public void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         spaceCount++;
    //         OnSpacePress?.Invoke(this, new OnSpacePressEventArgs {spaceCount = spaceCount});
    //     }
    // }
    // void Testing_OnSpacePress(object sender, OnSpacePressEventArgs e)
    // {
    //     Debug.Log("TestingEvent: space hit! " + e.spaceCount);
    // }
    
    
    // ----- Part 2 -----
    // Create an event trigger everytime hit "space" and calculate how many time a "space" been hit
    // but separating logic and visuals.
    // event and trigger in TestingEvent, function to called in TestingEventSubcriber.
    // 

    public event EventHandler<OnSpacePressEventArgs> OnSpacePress;
    public class OnSpacePressEventArgs : EventArgs
    {
       public int countSpace;
    }

    int countSpace;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countSpace++;
            OnSpacePress?.Invoke(this, new OnSpacePressEventArgs{countSpace = countSpace});
        }
    }
}
