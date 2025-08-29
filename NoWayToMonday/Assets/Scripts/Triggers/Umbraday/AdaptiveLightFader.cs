using UnityEngine;
using Fungus;
using DG.Tweening;
using UnityEngine.Rendering.Universal;


public class AdaptiveLightFader : MonoBehaviour
{
    [Header("ターゲット設定")]
    [Tooltip("色を変更するライト（Directional Light）")]
    [SerializeField]
    private Light2D globalLight;

    [Tooltip("実行したいFungusのFlowchart")]
    [SerializeField]
    private Flowchart targetFlowchart;

    [Tooltip("実行したいFlowchart内のブロック名")]
    [SerializeField]
    private string targetBlockName = "BlackOut";

    [Header("アニメーション設定")]
    [Tooltip("ライトが黒になるまでの時間（秒）")]
    [SerializeField]
    private float fadeDuration = 70.0f;

    [Tooltip("完全に黒くなった後、Flowchartが始まるまでの待機時間（秒）")]
    [SerializeField]
    private float delayAfterFade = 2.0f;

    // 実行中のシーケンスを管理するための変数
    private Sequence fadeSequence;

    void Start()
    {
        StartAdaptiveFade(globalLight.color);
    }
    public void StopFade()
    {
        fadeSequence?.Kill();
        Debug.Log("フェード処理を停止しました。");
    }
    public void StartAdaptiveFade(Color startCol)
    {
        if (globalLight == null || targetFlowchart == null)
        {
            Debug.LogError("ライト、またはFlowchartが設定されていません!");
            return;
        }

        // 既に実行中のシーケンスがあれば、それを停止してリセットする
        fadeSequence?.Kill();
        fadeSequence = DOTween.Sequence();

        // 1. ライトの色を黒にする
        fadeSequence.Append(
            DOTween.To(
                () => globalLight.color,
                x => globalLight.color = x,
                Color.black,
                fadeDuration
            )
        );

        // 2. 指定秒数待機
        fadeSequence.AppendInterval(delayAfterFade);

        // 3. 待機完了後、Fungusのブロックを実行
        fadeSequence.AppendCallback(() =>
        {
            if (globalLight.color == Color.black)
            {
                Debug.Log("光源が黒色であることを確認。Flowchartを実行します。");
                targetFlowchart.ExecuteBlock(targetBlockName);
            }
            else
            {
                Debug.LogWarning("光源が黒色ではないため、Flowchartの実行をキャンセルしました。");
            }
        });
    }

    // オブジェクトが破棄される際に、実行中のDOTweenを安全に停止する
    void OnDestroy()
    {
        fadeSequence?.Kill();
    }
}