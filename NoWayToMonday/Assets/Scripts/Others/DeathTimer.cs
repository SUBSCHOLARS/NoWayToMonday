using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour
{
    private float UntilDeathTimer = 0f;
    bool StartTimer = true;
    [SerializeField] Image damageImg;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        damageImg.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            UntilDeathTimer += Time.deltaTime;
            if (UntilDeathTimer >= 900f)
            {
                damageImg.DOFade(1f, 0.5f).OnComplete(
                    () =>
                    {
                        audioSource.PlayOneShot(audioSource.clip);
                        damageImg.DOFade(0f, 0.5f);
                    }
                );
            }
        }
    }
    public void TimerSet(bool start)
    {
        StartTimer = start;
    }
}
