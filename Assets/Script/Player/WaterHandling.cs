using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHandling : MonoBehaviour
{
    public bool CoatedInWater;

    public void StartDash()
    {
        CoatedInWater = true;
    }
    
    public void EndDash()
    {
        CoatedInWater = false;
    }
}
