using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueRandomKanjiGenerator : MonoBehaviour
{
    public string LastGeneratedKanji;
    private string[] refinedKanjis= new string[]
    {
        "衊", "火", "水", "木", "金", "土", "日", "目", "眼"
    };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GenerateUniqueRandomKanji()
    {
        int startCode=0x4E00;
        int endCode=0x9FFF;
        int randomCodePoint;
        randomCodePoint=Random.Range(startCode,endCode+1);
        LastGeneratedKanji=char.ConvertFromUtf32(randomCodePoint);
        if(LastGeneratedKanji=="月"||
        LastGeneratedKanji=="火"||
        LastGeneratedKanji=="水"||
        LastGeneratedKanji=="木"||
        LastGeneratedKanji=="金"||
        LastGeneratedKanji=="土"||
        LastGeneratedKanji=="日"||
        LastGeneratedKanji=="目"||
        LastGeneratedKanji=="眼"){
            LastGeneratedKanji="彁";
        }
        return LastGeneratedKanji;
    }
}
