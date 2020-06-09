using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightValueChange : MonoBehaviour
{

    private Light2D light;

    private float intensity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = intensity;
    }

    public void SetIntensity(float inte)
    {
        intensity = inte;
    }
}
