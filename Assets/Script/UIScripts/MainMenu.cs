using Assets.Script.General;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string NewGameScene;
    public Text KeyboardLayoutPreference;

    public void Start()
    {
        if (!PlayerPrefs.HasKey(Constants.KeyboardLayout))
            PlayerPrefs.SetString(Constants.KeyboardLayout, Constants.Azerty);        
        KeyboardLayoutPreference.text = PlayerPrefs.GetString(Constants.KeyboardLayout);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePlayerPreference()
    {
        if (PlayerPrefs.GetString(Constants.KeyboardLayout) == Constants.Azerty)
            PlayerPrefs.SetString(Constants.KeyboardLayout, Constants.Qwerty);
        else
            PlayerPrefs.SetString(Constants.KeyboardLayout, Constants.Azerty);
        KeyboardLayoutPreference.text = PlayerPrefs.GetString(Constants.KeyboardLayout);
    }
}
