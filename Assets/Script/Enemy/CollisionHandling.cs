using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionHandling : MonoBehaviour
{
    public GameObject Enemy;    

    private float CurrentTime;
    private bool doused = false;
    private float LifeTime;

    private void Start()
    {
        LifeTime = Enemy.GetComponentInChildren<ParticleSystem>().main.startLifetimeMultiplier;
    }

    private void Update()
    {
        float diff = Time.time - CurrentTime;
        if (doused && diff > LifeTime)
            Destroy(Enemy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject;

            if (player.GetComponent<WaterHandling>().CoatedInWater)
            {                
                Enemy.GetComponentsInChildren<ParticleSystem>().ToList().ForEach(x => x.Stop());
                CurrentTime = Time.time;
                doused = true;
            }            
        }
    }    
}
