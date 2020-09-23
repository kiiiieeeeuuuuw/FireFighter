using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyMeteor : MonoBehaviour
{
    // Start is called before the first frame update    

    private bool Destroy;
    private List<ParticleSystem> Particles;

    public ParticleSystem ExtinguishEffect;

    void Start()
    {
        Particles = GetComponentsInChildren<ParticleSystem>().ToList();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Destroy && !Particles.Any(x => x.IsAlive()))        
            Destroy(gameObject);        
    }

    public void DestroyMe()
    {
        Destroy = true;
        // Stop meteor effect
        GetComponent<TrailRenderer>().enabled = false;

        // Stop meteor from moving
        Destroy(GetComponent<Rigidbody2D>());

        // Stop meteor from spawning more fires
        GetComponent<Collider2D>().enabled = false;

        // Stop particleSystems from emitting more
        Particles.ForEach(x => x.Stop());
    }

    public void DestroyByPlayer()
    {
        Instantiate(ExtinguishEffect, transform.position, Quaternion.identity, transform);
        DestroyMe();        
    }
}
