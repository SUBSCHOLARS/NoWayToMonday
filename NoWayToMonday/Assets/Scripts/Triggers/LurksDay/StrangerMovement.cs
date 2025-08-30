using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StrangerMovement : MonoBehaviour
{
    public GameObject YoyoPoint1; // 移動先1
    public GameObject YoyoPoint2; // 移動先2
    public float moveDuration = 2.0f; // 移動にかかる時間
    public int repeatCount = 3; // 往復回数
    public float idleDuration = 2.0f; // 停止時間
    private Animator animator; // 自身のアニメーター

    void Start()
    {
        animator = GetComponent<Animator>();
        StartYoyoMovement();
    }

    void StartYoyoMovement()
    {
        // 1. 移動先の座標を取得
        Vector3 point1 = YoyoPoint1.transform.position;
        Vector3 point2 = YoyoPoint2.transform.position;

        // 2. DOTweenのシーケンスを作成
        Sequence yoyoSequence = DOTween.Sequence();

        // 3. 往復動作を設定
        yoyoSequence.Append(transform.DOMove(point1, moveDuration).SetEase(Ease.InOutSine))
                .AppendCallback(() =>
                {
                    // 停止してIdleアニメーションを再生
                    animator.SetBool("Idle", true);
                })
                .AppendInterval(idleDuration) // 停止時間
                .AppendCallback(() =>
                {
                    // Idleアニメーションを解除
                    animator.SetBool("Idle", false);
                    FlipTowards(point2.x);
                })
                .Append(transform.DOMove(point2, moveDuration).SetEase(Ease.InOutSine))
                .AppendCallback(() =>
                {
                    // 停止してIdleアニメーションを再生
                    animator.SetBool("Idle", true);
                })
                .AppendInterval(idleDuration) // 停止時間
                .AppendCallback(() =>
                {
                    // Idleアニメーションを解除
                    animator.SetBool("Idle", false);
                    FlipTowards(point1.x);
                })
                .SetLoops(repeatCount, LoopType.Restart) // 往復を指定回数繰り返す
                .OnComplete(() =>
                {
                    // 4. 往復完了後にオブジェクトを消す
                    Destroy(gameObject);
                });

        // 5. シーケンスを開始
        yoyoSequence.Play();
    }
    // 移動方向に応じてスケールを反転
    void FlipTowards(float targetX)
    {
        Vector3 scale = transform.localScale;
        if (targetX > transform.position.x)
        {
            // 右に移動する場合
            scale.x = Mathf.Abs(scale.x); // 正のスケール
        }
        else
        {
            // 左に移動する場合
            scale.x = -Mathf.Abs(scale.x); // 負のスケール
        }
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // DOTweenのアニメーションを停止
            DOTween.Kill(transform);

            // Playerのアニメーターを取得してStabbedByStrangerを設定
            Animator playerAnimator = collision.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("StabbedByStranger", true);
            }

            // 自身のアニメーションを停止
            animator.SetBool("Idle", true);
        }
    }
}