using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class TriggerSay : MonoBehaviour
{
    public Flowchart flowchart;
    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || hasTriggered) return;
        hasTriggered = true;
        DayKanjiDatabase.SetKanjiToFlowchart(flowchart, DayCountManager.DayCount);
        switch (DayCountManager.DayCount)
        {
            case 1:  flowchart.ExecuteBlock("DayOne");           break;
            case 2:  flowchart.ExecuteBlock("DayTwo");           break;
            case 3:  flowchart.ExecuteBlock("DayThree");         break;
            case 4:  flowchart.ExecuteBlock("DayFour");          break;
            case 5:  flowchart.ExecuteBlock("DayFiveNoBrother"); break;
            case 6:  flowchart.ExecuteBlock("DaySix");           break;
            case 7:  flowchart.ExecuteBlock("DaySeven");         break;
            default: flowchart.ExecuteBlock("DayOne");           break;
        }
    }

    public void ResetTrigger() => hasTriggered = false;
}
