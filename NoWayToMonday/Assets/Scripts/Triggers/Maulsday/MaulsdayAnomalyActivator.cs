using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaulsdayAnomalyActivator : MonoBehaviour
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

        GameObject selectedAnomaly = anomalyPrefabs[Random.Range(0, anomalyPrefabs.Length)];
        Instantiate(selectedAnomaly, transform.position, transform.rotation);
        isActivated = true;
        Debug.Log(gameObject.name + "で異常が発生しました！");
    }
}
