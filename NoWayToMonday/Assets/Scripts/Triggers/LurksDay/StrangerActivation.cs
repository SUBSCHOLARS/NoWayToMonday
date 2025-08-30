using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerActivation : MonoBehaviour
{
    public GameObject StrangerinLivingroom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StrangerinLivingroom.SetActive(true);
        }
    }
}
