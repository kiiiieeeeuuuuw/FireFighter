using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject QuitButton;
    public ParticleSystem ButtonFire;
    public ParticleSystem ButtonHoverFire;

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
        ButtonFire.Stop();
        ButtonHoverFire.Play();
        Debug.Log("hover enter");
    }

    public void HoverLeaveQuitButton()
    {        
        ButtonHoverFire.Stop();
        ButtonFire.Play();
        Debug.Log("hover leave");
    }
}
