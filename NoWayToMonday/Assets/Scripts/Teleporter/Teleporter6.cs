using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter6 : MonoBehaviour
{
    public GameObject player;
    public GameObject MainCamera;
    public AudioManager audioManager;
    private int isFirst = 1;
    public GameObject StabbedBrother;
    public GameObject LeftBook;
    public static bool ComeBackFlag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isFirst == 1)
            {
                StabbedBrother.SetActive(false);
                LeftBook.SetActive(true);
                ComeBackFlag = true;
                isFirst++;
            }
            player.transform.position=new Vector3(73f,-7.7f,0f);
            MainCamera.transform.position=new Vector3(62.4f,-0.19f,-10f);
            audioManager.PlayAuido();
        }
    }
}
