using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalMovement : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] inversedplayers;
    private bool Final=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Final)
        {
            DeactivatePlayers();
            inversedplayers[0].SetActive(true);
        }
    }
    public void FinalMovement(bool finalEnable)
    {
        Final=finalEnable;
    }
    public void DeactivatePlayers()
    {
        for(int i=0; i<players.Length; i++)
        {
            players[i].SetActive(false);
        }
    }
}
