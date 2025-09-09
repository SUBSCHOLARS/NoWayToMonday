using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class UndayDontGoAnywhere : MonoBehaviour
{
    public Flowchart UndayFlowchart;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UndayFlowchart.ExecuteBlock("UndayDontGoAnywhere");
        }
    }
}
