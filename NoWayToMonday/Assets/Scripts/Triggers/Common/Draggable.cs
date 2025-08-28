using UnityEngine;
using UnityEngine.EventSystems; // Unityのイベントシステムを使うために必要

/// <summary>
/// オブジェクトをドラッグできるようにするスクリプト
/// </summary>
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    // ドラッグが開始された時に一度だけ呼ばれる
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("ドラッグ開始");
        originalPosition = rectTransform.anchoredPosition; // 元の位置を記憶
        canvasGroup.alpha = 0.6f; // 少し半透明にして、掴んでいる感を出す
        canvasGroup.blocksRaycasts = false; // ドロップ先の検知ができるように
    }

    // ドラッグ中に毎フレーム呼ばれる
    public void OnDrag(PointerEventData eventData)
    {
        // オブジェクトをマウスカーソルの位置に追従させる
        rectTransform.anchoredPosition += eventData.delta / transform.parent.localScale.x;
    }

    // ドラッグが終了した時に一度だけ呼ばれる
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ドラッグ終了");
        canvasGroup.alpha = 1f; // 透明度を元に戻す
        canvasGroup.blocksRaycasts = true; // 元に戻す

        // eventData.pointerDragがnullになっていなければ、ドロップに成功していない
        // （DropZoneでDestroyされなかったということ）
        if (eventData.pointerDrag != null)
        {
            // 元の位置に戻す
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}