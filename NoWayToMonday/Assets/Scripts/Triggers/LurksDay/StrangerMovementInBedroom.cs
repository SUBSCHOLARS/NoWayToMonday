using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerMovementInBedroom : MonoBehaviour
{
    private AudioSource audioSource;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += new Vector3(-5f, 0, 0) * Time.deltaTime;
        if (timer >= 6f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "StrangerActivationdeletion")
        {
            this.gameObject.SetActive(false);
        }
    }
}
