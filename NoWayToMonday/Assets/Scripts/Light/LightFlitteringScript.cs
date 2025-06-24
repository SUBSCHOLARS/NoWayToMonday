using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlitteringScript : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] float speed;
    [SerializeField] float intensity;

    Light2D lightSource;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        lightSource.intensity = intensity * animationCurve.Evaluate(time * speed);
    }
}
