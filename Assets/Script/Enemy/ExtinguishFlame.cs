using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ExtinguishFlame : MonoBehaviour
{    
    private bool Doused;

    public GameObject ExtinguishEffect;
    private List<ParticleSystem> Particles;

    // Start is called before the first frame update
    void Start()
    {        
        Particles = GetComponentsInChildren<ParticleSystem>().ToList();
        Doused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Doused)
        {
            if (!Particles.Any(x => x.IsAlive()))
                Destroy(gameObject);            
        }
    }

    public void Extinguish()
    {
        if (!Doused)
        {
            if (Particles.Count == 0)
                Debug.LogError("no children for " + gameObject.name);
            foreach (var particle in Particles)
            {
                particle.Stop();                
            }
            Instantiate(ExtinguishEffect, Particles.First().transform.position, Quaternion.identity, Particles.First().transform);
            Doused = true;
        }
    }
}
