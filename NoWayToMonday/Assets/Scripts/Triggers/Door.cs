using System.Collections;
using UnityEngine;

/// <summary>
/// 部屋間のテレポートを管理するドア。
/// </summary>
public class Door : MonoBehaviour
{
    [Header("ドアの設定")]
    public Transform spawnPoint; // プレイヤーがこのドアから出現する位置

    // StageManagerによって自動で設定される
    [HideInInspector] public Room parentRoom; // このドアが属する部屋
    [HideInInspector] public Door connectedDoor; // このドアが繋がっている先のドア

    private BoxCollider2D doorCollider;
    private bool isCoolingDown = false;

    void Awake()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        if (doorCollider == null)
        {
            Debug.LogError("ドアにBoxCollider2Dがありません！", gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCoolingDown && connectedDoor != null)
        {
            connectedDoor.ReceivePlayer(other.transform);
            StartCooldown();
            connectedDoor.StartCooldown();
        }
    }

    public void ReceivePlayer(Transform player)
    {
        player.position = spawnPoint.position;

        // --- ★ここが重要な変更点★ ---
        // シーン上のメインカメラを探し、それにアタッチされたCameraControllerを取得する
        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        if (parentRoom.cameraPoint != null && cameraController != null)
        {
            Vector3 cameraTargetPos = new Vector3(
                parentRoom.cameraPoint.position.x,
                parentRoom.cameraPoint.position.y,
                Camera.main.transform.position.z // Z座標はカメラのものを維持
            );
            // 取得したCameraControllerのMoveToメソッドを呼び出す
            cameraController.MoveTo(cameraTargetPos);
        }
        else
        {
            Debug.LogWarning("CameraPointまたはCameraControllerが見つかりませんでした。");
        }
    }

    public void StartCooldown()
    {
        StartCoroutine(CooldownCoroutine(1.0f));
    }

    private IEnumerator CooldownCoroutine(float duration)
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(duration);
        isCoolingDown = false;
    }
}