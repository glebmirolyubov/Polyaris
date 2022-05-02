using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundImpact : MonoBehaviour
{
    public AudioClip[] impactSoundClips;

    public AudioSource impactSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1f)
        {
            impactSound.clip = impactSoundClips[Random.Range(0, impactSoundClips.Length)];
            impactSound.Play();
        }
    }
}
