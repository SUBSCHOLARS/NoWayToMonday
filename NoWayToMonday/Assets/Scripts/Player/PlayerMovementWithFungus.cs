using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Fungus;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementWithFungus : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerFinalMovement playerFinalMovement;
    public TextMeshPro KnifeText;
    public GameObject SleepActivator;
    public TextMeshPro SleepText;
    public GameObject BGMs;
    public GameObject Reason;
    public GameObject Teleporter2;
    public BrotherAutoMovement brotherAutoMovement;
    public BrotherAutoMovementTrueEnd brotherAutoMovementTrueEnd;
    public GameObject BrotherTrueEnd;
    public GameObject BrotherBadEnd;
    public GameObject Knife;
    public GameObject TrueKnife;
    public GameObject TextAppearer;
    public GameObject TriggerZone3;
    public AudioClip Noise;
    public GameObject MainCamera;
    public GameObject Player;
    public GameObject BrotherNormal;
    public GameObject BrotherFlower;
    private AudioSource audioSource;
    public GameObject Bed;
    public Flowchart UndayFlowchart;
    public GameObject DontGoAnywhere;
    public Image NoImage;
    Animator animator;
    void Start()
    {
        // animator = Player.GetComponent<Animator>();
    }
    public void DisableMovement()
    {
        playerMovement.SetMovement(false);
    }
    public void EnableMovement()
    {
        playerMovement.SetMovement(true);
    }
    public void AutoMovement()
    {
        playerMovement.AutoMovement(true);
    }
    public void AutoMovementDisable()
    {
        playerMovement.AutoMovement(false);
    }
    public void BackMovement()
    {
        playerMovement.BackMovement(true);
    }
    public void BackMovementDisable()
    {
        playerMovement.BackMovement(false);
    }
    public void AutoMoveRightDisable()
    {
        playerMovement.AutoMovementRight(false);
    }
    public void AutoMoveRightEnable()
    {
        playerMovement.AutoMovementRight(true);
    }
    public void DOMoveRightEnable()
    {
        playerMovement.DOMoveRight();
    }
    public void DOMoveRightDisable()
    {
        playerMovement.DOMoveRight();
    }
    public void KnifeTextDeactivate()
    {
        KnifeText.alpha = 0;
    }
    public void SleepActivate()
    {
        SleepActivator.SetActive(true);
        SleepText.gameObject.SetActive(true);
    }
    public void SleepDeactivate()
    {
        SleepActivator.SetActive(false);
        SleepText.gameObject.SetActive(false);
    }
    public void BGMStop()
    {
        BGMs.SetActive(false);
    }
    public void BGMPlay()
    {
        BGMs.SetActive(true);
    }
    public void ReasonDeactivate()
    {
        Reason.SetActive(false);
        Teleporter2.SetActive(true);
    }
    public void FinalMove()
    {
        playerFinalMovement.FinalMovement(true);
    }
    public void BrotherMoveEnableBadEnd()
    {
        brotherAutoMovement.BrotherMoving(true);
        Knife.SetActive(true);
    }
    public void BrotherMoveEnableTrueEnd()
    {
        brotherAutoMovementTrueEnd.BrotherMoving(true);
        TrueKnife.SetActive(true);
    }
    public void InstantiateBrotherBadEnd()
    {
        BrotherBadEnd.SetActive(true);
    }
    public void InstantiateBrotherTrueEnd()
    {
        BrotherTrueEnd.SetActive(true);
    }
    public void TextAppearerDeactivate()
    {
        TextAppearer.SetActive(false);
    }
    // public void TriggerZone3Deactivate(){
    //     TriggerZone3.SetActive(false);
    // }
    public void LoadKnifeBadEnd()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Noise);
        SceneManager.LoadSceneAsync("KnifeBadEnd");
    }
    public void NormalBrotherActivate()
    {
        BrotherNormal.SetActive(true);
    }
    public void CameraMove()
    {
        float playerPos = Player.transform.position.x;
        if (playerPos > 13f && playerPos < 11)
        {
            MainCamera.transform.position = new Vector3(-1.6f, -0.66f, -10f);
        }
        else if (playerPos > 20 && playerPos < 44)
        {
            MainCamera.transform.position = new Vector3(32f, -0.66f, -10f);
        }
        else if (playerPos > 50 && playerPos < 74)
        {
            MainCamera.transform.position = new Vector3(62.4f, -0.66f, -10f);
        }
        else if (playerPos > 83)
        {
            MainCamera.transform.position = new Vector3(94.9f, -0.66f, -10f);
        }
    }
    public void DisableMenuAction(GameObject menu)
    {
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }
    public void EnableMenuAction(GameObject menu)
    {
        if (menu != null)
        {
            menu.SetActive(true);
        }
    }
    public void ExploringStartSet()
    {
        playerMovement.ExploringStart(true);
    }
    public void ExploringFinishSet()
    {
        playerMovement.ExploringFinish();
    }
    public void LoadGameStage()
    {
        SceneManager.LoadSceneAsync("GameStage");
    }
    public void FlowerBrotherActivate()
    {
        BrotherNormal.SetActive(false);
        BrotherFlower.SetActive(true);
    }
    public void BrotherActivate()
    {
        BrotherNormal.SetActive(true);
    }
    public void CalculateFlowerNumAndChangeInsanityLevel()
    {
        GameObject[] flowers = GameObject.FindGameObjectsWithTag("Flower");
        PlayerMovement.insanityLevel += flowers.Length;
    }
    public void CalculateBloodNumAndChangeInsanityLevel()
    {
        GameObject[] bleed = GameObject.FindGameObjectsWithTag("Blood");
        PlayerMovement.insanityLevel += bleed.Length;
    }
    public void BackMoving()
    {
        animator = Player.GetComponent<Animator>();
        Vector3 scale = Player.transform.localScale;
        scale.x = -1;
        Player.transform.localScale = scale; // これが必要
        animator.SetBool("IsWalking", true);
        Player.transform.DOMoveX(71f, 2.0f).OnComplete(
            () =>
            {
                animator.SetBool("IsWalking", false);
            }
        );
    }
    public void ShuraudayPenalty()
    {
        PlayerMovement.insanityLevel += 30f;
    }
    public void GetSinkTags()
    {
        GameObject[] sinks = GameObject.FindGameObjectsWithTag("Sink");
        for (int i = 0; i < sinks.Length; i++)
        {
            sinks[i].GetComponent<Animator>().SetBool("IsDripping", false);
        }
    }
    public void NoImageActivationAndPlaySound()
    {
        NoImage.gameObject.SetActive(true); // 画像を表示
        AudioSource audioSource = NoImage.GetComponent<AudioSource>(); // AudioSourceを取得
        SetPlayerOnBed();
        if (audioSource != null)
        {
            audioSource.Play(); // 音を再生
            StartCoroutine(DisableNoImageAfterSound(audioSource)); // 再生終了後に非表示にするコルーチンを開始
        }
    }

    private IEnumerator DisableNoImageAfterSound(AudioSource audioSource)
    {
        // 再生中は待機
        while (audioSource.isPlaying)
        {
            yield return null; // 次のフレームまで待機
        }

        // 再生が終了したら非表示にする
        NoImage.gameObject.SetActive(false);
    }
    public void SetPlayerOnBed()
    {
        Player.transform.position = new Vector3(-9.1f, -7.7f, 0);
        MainCamera.transform.position = new Vector3(-1.3f, -0.79f, -10f);
        UndayFlowchart.ExecuteBlock("Unday");
        DontGoAnywhere.SetActive(true);
    }
    public void DontGoAnywhereDeactivate()
    {
        DontGoAnywhere.SetActive(false);
    }
    public void BackMovingUnday()
    {
        animator = Player.GetComponent<Animator>();
        Vector3 scale = Player.transform.localScale;
        scale.x = -1;
        Player.transform.localScale = scale; // これが必要
        animator.SetBool("IsWalking", true);
        Player.transform.DOMoveX(-9.1f, 2.0f).OnComplete(
            () =>
            {
                animator.SetBool("IsWalking", false);
            }
        );
    }
    public void AudioListenerReturns()
    {
        AudioListener.volume = 1f;
    }
}
