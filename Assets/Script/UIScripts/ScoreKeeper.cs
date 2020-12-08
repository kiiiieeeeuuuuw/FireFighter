using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [Header("Animation")]
    public Animator ScoreAC;

    private Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void IncreaseScore(int extraScore)
    {
        score += extraScore;
        scoreText.text = score.ToString();
        ScoreAC.SetTrigger("Score");
    }
}
