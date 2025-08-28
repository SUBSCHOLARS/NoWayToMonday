using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TVScript : MonoBehaviour
{
    bool isNearTV = false;
    bool isTVOff = false;
    public static bool hadBeenStoppedTV = false;
    public GameObject TV;
    public GameObject Screen;
    public GameObject FlowerEnchanting;
    public GameObject tvInteractableIcon;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = TV.GetComponent<AudioSource>();
        spriteRenderer = tvInteractableIcon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearTV && !isTVOff && Input.GetKeyDown(KeyCode.Space))
        {
            Screen.SetActive(false);
            FlowerEnchanting.SetActive(true);
            audioSource.Pause();
            isTVOff = true;
            hadBeenStoppedTV = true;
        }
        else if (isNearTV && isTVOff && Input.GetKeyDown(KeyCode.Space))
        {
            Screen.SetActive(true);
            FlowerEnchanting.SetActive(false);
            audioSource.UnPause();
            isTVOff = false;
            hadBeenStoppedTV = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearTV = true;
            spriteRenderer.DOFade(0.5f, 2.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearTV = false;
            spriteRenderer.DOFade(0f, 2.5f);
        }
    }
    public void PauseTVSound()
    {
        audioSource.Pause();
    }
    public void UnpauseTVSound()
    {
        audioSource.UnPause();
    }    
}
