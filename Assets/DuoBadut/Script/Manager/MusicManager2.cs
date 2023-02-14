using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager2 : MonoBehaviour
{
    private AudioSource music2AudioSource;

    [SerializeField] private AudioClip[] theAudioClip;

    public int onPlay;
    // Start is called before the first frame update
    void Start()
    {
        music2AudioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic2(int music2ID)
    {
        music2AudioSource.clip = theAudioClip[music2ID];
        music2AudioSource.Play();
        music2AudioSource.loop = true;
        onPlay = music2ID;
    }

    public void StopMusic2()
    {
        music2AudioSource.Stop();
    }

    public int GetCurrentPlaying()
    {
        return onPlay;
    }
}
