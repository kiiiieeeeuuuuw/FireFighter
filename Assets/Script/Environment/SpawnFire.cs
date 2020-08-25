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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {
            Vector3 impactPos = collision.transform.position;
            if (xDelta)
                impactPos.x -= delta;
            if (yDelta)
                impactPos.y -= delta;
            else return;
            Instantiate(Explosion,impactPos, Quaternion.identity, this.transform);
            Instantiate(Fire, impactPos, Quaternion.identity, this.transform);
            Destroy(collision.gameObject);
        }
    }
}
