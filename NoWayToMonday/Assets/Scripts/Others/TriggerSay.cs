using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class TriggerSay : MonoBehaviour
{
    public Flowchart flowchart;
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
        if(other.gameObject.CompareTag("Player"))
        {
            switch (DayCountManager.DayCount)
            {
                case 7:
                    flowchart.ExecuteBlock("DaySeven");
                    break;
                default:
                    flowchart.ExecuteBlock("DayOne");
                    break;
            }
        }
    }
}
