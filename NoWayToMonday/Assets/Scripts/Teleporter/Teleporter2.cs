using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Teleporter2 : MonoBehaviour
{
    public GameObject player;
    public GameObject MainCamera;
    public GameObject Reason;
    public AudioManager audioManager;
    public Flowchart flowchart;
    public Flowchart ComeBackAndFoundBrotherMissingFlowChart;
    bool isMoveNormally = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlayAuido();
            player.transform.position = new Vector3(84.8f, -7.2f, 0f);
            MainCamera.transform.position = new Vector3(94.9f, -0.66f, -10f);
        }
    }
}
