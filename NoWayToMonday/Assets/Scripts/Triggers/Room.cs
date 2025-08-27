using UnityEngine;

/// <summary>
/// 部屋の主要な構成要素を管理するデータコンテナ。
/// </summary>
public class Room : MonoBehaviour
{
    [Header("部屋の構成要素")]
    public Door entryDoor; // この部屋への入口となるドア
    public Door exitDoor;  // この部屋からの出口となるドア
    public Transform cameraPoint; // この部屋のカメラ位置

    // StageManagerによって自動で設定される
    [HideInInspector] public Room previousRoom;
    [HideInInspector] public Room nextRoom;
}
