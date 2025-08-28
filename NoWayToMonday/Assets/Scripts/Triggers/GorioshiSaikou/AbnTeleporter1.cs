using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class AbnTeleporter1 : MonoBehaviour
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        //flowchart.ExecuteBlock("BlossoDay");
    }
}
