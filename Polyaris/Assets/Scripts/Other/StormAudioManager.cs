using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormAudioManager : MonoBehaviour
{
    public AudioSource[] soundsToControl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var s in soundsToControl)
            {
                s.volume = 0.1f; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var s in soundsToControl)
            {
                s.volume = 1f;
            }
        }
    }
}
