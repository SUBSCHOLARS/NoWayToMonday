using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class LightScriptForUmbraday : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    bool isNearSwitch = false;
    bool isLightOff = true;
    public GameObject faucetInteractableIcon;
    public GameObject Light;
    SpriteRenderer spriteRenderer;
    public AudioClip offSound;
    public AudioClip onSound;
    public GameObject UmbradayRommsSetting;
    public Light2D globalLight;
    [Header("連携スクリプト")]
    public AdaptiveLightFader lightFader;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        spriteRenderer = faucetInteractableIcon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearSwitch && !isLightOff && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(offSound);
            isLightOff = true;
            // 変更したい16進数カラーコード
            string hexColor = "#020205";
            // Color型の変数を用意
            Color myColor;
            // TryParseHtmlStringで16進数文字列をColor型に変換
            if (ColorUtility.TryParseHtmlString(hexColor, out myColor))
            {
                globalLight.GetComponent<Light2D>().color = myColor;
                // 変換が成功したら、ライトの色に設定
                // globalLight.color = myColor;
            }
            else
            {
                Debug.LogError("無効なカラーコードです: " + hexColor);
            }
            lightFader?.StartAdaptiveFade(globalLight.color);
            UmbradayRommsSetting.SendMessage("onMultiplierIncrement");
            Light.SetActive(false);
        }
        else if (isNearSwitch && isLightOff && Input.GetKeyDown(KeyCode.Space))
        {
            string hexColor = "#636993";
            // Color型の変数を用意
            Color myColor;
            // TryParseHtmlStringで16進数文字列をColor型に変換
            if (ColorUtility.TryParseHtmlString(hexColor, out myColor))
            {
                // 変換が成功したら、ライトの色に設定
                globalLight.GetComponent<Light2D>().color = myColor;
                // globalLight.color = myColor;
            }
            else
            {
                Debug.LogError("無効なカラーコードです: " + hexColor);
            }
            audioSource.PlayOneShot(onSound);
            isLightOff = false;
            UmbradayRommsSetting.SendMessage("onMultiplierDecrement");
            lightFader?.StartAdaptiveFade(globalLight.color);
            Light.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearSwitch = true;
            spriteRenderer.DOFade(0.5f, 2.5f);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearSwitch = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearSwitch = false;
            spriteRenderer.DOFade(0f, 2.5f);
        }
    }
}
