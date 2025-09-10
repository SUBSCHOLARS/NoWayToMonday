using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOnAndOff : MonoBehaviour
{
    private GameObject[] Light;
    public Light2D globalLight;
    public float dimmedIntensity = 0.1f;
    private AudioSource audioSource;
    private GameObject[] ghosts;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(GetLightAndGhosts());
        Debug.Log("Startメソッドが実行されました");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator GetLightAndGhosts()
    {
        yield return new WaitForSeconds(1.5f); // 少し待つ
        Light = GameObject.FindGameObjectsWithTag("Light");
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        Debug.Log("ライトとゴーストのオブジェクトを取得しました");
        StartCoroutine(LightOnThenAndOff());
    }
    public IEnumerator LightOnThenAndOff()
    {
        while (true)
        {
            //Debug.Log("ライトをオフにします");
            for (int i = 0; i < Light.Length; i++)
            {
                Light[i].SetActive(false);
            }
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
            yield return new WaitForSeconds(Random.Range(4f, 6.2f));

            //Debug.Log("ライトをオンにします");
            for (int i = 0; i < Light.Length; i++)
            {
                Light[i].SetActive(true);
            }
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
            yield return new WaitForSeconds(Random.Range(4f, 6.2f));
        }
    }
}
