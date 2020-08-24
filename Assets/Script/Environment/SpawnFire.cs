using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public ParticleSystem Explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {
            Instantiate(Explosion,collision.transform.position, Quaternion.identity, this.transform);
            Destroy(collision.gameObject);
        }
    }
}
