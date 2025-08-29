using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbradayRoomsSetting : MonoBehaviour
{
    [Header("ステージ設定")]
    public GameObject[] roomPrefabs; // 部屋のテンプレートプレハブを複数登録
    public GameObject bedroomPrefab;
    [Header("異常アニメーション設定")]
    [Tooltip("キッチンで異常アニメーションが発生する確率")]
    [Range(0, 1)] public float kitchenAnomalyChance = 0.3f; // 30%の確率

    [Header("狂気レベルに応じた設定")]
    // 狂気レベルが低い時の設定
    [Range(1, 10)] public int rooms_Min_LowInsanity = 3;
    [Range(1, 10)] public int rooms_Max_LowInsanity = 5;
    [Range(0, 1)] public float anomalyChance_LowInsanity = 0.8f; // 異常発生確率20%

    // 狂気レベルが高い時の設定
    [Range(1, 10)] public int rooms_Min_HighInsanity = 6;
    [Range(1, 10)] public int rooms_Max_HighInsanity = 8;
    [Range(0, 1)] public float anomalyChance_HighInsanity = 0.6f; // 異常発生確率60%

    public float insanityThreshold = 50f; // 狂気レベルの高低を分けるしきい値
    public float roomSpacing = 45f;
    public GameObject canvasObject;
    public Vector3 startPosition = new Vector3(63f, 0, 0);
    int UmbradayMultiplier = 3;
    void Start()
    {
        GenerateStage();
    }
    void Update()
    {
        PlayerMovement.insanityLevel += 0.01f * Time.deltaTime * UmbradayMultiplier;
    }

    void GenerateStage()
    {
        // 1. 狂気レベルに基づいてパラメータを決定する
        int roomCount;

        if (PlayerMovement.insanityLevel <= insanityThreshold)
        {
            roomCount = Random.Range(rooms_Min_LowInsanity, rooms_Max_LowInsanity + 1);
        }
        else
        {
            roomCount = Random.Range(rooms_Min_HighInsanity, rooms_Max_HighInsanity + 1);
        }

        // 2. 決定した数だけ部屋を生成する
        for (int i = 0; i < roomCount; i++)
        {
            GameObject selectedRoomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
            // 部屋を生成（位置や繋ぎ方はゲームの仕様に合わせて調整）
            Vector3 spawnPos = new Vector3(63.5f + i * -45, -0.7f, 0); // 仮の位置
            Instantiate(selectedRoomPrefab, spawnPos, Quaternion.identity);
        }
        // 最後の部屋（寝室）を生成
        Vector3 finalRoomPos = startPosition + new Vector3(roomCount * -roomSpacing, -3.5f, 0);
        Instantiate(bedroomPrefab, finalRoomPos, Quaternion.identity);
    }
    public void onMultiplierDecrement()
    {
        UmbradayMultiplier--;
    }
    public void onMultiplierIncrement()
    {
        UmbradayMultiplier++;
    }
}
