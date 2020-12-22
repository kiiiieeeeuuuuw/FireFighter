using Assets.Script.UIScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : FireButton
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
