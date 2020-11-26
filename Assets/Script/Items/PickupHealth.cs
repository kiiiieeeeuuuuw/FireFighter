using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public float HealingAmount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Heal(HealingAmount);
            Destroy(gameObject);
        }
    }
}
