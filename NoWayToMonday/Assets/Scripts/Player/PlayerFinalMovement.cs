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
            Vector3 scale = player.transform.localScale;
            scale.x = -1;
            player.transform.localScale = scale;
        }
    }
    public void FinalMovement(bool finalEnable)
    {
        Final=finalEnable;
    }
}
