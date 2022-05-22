using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPuzzleManager : MonoBehaviour
{
    public GameObject openDoorInteraction;
    public GameObject puzzleUI;

    bool puzzleSolved = false;

    private void Start()
    {
        openDoorInteraction.SetActive(false);
    }

    public void SolvePuzzle()
    {
        openDoorInteraction.SetActive(true);
        puzzleUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzleSolved = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !puzzleSolved)
        {
            Debug.Log("Player Detected!");
            puzzleUI.SetActive(true);
            //Set Cursor to be visible
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !puzzleSolved)
        {
            puzzleUI.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
