using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazedayAnomalyActivator : MonoBehaviour
{
   [Header("発生させる異常オブジェクト")]
    public GameObject[] anomalyPrefabs;
    private bool isActivated = false;

    public void Activate()
    {
        if (isActivated || anomalyPrefabs.Length == 0)
        {
            return;
        }
        float randomZRotation = Random.Range(-15f, 15f);
Quaternion randomRotation = Quaternion.Euler(0, 0, randomZRotation);
        GameObject selectedAnomaly = anomalyPrefabs[Random.Range(0, anomalyPrefabs.Length)];
        Instantiate(selectedAnomaly, transform.position, randomRotation,transform);
        isActivated = true;
        Debug.Log(gameObject.name + "で異常が発生しました！");
    }
}
