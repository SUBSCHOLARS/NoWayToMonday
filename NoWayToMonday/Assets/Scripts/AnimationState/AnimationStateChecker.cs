using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationStateChecker : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("アニメーションの再生が終了しました！");
        if (animator.GetBool("Stabbing"))
        {
            Debug.Log("スタビングアニメーションが終了しました。");
            // ここでスタビングアニメーションが終了した後の処理を追加できます。
            // 例えば、次のシーンに遷移するなど。
            SceneManager.LoadScene("KnifeBadEndText"); // 適切なシーン名に置き換えてください
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
