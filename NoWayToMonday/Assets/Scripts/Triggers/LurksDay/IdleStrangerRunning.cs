using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStrangerRunning : MonoBehaviour
{
    public GameObject IdleStranger;
    Animator animator;
    bool isDetectPlayer = false;
    float speed = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isDetectPlayer)
        {
            IdleStranger.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDetectPlayer = true;
            animator.SetBool("IsRunning", true);
        }
    }
}
