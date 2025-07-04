using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration=2.0f;
    public float clearFadeDuration=4.0f;
    public AudioManager audioManager;
    public GameObject MainCamera;
    public GameObject player;

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
            MainCamera.transform.position=new Vector3(62.4f,-0.19f,-10f);
            fadeImage.DOFade(0, clearFadeDuration).SetEase(Ease.InOutQuad);
        });
    }
    public void FadeToBlackThenToClearFinalDay()
    {
        fadeImage.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            audioManager.PlayAuido();
            MainCamera.transform.position=new Vector3(94.9f,-0.19f,-10f);
            player.transform.position = new Vector3(84.8f,-7.2f,0f);
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
