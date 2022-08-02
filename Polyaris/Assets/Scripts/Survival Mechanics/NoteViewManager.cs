using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PadlockSystem;

public class NoteViewManager : MonoBehaviour
{
    public GameObject clipboardObject;
    public GameObject clipboardToDisable;

    [Header("UI Prompt")]
    public GameObject interactPrompt;
    public GameObject interactExitPrompt;

    private const string playerTag = "Player";
    private bool canUse;
    private bool inZoomView = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            canUse = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            canUse = false;
            interactPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (canUse)
        {
            if (Input.GetKeyDown(PLInputManager.instance.triggerInteractKey))
            {
                PLDisableManager.instance.DisablePlayer(true);
                clipboardObject.SetActive(true);
                Camera.main.transform.localEulerAngles = new Vector3(0, 0, 0);
                interactPrompt.SetActive(false);
                clipboardToDisable.SetActive(false);
                inZoomView = true;
                interactExitPrompt.SetActive(true);
            }

            if (inZoomView && Input.GetKeyDown(KeyCode.Mouse1))
            {
                PLDisableManager.instance.DisablePlayer(false);
                clipboardObject.SetActive(false);
                interactPrompt.SetActive(true);
                clipboardToDisable.SetActive(true);
                inZoomView = false;
                interactExitPrompt.SetActive(false);
            }
        }
    }
}
