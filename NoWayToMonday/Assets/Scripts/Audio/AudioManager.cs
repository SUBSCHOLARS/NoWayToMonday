using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        if(audioSource!=null&&audioClip!=null)
        {
            audioSource.clip=audioClip;
        }
    }

    public void PlayAuido()
    {
        if(audioSource!=null&&!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void StopAudio()
    {
        if(audioSource!=null&&audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
