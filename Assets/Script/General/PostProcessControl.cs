using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessControl : MonoBehaviour
{
    private PostProcessVolume Volume;
    private Vignette Vg;
    public float VgIntensity;
    public float HitEffectDuration;
    // Start is called before the first frame update
    void Start()
    {
        Volume = GetComponent<PostProcessVolume>();
        Vg = Volume.GetComponent<Vignette>();
        VgIntensity = Vg.intensity.value;
    }

    // Update is called once per frame
    void Update()
    {
        //Vg.intensity.value = VgIntensity;
    }

    private IEnumerator ShowHitVignette()
    {
        yield return new WaitForSeconds(HitEffectDuration);
        Vg.intensity.value = VgIntensity;
    }
}
