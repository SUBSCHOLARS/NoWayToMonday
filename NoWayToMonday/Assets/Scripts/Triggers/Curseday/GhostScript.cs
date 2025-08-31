using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;
    private bool canDetectMovement = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SearchForPlayer()
    {
        // 自分の位置を基準に半径20の範囲でPlayerを探索
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 20f);

        bool playerFound = false;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player")) // Playerタグを持つオブジェクトを判定
            {
                playerTransform = hitCollider.gameObject.transform;
                lastPlayerPosition = playerTransform.position;
                playerFound = true;
                break; // プレイヤーが見つかったらループを抜ける
            }
        }

        if (!playerFound)
        {
            // 範囲内にプレイヤーがいない場合、playerTransformをリセット
            playerTransform = null;
        }
    }
}
