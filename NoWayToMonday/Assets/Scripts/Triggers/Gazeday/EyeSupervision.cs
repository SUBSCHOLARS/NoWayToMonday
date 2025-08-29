using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSupervision : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;
    private bool canDetectMovement = false;
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            lastPlayerPosition = playerTransform.position;
        }
        else
        {
            Debug.Log("Playerタグを持つオブジェクトが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canDetectMovement && playerTransform != null)
        {
            float distanceMoved = Vector3.Distance(playerTransform.position, lastPlayerPosition);
            if (distanceMoved >= 0.001f)
            {
                Debug.Log("プレイヤー動いているのを検知！");
                animator.SetBool("IsDetected", true);
                PlayerMovement.insanityLevel += 0.01f * Time.deltaTime;
                spriteRenderer.color = Color.red;
            }
            else
            {
                animator.SetBool("IsDetected", false);
                spriteRenderer.color = Color.white;
            }
            lastPlayerPosition = playerTransform.position;
        }
    }
    public void OnEyesOpen()
    {
        Debug.Log("目が開いた");
        canDetectMovement = true;
        if (playerTransform != null)
        {
            lastPlayerPosition = playerTransform.position;
        }
    }
    public void OnEyesClosed()
    {
        Debug.Log("目が閉じた");
        canDetectMovement = false;
    }
}
