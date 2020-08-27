using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    /*[System.Obsolete]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.get)
        Application.LoadLevel(Application.loadedLevel);        
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }        
    }
}
