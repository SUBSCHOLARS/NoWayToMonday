using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCScript : MonoBehaviour
{
    bool isNearPC = false;
    bool isPCOff = false;
    public static bool hadBeenStoppedPC = false;
    public GameObject PC;
    public GameObject PCScreen;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = PC.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearPC && !isPCOff && Input.GetKeyDown(KeyCode.Space))
        {
            PCScreen.SetActive(false);
            audioSource.Pause();
            isPCOff = true;
            hadBeenStoppedPC = true;
        }
        else if (isNearPC && isPCOff && Input.GetKeyDown(KeyCode.Space))
        {
            PCScreen.SetActive(true);
            audioSource.UnPause();
            isPCOff = false;
            hadBeenStoppedPC = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearPC = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearPC = false;
        }
    }
    public void PausePCSound()
    {
        audioSource.Pause();
    }
    public void UnpausePCSound()
    {
        audioSource.UnPause();
    }
}
