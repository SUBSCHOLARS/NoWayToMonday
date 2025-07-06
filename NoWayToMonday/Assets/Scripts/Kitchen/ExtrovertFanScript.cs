using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrovertFanScript : MonoBehaviour
{
    public GameObject ExtrovertFan;
    Animator animator;
    AudioSource audioSource;
    bool isNearSwitch = false;
    bool isFanStopped = false;

    public static bool hadBeenStoppedFan = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = ExtrovertFan.GetComponent<Animator>();
        audioSource = ExtrovertFan.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearSwitch && !isFanStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsStopFan", true);
            audioSource.Pause();
            isFanStopped = true;
            hadBeenStoppedFan = true;
        }
        else if (isNearSwitch && isFanStopped && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsStopFan", false);
            audioSource.UnPause();
            isFanStopped = false;
            hadBeenStoppedFan = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearSwitch = true;
            Debug.Log(isNearSwitch);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearSwitch = false;
            Debug.Log(isNearSwitch);
        }
    }
}
