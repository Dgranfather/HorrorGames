using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    private AudioSource sfxAudioSource;

    [SerializeField] private AudioClip[] theAudioClip;

    void Start()
    {
        sfxAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySfx(int sfxID)
    {
        sfxAudioSource.PlayOneShot(theAudioClip[sfxID]);
    }

    public void StopSfx()
    {
        sfxAudioSource.Stop();
    }
}
