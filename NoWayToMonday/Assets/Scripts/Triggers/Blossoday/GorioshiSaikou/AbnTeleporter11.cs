using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnTeleporter11 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
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
            Player.SendMessage("ThroughDoor");
            Player.transform.position = new Vector3(-129f, -8.48f, 0);
            Camera.transform.position = new Vector3(-117.5f, -1.42f, -10f);
        }
    }
}
