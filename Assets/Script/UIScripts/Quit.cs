using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject QuitButton;
    public ParticleSystem ButtonFire;

    [Header("Colors")]
    public Color HoverColor1;
    public Color HoverColor2;
    public Color IdleColor1;
    public Color IdleColor2;

    private Animator QuitButtonAC;

    public void Start()
    {
        QuitButtonAC = QuitButton.GetComponent<Animator>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HoverEnterQuitButton()
    {
        HandleColors(HoverColor1, HoverColor2);
    }

    public void HoverLeaveQuitButton()
    {
        HandleColors(IdleColor1, IdleColor2);
    }

    private void HandleColors(Color color1, Color color2)
    {
        //var bfMain = ButtonFire.main;
        //bfMain.startColor = new ParticleSystem.MinMaxGradient(color1, color2);

        ButtonFire.startColor = color1;
    }
}
