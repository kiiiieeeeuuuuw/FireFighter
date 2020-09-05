using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AutoDestroyParticleObject : MonoBehaviour
{
    private List<ParticleSystem> ParticleSystems;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystems = GetComponents<ParticleSystem>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ParticleSystems.Any(x => x.IsAlive()))
        {
            Destroy(gameObject);
        }
    }
}
