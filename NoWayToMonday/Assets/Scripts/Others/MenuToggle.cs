using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    // InspectorからメニューのCanvasをアタッチする
    public GameObject menuCanvas;

    void Start()
    {
        // 念のため、ゲーム開始時はメニューを非表示にしておく
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
        }
    }

    // このメソッドをボタンのOnClickイベントに登録する
    public void ToggleMenu()
    {
        // もしメニューが現在表示されているなら
        if (menuCanvas.activeSelf)
        {
            // メニューを非表示にする
            menuCanvas.SetActive(false);
            // 時間の流れを元に戻す（ゲーム再開）
            Time.timeScale = 1f;
        }
        // もしメニューが現在非表示なら
        else
        {
            // メニューを表示する
            menuCanvas.SetActive(true);
            // 時間の流れを止める（ゲームを一時停止）
            Time.timeScale = 0f;
        }
    }
}