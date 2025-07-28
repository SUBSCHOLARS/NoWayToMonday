using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class RefinedKanjiManager : MonoBehaviour
{
    public Flowchart flowchart;
    private string randomKanji;
    private string[] refinedKanjis = new string[]
    {
        "衊", "寢", "蔽", "瞵", "錆", "靈", "蕐", "翳", "蠱","瀛"
    };
    public string GetRandomRefinedKanji()
    {
        int randomIndex = Random.Range(0, refinedKanjis.Length);
        randomKanji = refinedKanjis[randomIndex];
        return randomKanji;
    }
    public void SetRandomKanjiForSpecificSay()
    {
        flowchart.SetStringVariable("Specific", "");
        string randomKanji = GetRandomRefinedKanji();
        flowchart.SetStringVariable("Specific", randomKanji);
    }
    public void RepeatRandomKanjiForSpecificSay()
    {
        flowchart.SetStringVariable("RepeatKanji", "");
        flowchart.SetStringVariable("RepeatKanji", randomKanji);
    }

}
