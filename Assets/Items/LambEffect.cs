using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LambEffect : MonoBehaviour
{
    public void FieldOfView()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light2D>().pointLightInnerRadius -= 0.5f;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light2D>().pointLightOuterRadius -= 0.5f;
        Destroy(gameObject);
    }
}
