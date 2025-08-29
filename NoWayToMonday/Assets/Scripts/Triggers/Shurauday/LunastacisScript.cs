using Fungus;
using UnityEngine;
public class LunastacisScript : MonoBehaviour
{
    bool isNear = false;
    Flowchart LunastacisFlowchart;
    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.Space))
        {
            LunastacisFlowchart.ExecuteBlock("Lunastacis");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}