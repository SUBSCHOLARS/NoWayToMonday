using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PodScript : MonoBehaviour
{
    public Flowchart PodFlowchart;
    public static bool isPodTaken = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PodTaken()
    {
        isPodTaken = true;
        this.gameObject.SetActive(false);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PodFlowchart.ExecuteBlock("Pod");
            }
        }
    }
}
