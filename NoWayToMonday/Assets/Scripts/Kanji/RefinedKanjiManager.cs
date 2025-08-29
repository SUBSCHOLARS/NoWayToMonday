using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class RefinedKanjiManager : MonoBehaviour
{
    public Flowchart flowchart;
    public static string savedKanji;
    private string savedReading;
    public static string furiganaText;
    int sizePercentage;
    float horizontalOffset;
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
        { "瀛", "うみ" }
    };
    private Dictionary<string, string> rareKanjiDictionary = new Dictionary<string, string>
    {
        { "彁", " " },
        { "墸", "  " },
        { "妛", "    " },
        { "蟐", "   " }
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
        switch (CurrentReading.Length)
        {
            case 1:
                sizePercentage = 75;
                horizontalOffset = -0.9f;
                break;
            case 2:
                sizePercentage = 50;
                horizontalOffset = -1.0f;
                break;
            case 3:
                sizePercentage = 40;
                horizontalOffset = -1.15f;
                break;
            default:
                sizePercentage = 30;
                horizontalOffset = -1.3f;
                break;
        }
        sourceDictionary.Remove(randomKey); // Remove the selected kanji to ensure uniqueness
    }
    public void SetRandomKanjiForSpecificSay()
    {
        GetRandomRefinedKanji();
        if (!string.IsNullOrEmpty(CurrentKanji))
        {
            furiganaText = $"{CurrentKanji}<space={horizontalOffset}em><voffset=1em><size={sizePercentage}%>{CurrentReading}</size></voffset>";
            flowchart.SetStringVariable("currentKanji", furiganaText);
            flowchart.SetStringVariable("currentReading", CurrentReading);
            flowchart.SetStringVariable("pureCurrentKanji", CurrentKanji);
            // savedKanji = furiganaText; // Store the current kanji for repeat use
            savedReading = CurrentReading; // Store the current reading for repeat use
        }
        else
        {
            Debug.LogWarning("No kanji has been generated yet.");
        }
    }
    public void RepeatRandomKanjiForSpecificSay()
    {
        flowchart.SetStringVariable("repeatKanji", savedKanji);
        //flowchart.SetStringVariable("repeatReading", savedKanji);
    }
    public void SetBeforeKanji()
    {
        savedKanji = furiganaText;
    }

}
