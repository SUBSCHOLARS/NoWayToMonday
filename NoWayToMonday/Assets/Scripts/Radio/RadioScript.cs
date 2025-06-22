using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    [SerializeField]private AudioClip[] radioClips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(radioClips[DayCountManager.DayCount - 1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
