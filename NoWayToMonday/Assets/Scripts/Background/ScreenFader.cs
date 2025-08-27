using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration=2.0f;
    public float clearFadeDuration=4.0f;
    public AudioManager audioManager;
    public GameObject MainCamera;
    public GameObject player;
    public Flowchart flowchart;

    public void FadeToBlack()
    {
        fadeImage.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad);
    }
    public void FadeToClear()
    {
        fadeImage.DOFade(0,clearFadeDuration).SetEase(Ease.InOutQuad);
    }
    public void FadeToBlackThenToClear()
    {
        fadeImage.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            fadeImage.DOFade(0, clearFadeDuration).SetEase(Ease.InOutQuad);
        });
    }
    public void FadeToBlackThenToClearWithSound()
    {
        fadeImage.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            audioManager.PlayAuido();
            Vector3 playerScale=player.transform.localScale;
            playerScale.x=-1;
            player.transform.localScale=playerScale;
            MainCamera.transform.position=new Vector3(62.4f,-0.66f,-10f);
            fadeImage.DOFade(0, clearFadeDuration).SetEase(Ease.InOutQuad);
        });
    }
    public void FadeToBlackThenToClearWithSoundBloosoDay()
    {
        fadeImage.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            audioManager.PlayAuido();
            Vector3 playerScale=player.transform.localScale;
            playerScale.x=-1;
            player.transform.localScale=playerScale;
            string CurrentDay=flowchart.GetStringVariable("pureCurrentKanji");
            switch(CurrentDay){
                case "蕐":
                    SceneManager.LoadSceneAsync("BlossoDay");
                    break;
                case "衊":
                    SceneManager.LoadSceneAsync("MaulsDay");
                    break;
                case "寢":
                    SceneManager.LoadSceneAsync("ShurauDay");
                    break;
                case "蔽":
                    SceneManager.LoadSceneAsync("LurksDay");
                    break;
                case "瞵":
                    SceneManager.LoadSceneAsync("GazeDay");
                    break;
                case "錆":
                    SceneManager.LoadSceneAsync("RottsDay");
                    break;
                case "靈":
                    SceneManager.LoadSceneAsync("CursedDay");
                    break;
                case "翳":
                    SceneManager.LoadSceneAsync("UmbraDay");
                    break;
                case "瀛":
                    SceneManager.LoadSceneAsync("Seepsday");
                    break;
                default:
                    SceneManager.LoadSceneAsync("UnDay");
                    break;
            }
            // fadeImage.DOFade(0, clearFadeDuration).SetEase(Ease.InOutQuad);
        });
    }
    public void FadeToBlackThenToClearFinalDay()
    {
        fadeImage.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            audioManager.PlayAuido();
            MainCamera.transform.position = new Vector3(94.9f, -0.66f, -10f);
            player.transform.position = new Vector3(84.8f, -7.2f, 0f);
            fadeImage.DOFade(0, clearFadeDuration).SetEase(Ease.InOutQuad);
        });
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
