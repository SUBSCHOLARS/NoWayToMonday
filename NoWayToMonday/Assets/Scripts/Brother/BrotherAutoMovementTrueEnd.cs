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
    public GameObject[] gameObjectsToBeFalse;
    public GameObject[] gameObjectsToBeTrue;
    AudioSource audioSource;
    public AudioClip Bleeding;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * 0.05f * Time.deltaTime;
        if (BrotherMove)
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
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
            audioSource.PlayOneShot(audioSource.clip,1.0f);
            audioSource.PlayOneShot(Bleeding);
            if (SinkScript.hadBeenStoppedDrip && ExtrovertFanScript.hadBeenStoppedFan && TVScript.hadBeenStoppedTV&&PCScript.hadBeenStoppedPC)
            {
                FlowchartExtendedTrueEnd.ExecuteBlock("ExtendedTrueEvent");
                foreach (GameObject obj in gameObjectsToBeFalse)
                {
                    obj.SetActive(false);
                }
                foreach (GameObject obj in gameObjectsToBeTrue)
                {
                    obj.SetActive(true);
                }
                transform.gameObject.SetActive(false);
            }
            else
            {
                SceneManager.LoadSceneAsync("TrueEnd");
            }
        }
    }
}
