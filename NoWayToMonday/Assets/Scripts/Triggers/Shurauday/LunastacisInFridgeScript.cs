using Fungus;
using UnityEngine;

public class LunastacisInFridgeScript : MonoBehaviour
{
    AudioSource audioSource;
    public Flowchart LunastacisFlowchart;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        LunastacisFlowchart.ExecuteBlock("Lunastacis");
    }
}