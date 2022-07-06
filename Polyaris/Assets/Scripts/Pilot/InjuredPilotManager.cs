using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjuredPilotManager : MonoBehaviour
{
    public GameObject pickUpPilotText;
    public Animator playerAnimator;

    private bool canPickUpPilot = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canPickUpPilot)
            {
                PickUpPilot();
            }
        }
    }

    void PickUpPilot()
    {
        playerAnimator.SetTrigger("Pick Up Pilot");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpPilotText.SetActive(true);
            canPickUpPilot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpPilotText.SetActive(false);
            canPickUpPilot = false;
        }
    }
}
