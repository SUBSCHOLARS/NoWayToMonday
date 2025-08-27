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
                case 1:
                    flowchart.ExecuteBlock("DayOne");
                    break;
                case 2:
                    flowchart.ExecuteBlock("DayTwo");
                    break;
                case 3:
                    flowchart.ExecuteBlock("DayThree");
                    break;
                case 4:
                    flowchart.ExecuteBlock("DayFour");
                    break;
                case 5:
                    flowchart.ExecuteBlock("DayFive");
                    break;
                case 6:
                    flowchart.ExecuteBlock("DaySix");
                    break;
                case 7:
                    flowchart.ExecuteBlock("DaySeven");
                    break;
            }
        }
    }
}
