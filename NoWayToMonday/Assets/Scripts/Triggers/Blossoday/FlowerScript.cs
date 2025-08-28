using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
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
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            PenaltyManager.Instance.OnFlowerDestroyed(gameObject);
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isNear = true;
            Debug.Log("Triggered!");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isNear = false;
            Debug.Log("Exit!");
        }
    }
}
