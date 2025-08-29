using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffectControllerForUmbraday : MonoBehaviour
{
    [Header("テキストオブジェクト設定")]
    [SerializeField]
    private TextMeshPro textMeshPro1; // 上に配置したTextMeshProオブジェクト

    [Header("タイミング設定")]
    [SerializeField]
    private float typingSpeed = 0.05f; // 1文字を表示する間隔（秒）

    [SerializeField]
    private float allTextShownWaitTime = 2.0f; // 全文表示後に待つ時間（秒）

    [SerializeField]
    private float loopCycleWaitTime = 1.0f; // 次のループが始まるまでの待機時間（秒）

    void Start()
    {
        // ゲーム開始時にテキスト表示のコルーチンを開始します
        StartCoroutine(AnimateTextRoutine());
    }

    /// <summary>
    /// テキストアニメーション全体の流れを制御するコルーチン
    /// </summary>
    private IEnumerator AnimateTextRoutine()
    {
        // このwhileループで処理を無限に繰り返します
        while (true)
        {
            // 1つ目のテキストを1文字ずつ表示
            yield return StartCoroutine(ShowTextOneByOne(textMeshPro1));

            // 全てのテキストが表示された後、指定された秒数だけ待機
            yield return new WaitForSeconds(allTextShownWaitTime);

            // 両方のテキストを非表示にする
            textMeshPro1.maxVisibleCharacters = 0;

            // 次のループサイクルまで指定された秒数だけ待機
            yield return new WaitForSeconds(loopCycleWaitTime);
        }
    }

    /// <summary>
    /// 渡されたTextMeshProオブジェクトのテキストを1文字ずつ表示するコルーチン
    /// </summary>
    /// <param name="tmpro">対象のTextMeshProコンポーネント</param>
    private IEnumerator ShowTextOneByOne(TextMeshPro tmpro)
    {
        // 対象オブジェクトが設定されていない場合は何もしない
        if (tmpro == null)
        {
            yield break;
        }

        // 表示する文字数を0にリセット
        tmpro.maxVisibleCharacters = 0;
        // 全ての文字数を取得
        int totalVisibleCharacters = tmpro.textInfo.characterCount;

        // 1文字ずつ表示文字数を増やしていく
        for (int i = 0; i <= totalVisibleCharacters; i++)
        {
            tmpro.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
