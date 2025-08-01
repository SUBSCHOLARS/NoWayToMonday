using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodySinkScript : MonoBehaviour
{
    public GameObject AbnormalKitchen;
    Animator animator;
    AudioSource audioSource;
    public AudioClip drippingSound;
    public AudioClip stopSound;
    bool isNearFaucet = false;
    bool isDripStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = AbnormalKitchen.GetComponent<Animator>();
        audioSource = AbnormalKitchen.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearFaucet && !isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("BleedingStop");
            audioSource.PlayOneShot(stopSound);
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
