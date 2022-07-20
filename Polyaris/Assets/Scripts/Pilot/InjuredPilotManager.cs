using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjuredPilotManager : MonoBehaviour
{
    public GameObject pickUpPilotText;
    public Animator playerAnimator;
    public Transform player;
    public Collider capsuleCollider;
    public Collider boxCollider;
    public Opsive.Shared.Input.UnityInput inputScript;
    public Opsive.UltimateCharacterController.Character.UltimateCharacterLocomotionHandler locomotionScript;

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
        pickUpPilotText.SetActive(false);
        capsuleCollider.enabled = false;
        boxCollider.enabled = false;
        inputScript.enabled = false;
        locomotionScript.enabled = false;

        StartCoroutine("PilotParentingDelay");
    }

    IEnumerator PilotParentingDelay()
    {
        yield return new WaitForSeconds(4f);

        ParentPilotToPlayer();
    }

    void ParentPilotToPlayer()
    {
        transform.SetParent(player);
        inputScript.enabled = true;
        locomotionScript.enabled = true;
        transform.localPosition = pilotFinalPosition;
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
