using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using DG.Tweening;

public class FridgeScript : MonoBehaviour
{
    bool isNearFridge = false;
    bool isMove = false;
    public GameObject fridgeInteractableIcon;
    public GameObject mainCamera;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Camera set!");
        spriteRenderer = fridgeInteractableIcon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearFridge && !isMove && Input.GetKeyDown(KeyCode.Space))
        {
            isMove = true;
            mainCamera.transform.position = new Vector3(transform.position.x,25f,-10f);
        }
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
}
