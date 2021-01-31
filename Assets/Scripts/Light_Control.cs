using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Control : MonoBehaviour
{
    new Light2D light;
    private const float OUTER_RADIUS = 2f;
    private const float INNER_RADIUS = 1f;

    [SerializeField]
    private SpriteMask spriteMask;
    //private Vector3 initialSpriteMaskScale = new Vector3(1f, 1f, 1f);

    private void Start()
    {

        light = gameObject.GetComponent<Light2D>();
        light.pointLightOuterRadius = 2f;
        light.pointLightInnerRadius = 1f;
    }

    public void SetRadiusRange(float score)
    {
        float percentage = (1 * score) / 50;
        float outerRadius = Mathf.Lerp(0, 15f, percentage);
        float innerRadius = Mathf.Lerp(0, 5f, percentage);
        light.pointLightOuterRadius = OUTER_RADIUS + outerRadius;
        light.pointLightInnerRadius = INNER_RADIUS + innerRadius;
        spriteMask.transform.localScale = this.transform.localScale * 2 * (INNER_RADIUS + innerRadius + 0.5f);
    }

}
