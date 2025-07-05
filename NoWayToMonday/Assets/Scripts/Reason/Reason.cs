using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Reason : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject PlayerStopper;
    public string message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Player"))
        {
            flowchart.SendFungusMessage(message);
            PlayerStopper.SetActive(true);
        }
    }
}
