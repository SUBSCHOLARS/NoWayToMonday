using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnTeleporter9 : MonoBehaviour
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
            Player.transform.position = new Vector3(-89f, -7.7f, 0);
            Camera.transform.position = new Vector3(-73.5f, -0.7f, -10f);
        }
    }
}
