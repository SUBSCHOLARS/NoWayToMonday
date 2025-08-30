using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Unity.VisualScripting;
public class PlayerMonologue : MonoBehaviour
{
    public Flowchart Monologue;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMovement.insanityLevel <= 60f)
        {
            switch (DayCountManager.DayCount)
            {
                case 1:
                    Monologue.ExecuteBlock("DayOneMonologue");
                    break;
                case 2:
                    Monologue.ExecuteBlock("DayTwoMonologue");
                    break;
                case 3:
                    Monologue.ExecuteBlock("DayThreeMonologue");
                    break;
                case 4:
                    Monologue.ExecuteBlock("DayFourMonologue");
                    break;
                case 5:
                    Monologue.ExecuteBlock("DayFiveMonologue");
                    break;
                case 6:
                    Monologue.ExecuteBlock("DaySixMonologue");
                    break;
                case 7:
                    Monologue.ExecuteBlock("DaySevenMonologue");
                    break;
            }
        }
        else
        {
            Debug.Log("Bad End!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
