using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeFocusedScript : MonoBehaviour
{
    public GameObject Open;
    public GameObject Close;
    bool isOpen=false;
    public AudioClip[] audioClips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (!isOpen)
        {
            audioSource.PlayOneShot(audioClips[0]);
            Close.SetActive(false);
            Open.SetActive(true);
        }
        else
        {
            audioSource.PlayOneShot(audioClips[1]);
            Close.SetActive(true);
            Open.SetActive(false);
        }
    }
}
