using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacuationScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerEvacuated;
    bool isNear = false;
    bool isEvacuated = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isEvacuated && isNear && Input.GetKeyDown(KeyCode.Space))
        {
            isEvacuated = true;
            Player.SetActive(false);
            PlayerEvacuated.SetActive(true);
        }
        if (isEvacuated && isNear && Input.GetKeyDown(KeyCode.Space))
        {
            Player.SetActive(true);
            PlayerEvacuated.SetActive(false);
            isEvacuated = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}
