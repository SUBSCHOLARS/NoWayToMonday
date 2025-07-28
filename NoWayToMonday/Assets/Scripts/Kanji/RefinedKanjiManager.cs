using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class RefinedKanjiManager : MonoBehaviour
{
    public Flowchart flowchart;
    private string randomKanji;
    private List<string> refinedKanjiList = new List<string>
    {
        "衊", "寢", "蔽", "瞵", "錆", "靈", "蕐", "翳", "蠱", "瀛"
    };
    private List<string> rareKanjiList = new List<string>
    {
        "彁", "墸", "妛", "蟐"
    };
    public string GetRandomRefinedKanji()
    {
        float weight = Random.Range(0f, 1f);
        if (weight < 0.1f && rareKanjiList.Count > 0) // 10% chance to get a rare kanji
        {
            int randomIndex = Random.Range(0, rareKanjiList.Count);
            randomKanji = rareKanjiList[randomIndex];
            rareKanjiList.RemoveAt(randomIndex); // Remove to ensure uniqueness
            return randomKanji;
        }
        else
        {
            int randomIndex = Random.Range(0, refinedKanjiList.Count);
            randomKanji = refinedKanjiList[randomIndex];
            refinedKanjiList.RemoveAt(randomIndex); // Remove to ensure uniqueness
            return randomKanji;
        }
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
