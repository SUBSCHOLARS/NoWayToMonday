using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed=2.0f;
    private bool canMove=true;
    private bool autoMove=false;
    private bool autoMoveRight=false;
    private bool backMove=false;
    public GameObject WalkingSound;
    Rigidbody2D rb2D;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.RightArrow)&&canMove)||(Input.GetKey(KeyCode.D)&&canMove))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1; // Flip the sprite to face right
            transform.localScale = scale;
            animator.SetBool("IsWalking", true);
            transform.position+=new Vector3(1,0,0)*speed*Time.deltaTime;
        }
        if((Input.GetKey(KeyCode.LeftArrow)&&canMove)||(Input.GetKey(KeyCode.A)&&canMove))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            animator.SetBool("IsWalking", true);
            transform.position+=new Vector3(-1,0,0)*speed*Time.deltaTime;
        }
        if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.LeftArrow))&&canMove)
        {
            WalkingSound.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || 
           Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsWalking", false);
            WalkingSound.SetActive(false);
        }
        if(this.gameObject.transform.position.x<-8f)
        {
            this.gameObject.transform.position=new Vector3(-8f,-1.8f,0);
        }
        if(autoMove)
        {
            transform.position+=new Vector3(-1,0,0)*speed*Time.deltaTime;
        }
        if(autoMoveRight)
        {
            transform.position+=new Vector3(1,0,0)*speed*Time.deltaTime;
        }
        if(backMove)
        {
            transform.position+=new Vector3(-1,0,0)*speed*Time.deltaTime;
        }
    }
    public void SetMovement(bool enable)
    {
        canMove=enable;
    }
    public void AutoMovement(bool autoEnable)
    {
        autoMove=autoEnable;
    }
    public void AutoMovementRight(bool autoEnableRight)
    {
        autoMoveRight=autoEnableRight;
    }
    public void BackMovement(bool backEnable)
    {
        backMove=backEnable;
    }
    public void SlidePlayer()
    {
        transform.DOMoveX(55f,1f);
    }
}
