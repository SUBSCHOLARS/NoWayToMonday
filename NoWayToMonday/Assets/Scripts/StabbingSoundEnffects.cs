using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbingSoundEnffects : MonoBehaviour
{
    public GameObject StabbingSound;
    public GameObject Bleeding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StabbingSoundPlay(){
        StabbingSound.SetActive(true);
        Bleeding.SetActive(true);
    }
}
