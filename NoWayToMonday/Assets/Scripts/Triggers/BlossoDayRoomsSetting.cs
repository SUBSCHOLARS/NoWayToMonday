using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの部屋を安全に生成し、接続する管理者。
/// </summary>
public class StageManager : MonoBehaviour
{
    [Header("部屋のプレハブ")]
    public GameObject[] randomRoomPrefabs;
    public GameObject bedroomPrefab; // 固定の最後の部屋

    [Header("ステージ設定")]
    public int numberOfRandomRooms = 5;
    public float roomSpacing = 45f;
    public Vector3 startPosition = new Vector3(63f, 0, 0);
    int randomValue;

    void Start()
    {
        GenerateStage();
    }

    void GenerateStage()
    {
        if (PlayerMovement.insanityLevel <= 50f)
        {
            randomValue = Random.Range(3, numberOfRandomRooms);
        }
            List<Room> spawnedRooms = new List<Room>();

            // --- フェーズ1: 全ての部屋をインスタンス化 ---
            // ランダムな部屋を生成
            for (int i = 0; i < randomValue; i++)
            {
                GameObject roomPrefab = randomRoomPrefabs[Random.Range(0, randomRoomPrefabs.Length)];
                Vector3 spawnPos = startPosition + new Vector3(i * -roomSpacing, 0, 0);
                GameObject roomGO = Instantiate(roomPrefab, spawnPos, Quaternion.identity);
                spawnedRooms.Add(roomGO.GetComponent<Room>());
            }

            // 最後の部屋（寝室）を生成
            Vector3 finalRoomPos = startPosition + new Vector3(numberOfRandomRooms * -roomSpacing, 0, 0);
            GameObject finalRoomGO = Instantiate(bedroomPrefab, finalRoomPos, Quaternion.identity);
            spawnedRooms.Add(finalRoomGO.GetComponent<Room>());
    }
}
