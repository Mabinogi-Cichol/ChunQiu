using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ParticleSystemColorSetter : MonoBehaviour, ColorSetterInterface
{
    [SerializeField] Gradient gradient = null;
    [SerializeField] GameObject fire;


    private Light2D lights;
    private ParticleSystem particleSystem;


    public void Refresh()
    {
        lights = GetComponent<Light2D>();
        particleSystem = fire.GetComponent<ParticleSystem>();
    }

    public void SetColor(float time)
    {
            if (lights.intensity < 0.1)
            {
            fire.SetActive(false);
            }
            else
            {
                fire.SetActive(true);
                var main = particleSystem.main;
                main.startColor = gradient.Evaluate(time);
            }
    }
}
