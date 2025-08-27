using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class AbnormalDayReason : MonoBehaviour
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
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            string CurrentDay = flowchart.GetStringVariable("pureCurrentKanji");
            switch (CurrentDay)
            {
                case "蕐":
                    flowchart.ExecuteBlock("BlossoDayReason");
                    break;
                case "衊":
                    flowchart.ExecuteBlock("MaulsDayReason");
                    break;
                case "寢":
                    flowchart.ExecuteBlock("ShurauDayReason");
                    break;
                case "蔽":
                    flowchart.ExecuteBlock("VeilDayReason");
                    break;
                case "瞵":
                    flowchart.ExecuteBlock("GazeDayReason");
                    break;
                case "錆":
                    flowchart.ExecuteBlock("RottsDayReason");
                    break;
                case "靈":
                    flowchart.ExecuteBlock("CursedDayReason");
                    break;
                case "翳":
                    flowchart.ExecuteBlock("UmbraDayReason");
                    break;
                case "瀛":
                    flowchart.ExecuteBlock("SeepsDayReason");
                    break;
                default:
                    flowchart.ExecuteBlock("UnDayReason");
                    break;
            }
        }
    }
}
