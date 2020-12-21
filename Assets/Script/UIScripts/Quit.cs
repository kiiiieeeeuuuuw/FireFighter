using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject QuitButton;
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
        QuitButtonAC.SetBool("Hover", true);
    }

    public void HoverLeaveQuitButton()
    {
        QuitButtonAC.SetBool("Hover", false);
    }
}
