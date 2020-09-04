using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (collision.gameObject.CompareTag("Meteor"))
        {
            collision.gameObject.GetComponent<DestroyMeteor>().DestroyMe();
        }
    }
}
