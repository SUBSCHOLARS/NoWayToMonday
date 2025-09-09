using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x <= transform.position.x + 0.5f)
        {
            Player.transform.position = new Vector3(transform.position.x + 0.5f, Player.transform.position.y, Player.transform.position.z);
        }
    }
}
