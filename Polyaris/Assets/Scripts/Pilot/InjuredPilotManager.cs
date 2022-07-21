using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjuredPilotManager : MonoBehaviour
{
    public GameObject pickUpPilotText;
    public Animator playerAnimator;
    public Animator pilotAnimator;
    public Transform player;
    public Transform playerPickupRelocationPosition;
    public Collider capsuleCollider;
    public Collider boxCollider;
    public Opsive.Shared.Input.UnityInput inputScript;
    public Opsive.UltimateCharacterController.Character.UltimateCharacterLocomotionHandler locomotionScript;
    public Opsive.UltimateCharacterController.Character.UltimateCharacterLocomotion locomotionMainScript;

    Vector3 pilotFinalPosition = new Vector3(-0.5f, 0f, 0f);

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
        playerAnimator.SetBool("Injured State", true);
        pilotAnimator.SetTrigger("Stand Up");
        pickUpPilotText.SetActive(false);
        //locomotionMainScript.enabled = false;
        transform.SetParent(player);
        transform.position = playerPickupRelocationPosition.position;
        transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
        capsuleCollider.enabled = false;
        boxCollider.enabled = false;
        inputScript.enabled = false;
        locomotionScript.enabled = false;
        //locomotionMainScript.enabled = true;

        StartCoroutine("PilotParentingDelay");
    }

    IEnumerator PilotParentingDelay()
    {
        yield return new WaitForSeconds(4f);

        ParentPilotToPlayer();
    }

    void ParentPilotToPlayer()
    {
        inputScript.enabled = true;
        locomotionScript.enabled = true;
        locomotionMainScript.enabled = true;
        //transform.localPosition = pilotFinalPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !canPickUpPilot)
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