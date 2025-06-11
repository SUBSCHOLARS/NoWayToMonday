using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;
using DG.Tweening;

public class FloatingSleepText : MonoBehaviour
{
    public TextMeshPro floatingText;
    public Flowchart SleepFlowChart;
    public float fadeDuration = 1.0f;
    private bool menuTriggered=false;
    private bool isFadingIn=false;
    private bool isFadingOut=false;
    private bool PlayerInRange=false;
    void Start()
    {
        floatingText.alpha = 0f;
    }
    void Update()
    {
        if(PlayerInRange&&!menuTriggered&&Input.GetKeyDown(KeyCode.Space))
        {
            SleepFlowChart.ExecuteBlock("SleepMenu");
            menuTriggered=true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerInRange=true;
        if (other.CompareTag("Player"))
        {
            if (!isFadingIn && floatingText.alpha < 1f)
            {
                FadeIn();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerInRange=false;
        if (other.CompareTag("Player"))
        {
            if (!isFadingOut && floatingText.alpha > 0f)
            {
                FadeOut();
            }
        }
    }

    private void FadeIn()
    {
        isFadingIn = true;
        isFadingOut = false;
        floatingText.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            isFadingIn = false;
        });
    }

    private void FadeOut()
    {
        isFadingOut = true;
        isFadingIn = false;
        floatingText.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            isFadingOut = false;
        });
    }
    public void ResetMenuTriggerSleep()
    {
        menuTriggered=false;
        Debug.Log(menuTriggered);
    }
}
