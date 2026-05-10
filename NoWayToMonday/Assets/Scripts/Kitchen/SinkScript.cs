using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using DG.Tweening;

public class SinkScript : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    public AudioClip drippingSound;
    bool isNearFaucet = false;
    bool isDripStopped=false;
    private bool isSandStopped = false;
    public static bool hadBeenStoppedDrip = false;
    public static bool isSand = false;
    public Flowchart PodFlowchart;
    public static bool isPodFilled = false;
    public GameObject faucetInteractableIcon;
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
        // 砂・ポッド関連のインタラクションは廃止（SinkNarrativeScriptに移行）
        // if (!isSand && isNearFaucet && !isDripStopped && Input.GetMouseButtonDown(0)) { ... }
    }
    public void DripSound()
    {
        audioSource.PlayOneShot(drippingSound);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearFaucet = true;
            spriteRenderer.DOFade(0.5f, 2.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearFaucet = false;
            spriteRenderer.DOFade(0f, 2.5f);
        }
    }
}
