using Assets.Script.UIScripts;
using UnityEngine.SceneManagement;

public class Restart : FireButton
{
    public void RestartGame()
    {
        SceneManager.LoadScene("CityLevel");
    }
}
