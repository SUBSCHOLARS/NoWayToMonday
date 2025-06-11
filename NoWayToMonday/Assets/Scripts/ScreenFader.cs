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

    public void FadeToBlack()
    {
        fadeImage.DOFade(1,fadeDuration).SetEase(Ease.InOutQuad);
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
