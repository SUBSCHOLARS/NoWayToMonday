using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private AudioSource audioSource;
    public void DisableMovement()
    {
        playerMovement.SetMovement(false);
    }
    public void EnableMovement(){
        playerMovement.SetMovement(true);
    }
    public void AutoMovement(){
        playerMovement.AutoMovement(true);
    }
    public void AutoMovementDisable(){
        playerMovement.AutoMovement(false);
    }
    public void BackMovement(){
        playerMovement.BackMovement(true);
    }
    public void BackMovementDisable(){
        playerMovement.BackMovement(false);
    }
    public void AutoMoveRightDisable(){
        playerMovement.AutoMovementRight(false);
    }
    public void AutoMoveRightEnable(){
        playerMovement.AutoMovementRight(true);
    }
    public void DOMoveRightEnable(){
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
    public void SleepActivate(){
        SleepActivator.SetActive(true);
        SleepText.gameObject.SetActive(true);
    }
    public void SleepDeactivate(){
        SleepActivator.SetActive(false);
        SleepText.gameObject.SetActive(false);
    }
    public void BGMStop(){
        BGMs.SetActive(false);
    }
    public void BGMPlay(){
        BGMs.SetActive(true);
    }
    public void ReasonDeactivate(){
        Reason.SetActive(false);
        Teleporter2.SetActive(true);
    }
    public void FinalMove(){
        playerFinalMovement.FinalMovement(true);
    }
    public void BrotherMoveEnableBadEnd(){
        brotherAutoMovement.BrotherMoving(true);
        Knife.SetActive(true);
    }
    public void BrotherMoveEnableTrueEnd(){
        brotherAutoMovementTrueEnd.BrotherMoving(true);
        TrueKnife.SetActive(true);
    }
    public void InstantiateBrotherBadEnd(){
        BrotherBadEnd.SetActive(true);
    }
    public void InstantiateBrotherTrueEnd(){
        BrotherTrueEnd.SetActive(true);
    }
    public void TextAppearerDeactivate(){
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
