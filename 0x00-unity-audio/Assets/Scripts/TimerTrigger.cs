using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Triger the timer when player move</summary>
public class TimerTrigger : MonoBehaviour
{
    // Get the player gameobject to set timer to false
    public Timer timer;
    // Get the trigger box for destroy it.
    public GameObject triggerBox;

    // When the player move, enable the timer
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.enabled = true;
            Destroy(triggerBox);
        }
    }
}
