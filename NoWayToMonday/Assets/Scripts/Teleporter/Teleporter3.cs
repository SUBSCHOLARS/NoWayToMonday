using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter3 : MonoBehaviour
{
    public GameObject player;
    public GameObject MainCamera;
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
        if(other.gameObject.CompareTag("Player")&&DayCountManager.DayCount==7)
        {
            player.transform.position=new Vector3(52.6f,-6.2f,0f);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position=new Vector3(38f,-4.5f,0f);
            MainCamera.transform.position=new Vector3(30f,0f,-10f);
            audioManager.PlayAuido();
        }
    }
}
