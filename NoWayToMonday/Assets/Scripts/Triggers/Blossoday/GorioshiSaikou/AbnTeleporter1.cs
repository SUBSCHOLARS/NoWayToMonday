using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        switch (SceneManager.GetActiveScene().name)
        {
            case "BlossoDay":
                flowchart.ExecuteBlock("BlossoDayReason");
                break;
            case "MaulsDay":
                flowchart.ExecuteBlock("MaulsDayReason");
                break;
            case "ShurauDay":
                flowchart.ExecuteBlock("ShurauDayReason");
                break;
        }
    }
}
