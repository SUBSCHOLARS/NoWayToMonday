using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOnAndOff : MonoBehaviour
{
    public GameObject Light;
    public Light2D globalLight;
    public float dimmedIntensity = 0.1f;
    private AudioSource audioSource;
    public GameObject[] ghosts;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(LightOnThenAndOff());
        Debug.Log("Startメソッドが実行されました");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator LightOnThenAndOff()
    {
        while (true)
        {
            Debug.Log("ライトをオフにします");
            Light.SetActive(false);
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].SetActive(true);
                ghosts[i].GetComponent<AudioSource>().Play();
            }
            audioSource.PlayOneShot(audioSource.clip);
            if (globalLight != null)
            {
                globalLight.intensity = dimmedIntensity;
            }
            yield return new WaitForSeconds(4f);

            Debug.Log("ライトをオンにします");
            Light.SetActive(true);
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].SetActive(false);
                ghosts[i].GetComponent<AudioSource>().Stop();
            }
            audioSource.PlayOneShot(audioSource.clip);
            if (globalLight != null)
            {
                globalLight.intensity = 1f;
            }
            yield return new WaitForSeconds(4f);
        }
    }
}
