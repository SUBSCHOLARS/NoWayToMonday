using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCBackToLivingroom : MonoBehaviour
{
    public Image PCDesktop;
    public GameObject PlayerMovementWithFungus;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackToLiving()
    {
        PlayerMovementWithFungus.SendMessage("EnableMovement");
        PCDesktop.gameObject.SetActive(false);
    }
}
