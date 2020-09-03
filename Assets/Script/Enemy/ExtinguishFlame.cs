using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ExtinguishFlame : MonoBehaviour
{
    private float LifeTime;
    private float PassedTime;
    private bool Doused;

    public GameObject ExtinguishEffect;

    // Start is called before the first frame update
    void Start()
    {
        LifeTime = GetComponentInChildren<ParticleSystem>().main.startLifetimeMultiplier;
        PassedTime = 0;
        Doused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Doused)
        {
            PassedTime += Time.deltaTime;
            if (PassedTime > LifeTime)
                Destroy(gameObject);
        }
    }

    public void Extinguish()
    {
        var particles = GetComponentsInChildren<ParticleSystem>().ToList();
        if (particles.Count == 0)
            Debug.LogError("no children for " + gameObject.name);
        foreach (var particle in particles)
        {
            particle.Stop();
            Instantiate(ExtinguishEffect, particle.transform.position, Quaternion.identity, particle.transform);
        }
        Doused = true;                 
    }
}
