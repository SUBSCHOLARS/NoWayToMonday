using UnityEngine;
using UnityEngine.EventSystems; // Unityのイベントシステムを使うために必要
using UnityEngine.UI;

/// <summary>
/// Draggableオブジェクトを受け入れるエリアのスクリプト
/// </summary>
public class DropZone : MonoBehaviour, IDropHandler
{
    [Header("ドロップされた時の効果音")]
    public AudioClip dropSound;
    public Image BeforeThrown;
    public Image AfterThrown;
    public static bool isThrownOnce = false;

    // オブジェクトがこのエリア内でドロップされた時に呼ばれる
    public void OnDrop(PointerEventData eventData)
    {
        // ドロップされたオブジェクトを取得
        GameObject droppedObject = eventData.pointerDrag;
        Debug.Log(droppedObject.name + " がドロップされました");

        // Draggableコンポーネントがあるか確認（念のため）
        Draggable draggable = droppedObject.GetComponent<Draggable>();
        if (draggable != null)
        {
            // --- ここでドロップ成功時の処理を実行 ---

            // 1. 音を鳴らす
            if (dropSound != null)
            {
                // 2D空間で音を鳴らすシンプルな方法
                AudioSource.PlayClipAtPoint(dropSound, Camera.main.transform.position);
            }
            if (!isThrownOnce)
            {
                BeforeThrown.gameObject.SetActive(false);
                AfterThrown.gameObject.SetActive(true);
            }
            isThrownOnce = true;

            // 2. ドラッグしていたオブジェクトを破壊する
            PenaltyManager.Instance.OnFlowerDestroyed(gameObject);
            Destroy(droppedObject);
        }
    }
}
