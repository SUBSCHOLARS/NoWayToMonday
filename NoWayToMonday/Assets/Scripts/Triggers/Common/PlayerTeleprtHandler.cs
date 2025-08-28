using System.Collections;
using UnityEngine;

public class PlayerTeleportHandler : MonoBehaviour
{
    // ① 現在の状態を示す「スイッチ」
    public bool canTeleport = true;

    // ② 他のスクリプトから呼ばれる「ボタン」
    public void StartCooldown(float cooldownTime)
    {
        if (canTeleport)
        {
            StartCoroutine(TeleportCooldown(cooldownTime));
        }
    }

    // ③ 時間をかけて状態を切り替える特殊な処理「コルーチン」
    private IEnumerator TeleportCooldown(float cooldownTime)
    {
        // まずスイッチをOFFにする
        canTeleport = false;
        
        // 指定された時間、処理を「一時停止」する
        yield return new WaitForSeconds(cooldownTime);
        
        // 一時停止が終わったら、スイッチをONに戻す
        canTeleport = true;
    }
}