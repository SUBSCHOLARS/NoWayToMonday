using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class KnifeBadEndTextExecution : MonoBehaviour
{
    public Flowchart KnifeBadEndText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RandomNumberGenerationAndExecuteBlock()
    {
        int randomNumber = Random.Range(1, 5);
        switch (randomNumber)
        {
            case 1:
                KnifeBadEndText.ExecuteBlock("FlavorText1");
                break;
            case 2:
                KnifeBadEndText.ExecuteBlock("FlavorText2");
                break;
            case 3:
                KnifeBadEndText.ExecuteBlock("FlavorText3");
                break;
            case 4:
                KnifeBadEndText.ExecuteBlock("FlavorText4");
                break;
            default:
                Debug.LogError("Invalid random number generated: " + randomNumber);
                break;
        }
    }
}
