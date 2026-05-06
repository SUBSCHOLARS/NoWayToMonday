using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] radioClips;
    AudioSource audioSource;
    bool isNearRadio = false;
    public static bool hadBeenStoppedRadio = false;
    public GameObject radioInteractableIcon;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = radioInteractableIcon.GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearRadio = true;
            spriteRenderer.DOFade(0.5f, 2.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearRadio = false;
            spriteRenderer.DOFade(0f, 2.5f);
        }
    }
}
