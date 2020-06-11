using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHandling : MonoBehaviour
{
    public bool CoatedInWater;
    public float WaterTime = 5f;
    public KeyCode WaterCoat = KeyCode.J;
    public SpriteRenderer sprite;
    public float diff;

    private float StartWaterCoat;

    public void Update()
    {
        if (Input.GetKeyDown(WaterCoat) && !CoatedInWater)
        {
            CoatedInWater = true;
            StartWaterCoat = Time.deltaTime;
        }

        if (CoatedInWater)
        {
            diff = Time.deltaTime - StartWaterCoat;
            sprite.color = Color.Lerp(new Color(0,0,255), new Color(0,255,0), Time.deltaTime - StartWaterCoat);            
            CoatedInWater = Time.deltaTime - StartWaterCoat > 5f;
        }
    }

    public void StartDash()
    {
        CoatedInWater = true;
    }
    
    public void EndDash()
    {
        CoatedInWater = false;
    }
}
