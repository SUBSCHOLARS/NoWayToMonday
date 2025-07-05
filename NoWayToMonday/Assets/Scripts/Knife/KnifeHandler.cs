using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class KnifeHandler : MonoBehaviour
{
    public Flowchart KnifeFlowchart;
    public Flowchart SleepFlowchart;
    // Start is called before the first frame update
    void Start()
    {
        KnifeFlowchart.SetIntegerVariable("DayCount",DayCountManager.DayCount);
    }
    public void IncrementDayCounter(){
        DayCountManager.DayCount++;
        KnifeFlowchart.SetIntegerVariable("DayCount",DayCountManager.DayCount);
        SleepFlowchart.SetIntegerVariable("DayCount",DayCountManager.DayCount);
        Debug.Log("count up:");
        Debug.Log(DayCountManager.DayCount);
    }
    public void CheckKnifeAction(){
        int counter=KnifeFlowchart.GetIntegerVariable("DayCount");
        string action=KnifeFlowchart.GetStringVariable("selectedAction");
        if(counter==7&&action=="取る")
        {
            KnifeFlowchart.ExecuteBlock("KnifeTaken");
        }
        else if(counter!=7&&action=="取る")
        {
            KnifeFlowchart.ExecuteBlock("KnifeUnnecessary");
        }
        else if(counter==7&&action=="取らない")
        {
            KnifeFlowchart.ExecuteBlock("KnifeNotTakenFinal");
        }
        else if(counter!=7&&action=="取らない")
        {
            KnifeFlowchart.ExecuteBlock("KnifeNotTaken");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
