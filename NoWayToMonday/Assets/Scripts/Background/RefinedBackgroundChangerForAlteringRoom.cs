using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefinedBackgroundChangerForAlteringRoom : MonoBehaviour
{
    public GameObject Room;
    public GameObject AlteredRoom;
    public GameObject Brother;
    public GameObject Reason2;
    public GameObject NormalCalendar;
    public GameObject AlteredCalendar;
    public GameObject Lunastasis;
    // Start is called before the first frame update
    void Start()
    {
        switch (DayCountManager.DayCount)
        {
            case 3:
                NormalCalendar.SetActive(false);
                AlteredCalendar.SetActive(true);
                break;
            case 5:
                Lunastasis.SetActive(true);
                break;
            case 7:
                Room.SetActive(false);
                AlteredRoom.SetActive(true);
                if (Brother.activeSelf)
                {
                    Destroy(Brother);
                }
                Reason2.SetActive(true);
                break;
            case 8:
                //惰眠を貪るエンド
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
