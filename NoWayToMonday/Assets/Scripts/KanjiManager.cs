using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class KanjiManager : MonoBehaviour
{
    public Flowchart flowchart;
    public UniqueRandomKanjiGenerator uniqueRandomKanjiGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveGeneratedKanji()
    {
        Debug.Log(uniqueRandomKanjiGenerator.LastGeneratedKanji);
        flowchart.SetStringVariable("LastGeneratedKanji",uniqueRandomKanjiGenerator.LastGeneratedKanji);
        Debug.Log("Kanji is set!");
    }
}
