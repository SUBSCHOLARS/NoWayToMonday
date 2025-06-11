using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDeactivator : MonoBehaviour
{
    public GameObject KnifeText;
    public GameObject KnifeActivator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KnifeFinalDeactivate(){
        KnifeText.SetActive(false);
        KnifeActivator.SetActive(false);
    }
}
