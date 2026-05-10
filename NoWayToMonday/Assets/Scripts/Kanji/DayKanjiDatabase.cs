using Fungus;
using UnityEngine;

public static class DayKanjiDatabase
{
    private static readonly (string kanji, string reading)[] Entries = {
        ("翳", "かげ"),   // Day1
        ("蔽", "へい"),   // Day2
        ("瞵", "りん"),   // Day3
        ("衊", "ばつ"),   // Day4
        ("蠱", "こ"),     // Day5
        ("靈", "りょう"), // Day6
        ("寢", "ね"),     // Day7
    };

    public static void SetKanjiToFlowchart(Flowchart flowchart, int dayCount)
    {
        var (kanji, reading) = Entries[Mathf.Clamp(dayCount - 1, 0, 6)];
        string furigana = BuildFurigana(kanji, reading);
        flowchart.SetStringVariable("currentKanji", furigana);
        flowchart.SetStringVariable("currentReading", reading);
        flowchart.SetStringVariable("pureCurrentKanji", kanji);
    }

    private static string BuildFurigana(string kanji, string reading)
    {
        int sizePercentage;
        float horizontalOffset;
        switch (reading.Length)
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
        return $"{kanji}<space={horizontalOffset}em><voffset=1em><size={sizePercentage}%>{reading}</size></voffset>";
    }
}
