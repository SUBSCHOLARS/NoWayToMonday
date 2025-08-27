using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class BlossoDayRoomsSetting : MonoBehaviour
{
    [Header("ステージ設定")]
    public GameObject[] roomPrefabs; // 部屋のテンプレートプレハブを複数登録
    public GameObject[] corridorPrefabs; // 部屋を繋ぐ廊下など
    int randomRoomNum;
    float anomalyChance;
    public Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMovement.insanityLevel <= 50f)
        {
            randomRoomNum = Random.Range(3, 6);
            anomalyChance = Random.Range(0.2f, 0.5f);
        }
        for (int i = 0; i < randomRoomNum; i++)
        {
            GameObject selectedRoomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
            // 部屋を生成（位置や繋ぎ方はゲームの仕様に合わせて調整）
            Vector3 spawnPos = new Vector3(63f + i * -45, 0, 0); // 仮の位置
            GameObject newRoom = Instantiate(selectedRoomPrefab, spawnPos, Quaternion.identity);

            // 3. 生成した部屋の異常発生ポイントを処理する
            ActivateAnomaliesInRoom(newRoom, anomalyChance);
        }
    }

    public static void ActivateAnomaliesInRoom(GameObject roomObject, float chance)
    {
        AnomalyActivator[] spawnPoints = roomObject.GetComponentsInChildren<AnomalyActivator>();
        Debug.Log(roomObject.name + " 内に " + spawnPoints.Length + " 個の異常発生ポイントを発見");
        foreach (AnomalyActivator anomalyActivator in spawnPoints)
        {
            if (Random.value < chance)
            {
                anomalyActivator.Activate();
            }
        }
    }
}
