using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour
{
    public void Start()
    {
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        testingEvents.OnSpacePress += TestingEventsOnOnSpacePress;
    }
    void TestingEventsOnOnSpacePress(object sender, TestingEvents.OnSpacePressEventArgs e)
    {
        Debug.Log("TestingEventSubscriber: Space hit! " + e.countSpace);
    }
}