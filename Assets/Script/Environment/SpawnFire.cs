using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public ParticleSystem Explosion;
    public GameObject Fire;
    public GameObject CrackSpawner;
    public float delta;

    private float index;    

    private void Start()
    {
        index = 0;                
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {
            bool flipCrack = false;
            var impactPos = collision.transform.position;
            var top = gameObject.transform.parent.Find("TopLocation").transform.position;
            if (impactPos.x > top.x)
                impactPos.x -= delta;
            if (impactPos.x < top.x)
            {
                impactPos.x += delta;
                flipCrack = true;
            }
            if (impactPos.y > top.y)
                impactPos.y -= delta;


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

            var crack = Instantiate(CrackSpawner, impactPos, Quaternion.identity);
            var rootScale = collision.transform.root.localScale;
            if (flipCrack) {
                var scale = crack.transform.localScale;                
                crack.transform.localScale = new Vector3(-scale.x , scale.y, scale.z);
            }            
        }
    }    
}
