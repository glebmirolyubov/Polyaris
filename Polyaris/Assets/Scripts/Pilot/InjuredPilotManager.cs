using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;

public class InjuredPilotManager : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator pilotAnimator;
    public Transform player;
    public Transform pilotRelocationPoint;
    public Collider capsuleCollider;
    public Collider boxCollider;
    public Opsive.UltimateCharacterController.Character.UltimateCharacterLocomotion locomotionScript;
    public GameObject windstormToDisable;

    private bool canPickUpPilot = false;
    private bool canDropOff = false;

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
        locomotionScript.GetAbility<Jump>().Enabled = false;
        locomotionScript.GetAbility<SpeedChange>().Enabled = false;
        windstormToDisable.SetActive(false);

        capsuleCollider.enabled = false;
        canDropOff = true;

        StartCoroutine("PilotParentingDelay");
    }

    IEnumerator PilotParentingDelay()
    {

        yield return new WaitForSeconds(1f);

        playerAnimator.SetTrigger("Pick Up Pilot");
        playerAnimator.SetBool("Injured State", true);

        yield return new WaitForSeconds(5f);

        transform.SetParent(pilotRelocationPoint);
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        yield return new WaitForSeconds(1f);

        canPickUpPilot = false;

        //pilotAnimator.SetTrigger("Stand Up");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !canPickUpPilot)
        {
            canPickUpPilot = true;
        }

        if (other.CompareTag("Pilot Drop Off") && canDropOff)
        {
            transform.SetParent(null);
            playerAnimator.SetBool("Injured State", false);
            locomotionScript.GetAbility<Jump>().Enabled = true;
            locomotionScript.GetAbility<SpeedChange>().Enabled = true;
            pilotAnimator.SetTrigger("Release Player");
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            boxCollider.enabled = false;
            capsuleCollider.enabled = true;

            canDropOff = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUpPilot = false;
        }
    }
}