using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    public void IncreaseScore(int extraScore)
    {
        score += extraScore;
        scoreText.text = score.ToString();
    }
}
