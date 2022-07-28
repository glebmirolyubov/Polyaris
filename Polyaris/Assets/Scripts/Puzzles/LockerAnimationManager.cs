using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerAnimationManager : MonoBehaviour
{
    public GameObject lockTrigger;

    private Animation lockerAnimation;
    private AudioSource lockerAudio;

    // Start is called before the first frame update
    void Start()
    {
        lockerAnimation = GetComponent<Animation>();
        lockerAudio = GetComponent<AudioSource>();
    }


    public void OpenLocker()
    {
        lockerAnimation.Play();
        lockTrigger.SetActive(false);
        lockerAudio.Play();
    }
}
