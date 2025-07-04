using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutScript : MonoBehaviour
{
    public GameObject blackOutSheet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BlackOut()
    {
        blackOutSheet.SetActive(true);
    }
}
