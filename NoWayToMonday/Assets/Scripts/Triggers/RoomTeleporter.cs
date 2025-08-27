using UnityEngine;

/// <summary>
/// プレイヤーを指定の場所にテレポートさせるスクリプト
/// </summary>
public class RoomTeleporter : MonoBehaviour
{
    // ワープ先のTransform。StageGeneratorによって自動で設定される。
    public Transform destination;

    // このオブジェクトのColliderに何かが入った時に呼び出される
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 入ってきたのがプレイヤーかどうかをタグで確認
        if (other.CompareTag("Player"))
        {
            if (destination != null)
            {
                // プレイヤーをワープ先の位置に移動させる
                other.transform.position = destination.position;
            }
            else
            {
                Debug.LogError("ワープ先が設定されていません！", this.gameObject);
            }
        }
    }
}
