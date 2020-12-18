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

    [Header("Difficulty")]
    public int DifficultyThreshold;
    public float deltaSpawnTime;
    public GameObject MeteorSpawner;


    private int CurrentHealthThreshold;
    private int CurrentDifficultyThreshold;
    private Text scoreText;    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        CurrentHealthThreshold = HealthThreshold;
        CurrentDifficultyThreshold = DifficultyThreshold;
    }

    public void IncreaseScore(int extraScore)
    {
        score += extraScore;
        scoreText.text = score.ToString();        

        if(score >= CurrentHealthThreshold)
        {
            CurrentHealthThreshold += HealthThreshold;
            HealingUIEffect.Play();
            ScoreAC.SetTrigger("HealthScore");
            Player.GetComponent<PlayerHealth>().Heal(25);
        }
        else
        {
            ScoreAC.SetTrigger("Score");
        }

        if(score >= CurrentDifficultyThreshold)
        {
            CurrentDifficultyThreshold += DifficultyThreshold;
            MeteorSpawner.GetComponent<SpawnMeteor>().DecreaseMaxSpawnTime(deltaSpawnTime);
        }
    }
}
