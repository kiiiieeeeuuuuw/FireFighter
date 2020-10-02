using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailIntensityOverLifeTime : MonoBehaviour
{
    [Header("Parameters")]
    public float Duration;
    public float IntensityMultiplier;
    public float MaxIntensity;
    public GameObject TrailSprite;

    private float TimePassed;    
    void Start()
    {
        TimePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed += Time.deltaTime;
        var renderer = TrailSprite.GetComponent<SpriteRenderer>();
        var spriteColor = renderer.color;
        float intensity = IntensityMultiplier * (TimePassed / Duration);
        spriteColor.a = intensity < MaxIntensity? intensity : MaxIntensity;
        renderer.color = spriteColor;
    }
}
