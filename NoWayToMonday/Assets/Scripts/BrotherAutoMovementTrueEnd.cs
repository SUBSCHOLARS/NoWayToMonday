using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrotherAutoMovementTrueEnd : MonoBehaviour
{
    public float speed=10.0f;
    private bool BrotherMove=false;
    //public GameObject KnifeInverse;
    //public GameObject StabbingSound;
    //public GameObject Bleeding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BrotherMove)
        {
            transform.position+=new Vector3(1,0,0)*speed*Time.deltaTime;
        }
    }
    public void BrotherMoving(bool brotherEnable)
    {
        BrotherMove=brotherEnable;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //KnifeInverse.SetActive(true);
            //StabbingSound.SetActive(true);
            //Bleeding.SetActive(true);
            SceneManager.LoadSceneAsync("TrueEnd");
        }
    }
}
