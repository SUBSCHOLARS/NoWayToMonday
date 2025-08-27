using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using DG.Tweening;

public class FridgeScript : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    bool isNearFridge = false;
    bool isMove = false;
    public GameObject faucetInteractableIcon;
    Camera mainCamera;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        animator = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        spriteRenderer = faucetInteractableIcon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearFridge && !isMove && Input.GetMouseButtonDown(0))
        {
            isMove = true;
            mainCamera.transform.position = new Vector3(55f,25f,-10f);
        }
        else if (isNearFridge && Input.GetMouseButtonDown(0))
        {
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearFridge = true;
            spriteRenderer.DOFade(0.5f, 2.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearFridge = false;
            spriteRenderer.DOFade(0f, 2.5f);
        }
    }
}
