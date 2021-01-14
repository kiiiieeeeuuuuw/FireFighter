using Assets.Script.General;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string NewGameScene;
    public Text KeyboardLayoutPreference;
    public Text InputText;

    public void Start()
    {
        if (!PlayerPrefs.HasKey(Constants.KeyboardLayout))
            PlayerPrefs.SetString(Constants.KeyboardLayout, Constants.Azerty);
        var pref = PlayerPrefs.GetString(Constants.KeyboardLayout);
        KeyboardLayoutPreference.text = pref;
        if (pref == Constants.Azerty)
            InputText.text = Constants.AzertyInput;
        else
            InputText.text = Constants.QwertyInput;
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

        var pref = PlayerPrefs.GetString(Constants.KeyboardLayout);
        KeyboardLayoutPreference.text = pref;
        if (pref == Constants.Azerty)
            InputText.text = Constants.AzertyInput;
        else
            InputText.text = Constants.QwertyInput;
    }
}
