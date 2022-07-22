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

    private Vector3 playerOriginPos;

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

    public IEnumerator moveObject()
    {
        float totalMovementTime = 3f; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(player.transform.position, playerPickupRelocationPosition.position) > 0)
        {
            Debug.Log(Vector3.Distance(player.transform.position, playerPickupRelocationPosition.position));
            currentMovementTime += Time.deltaTime;
            player.transform.localPosition = Vector3.Lerp(playerOriginPos, playerPickupRelocationPosition.position, currentMovementTime / totalMovementTime);
            yield return null;
        }

        StartCoroutine("PilotParentingDelay");

        playerAnimator.SetTrigger("Pick Up Pilot");
        playerAnimator.SetBool("Injured State", true);
        pilotAnimator.SetTrigger("Stand Up");
        transform.SetParent(player);
    }

    void PickUpPilot()
    {
        playerOriginPos = player.position;
        pickUpPilotText.SetActive(false);
        capsuleCollider.enabled = false;
        boxCollider.enabled = false;
        inputScript.enabled = false;
        locomotionScript.enabled = false;

        StartCoroutine("moveObject");
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