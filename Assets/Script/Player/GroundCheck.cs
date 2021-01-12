using Assets.Script.Items;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject Player;
    public ParticleSystem LandingDustEffect;
    public Transform DustPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerMovement>().isGrounded = true;
            Instantiate(LandingDustEffect, DustPos.position, LandingDustEffect.transform.rotation);
        }
        if (collision.collider.tag == "Pickup")
        {
            collision.gameObject.GetComponent<PickupItem>().PickupAction(Player);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
