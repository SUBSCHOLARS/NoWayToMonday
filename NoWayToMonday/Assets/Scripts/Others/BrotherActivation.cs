using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherActivation : MonoBehaviour
{
    public GameObject FlowerBrother;
    public GameObject Brother;
    public void FlowerBrotherActivate()
    {
        FlowerBrother.SetActive(true);
        Brother.SetActive(false);
    }
    public void BrotherActivate()
    {
        FlowerBrother.SetActive(false);
        Brother.SetActive(true);
    }
}
