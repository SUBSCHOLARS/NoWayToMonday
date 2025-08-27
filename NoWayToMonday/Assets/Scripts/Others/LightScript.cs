using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using DG.Tweening;

public class LightScript : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    bool isNearSwitch = false;
    bool isLightOff = false;
    public GameObject faucetInteractableIcon;
    public GameObject Light;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        spriteRenderer = faucetInteractableIcon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearSwitch && !isLightOff && Input.GetMouseButtonDown(0))
        {
            Light.SetActive(false);
        }
        else if (isNearSwitch && isLightOff && Input.GetMouseButtonDown(0))
        {
            Light.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearSwitch = true;
            spriteRenderer.DOFade(0.5f, 2.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearSwitch = false;
            spriteRenderer.DOFade(0f, 2.5f);
        }
    }
}
