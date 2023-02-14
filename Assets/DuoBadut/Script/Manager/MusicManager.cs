using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicAudioSource;

    [SerializeField] private AudioClip[] theAudioClip;

    public int onPlay;
    private float targetVolume;
    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        targetVolume = musicAudioSource.volume;
    }

    private void FixedUpdate()
    {
        musicAudioSource.volume = Mathf.Lerp(musicAudioSource.volume, targetVolume, Time.deltaTime * 1f);
    }

    public void PlayMusic(int musicID)
    {
        //if (onPlay == musicID)
        //{
        //    return;
        //}
        //musicAudioSource.clip = theAudioClip[musicID];
        //musicAudioSource.Play();
        //musicAudioSource.loop = true;
        //onPlay = musicID;

        StartCoroutine(FadeOutMusic(musicID));
    }

    public void StopMusic()
    {
        //musicAudioSource.Stop();
        StartCoroutine(FadeOut());
    }

    public int GetCurrentPlaying()
    {
        return onPlay;
    }

    private IEnumerator FadeOut()
    {
        while (musicAudioSource.volume > 0.1)
        {
            targetVolume = 0;
            yield return null;
        }
        musicAudioSource.Stop();
    }


    private IEnumerator FadeOutMusic(int musicID)
    {
        if (musicID != 1)
        {
            while (musicAudioSource.volume > 0.1)
            {
                //musicAudioSource.volume -= Time.deltaTime / 0.1f;
                targetVolume = 0;
                yield return null;
            }
        }

            musicAudioSource.Stop();
            musicAudioSource.clip = theAudioClip[musicID];
            musicAudioSource.Play();
            targetVolume = 1;
            musicAudioSource.loop = true;
            onPlay = musicID;
    }
}
