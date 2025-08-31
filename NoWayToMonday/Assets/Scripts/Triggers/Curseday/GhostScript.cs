using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;
    public AudioSource targetAudioSource;
    bool playerFound;
    // Start is called before the first frame update
    void Start()
    {
        targetAudioSource = GetComponent<AudioSource>();
        StartCoroutine(Search());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerFound && IsSoundAudibleToPlayer())
        {
            Debug.Log("Detected!");
            PlayerMovement.insanityLevel += 0.01f * Time.deltaTime;
        }
    }
    void SearchForPlayer()
    {
        // 自分の位置を基準に半径20の範囲でPlayerを探索
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 20f);

        playerFound = false;

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
    IEnumerator Search()
    {
        SearchForPlayer();
        yield return null;
    }
    public bool IsSoundAudibleToPlayer()
    {
        if (targetAudioSource == null)
        {
            return false;
        }

        // 条件1: AudioSourceが現在再生中か？ (ミュートされておらず、ボリュームが0より大きいかも確認)
        if (!targetAudioSource.isPlaying || targetAudioSource.mute || targetAudioSource.volume <= 0 || AudioListener.volume == 0f)
        {
            return false;
        }

        // 全ての条件をクリアした場合、聞こえていると判断
        return true;
    }
}
