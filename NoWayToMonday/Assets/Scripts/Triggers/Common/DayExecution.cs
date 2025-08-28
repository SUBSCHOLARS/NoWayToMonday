using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class DayExecution : MonoBehaviour
{
    public Flowchart flowchart;
    public void ExecuteBlossoday()
    {
        flowchart.ExecuteBlock("Blossoday");
    }
    public void ExecuteLurksday()
    {
        flowchart.ExecuteBlock("Lurksday");
    }
    public void ExecuteGazeday()
    {
        flowchart.ExecuteBlock("Gazeday");
    }
    public void ExecuteUmbraday()
    {
        flowchart.ExecuteBlock("Umbraday");
    }
    public void ExecuteRottsday()
    {
        flowchart.ExecuteBlock("Rottsday");
    }
    public void ExecuteCurseday()
    {
        flowchart.ExecuteBlock("Curseday");
    }
    public void ExecuteMaulsday()
    {
        flowchart.ExecuteBlock("Maulsday");
    }
    public void ExecuteShrauday()
    {
        flowchart.ExecuteBlock("Seepsday");
    }
}
