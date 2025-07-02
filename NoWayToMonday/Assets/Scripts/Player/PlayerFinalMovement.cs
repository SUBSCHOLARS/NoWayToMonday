using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalMovement : MonoBehaviour
{
    public GameObject player;
    private bool Final=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Final)
        {
            Vector3 playerScale = player.transform.localScale;
            playerScale.x = -1;
        }
    }
    public void FinalMovement(bool finalEnable)
    {
        Final=finalEnable;
    }
}
