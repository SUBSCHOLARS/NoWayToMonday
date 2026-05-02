using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] endTexts;
    public static int SeenEndCounter=0;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("End1Seen", 0) == 1)
        {
            Debug.Log("End 1 has been seen.");
            endTexts[0].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("End2Seen", 0) == 1)
        {
            Debug.Log("End 2 has been seen.");
            endTexts[1].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("End3Seen", 0) == 1)
        {
            Debug.Log("End 3 has been seen.");
            endTexts[2].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("End4Seen", 0) == 1)
        {
            Debug.Log("End 4 has been seen.");
            endTexts[3].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
