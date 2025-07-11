using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class AquariumScript : MonoBehaviour
{
    bool isNearAquarium = false;
    public Flowchart AquariumFlowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SinkScript.isPodFilled && isNearAquarium && Input.GetKeyDown(KeyCode.Space))
        {
            AquariumFlowchart.ExecuteBlock("FillAquariumWithSand");
            SinkScript.isPodFilled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearAquarium= true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearAquarium = false;
        }
    }
}
