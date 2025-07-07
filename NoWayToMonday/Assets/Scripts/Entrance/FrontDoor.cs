using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
    private bool isOnDoor = false;
    public Flowchart OpenFlowchat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnDoor && Input.GetKeyDown(KeyCode.Space))
        {
            OpenFlowchat.ExecuteBlock("Open");
        }
    }
    void OnCollisionStay2D(UnityEngine.Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            isOnDoor = true;
        }
    }
}
