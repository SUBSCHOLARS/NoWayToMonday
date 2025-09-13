using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeKeyTitleBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DayCountManager.DayCount = 1;
            RefinedKanjiManager.ResetKanjiDictionaries(); // ←ここでリストを復元
            SceneManager.LoadScene("Title");
        }
    }
}
