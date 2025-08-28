using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomalyActivatorInPC : MonoBehaviour
{
   [Header("発生させる異常オブジェクト")]
    public Image[] anomalyPrefabs;
    private bool isActivated = false;

    public void Activate()
    {
        if (isActivated || anomalyPrefabs.Length == 0)
        {
            return;
        }

        Image selectedAnomaly = anomalyPrefabs[Random.Range(0, anomalyPrefabs.Length)];
        Image spawned = Instantiate(selectedAnomaly, transform);
        spawned.rectTransform.anchoredPosition = Vector2.zero; // 親の位置に合わせる
        isActivated = true;
        Debug.Log(gameObject.name + "で異常が発生しました！");
    }
}
