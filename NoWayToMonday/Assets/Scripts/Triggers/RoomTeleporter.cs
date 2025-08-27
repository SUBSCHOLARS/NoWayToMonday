using UnityEngine;

/// <summary>
/// プレイヤーを指定の場所にテレポートさせるスクリプト
/// </summary>
public class RoomTeleporter : MonoBehaviour
{
    // ワープ先のTransform。StageGeneratorによって自動で設定される。
    public Transform destination;
    public Transform cameraDestination;
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // このオブジェクトのColliderに何かが入った時に呼び出される
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 入ってきたのがプレイヤーかどうかをタグで確認
        if (other.CompareTag("Player"))
        {
            Vector3 triggeredPos = other.transform.position;
            PlayerTeleportHandler playerTeleportHandler = other.GetComponent<PlayerTeleportHandler>();
            if (playerTeleportHandler != null && playerTeleportHandler.canTeleport)
            {
                playerTeleportHandler.StartCooldown(1.0f);
                other.SendMessage("ThroughDoor");
                if (destination != null)
                {
                    // プレイヤーをワープ先の位置に移動させる
                    other.transform.position = new Vector3(destination.position.x, -7.7f, destination.position.z);
                    mainCamera.transform.position = new Vector3(cameraDestination.position.x, cameraDestination.position.y, -10f);
                    Debug.Log("CameraPoint world position: " + cameraDestination.position);
                }
                else
                {
                    Debug.LogError("ワープ先が設定されていません！", this.gameObject);
                }
            }
            else
            {
                other.transform.position = triggeredPos;
            }
        }
    }
}
