using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [Header("Animation")]
    public Animator ScoreAC;
    public ParticleSystem HealingUIEffect;

    [Header("Score")]
    public int score;
    public GameObject Player;
    public int HealthThreshold;


    private int CurrentThreshold;
    private Text scoreText;    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        CurrentThreshold = HealthThreshold;
    }

    public void IncreaseScore(int extraScore)
    {
        score += extraScore;
        scoreText.text = score.ToString();        

        if(score >= CurrentThreshold)
        {
            CurrentThreshold += HealthThreshold;
            HealingUIEffect.Play();
            ScoreAC.SetTrigger("HealthScore");
            Player.GetComponent<PlayerHealth>().Heal(25);
        }
        else
        {
            ScoreAC.SetTrigger("Score");
        }
    }
}
