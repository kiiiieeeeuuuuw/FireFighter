using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeteor : MonoBehaviour
{
    // Start is called before the first frame update
    private float LifeTime;
    private float PassedTime;

    private bool Destroy;

    void Start()
    {
        LifeTime = GetComponentInChildren<ParticleSystem>().main.startLifetimeMultiplier;
        PassedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Destroy)
        {
            PassedTime += Time.deltaTime;
            if (PassedTime > LifeTime)
                Destroy(this);
        }
    }

    public void DestroyMe()
    {
        Destroy = true;
        GetComponent<TrailRenderer>().enabled = false;
    }
}
