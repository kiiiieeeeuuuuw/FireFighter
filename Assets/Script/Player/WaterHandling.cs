using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHandling : MonoBehaviour
{
    public bool CoatedInWater;
    public float WaterTime = 2f;
    public KeyCode WaterCoat = KeyCode.J;
    public SpriteRenderer sprite;    

    public float StartWaterCoat;
    public float tempDelta;

    Color blue = new Color(0, 0, 255);
    Color yellow = new Color(0, 255, 0);
    public void Update()
    {
        tempDelta = Time.deltaTime;

        if (Input.GetKeyDown(WaterCoat) && !CoatedInWater)
        {
            CoatedInWater = true;
            StartWaterCoat = WaterTime;
        }

        if (CoatedInWater)
        {
            StartWaterCoat -= Time.deltaTime;
            sprite.color = Color.Lerp(yellow, blue, StartWaterCoat);            
            CoatedInWater = StartWaterCoat > 0f;
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
