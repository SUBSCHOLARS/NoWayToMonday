using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedTrueEndBoolManager : MonoBehaviour
{
    public static bool foundSandisWater = false;
    public static bool foundLunastatsisisSleepingPills = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetFoundSandIsWaterTrue()
    {
        foundSandisWater = true;
    }
    public void SetFoundLunastatsisSleepingPillsTrue()
    {
        foundLunastatsisisSleepingPills = true;
    }
}
