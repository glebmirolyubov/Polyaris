using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPuzzleManager : MonoBehaviour
{
    public GameObject openDoorInteraction;

    bool puzzleSolved = false;

    private void Start()
    {
        openDoorInteraction.SetActive(false);
    }

    public void SolvePuzzle()
    {
        openDoorInteraction.SetActive(true);
        puzzleSolved = true;
    }

}
