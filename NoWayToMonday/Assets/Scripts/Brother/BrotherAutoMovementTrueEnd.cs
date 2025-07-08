using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrotherAutoMovementTrueEnd : MonoBehaviour
{
    public float speed=10.0f;
    private bool BrotherMove=false;
    private float timer = 0f;
    public Flowchart FlowchartExtendedTrueEnd;
    public GameObject[] gameObjectsToBeFalse;
    public GameObject[] gameObjectsToBeTrue;
    AudioSource audioSource;
    public AudioClip Bleeding;
    public DeathTimer deathTimer;
    public GameObject TrueKnife;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 30f)
        {
            transform.position += new Vector3(1, 0, 0) * 0.01f * Time.deltaTime;
        }
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
            audioSource.PlayOneShot(Bleeding);
            TrueKnife.SetActive(false);
            if (SinkScript.hadBeenStoppedDrip && ExtrovertFanScript.hadBeenStoppedFan && TVScript.hadBeenStoppedTV && PCScript.hadBeenStoppedPC && RadioScript.hadBeenStoppedRadio)
            {
                FlowchartExtendedTrueEnd.ExecuteBlock("ExtendedTrueEvent");
                deathTimer.TimerSet(true);
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
