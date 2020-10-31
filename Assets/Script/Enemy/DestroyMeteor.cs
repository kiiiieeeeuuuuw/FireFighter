using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyMeteor : MonoBehaviour
{
    // Start is called before the first frame update    

    private bool Destroy;
    private List<ParticleSystem> Particles;

    public ParticleSystem ExtinguishEffect;
    public GameObject BreakableObject;
    private bool broken;
    private SpawnMeteorTrajectory SMT;

    void Start()
    {
        Particles = GetComponentsInChildren<ParticleSystem>().ToList();
        SMT = GetComponentInParent<SpawnMeteorTrajectory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Destroy)
        {
            var pumpkin = transform.Find("pumpkin");
            if (pumpkin != null)
                pumpkin.gameObject.SetActive(false);
            if (BreakableObject != null && !broken)
            {
                Instantiate(BreakableObject, transform.position, Quaternion.identity);
                broken = true;
            }
        }
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

        SMT.DestroyTrajectory(name);

        // Stop particleSystems from emitting more
        Particles.ForEach(x => x.Stop());        
    }

    public void DestroyByPlayer()
    {
        Instantiate(ExtinguishEffect, transform.position, Quaternion.identity, transform);
        DestroyMe();        
    }
}
