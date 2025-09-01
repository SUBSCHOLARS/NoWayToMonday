using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
public class PlayerMonologue : MonoBehaviour
{
    public Flowchart Monologue;
    public Light2D globalLight;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMovement.insanityLevel <= 60f)
        {
            MonoloqueSwitcher();
        }
        else
        {
            globalLight.color = Color.red;
            MonoloqueSwitcher();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void MonoloqueSwitcher()
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
}
