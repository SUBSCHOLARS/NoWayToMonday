using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PCScript : MonoBehaviour
{
    bool isNearPC = false;
    bool isPCOff = false;
    public static bool hadBeenStoppedPC = false;
    public GameObject PC;
    public GameObject PCScreen;
    public GameObject pcInteractableIcon;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = PC.GetComponent<AudioSource>();
        spriteRenderer = pcInteractableIcon.GetComponent<SpriteRenderer>();
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
            spriteRenderer.DOFade(0.5f, 2.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearPC = false;
            spriteRenderer.DOFade(0f, 2.5f);
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
