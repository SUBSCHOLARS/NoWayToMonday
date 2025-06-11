using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleBranchManager : MonoBehaviour
{
    public GameObject HasKnife;
    public GameObject NoKnife;
    public void HasKnifeActivate()
    {
        HasKnife.SetActive(true);
        NoKnife.SetActive(false);
    }
    public void NoKnifeActivate()
    {
        NoKnife.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
