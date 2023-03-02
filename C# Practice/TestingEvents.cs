using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Android;

public class TestingEvents : MonoBehaviour
{
    // // Define the event / accessor.
    // // EventHandler is a delegate with two fields.
    // public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    // public class OnSpacePressedEventArgs : EventArgs
    // {
    //     public int spaceCount;
    // }
    //
    // int spaceCount;
    // void Start()
    // {
    //
    // }
    //
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         //for the trigger
    //         // OnSpacePressed(this, EventArgs.Empty); <== this will raise an error because it don't have any subscribers.
    //         // First test the event is not null.
    //         spaceCount ++;
    //         OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs{spaceCount = spaceCount});
    //     }
    // }
    
    // public static Action Ondelegate = delegate { };
    //
    // public void Awake()
    // {
    //     Ondelegate += function;
    // }
    //
    // public void function()
    // {
    //     Debug.Log("hello world");
    // }
    
    
    // Create an event trigger everytime hit "space" and calculate how many time a "space" been hit in the TestingEvents script,

    public event EventHandler<OnSpacePressEventArgs> OnSpacePress;
    public class OnSpacePressEventArgs : EventArgs
    {
        public int spaceCount;
    }
    int spaceCount;
    public void Awake()
    {
        OnSpacePress += SpacePress;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount++;
            OnSpacePress?.Invoke(this, new OnSpacePressEventArgs {spaceCount = spaceCount});
        }
    }
    void SpacePress(object sender, OnSpacePressEventArgs e)
    {
        Debug.Log("space hit! " + e.spaceCount);
    }
    
    
}
