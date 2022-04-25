using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public ColdManager coldManagerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coldManagerScript.damagePlayer = false;
            coldManagerScript.ResetTimer();
            coldManagerScript.StartTimer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coldManagerScript.damagePlayer = true;
            coldManagerScript.StartTimer();
        }
    }
}
