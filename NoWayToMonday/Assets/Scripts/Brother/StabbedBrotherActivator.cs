using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbedBrotherActivator : MonoBehaviour
{
    public GameObject StabbeedBrother;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StabbedBrotherActivate()
    {
        StabbeedBrother.SetActive(true);
    }
}
