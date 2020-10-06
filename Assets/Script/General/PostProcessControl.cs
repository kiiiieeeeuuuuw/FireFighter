using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessControl : MonoBehaviour
{        
    [Header("Vignette Effect Parameters")]
    public float HitEffectDuration;
    public float MaxIntensity;
    public Color HitColor;
    public Color HealColor;

    private Vignette VignetteLayer;    
    private float HitEffectCurrentTime;
    private float OGIntensity;
    private float deltaIntensity;
    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out VignetteLayer);
        OGIntensity = VignetteLayer.intensity.value;
        deltaIntensity = (MaxIntensity - OGIntensity) / HitEffectDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(HitEffectCurrentTime > 0)
        {
            var newIntensity = VignetteLayer.intensity.value - deltaIntensity;
            if (newIntensity > OGIntensity)
                VignetteLayer.intensity.value = newIntensity;
            else
            {
                VignetteLayer.intensity.value = OGIntensity;
                HitEffectCurrentTime = 0;
                VignetteLayer.color.value = HitColor;
            }
        }        
    }

    public void ShowVignetteEffect(bool damage, bool heal)
    {
        HitEffectCurrentTime = HitEffectDuration;
        VignetteLayer.intensity.value = MaxIntensity;
        if (damage) VignetteLayer.color.value = HitColor;
        if (heal) VignetteLayer.color.value = HealColor;
    }
}
