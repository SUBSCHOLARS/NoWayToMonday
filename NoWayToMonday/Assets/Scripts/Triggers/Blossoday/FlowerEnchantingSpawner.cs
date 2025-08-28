using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerEnchantingSpawner : MonoBehaviour
{
    [Header("発生させる異常オブジェクト")]
    public GameObject[] anomalyPrefabs;
    private bool isActivated = false;
    private string[] penaltyNames;

    public void Activate()
    {
        if (isActivated || anomalyPrefabs.Length == 0)
        {
            return;
        }

        GameObject selectedAnomaly = anomalyPrefabs[Random.Range(0, anomalyPrefabs.Length)];
        GameObject spawned = Instantiate(selectedAnomaly, transform.position, transform.rotation, transform);

        if (spawned.name.Contains("TVBlueFlower"))
        {
            penaltyNames = new string[] { "BlueFlower", "BlueFlowerUI" };
        }
        else if (spawned.name.Contains("TVRedFlower"))
        {
            penaltyNames = new string[] { "RedFlower", "RedFlowerUI" };
        }
        else if (spawned.name.Contains("TVYellowFlower"))
        {
            penaltyNames = new string[] { "YellowFlower", "YellowFlowerUI" };
        }
        else
        {
            penaltyNames = new string[0];
        }
        PenaltyManager.Instance.RegisterPenaltyZone(spawned, penaltyNames);
        isActivated = true;
    }
}
