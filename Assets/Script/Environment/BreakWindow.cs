using UnityEngine;

public class BreakWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject Window;
    [SerializeField]
    private GameObject BrokenWindow;
    private bool Triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered && collision.gameObject.tag.Contains("Meteor"))
        {
            Window.SetActive(false);
            BrokenWindow.SetActive(true);
            Triggered = true;
        }
    }
}
