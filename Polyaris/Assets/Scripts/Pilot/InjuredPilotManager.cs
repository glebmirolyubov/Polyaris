using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjuredPilotManager : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator pilotAnimator;
    public Transform player;
    public Transform pilotRelocationPoint;
    public Collider capsuleCollider;
    public Collider boxCollider;

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
        capsuleCollider.enabled = false;

        StartCoroutine("PilotParentingDelay");
    }

    IEnumerator PilotParentingDelay()
    {

        yield return new WaitForSeconds(1f);

        playerAnimator.SetTrigger("Pick Up Pilot");
        playerAnimator.SetBool("Injured State", true);

        yield return new WaitForSeconds(5f);

        transform.SetParent(pilotRelocationPoint);

        yield return new WaitForSeconds(2f);

        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        //pilotAnimator.SetTrigger("Stand Up");

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !canPickUpPilot)
        {
            canPickUpPilot = true;
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