using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class BlossoDayRoomsSetting : MonoBehaviour
{
    int randomRoomNum=3;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMovement.insanityLevel <= 50f)
        {
            randomRoomNum = Random.Range(3, 5);
            
        }    
    }
}
