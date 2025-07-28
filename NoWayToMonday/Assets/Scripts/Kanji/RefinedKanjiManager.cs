using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class RefinedKanjiManager : MonoBehaviour
{
    public Flowchart flowchart;
    private string randomKanji;
    private Dictionary<string, string> kanjiDictionary = new Dictionary<string, string>
    {
        { "衊", "ばつ" },
        { "寢", "ね" },
        { "蔽", "へい" },
        { "瞵", "りん" },
        { "錆", "さび" },
        { "靈", "りょう" },
        { "蕐", "はな" },
        { "翳", "かげ" },
        { "蠱", "こ" },
        { "瀛", "うみ" }
    };
    private Dictionary<string, string> rareKanjiDictionary = new Dictionary<string, string>
    {
        { "彁", "◼︎◼︎" },
        { "墸", "◼︎" },
        { "妛", "◼︎◼︎◼︎◼︎" },
        { "蟐", "◼︎◼︎◼︎" }
    };
    public string CurrentKanji { get; private set; }
    public string CurrentReading { get; private set; }
    public void GetRandomRefinedKanji()
    {
        Dictionary<string, string> sourceDictionary;
        float weight = Random.Range(0f, 1f);
        if (weight < 0.1f && rareKanjiDictionary.Count > 0) // 10% chance to get a rare kanji
        {
            sourceDictionary = rareKanjiDictionary;
        }
        else if (kanjiDictionary.Count > 0) // 90% chance to get a regular kanji
        {
            sourceDictionary = kanjiDictionary;
        }
        else
        {
            Debug.LogWarning("No kanji available to select from.");
            return;
        }
        List<string> keyList = new List<string>(sourceDictionary.Keys);
        int randomIndex = Random.Range(0, keyList.Count);
        string randomKey = keyList[randomIndex];
        string randomValue = sourceDictionary[randomKey];
        CurrentKanji = randomKey;
        CurrentReading = randomValue;
        sourceDictionary.Remove(randomKey); // Remove the selected kanji to ensure uniqueness
    }
    public void SetRandomKanjiForSpecificSay()
    {
        if(!string.IsNullOrEmpty(CurrentKanji))
        {
            string furiganaText=$"<voffset=0.9em><size=60%>{CurrentReading}</size></voffset>{CurrentKanji}";
            flowchart.SetStringVariable("Specific", "");
            flowchart.SetStringVariable("Specific", furiganaText);
            randomKanji = CurrentKanji; // Store the current kanji for repeat use
        }
        else
        {
            Debug.LogWarning("No kanji has been generated yet.");
        }
    }
    public void RepeatRandomKanjiForSpecificSay()
    {
        flowchart.SetStringVariable("RepeatKanji", "");
        flowchart.SetStringVariable("RepeatKanji", randomKanji);
    }

}
