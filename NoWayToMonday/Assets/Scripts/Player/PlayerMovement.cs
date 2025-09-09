using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    public static float insanityLevel = 0.0f;
    private bool canMove = true;
    private bool isExploring = false;
    private bool autoMove = false;
    private bool autoMoveRight = false;
    private bool backMove = false;
    private int soundIndex = 0;
    public AudioClip[] walkingSounds;
    public AudioClip bleedingSound;
    public AudioClip openDoor;
    bool hasKnifeLurksday = false;
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
        if (isExploring)
        {
            insanityLevel += 0.01f * Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "CurseDay")
        {
            if ((Input.GetKey(KeyCode.RightArrow) && canMove) || (Input.GetKey(KeyCode.D) && canMove))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1; // Flip the sprite to face right
            transform.localScale = scale;
            animator.SetBool("NoSound", false);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) && canMove) || (Input.GetKey(KeyCode.A) && canMove))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            animator.SetBool("NoSound", false);
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ||
           Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
           || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            animator.SetBool("NoSound", true);
        }
        if (this.gameObject.transform.position.x < -13f && SceneManager.GetActiveScene().name == "GameStage")
        {
            this.gameObject.transform.position = new Vector3(-13f, -7.7f, 0f);
        }
        if (this.gameObject.transform.position.x > 106.15)
        {
            this.gameObject.transform.position = new Vector3(106.15f, -7.2f, 0f);
        }
        if (autoMove)
        {
            animator.SetBool("NoSound", false);
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (autoMoveRight)
        {
            animator.SetBool("NoSound", false);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (backMove)
        {
            animator.SetBool("NoSound", false);
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("IdleEarClosing"))
            {
                AudioListener.volume = 0f;
                //Debug.Log("音量オフ！");
            }
            else
            {
                AudioListener.volume = 1f;
            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.RightArrow) && canMove) || (Input.GetKey(KeyCode.D) && canMove))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1; // Flip the sprite to face right
            transform.localScale = scale;
            animator.SetBool("IsWalking", true);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (!PodScript.isPodTaken && ((Input.GetKey(KeyCode.LeftArrow) && canMove) || (Input.GetKey(KeyCode.A) && canMove)))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            animator.SetBool("IsWalking", true);
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }

        if (PodScript.isPodTaken && ((Input.GetKey(KeyCode.RightArrow) && canMove) || (Input.GetKey(KeyCode.D) && canMove)))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1; // Flip the sprite to face right
            transform.localScale = scale;
            animator.SetBool("IsWalkingWithPod", true);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (PodScript.isPodTaken && ((Input.GetKey(KeyCode.LeftArrow) && canMove) || (Input.GetKey(KeyCode.A) && canMove)))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            animator.SetBool("IsWalkingWithPod", true);
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ||
           Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
           || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsWalkingWithPod", false);
        }
        if (this.gameObject.transform.position.x < -13f && SceneManager.GetActiveScene().name == "GameStage")
        {
            this.gameObject.transform.position = new Vector3(-13f, -7.7f, 0f);
        }
        if (this.gameObject.transform.position.x > 106.15)
        {
            this.gameObject.transform.position = new Vector3(106.15f, -7.2f, 0f);
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
    }
    public void ThroughDoor()
    {
        audioSource.PlayOneShot(openDoor);
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
        if (soundIndex < walkingSounds.Length - 1)
        {
            soundIndex++;
        }
        else
        {
            soundIndex = 0;
        }
    }
    public void PlayBleedingSound()
    {
        audioSource.PlayOneShot(bleedingSound);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerStopper"))
        {
            animator.SetBool("IsWalking", false);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DoorFront"))
        {
            animator.SetBool("IsWalking", false);
            transform.position = new Vector3(106.15f, -7.7f, 0f);
        }
    }
    public void ExploringStart(bool exploring)
    {
        isExploring = exploring;
    }
    public void ExploringFinish()
    {
        isExploring = false;
    }
    public void KnifeTakenAnim()
    {
        animator.SetBool("TakeKnife", true);
        GameObject[] knives = GameObject.FindGameObjectsWithTag("Knife");
        GameObject[] knivestaken = GameObject.FindGameObjectsWithTag("KnifeTaken");
        for (int i = 0; i < knives.Length; i++)
        {
            knives[i].SetActive(false);
        }
        for (int i = 0; i < knivestaken.Length; i++)
        {
            knivestaken[i].SetActive(true);
        }
        hasKnifeLurksday = true;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stranger"))
        {
            if (hasKnifeLurksday)
            {
                collision.gameObject.SetActive(false);
            }
            else
            {
                animator.SetBool("StabbedByStranger", true);
            }
        }
        if (collision.gameObject.CompareTag("StrangerInBedroom"))
        {
            animator.SetBool("StabbedByStranger", true);
        }
    }
}
