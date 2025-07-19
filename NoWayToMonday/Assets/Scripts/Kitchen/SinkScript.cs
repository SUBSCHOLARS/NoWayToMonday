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
    bool isSandStopped = false;
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
        if (!isSand && isNearFaucet && !isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsDripping", false);
            audioSource.PlayOneShot(audioSource.clip);
            isDripStopped = true;
            hadBeenStoppedDrip = true;
        }
        else if (!isSand && isNearFaucet && isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsDripping", true);
            isDripStopped = false;
            hadBeenStoppedDrip = false;
        }
        else if (!PodScript.isPodTaken&&isSand && isNearFaucet && !isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsSand", false);
            audioSource.PlayOneShot(audioSource.clip);
            isSandStopped = true;
        }
        else if (!PodScript.isPodTaken&&isSand && isNearFaucet && isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsSand", true);
            isSandStopped = false;
        }
        else if (isSand&&PodScript.isPodTaken && isNearFaucet && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Filled");
            animator.SetBool("IsSand", false);
            PodFlowchart.ExecuteBlock("PodFill");
            isPodFilled = true;
        }
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
