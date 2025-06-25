using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] radioClips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRadio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayRadio()
    {
        audioSource.PlayOneShot(radioClips[DayCountManager.DayCount-1]);
    }
    public void StopRadio()
    {
        audioSource.Stop();
    }
    public void ResumeRadio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }
    public void PauseRadio()
    {
        audioSource.Pause();
    }
}
