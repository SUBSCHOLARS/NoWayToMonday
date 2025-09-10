using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private string exposedParameterName;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        if (slider != null)
        {
            slider.onValueChanged.AddListener(SetVolume);

            float currentVolume;
            if (audioMixer.GetFloat(exposedParameterName, out currentVolume))
            {
                slider.value = currentVolume;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetVolume(float volume)
    {
        if (volume <= slider.minValue + 0.01f)
        {
            volume = -80f; // ミュートに近い値に設定
        }
        audioMixer.SetFloat(exposedParameterName, volume);
    }
}
