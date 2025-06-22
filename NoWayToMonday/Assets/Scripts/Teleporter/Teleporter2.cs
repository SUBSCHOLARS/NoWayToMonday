using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter2 : MonoBehaviour
{
    public GameObject player;
    public GameObject MainCamera;
    public GameObject Reason;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position=new Vector3(52.6f,-6.2f,0f);
            MainCamera.transform.position=new Vector3(60f,0f,-10f);
            audioManager.PlayAuido();
            this.gameObject.SetActive(false);
            if(DayCountManager.DayCount!=7){
            Reason.SetActive(true);
            }
        }
    }
}
