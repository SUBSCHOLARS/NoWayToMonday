using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullHand2 : MonoBehaviour
{
   public GameObject Open;
    public GameObject Close;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        audioSource.PlayOneShot(audioSource.clip);
        Close.SetActive(true);
        Open.SetActive(false);
    }
}
