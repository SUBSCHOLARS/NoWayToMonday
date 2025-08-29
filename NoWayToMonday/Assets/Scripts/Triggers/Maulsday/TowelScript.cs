using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelScript : MonoBehaviour
{
    public static bool isTowelTaken = false;
    AudioSource audioSource;
    bool isNear = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioSource.clip);
            isTowelTaken = true;
            GameObject[] towels = GameObject.FindGameObjectsWithTag("Towel");
            for (int i = 0; i < towels.Length; i++)
            {
                towels[i].SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}
