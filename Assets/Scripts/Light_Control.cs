using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Control : MonoBehaviour
{
    new Light2D light;
    private const float OUTER_RADIUS = 0.3f;
    private const float INNER_RADIUS = 0.1f;

    private void Start()
    {
        light = gameObject.GetComponent<Light2D>();
        light.pointLightOuterRadius = 0f;
        light.pointLightInnerRadius = 0f;
    }

    public void SetRadiusRange(float score)
    {
        float percentage = (1 * score) / 50;
        float outerRadius = Mathf.Lerp(0, 7.7f, percentage);
        float innerRadius = Mathf.Lerp(0, 1f, percentage);
        light.pointLightOuterRadius = OUTER_RADIUS + outerRadius;
        light.pointLightInnerRadius = INNER_RADIUS + innerRadius;
    }

}
