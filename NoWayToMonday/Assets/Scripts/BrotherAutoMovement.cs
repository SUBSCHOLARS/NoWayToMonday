using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrotherAutoMovement : MonoBehaviour
{
    public GameObject[] Brothers;
    public float switchinterval=0.1f;
    public float speed=30f;
    public bool isBrotherMove=false;
    public GameObject StabbingSound;
    public GameObject Bleeding;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(isBrotherMove);
    }

    // Update is called once per frame
    void Update()
    {
        if(isBrotherMove)
        {
            transform.position+=new Vector3(1,0,0)*speed*Time.deltaTime;
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
            StabbingSound.SetActive(true);
            Bleeding.SetActive(true);
            SceneManager.LoadScene("BadEnd");
        }
    }
}
