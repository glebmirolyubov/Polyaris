using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormAudioManager : MonoBehaviour
{
    public AudioSource[] soundsToControl;

    public GameObject audioReverbZone;

    private void Awake()
    {
        audioReverbZone.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioReverbZone.SetActive(true);

            foreach (var s in soundsToControl)
            {
                StartCoroutine(ReduceVolume(s));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioReverbZone.SetActive(false);

            foreach (var s in soundsToControl)
            {
                StartCoroutine(IncreaseVolumeUntilFull(s));
            }
        }
    }

    private IEnumerator IncreaseVolumeUntilFull(AudioSource s)
    {
        while (s.volume < 1)
        {
            s.volume += 0.003f;
            yield return null;
        }
    }

    private IEnumerator ReduceVolume(AudioSource s)
    {
        while (s.volume > 0.2)
        {
            s.volume -= 0.003f;
            yield return null;
        }
    }

}
