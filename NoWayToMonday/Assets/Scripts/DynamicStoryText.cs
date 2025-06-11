using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DynamicStoryText : MonoBehaviour
{
    public Flowchart flowchart;
    public UniqueRandomKanjiGenerator uniqueRandomKanjiGenerator;
    public void SetRandomKanjiForSpecificSay()
    {
        flowchart.SetStringVariable("Specific", "");
        string randomKanji=uniqueRandomKanjiGenerator.GenerateUniqueRandomKanji();
        flowchart.SetStringVariable("Specific",randomKanji);
    }
    public void RepeatRandomKanjiForSpecificSay()
    {
        flowchart.SetStringVariable("RepeatKanji", "");
        string repeatOnceKanji=uniqueRandomKanjiGenerator.LastGeneratedKanji;
        flowchart.SetStringVariable("RepeatKanji", repeatOnceKanji);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
