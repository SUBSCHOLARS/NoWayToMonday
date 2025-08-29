using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using DG.Tweening;

public class FridgeScript : MonoBehaviour
{
    bool isNearFridge = false;
    //bool isMove = false;
    public GameObject fridgeInteractableIcon;
    public GameObject PlayerMovementWithFungus;
    public GameObject mainCamera;
    //bool isMoved = false;
    SpriteRenderer spriteRenderer;
    public static FridgeScript lastUsedFridge;
    public Vector3 CachedPos { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Camera set!");
        spriteRenderer = fridgeInteractableIcon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearFridge && Input.GetKeyDown(KeyCode.Space))
        {
            FridgeOps();
        }
    }
    public void FridgeOps()
    {
        CachedPos = mainCamera.transform.position;
        lastUsedFridge = this;
        Debug.Log("CashedPos: " + CachedPos);
        PlayerMovementWithFungus.SendMessage("DisableMovement");
        mainCamera.transform.position = new Vector3(transform.position.x + 6, 25f, -10f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearFridge = true;
            spriteRenderer.DOFade(0.5f, 2.5f);
            Debug.Log("Triggered!");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearFridge = false;
            spriteRenderer.DOFade(0f, 2.5f);
            Debug.Log("Untriggered!");
        }
    }
    public Vector3 GetCachedPos()
    {
        return CachedPos;
    }
}
