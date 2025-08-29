using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSupervision : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;
    private bool canDetectMovement = false;
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // if (player != null)
        // {
        //     playerTransform = player.transform;
        //     lastPlayerPosition = playerTransform.position;
        // }
        // else
        // {
        //     Debug.Log("Playerタグを持つオブジェクトが見つかりません");
        // }
        StartCoroutine(SearchForPlayerRoutine());
    }
    IEnumerator SearchForPlayerRoutine()
{
    while (true)
    {
        SearchForPlayer();
        yield return new WaitForSeconds(0.5f); // 0.5秒ごとに実行
    }
}

    // Update is called once per frame
    void Update()
    {
        if (canDetectMovement && playerTransform != null)
        {
            float distanceMoved = Vector3.Distance(playerTransform.position, lastPlayerPosition);
            if (distanceMoved >= 0.001f)
            {
                Debug.Log("プレイヤー動いているのを検知！");
                animator.SetBool("IsDetected", true);
                PlayerMovement.insanityLevel += 0.01f * Time.deltaTime;
                spriteRenderer.color = Color.red;
            }
            else
            {
                animator.SetBool("IsDetected", false);
                spriteRenderer.color = Color.white;
            }
            lastPlayerPosition = playerTransform.position;
        }
    }
    public void OnEyesOpen()
    {
        Debug.Log("目が開いた");
        canDetectMovement = true;
        if (playerTransform != null)
        {
            lastPlayerPosition = playerTransform.position;
        }
    }
    public void OnEyesClosed()
    {
        Debug.Log("目が閉じた");
        canDetectMovement = false;
    }
    void SearchForPlayer()
    {
        // 自分の位置を基準に半径20の範囲でPlayerを探索
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 20f);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player")) // Playerタグを持つオブジェクトを判定
            {
                //Debug.Log("Playerが範囲内にいます: " + hitCollider.gameObject.name);
                // 必要な処理をここに記述
                playerTransform = hitCollider.gameObject.transform;
                lastPlayerPosition = playerTransform.position;
            }
            else
            {
                Debug.Log("いません");
            }
        }
    }
}
