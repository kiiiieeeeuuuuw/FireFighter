﻿using UnityEngine;

public class MainMenuCleanup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            var destory = collision.gameObject.GetComponent<DestroyMeteor>();
            destory.DestroyMe();
        }
    }
}
