using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnTeleporter8 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    bool isFinal = false;
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
        if (collision.gameObject.CompareTag("Player") && !isFinal)
        {
            Player.SendMessage("ThroughDoor");
            Player.transform.position = new Vector3(-108f, -8.48f, 0);
            Camera.transform.position = new Vector3(-117.5f, -1.42f, -10f);
        }
        else
        {
            Player.transform.position = new Vector3(-174f, -6.5f, 0);
            Camera.transform.position = new Vector3(-163.5f, 0.1f, -10f);
        }
    }
    public void IsFinalEnable()
    {
        isFinal = true;
    }
}
