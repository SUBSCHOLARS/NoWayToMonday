using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] inversedplayers;
    private float switchInterval=0.2f;
    private float timer=0f;
    private int currentIndex=0;
    private int currentinversedIndex=0;
    public float speed=2.0f;
    private bool canMove=true;
    private bool autoMove=false;
    private bool autoMoveRight=false;
    private bool backMove=false;
    public GameObject WalkingSound;
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        ActivateCurrentObject();
        rb2D=this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)&&canMove)
        {
            DeactivateInversedPlayers();
            ActivateCurrentObject();
            timer+=Time.deltaTime;
            if(timer>=switchInterval)
            {
                SwitchPlayers();
                timer=0f;
            }
            transform.position+=new Vector3(1,0,0)*speed*Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)&&canMove)
        {
            DeactivatePlayers();
            ActivateCurrentInversedObject();
            timer+=Time.deltaTime;
            if(timer>=switchInterval)
            {
                SwitchInversedPlayers();
                timer=0f;
            }
            transform.position+=new Vector3(-1,0,0)*speed*Time.deltaTime;
        }
        else
        {
            timer=0f;
        }
        if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.LeftArrow))&&canMove)
        {
            WalkingSound.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            DeactivatePlayers();
            players[0].SetActive(true);
            WalkingSound.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            DeactivateInversedPlayers();
            inversedplayers[0].SetActive(true);
            WalkingSound.SetActive(false);
        }
        if(this.gameObject.transform.position.x<-8f)
        {
            this.gameObject.transform.position=new Vector3(-8f,-1.8f,0);
        }
        if(autoMove)
        {
            DeactivatePlayers();
            ActivateCurrentInversedObject();
            timer+=Time.deltaTime;
            if(timer>=switchInterval)
            {
                SwitchInversedPlayers();
                timer=0f;
            }
            transform.position+=new Vector3(-1,0,0)*speed*Time.deltaTime;
        }
        if(autoMoveRight)
        {
            DeactivateInversedPlayers();
            ActivateCurrentObject();
            timer+=Time.deltaTime;
            if(timer>=switchInterval)
            {
                SwitchPlayers();
                timer=0f;
            }
            transform.position+=new Vector3(1,0,0)*speed*Time.deltaTime;
        }
        if(backMove)
        {
            DeactivatePlayers();
            ActivateCurrentInversedObject();
            timer+=Time.deltaTime;
            if(timer>=switchInterval)
            {
                SwitchInversedPlayers();
                timer=0f;
            }
            transform.position+=new Vector3(-1,0,0)*speed*Time.deltaTime;
        }
    }
    public void SwitchPlayers()
    {
        players[currentIndex].SetActive(false);
        currentIndex=(currentIndex+1)%players.Length;
        ActivateCurrentObject();
    }
    public void SwitchInversedPlayers()
    {
        inversedplayers[currentinversedIndex].SetActive(false);
        currentinversedIndex=(currentinversedIndex+1)%inversedplayers.Length;
        ActivateCurrentInversedObject();

    }
    public void DeactivatePlayers()
    {
        for(int i=0; i<players.Length; i++)
        {
            players[i].SetActive(false);
        }
    }
    public void DeactivateInversedPlayers()
    {
        for(int i=0; i<inversedplayers.Length; i++)
        {
            inversedplayers[i].SetActive(false);
        }
    }
    public void ActivateCurrentObject()
    {
        players[currentIndex].SetActive(true);
    }
    public void ActivateCurrentInversedObject()
    {
        inversedplayers[currentinversedIndex].SetActive(true);
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
