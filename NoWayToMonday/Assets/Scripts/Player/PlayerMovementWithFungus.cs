using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public void DisableMovement(){
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
    public void KnifeTextDeactivate(){
        KnifeText.alpha=0;
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
    public void TriggerZone3Deactivate(){
        TriggerZone3.SetActive(false);
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
