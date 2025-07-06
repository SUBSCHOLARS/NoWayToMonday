using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrotherAutoMovementTrueEnd : MonoBehaviour
{
    public float speed=10.0f;
    private bool BrotherMove=false;
    public Flowchart FlowchartExtendedTrueEnd;
    AudioSource audioSource;
    //public GameObject KnifeInverse;
    //public GameObject StabbingSound;
    //public GameObject Bleeding;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(audioSource.clip);
            if (SinkScript.hadBeenStoppedDrip && ExtrovertFanScript.hadBeenStoppedFan && TVScript.hadBeenStoppedTV)
            {
                FlowchartExtendedTrueEnd.ExecuteBlock("ExtendedTrueEvent");
            }
            else
            {
                SceneManager.LoadSceneAsync("TrueEnd");
            }
        }
    }
}
