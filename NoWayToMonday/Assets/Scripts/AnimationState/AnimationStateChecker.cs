using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationStateChecker : StateMachineBehaviour
{
    public Image BlackOut;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("アニメーションの再生が終了しました！");
            Debug.Log("スタビングアニメーションが終了しました。");
            // ここでスタビングアニメーションが終了した後の処理を追加できます。
            // 例えば、次のシーンに遷移するなど。
            SceneManager.LoadSceneAsync("KnifeBadEndText"); // 適切なシーン名に置き換えてください

    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("Stabbing"))
        {
            BlackOut.gameObject.SetActive(true);
            BlackOut.DOFade(1, 2.0f);
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
