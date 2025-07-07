using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
    private bool isOnDoor = false;
    public Flowchart OpenFlowchat;
    bool isFirst = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnDoor && Input.GetKeyDown(KeyCode.Space) && isFirst)
        {
            OpenFlowchat.ExecuteBlock("Open");
            isFirst = false;
        }
        else if (isOnDoor && Input.GetKeyDown(KeyCode.Space) && !isFirst)
        {
            
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
