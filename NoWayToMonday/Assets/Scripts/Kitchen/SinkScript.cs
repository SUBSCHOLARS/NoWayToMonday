using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
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
        else if (isSand && isNearFaucet && !isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsSand", false);
            audioSource.PlayOneShot(audioSource.clip);
            isSandStopped = true;
            hadBeenStoppedDrip = true;
        }
        else if (isSand && isNearFaucet && isDripStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsSand", true);
            isSandStopped = false;
            hadBeenStoppedDrip = false;
        }
        else if (PodScript.isPodTaken && isNearFaucet && Input.GetKeyDown(KeyCode.Space))
        {
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
