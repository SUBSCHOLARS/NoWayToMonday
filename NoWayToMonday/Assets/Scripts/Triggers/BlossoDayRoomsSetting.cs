using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BlossoDayRoomsSetting : MonoBehaviour
{
    // ▼ Unityエディタで設定する項目 ▼
    [Header("ステージ設定")]
    public GameObject[] roomPrefabs; // 部屋のテンプレートプレハブを複数登録
    public GameObject bedroomPrefab;

    [Header("狂気レベルに応じた設定")]
    // 狂気レベルが低い時の設定
    [Range(1, 10)] public int rooms_Min_LowInsanity = 3;
    [Range(1, 10)] public int rooms_Max_LowInsanity = 5;
    [Range(0, 1)] public float anomalyChance_LowInsanity = 0.2f; // 異常発生確率20%

    // 狂気レベルが高い時の設定
    [Range(1, 10)] public int rooms_Min_HighInsanity = 6;
    [Range(1, 10)] public int rooms_Max_HighInsanity = 8;
    [Range(0, 1)] public float anomalyChance_HighInsanity = 0.6f; // 異常発生確率60%

    public float insanityThreshold = 50f; // 狂気レベルの高低を分けるしきい値
                                          // ▲ Unityエディタで設定する項目ここまで ▲
    public float roomSpacing = 45f;
    public GameObject canvasObject;
    public Vector3 startPosition = new Vector3(63f, 0, 0);
    void Start()
    {
        GenerateStage();
    }

    void GenerateStage()
    {
        // 1. 狂気レベルに基づいてパラメータを決定する
        int roomCount;
        float anomalyChance;

        if (PlayerMovement.insanityLevel <= insanityThreshold)
        {
            roomCount = Random.Range(rooms_Min_LowInsanity, rooms_Max_LowInsanity + 1);
            anomalyChance = anomalyChance_LowInsanity;
        }
        else
        {
            roomCount = Random.Range(rooms_Min_HighInsanity, rooms_Max_HighInsanity + 1);
            anomalyChance = anomalyChance_HighInsanity;
        }

        // 2. 決定した数だけ部屋を生成する
        for (int i = 0; i < roomCount; i++)
        {
            GameObject selectedRoomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
            // 部屋を生成（位置や繋ぎ方はゲームの仕様に合わせて調整）
            Vector3 spawnPos = new Vector3(63.5f + i * -45, -0.7f, 0); // 仮の位置
            GameObject newRoom = Instantiate(selectedRoomPrefab, spawnPos, Quaternion.identity);
            // 3. 生成した部屋の異常発生ポイントを処理する
            ActivateAnomaliesInRoom(newRoom, anomalyChance);
        }
        // 最後の部屋（寝室）を生成
        Vector3 finalRoomPos = startPosition + new Vector3(roomCount * -roomSpacing, -3.5f, 0);
        Instantiate(bedroomPrefab, finalRoomPos, Quaternion.identity);
        // switch (roomCount)
        // {
        //     case 3:
        //         abnTeleporter6.IsFinalEnable();
        //         break;
        //     case 4:
        //         abnTeleporter8.IsFinalEnable();
        //         break;
        //     default:
        //         break;
        // }
    }
    public void ActivateAnomaliesInRoom(GameObject roomObject, float chance)
    {
        // 1. 部屋の中にある全ての「AnomalySpawnPoint」コンポーネントを探し出す
        AnomalyActivator[] spawnPoints = roomObject.GetComponentsInChildren<AnomalyActivator>();
        AnomalyActivatorInFridge[] fridgeSpawnPoints = roomObject.GetComponentsInChildren<AnomalyActivatorInFridge>();
        AnomalyActivatorInPC[] pcSpawnPoints = canvasObject.GetComponentsInChildren<AnomalyActivatorInPC>();

        Debug.Log(roomObject.name + " 内に " + spawnPoints.Length + " 個の異常発生ポイントを発見。");
        Debug.Log(roomObject.name + " 内に " + fridgeSpawnPoints.Length + " 個の異常発生ポイントを発見。");
        Debug.Log(canvasObject.name + " 内に " + pcSpawnPoints.Length + " 個の異常発生ポイントを発見。");

        // 2. 見つかった全てのポイントを1つずつチェックする
        foreach (AnomalyActivator point in spawnPoints)
        {
            // 3. 確率の抽選を行う (0.0～1.0のランダムな値を生成し、chanceより小さいか判定)
            if (Random.value < chance)
            {
                // 4. 抽選に当たったら、そのポイントのActivate()メソッドを呼び出す
                point.Activate();
            }
        }
        foreach (AnomalyActivatorInFridge point in fridgeSpawnPoints)
        {
            // 3. 確率の抽選を行う (0.0～1.0のランダムな値を生成し、chanceより小さいか判定)
            if (Random.value < chance)
            {
                // 4. 抽選に当たったら、そのポイントのActivate()メソッドを呼び出す
                point.Activate();
            }
        }
        foreach (AnomalyActivatorInPC point in pcSpawnPoints)
        {
            // 3. 確率の抽選を行う (0.0～1.0のランダムな値を生成し、chanceより小さいか判定)
            if (Random.value < chance)
            {
                // 4. 抽選に当たったら、そのポイントのActivate()メソッドを呼び出す
                point.Activate();
            }
        }
    }
}