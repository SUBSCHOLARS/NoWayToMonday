using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public GameObject Kitchen;
    public GameObject AlteredKitchen;
    public GameObject Room;
    public GameObject AlteredRoom;
    public GameObject Brother;
    public GameObject Reason2;
    public GameObject NormalCalendar;
    public GameObject AlteredCalendar;
    public Flowchart SleepFlowchart;
    // Start is called before the first frame update
    void Start()
    {
        // if(DayCountManager.DayCount==7)
        // {
        //     Room.SetActive(false);
        //     AlteredRoom.SetActive(true);
        //     Destroy(Brother);
        //     Reason2.SetActive(true);
        //     Debug.Log("Altered!");
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AlteringKitchen()
    {
        Kitchen.SetActive(false);
        AlteredKitchen.SetActive(true);
    }
    public void AlteringRoom()
    {
        int counter = SleepFlowchart.GetIntegerVariable("DayCount");
        if (counter == 7)
        {
            Room.SetActive(false);
            AlteredRoom.SetActive(true);
            Destroy(Brother);
            Reason2.SetActive(true);
            Debug.Log("Altered!");
        }
        else if (counter == 2)
        {
            NormalCalendar.SetActive(false);
            AlteredCalendar.SetActive(true);
        }
    }
}
