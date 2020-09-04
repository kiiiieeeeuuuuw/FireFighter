using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public ParticleSystem Explosion;
    public GameObject Fire;
    public float delta;
    public bool xDelta;
    public bool yDelta;

    private float index;    

    private void Start()
    {
        index = 0;                
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {
            Vector3 impactPos = collision.transform.position;
            //if (xDelta)
            //    impactPos.x -= delta;
            //else if (yDelta)
            //    impactPos.y -= delta;
            //else return;
            Instantiate(Explosion,impactPos, Quaternion.identity, transform);
            var fire = Instantiate(Fire, impactPos, Quaternion.identity, transform);
            fire.name = "Ember_" + index;
            index++;
            try
            {
                collision.gameObject.GetComponent<DestroyMeteor>().DestroyMe();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            //Destroy(collision.gameObject);
        }
    }    
}
