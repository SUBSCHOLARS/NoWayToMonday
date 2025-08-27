using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    [Header("テレポート設定")]
    public GameObject teleporterPrefab;
    public GameObject teleporterCameraPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // 「一つ前に生成した部屋」の右側（出口）の接続ポイントを覚えておくための変数
        Transform previousLeftConnection = null;
        Transform previousRoomCameraPoint = null;
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

            Transform currentRoomLeftConnection = FindConnectionPoint(newRoom, "LeftConnection");
            Transform currentRoomRightConnection = FindConnectionPoint(newRoom, "RightConnection");
            Transform currentRoomCameraPoint = FindConnectionPoint(newRoom, "CameraPoint");

            if (i > 0 && previousLeftConnection != null && currentRoomLeftConnection != null)
            {
                GameObject teleporterA_GO = Instantiate(teleporterPrefab, previousLeftConnection.position, Quaternion.identity, previousLeftConnection);
                RoomTeleporter roomTeleporterA = teleporterA_GO.GetComponent<RoomTeleporter>();
                //GameObject teleporterCameraA_GO = Instantiate(teleporterCameraPrefab, previousRoomCameraPoint.position, Quaternion.identity, previousRoomCameraPoint);

                GameObject teleporter_B_GO = Instantiate(teleporterPrefab, currentRoomRightConnection.position, Quaternion.identity, currentRoomRightConnection);
                RoomTeleporter roomTeleporterB = teleporter_B_GO.GetComponent<RoomTeleporter>();
                //GameObject teleporterCameraB_GO = Instantiate(teleporterCameraPrefab, currentRoomCameraPoint.position, Quaternion.identity, currentRoomCameraPoint);

                roomTeleporterA.destination = roomTeleporterB.transform;
                roomTeleporterA.cameraDestination = currentRoomCameraPoint.transform;

                roomTeleporterB.destination = roomTeleporterA.transform;
                roomTeleporterB.cameraDestination = previousRoomCameraPoint.transform;

                // roomTeleporterA.cameraDestination = currentRoomCameraPoint;
                // roomTeleporterB.cameraDestination = previousRoomCameraPoint;
            }
            previousLeftConnection = currentRoomLeftConnection;
            previousRoomCameraPoint = currentRoomCameraPoint;

            // 3. 生成した部屋の異常発生ポイントを処理する
            ActivateAnomaliesInRoom(newRoom, anomalyChance);
        }
    }
    Transform FindConnectionPoint(GameObject room, string pointName)
    {
        Transform point = room.transform.Find(pointName);
        if (pointName == null)
        {
            Debug.LogError("接続ポイントが見つかりません！");
        }
        return point;
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
