using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public delegate void BallEnterEventHandler();
    public event BallEnterEventHandler OnBallEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            OnBallEnter.Invoke();
        }
    }
}
