using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbingSoundScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip stabbingCallClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StabbingSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
    public void StabbingCall()
    {
        audioSource.PlayOneShot(stabbingCallClip);
    }
}
