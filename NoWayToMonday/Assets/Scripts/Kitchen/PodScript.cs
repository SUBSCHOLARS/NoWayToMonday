using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PodScript : MonoBehaviour
{
    public Flowchart PodFlowchart;
    public static bool isPodTaken = false;
    bool isNearPod = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isNearPod && Input.GetKeyDown(KeyCode.Space) && !isPodTaken)
        {
            isPodTaken = true;
            this.gameObject.SetActive(false);
            PodFlowchart.ExecuteBlock("PodTaken");
        }
    }
    public void PodTaken()
    {
        isPodTaken = true;
        this.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearPod = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearPod = false;
        }
    }
}
