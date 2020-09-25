using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailIntensityOverLifeTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration;    
    public GameObject TrailSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var renderer = TrailSprite.GetComponent<SpriteRenderer>();
        var spriteColor = renderer.color;
        spriteColor.a += Time.deltaTime / duration;
        renderer.color = spriteColor;
    }
}
