using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaulsdayRoomsSetting : MonoBehaviour
{
    // ▼ Unityエディタで設定する項目 ▼
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
            if (newRoom.name.Contains("Kitchen"))
            {
                // 2. もしキッチンなら、異常アニメーションの発動を試みる
                TryActivateKitchenAnimation(newRoom);
            }
            // 3. 生成した部屋の異常発生ポイントを処理する
            ActivateAnomaliesInRoom(newRoom, anomalyChance);
        }
        // 最後の部屋（寝室）を生成
        Vector3 finalRoomPos = startPosition + new Vector3(roomCount * -roomSpacing, -3.5f, 0);
        Instantiate(bedroomPrefab, finalRoomPos, Quaternion.identity);
    }
    public void ActivateAnomaliesInRoom(GameObject roomObject, float chance)
    {
        // 1. 部屋の中にある全ての「AnomalySpawnPoint」コンポーネントを探し出す
        MaulsdayAnomalyActivator[] spawnPoints = roomObject.GetComponentsInChildren<MaulsdayAnomalyActivator>();

        Debug.Log(roomObject.name + " 内に " + spawnPoints.Length + " 個の異常発生ポイントを発見。");

        // 2. 見つかった全てのポイントを1つずつチェックする
        foreach (MaulsdayAnomalyActivator point in spawnPoints)
        {
            // 3. 確率の抽選を行う (0.0～1.0のランダムな値を生成し、chanceより小さいか判定)
            if (Random.value < chance)
            {
                // 4. 抽選に当たったら、そのポイントのActivate()メソッドを呼び出す
                point.Activate();
            }
        }
    }
    /// <summary>
    /// 指定されたキッチン部屋内の特定オブジェクトのアニメーションを、確率で異常なものに切り替える
    /// </summary>
    /// <param name="kitchenRoom">チェック対象のキッチン部屋オブジェクト</param>
    void TryActivateKitchenAnimation(GameObject kitchenRoom)
    {
        // 3. キッチンの中から、アニメーションさせたい特定のオブジェクトを探す
        //    ここでは例として "WallClock" という名前のオブジェクトを探す
        Transform animatedObject = kitchenRoom.transform.Find("Sink-Sheet_0");

        // オブジェクトが見つからなかった場合は何もしない（時計がないキッチンもあるかもしれない）
        if (animatedObject == null) return;

        // Animatorコンポーネントを取得
        Animator animator = animatedObject.GetComponent<Animator>();
        if (animator == null) return;

        // 4. 確率の抽選を行う
        if (Random.value < kitchenAnomalyChance)
        {
            // 5. 抽選に当たったら、Animatorのトリガーを発動させる
            Debug.Log("キッチンの異常アニメーションを発動させました！");
            animator.SetTrigger("isAbnormal");
        }
    }
}
