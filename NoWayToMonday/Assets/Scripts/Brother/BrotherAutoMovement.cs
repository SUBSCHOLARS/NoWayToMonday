using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrotherAutoMovement : MonoBehaviour
{
    //public GameObject[] Brothers;
    public float switchinterval=0.1f;
    private float timer = 0f;
    public float speed = 30f;
    bool isBrotherMove=false;
    AudioSource audioSource;
    public AudioClip Bleeding;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(isBrotherMove);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 30f)
        {
            transform.position += new Vector3(1, 0, 0) * 0.05f * Time.deltaTime;
        }
        if (isBrotherMove)
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
    }
    public void BrotherMoving(bool brotherEnable)
    {
        isBrotherMove=brotherEnable;
        Debug.Log(isBrotherMove);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioSource.clip);
            audioSource.PlayOneShot(Bleeding);
            SceneManager.LoadSceneAsync("BadEnd");
        }
    }
}
