using UnityEngine;
using UnityEngine.UI;

public class ChangeDeathMessage : MonoBehaviour
{
    public Text DeathText;

    public void SetDeathText(string text)
    {
        DeathText.text = text;
    }
}
