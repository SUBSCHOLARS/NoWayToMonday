// 新規ファイル例: PenaltyManager.cs
using System.Collections.Generic;
using UnityEngine;

public class PenaltyManager : MonoBehaviour
{
    public static PenaltyManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    // ペナルティ対象を管理
    private List<PenaltyZone> zones = new List<PenaltyZone>();

    public void RegisterPenaltyZone(GameObject center, string[] names)
    {
        zones.Add(new PenaltyZone(center, names));
    }

    // Flowerが消されたときに呼ぶ
    public void OnFlowerDestroyed(GameObject flower)
    {
        foreach (var zone in zones)
        {
            if (zone.IsWithinZone(flower) && zone.IsPenaltyTarget(flower))
            {
                // ペナルティ処理
                Debug.Log("ペナルティ発生！: " + flower.name);
                PlayerMovement.insanityLevel += 2.0f;
            }
        }
    }

    // ペナルティゾーン情報
    class PenaltyZone
    {
        public GameObject center;
        public string[] names;
        public PenaltyZone(GameObject c, string[] n) { center = c; names = n; }
        public bool IsWithinZone(GameObject obj)
        {
            // UIの場合はRectTransformのWorldPositionを使う
            Vector3 centerPos = GetWorldPosition(center);
            Vector3 objPos = GetWorldPosition(obj);
            return Vector3.Distance(centerPos, objPos) <= 22f;
        }
        public bool IsPenaltyTarget(GameObject obj)
        {
            foreach (var n in names)
                if (obj.name.Contains(n)) return true;
            return false;
        }
        Vector3 GetWorldPosition(GameObject go)
        {
            RectTransform rt = go.GetComponent<RectTransform>();
            if (rt != null)
                return rt.position; // UI
            else
                return go.transform.position; // 通常
        }
    }
}