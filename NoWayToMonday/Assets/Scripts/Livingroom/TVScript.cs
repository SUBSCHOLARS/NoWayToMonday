using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    bool isNearTV = false;
    bool isTVOff = false;
    public GameObject TV;
    public GameObject Screen;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = TV.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearTV && !isTVOff&& Input.GetKeyDown(KeyCode.Space))
        {
            Screen.SetActive(false);
            audioSource.Pause();
            isTVOff = true;
        }
        else if (isNearTV && isTVOff && Input.GetKeyDown(KeyCode.Space))
        {
            Screen.SetActive(true);
            audioSource.UnPause();
            isTVOff = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearTV = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearTV = false;
        }
    }
    
}
