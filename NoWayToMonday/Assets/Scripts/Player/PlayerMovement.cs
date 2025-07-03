using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    private bool canMove = true;
    private bool autoMove = false;
    private bool autoMoveRight = false;
    private bool backMove = false;
    private bool isMovingRight = false;
    private int soundIndex = 0;
    public AudioClip[] walkingSounds;
    //public GameObject WalkingSound;
    Rigidbody2D rb2D;
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightArrow) && canMove) || (Input.GetKey(KeyCode.D) && canMove))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1; // Flip the sprite to face right
            transform.localScale = scale;
            animator.SetBool("IsWalking", true);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) && canMove) || (Input.GetKey(KeyCode.A) && canMove))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            animator.SetBool("IsWalking", true);
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ||
           Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
           || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            animator.SetBool("IsWalking", false);
        }
        if (this.gameObject.transform.position.x < -13f)
        {
            this.gameObject.transform.position = new Vector3(-13f, -7.2f, 0);
        }
        if (autoMove)
        {
            animator.SetBool("IsWalking", true);
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (autoMoveRight)
        {
            animator.SetBool("IsWalking", true);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (backMove)
        {
            animator.SetBool("IsWalking", true);
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
    }
    public void SetMovement(bool enable)
    {
        canMove = enable;
    }
    public void AutoMovement(bool autoEnable)
    {
        autoMove = autoEnable;
    }
    public void AutoMovementRight(bool autoEnableRight)
    {
        autoMoveRight = autoEnableRight;
    }
    public void BackMovement(bool backEnable)
    {
        backMove = backEnable;
    }
    public void DOMoveRight()
    {
        Vector3 scale = transform.localScale;
        scale.x = 1; // Flip the sprite to face right
        transform.localScale = scale;
        animator.SetBool("IsWalking", true);
        transform.DOMoveX(89.7f, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            animator.SetBool("IsWalking", false);
        });
    }
    public void SlidePlayer()
    {
        transform.DOMoveX(55f, 1f);
    }
    public void WalkingSound()
    {
        audioSource.PlayOneShot(walkingSounds[soundIndex]);
        if(soundIndex < walkingSounds.Length - 1)
        {
            soundIndex++;
        }
        else
        {
            soundIndex = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerStopper"))
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
