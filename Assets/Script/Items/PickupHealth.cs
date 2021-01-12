using Assets.Script.Items;
using UnityEngine;

public class PickupHealth : MonoBehaviour, PickupItem
{
    public float HealingAmount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PickupAction(collision.gameObject);
        }
    }

    public void PickupAction(GameObject collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().Heal(HealingAmount);
        Destroy(gameObject);
    }
}
