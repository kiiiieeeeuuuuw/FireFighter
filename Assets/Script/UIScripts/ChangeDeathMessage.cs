using UnityEngine;
using UnityEngine.UI;

public class ChangeDeathMessage : MonoBehaviour
{
    public Text DeathText;
    public Text DeathScoreText;
    public Text TopScoreText;
    public GameObject ScoreKeeper;
    public void SetDeathText(string text)
    {
        DeathText.text = text;
        DeathScoreText.text = "Score: " + ScoreKeeper.GetComponent<ScoreKeeper>().Score.ToString();
        TopScoreText.text = "Top score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

}
