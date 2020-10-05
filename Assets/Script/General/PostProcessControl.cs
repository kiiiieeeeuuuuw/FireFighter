using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessControl : MonoBehaviour
{
    public PostProcessProfile Profile;
    private Vignette ogVign;
    public float VgIntensity;
    public float HitEffectDuration;
    // Start is called before the first frame update
    void Start()
    {
        Profile.TryGetSettings(out ogVign);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator ShowHitVignette()
    {
        yield return new WaitForSeconds(HitEffectDuration);
        ogVign.intensity.value = 1;
    }
}
