using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkScript : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    public AudioClip drippingSound;
    bool isNearFaucet = false;
    bool isDripStopped=false;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearFaucet && !isDripStopped&& Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsDripping", false);
            audioSource.PlayOneShot(audioSource.clip);
            isDripStopped = true;
        }
        else if (isNearFaucet && isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsDripping", true);
            isDripStopped = false;
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
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearFaucet = false;
        }
    }
}
