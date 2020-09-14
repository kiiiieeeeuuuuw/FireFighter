using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !GetComponent<ExtinguishFlame>().Doused)
        {
            collision.GetComponent<PlayerHealth>().Damage(25, GetComponent<Transform>().position);
        }
    }
}
