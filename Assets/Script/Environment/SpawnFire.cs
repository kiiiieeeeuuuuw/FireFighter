using System;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public ParticleSystem Explosion;
    public GameObject Fire;
    public GameObject CrackSpawner;
    public float delta;
    public LayerMask WhatIsPlayer;

    private float index;    

    private void Start()
    {
        index = 0;                
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy meteor on impact
        if (collision.tag.Contains("Meteor"))
        {                                   
            try
            {
                collision.gameObject.GetComponent<DestroyMeteor>().DestroyMe();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }                       
        }

        // Spawn fire when it's a fire meteor
        if (collision.CompareTag("FireMeteor"))
        {
            var impactPos = collision.transform.position;

            Collider2D[] PlayerCloseToImpact = Physics2D.OverlapCircleAll(impactPos, 4, WhatIsPlayer);
            if (PlayerCloseToImpact.Length > 0)
                AudioManagerScript.PlaySound("impact");


            var top = gameObject.transform.parent.Find("TopLocation").transform.position;
            if (impactPos.x > top.x)
                impactPos.x -= delta;
            if (impactPos.x < top.x)
                impactPos.x += delta;
            if (impactPos.y > top.y)
                impactPos.y -= delta;

            Instantiate(Explosion, impactPos, Quaternion.identity, transform);
            var fire = Instantiate(Fire, impactPos, Quaternion.identity, transform);
            fire.name = "Ember_" + index;
            index++;
        }

        // Spawn ice when it's an ice meteor
        if (collision.CompareTag("IceMeteor"))
        {

        }
    }    
}
