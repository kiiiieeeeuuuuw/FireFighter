using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayCloudsAndDestroy : MonoBehaviour
{
    private List<ParticleSystem> RepairClouds;
    private bool DestroyBuilding;
    // Start is called before the first frame update
    void Start()
    {
        RepairClouds = new List<ParticleSystem>();
        foreach (Transform t in transform)
        {
            if (t.name.Contains("RepairCloudEffect"))
                RepairClouds.Add(t.GetComponent<ParticleSystem>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyBuilding && !RepairClouds.Any(x => x.IsAlive()))                 
            Destroy(gameObject);                    
    }

    public void PlayClouds()
    {
        foreach(var cloud in RepairClouds)        
            cloud.Play();
        
        DestroyBuilding = true;
    }
}
