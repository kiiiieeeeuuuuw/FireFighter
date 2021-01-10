using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string NewGameScene;
    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
