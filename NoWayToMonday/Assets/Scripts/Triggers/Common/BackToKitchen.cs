using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToKitchen : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject PlayerMovementWithFungus;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public FridgeScript fridgeScript;

    void OnMouseDown()
    {
        if (FridgeScript.lastUsedFridge != null)
        {
            PlayerMovementWithFungus.SendMessage("EnableMovement");
            mainCamera.transform.position = FridgeScript.lastUsedFridge.GetCachedPos();
        }
        else
        {
            Debug.LogWarning("No fridge used yet.");
        }
    }
}
