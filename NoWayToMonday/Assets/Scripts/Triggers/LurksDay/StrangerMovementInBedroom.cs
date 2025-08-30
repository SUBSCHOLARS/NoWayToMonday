using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerMovementInBedroom : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-5f, 0, 0) * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "StrangerActivationdeletion")
        {
            Destroy(gameObject);
        }
    }
}
