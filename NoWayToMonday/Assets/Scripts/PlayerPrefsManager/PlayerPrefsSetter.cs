using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End1Seen()
    {
        PlayerPrefs.SetInt("End1Seen", 1);
    }
    public void End2Seen()
    {
        PlayerPrefs.SetInt("End2Seen", 1);
    }
    public void End3Seen()
    {
        PlayerPrefs.SetInt("End3Seen", 1);
    }
    public void End4Seen()
    {
        PlayerPrefs.SetInt("End4Seen", 1);
    }
}
