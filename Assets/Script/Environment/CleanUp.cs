using UnityEngine;

public class CleanUp : MonoBehaviour
{    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().KillPlayer();
        }
        if (collision.gameObject.tag.Contains("Meteor"))
        {
            collision.gameObject.GetComponent<DestroyMeteor>().DestroyMe();
        }
    }
}
