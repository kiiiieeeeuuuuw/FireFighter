using UnityEngine;

public class Quit : Assets.Script.UIScripts.FireButton
{     
    public void QuitGame()
    {
        Application.Quit();
    }
}
