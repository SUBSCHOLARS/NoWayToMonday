using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class KnifeBadEndFlowchartExecutor : MonoBehaviour
{
    [SerializeField] private Flowchart KnifeBadEndFlowchart;
    // Start is called before the first frame update
    void Start()
    {
        KnifeBadEndFlowchart.ExecuteBlock("KnifeBadEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
