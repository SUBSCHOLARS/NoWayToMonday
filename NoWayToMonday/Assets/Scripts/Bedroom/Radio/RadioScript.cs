using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] radioClips;
    AudioSource audioSource;
    bool isNearRadio = false;
    bool isRadioOff = false;
    public static bool hadBeenStoppedRadio = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRadio();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearRadio && !isRadioOff && Input.GetKeyDown(KeyCode.Space))
        {
            PauseRadio();
            isRadioOff = true;
            hadBeenStoppedRadio = true;
        }
        else if (isNearRadio && isRadioOff && Input.GetKeyDown(KeyCode.Space))
        {
            ResumeRadio();
            isRadioOff = false;
            hadBeenStoppedRadio = false;
        }   
    }
    public void PlayRadio()
    {
        audioSource.PlayOneShot(radioClips[DayCountManager.DayCount - 1]);
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearRadio = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearRadio = false;
        }
    }
}
