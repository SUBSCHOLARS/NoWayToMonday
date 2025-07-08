using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour
{
    private float UntilDeathTimer = 0f;
    bool StartTimer = false;
    bool isFading = true;
    [SerializeField] Image damageImg;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            UntilDeathTimer += Time.deltaTime;
            if (UntilDeathTimer >= 600f&&UntilDeathTimer<720f&&isFading)
            {
                isFading = false;
                damageImg.DOFade(0.4f, 2.0f).OnComplete(()
                =>
                {
                    audioSource.PlayOneShot(audioSource.clip);
                    damageImg.DOFade(0, 2.0f).OnComplete(()
                    =>
                    {
                        isFading = true;
                    });
                });
            }
            if (UntilDeathTimer >= 720f)
            {
                Debug.Log("You are dead!");
            }
        }
    }
    public void TimerSet(bool start)
    {
        StartTimer = start;
    }
}
